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
    public class CUSTOMER_ORDERSController : Controller
    {
        private S2G3_PVFDBEntities db = new S2G3_PVFDBEntities();

        // GET: CUSTOMER_ORDERS
        public ActionResult Index()
        {
            var oRDER = db.ORDER.Include(o => o.CUSTOMER);
            return View(oRDER.ToList());
        }

        // GET: CUSTOMER_ORDERS/Details/5
        /* public ActionResult Details(string id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             ORDER oRDER = db.ORDER.Find(id);
             if (oRDER == null)
             {
                 return HttpNotFound();
             }
             return View(oRDER);
         } */

        public ActionResult Details(string customerID, string orderID)
        {
            if (customerID == null || orderID == null)
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


        // GET: CUSTOMER_ORDERS/Create
        public ActionResult Create()
        {
            ViewBag.Customer_ID = new SelectList(db.CUSTOMER, "Customer_ID", "Customer_Name");
            return View();
        }

        // POST: CUSTOMER_ORDERS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_ID,Order_Date,Customer_ID")] ORDER oRDER)
        {
            if (ModelState.IsValid)
            {
                db.ORDER.Add(oRDER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_ID = new SelectList(db.CUSTOMER, "Customer_ID", "Customer_Name", oRDER.Customer_ID);
            return View(oRDER);
        }

        // GET: CUSTOMER_ORDERS/Edit/5
        public ActionResult Edit(string customerID, string orderID)
        {
            if (orderID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = db.ORDER.Find(orderID);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_ID = new SelectList(db.CUSTOMER, "Customer_ID", "Customer_Name", oRDER.Customer_ID);
            return View(oRDER);
        }

        // POST: CUSTOMER_ORDERS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_ID,Order_Date,Customer_ID")] ORDER oRDER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oRDER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_ID = new SelectList(db.CUSTOMER, "Customer_ID", "Customer_Name", oRDER.Customer_ID);
            return View(oRDER);
        }

        // GET: CUSTOMER_ORDERS/Delete/5
        public ActionResult Delete(string customerID, string orderID)
        {
            if (orderID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = db.ORDER.Find(orderID);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            return View(oRDER);
        }

        // POST: CUSTOMER_ORDERS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string customerID, string orderID)
        {
            ORDER oRDER = db.ORDER.Find(orderID);
            db.ORDER.Remove(oRDER);
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
