using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S2G3_PVFAPP.Models;

namespace S2G3_PVFAPP.Controllers
{
    public class CUSTOMER_ORDERController : Controller
    {
        private S2G3_PVFDBEntities db = new S2G3_PVFDBEntities();

        // GET: CUSTOMER_ORDER
        public ActionResult Index()
        {
            var oRDER_LINE = db.ORDER_LINE.Include(o => o.ORDER).Include(o => o.PRODUCT);
            return View(oRDER_LINE.ToList());
        }

        // GET: CUSTOMER_ORDER/Details/5
        public ActionResult Details(string customerID, string orderID)
        {
            if (customerID == null || orderID==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            CUSTOMER customerObj = db.CUSTOMER.Find(customerID);
            ORDER orderObj = db.ORDER.Find(orderID);
            List<PRODUCT> productList = db.PRODUCT.ToList();          
            List<ORDER_LINE> orderLineList = db.ORDER_LINE.ToList();

            List<CUSTOMER> custList = new List<CUSTOMER>();
            custList.Add(customerObj);
            List<ORDER> orderList = new List<ORDER>();
            orderList.Add(orderObj);
           
            var custOrder = from cust in custList
                            join order in orderList on cust.Customer_ID equals order.Customer_ID into table1
                            from order in table1.ToList()
                            join orderLine in orderLineList on order.Order_ID equals orderLine.Order_ID into table2
                            from orderLine in table2.ToList()
                            join prod in productList on orderLine.Product_ID equals prod.Product_ID into table3
                            from prod in table3.ToList()
                            select new CUSTOMER_ORDER
                            {
                                CUSTOMER = cust,
                                ORDER = order,
                                PRODUCT = prod,
                                ORDER_LINE = orderLine,
                                Extended_Price = prod.Product_Standard_Price * orderLine.Ordered_Quantity                               
                           };

            decimal totalAmount = 0;
            foreach (var item in custOrder)
            {
                totalAmount += item.Extended_Price;
            }

           CUSTOMER_ORDER_VIEW custView = new CUSTOMER_ORDER_VIEW();

            custView.CUSTOMER_ORDER_LIST = custOrder;
            custView.Order_ID = orderObj.Order_ID;
            custView.Customer_ID = customerObj.Customer_ID;
            custView.Customer_Name = customerObj.Customer_Name;
            custView.Customer_Address = customerObj.Customer_Address;
            custView.Total_Amount = totalAmount;
            //custView.Current_Date = DateTime.Now.ToString("dd-mm-yyyy");
            custView.Current_Date = orderObj.Order_Date.ToString();
            return View(custView);
        }

        // GET: CUSTOMER_ORDER/Create
        public ActionResult Create()
        {

            CUSTOMER_ORDER CUS_ORDR = new CUSTOMER_ORDER();
            //CUS_ORDR.CUSTOMER = db.CUSTOMER;
               // SqlQuery("select * from CUSTOMER").ToList<CUSTOMER>();
           // CUS_ORDR.PRODUCT = db.PRODUCT.SqlQuery("select * from PRODUCT").ToList<PRODUCT>();

            List<CUSTOMER> custList = db.CUSTOMER.ToList();
            List<PRODUCT> productList = db.PRODUCT.ToList();
            List<ORDER>    orderList = db.ORDER.ToList();

            CUSTOMER_ORDER custOrder = new CUSTOMER_ORDER();

           // custOrder.customerList = custList;
            //custOrder.productList = productList;
            //custOrder.orderList= orderList;

             return View(custOrder);
        }

        // POST: CUSTOMER_ORDER/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_ID,Product_ID,Ordered_Quantity")] ORDER_LINE oRDER_LINE)
        {
            if (ModelState.IsValid)
            {
                db.ORDER_LINE.Add(oRDER_LINE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Order_ID = new SelectList(db.ORDER, "Order_ID", "Customer_ID", oRDER_LINE.Order_ID);
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description", oRDER_LINE.Product_ID);
            return View(oRDER_LINE);
        }

        // GET: CUSTOMER_ORDER/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER_LINE oRDER_LINE = db.ORDER_LINE.Find(id);
            if (oRDER_LINE == null)
            {
                return HttpNotFound();
            }
            ViewBag.Order_ID = new SelectList(db.ORDER, "Order_ID", "Customer_ID", oRDER_LINE.Order_ID);
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description", oRDER_LINE.Product_ID);
            return View(oRDER_LINE);
        }

        // POST: CUSTOMER_ORDER/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_ID,Product_ID,Ordered_Quantity")] ORDER_LINE oRDER_LINE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oRDER_LINE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Order_ID = new SelectList(db.ORDER, "Order_ID", "Customer_ID", oRDER_LINE.Order_ID);
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description", oRDER_LINE.Product_ID);
            return View(oRDER_LINE);
        }

        // GET: CUSTOMER_ORDER/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER_LINE oRDER_LINE = db.ORDER_LINE.Find(id);
            if (oRDER_LINE == null)
            {
                return HttpNotFound();
            }
            return View(oRDER_LINE);
        }

        // POST: CUSTOMER_ORDER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ORDER_LINE oRDER_LINE = db.ORDER_LINE.Find(id);
            db.ORDER_LINE.Remove(oRDER_LINE);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
