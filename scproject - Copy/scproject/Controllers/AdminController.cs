using scproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace scproject.Controllers
{
    public class AdminController : Controller
    {

        // GET: Admin
        scprojeEntities123 _context = new scprojeEntities123();

        public void bager()
        {
            ViewBag.Count = _context.Suppliers.Count();
            ViewBag.Counter = _context.Products.Count();
            ViewBag.Counting = _context.Customers.Count();
            ViewBag.Counted = _context.CustomerSuppliers.Count();
        }

        //indexes
        public ActionResult Index()
        {
            bager();

            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Login");   
        }
        	
        public ActionResult IndexSupplier(string searchBy, string search)
        {
            if (searchBy == "CompanyName")
            {
                var data = _context.Suppliers.Where(model => model.CompanyName.StartsWith(search)).ToList();
                return View(data);
            }
            else if (searchBy == "ContactName")
            {
                var data = _context.Suppliers.Where(model => model.ContactName == search).ToList();
                return View(data);
            }
            else
            {
                var listofData = _context.Suppliers.ToList();
                return View(listofData);
            }
        }

        public ActionResult IndexProduct(string searchBy,string search)
        {
            if (searchBy == "ProductName")
            {
                var data = _context.Products.Where(model => model.ProductName.StartsWith(search)).ToList();
                return View(data);
            }
            else if (searchBy == "Category")
            {
                var data = _context.Products.Where(model => model.Category == search).ToList();
                return View(data);
            }
            else
            {
                var listofData = _context.Products.ToList();
                return View(listofData);
            }
        }
        
        public ActionResult IndexStock()
        {
            var listofData = _context.Stocks.ToList();
            return View(listofData);
        }
        public ActionResult IndexPayment()
        {
            var listofData = _context.Payments.ToList();
            return View(listofData);
        }
        public ActionResult IndexCustomerSupplier(string searchBy,string search)
        {
            if (searchBy == "CSName")
            {
                var data = _context.CustomerSuppliers.Where(model => model.CSName.StartsWith(search)).ToList();
                return View(data);
            }
   
            else
            {
                var listofData = _context.CustomerSuppliers.ToList();
                return View(listofData);
            }
        }
        public ActionResult IndexCustomer(string searchBy,string search)
        {
            if (searchBy == "CustomerName")
            {
                var data = _context.Customers.Where(model => model.CustomerName.StartsWith(search)).ToList();
                return View(data);
            }

            else
            {
                var listofData = _context.Customers.ToList();
                return View(listofData);
            }
        }

        //creates

        [HttpGet]
        public ActionResult CreateSupplier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSupplier(Supplier model)
        {
            _context.Suppliers.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "<script>alert('Data insert successfull!')</script>";
            // cookie
            if (ModelState.IsValid == true)
            {
                HttpCookie kook = new HttpCookie("ContactName");
                HttpCookie cooki = new HttpCookie("CompName");
                HttpCookie cooks = new HttpCookie("Addresss");
                cooki.Value = model.ContactName;
                kook.Value = model.CompanyName;
                cooks.Value = model.Addresss;
                HttpContext.Response.Cookies.Add(cooki);
                HttpContext.Response.Cookies.Add(kook);
                HttpContext.Response.Cookies.Add(cooks);
                return View();
                // return RedirectToAction("Index", "Dashb");
            }// cookie
            return View();
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product model)
        {
            _context.Products.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "<script>alert('Data insert successfull!')</script>";
            // cookie
            if (ModelState.IsValid == true)
            {
                HttpCookie kooki = new HttpCookie("ProductName");
                HttpCookie cookie = new HttpCookie("Category");
                HttpCookie cookies = new HttpCookie("CostPerKg");              
                cookie.Value = model.Category;
                kooki.Value = model.ProductName;
                cookies.Value = model.CostPerKg;                                 
                HttpContext.Response.Cookies.Add(cookie);
                HttpContext.Response.Cookies.Add(kooki);
                HttpContext.Response.Cookies.Add(cookies);
                return View();
                // return RedirectToAction("Index", "Dashb");
            }// cookie
            return View();
        }

        [HttpGet]
        public ActionResult CreateStock()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateStock(Stock model)
        {
            _context.Stocks.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "<script>alert('Data insert successfull!')</script>";
            return View();
        }

        [HttpGet]
        public ActionResult CreatePayment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePayment(Payment model)
        {
            _context.Payments.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "<script>alert('Data insert successfull!')</script>";
            return View();
        }

        [HttpGet]
        public ActionResult CreateCustomerSupplier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCustomerSupplier(CustomerSupplier model)
        {
            _context.CustomerSuppliers.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "<script>alert('Data insert successfull!')</script>";
            // cookie
            if (ModelState.IsValid == true)
            {
                HttpCookie oki = new HttpCookie("CSName");
                HttpCookie ok = new HttpCookie("CSAddress");
                HttpCookie c = new HttpCookie("Emailad");
                ok.Value = model.CSName;
                oki.Value = model.CSAddress;
                c.Value = model.Emailad;
                HttpContext.Response.Cookies.Add(ok);
                HttpContext.Response.Cookies.Add(oki);
                HttpContext.Response.Cookies.Add(c);
                return View();
                // return RedirectToAction("Index", "Dashb");
            }// cookie
            return View();
            
        }

        [HttpGet]
        public ActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCustomer(Customer model)
        {
            _context.Customers.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "<script>alert('Data insert successfull!')</script>";
            // cookie
            if (ModelState.IsValid == true)
            {
                HttpCookie okii = new HttpCookie("CustomerName");
                HttpCookie okk = new HttpCookie("CustomerAddress");
                HttpCookie cc = new HttpCookie("Emaill");
                okk.Value = model.CustomerName;
                okii.Value = model.CustomerAddress;
                cc.Value = model.Emaill;
                HttpContext.Response.Cookies.Add(okk);
                HttpContext.Response.Cookies.Add(okii);
                HttpContext.Response.Cookies.Add(cc);
                return View();
                // return RedirectToAction("Index", "Dashb");
            }// cookie
            return View();
        }
        // Detail
        public ActionResult DetailsSupplier(int id)
        {
            var data = _context.Suppliers.Where(x => x.SupplierID == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult DetailsProduct(int id)
        {
            var data = _context.Products.Where(x => x.ProductID == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult DetailsStock(int id)
        {
            var data = _context.Stocks.Where(x => x.StockID == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult DetailsPayment(int id)
        {
            var data = _context.Payments.Where(x => x.PaymentID == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult DetailsCustomerSupplier(int id)
        {
            var data = _context.CustomerSuppliers.Where(x => x.CSID == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult DetailsCustomer(int id)
        {
            var data = _context.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            return View(data);
        }

        // Delete
        public ActionResult DeleteSupplier(int id)
        {
            var data = _context.Suppliers.Where(x => x.SupplierID == id).FirstOrDefault();
            _context.Suppliers.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("indexSupplier");
        }

        public ActionResult DeleteProduct(int id)
        {
            var data = _context.Products.Where(x => x.ProductID == id).FirstOrDefault();
            _context.Products.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "<script>alert('Data deleted successfully!')</script>";
            return RedirectToAction("indexProduct");
        }

        public ActionResult DeleteStock(int id)
        {
            var data = _context.Stocks.Where(x => x.StockID == id).FirstOrDefault();
            _context.Stocks.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("indexStock");
        }

        public ActionResult DeletePayment(int id)
        {
            var data = _context.Payments.Where(x => x.PaymentID == id).FirstOrDefault();
            _context.Payments.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("indexPayment");
        }

        public ActionResult DeleteCustomerSupplier(int id)
        {
            var data = _context.CustomerSuppliers.Where(x => x.CSID == id).FirstOrDefault();
            _context.CustomerSuppliers.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("indexCustomerSupplier");
        }

        public ActionResult DeleteCustomer(int id)
        {
            var data = _context.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            _context.Customers.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("indexCustomer");
        }

        // Edit
        	[HttpGet]
        public ActionResult EditSupplier(int id)
        {
            var data = _context.Suppliers.Where(x => x.SupplierID == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult EditSupplier(Supplier Model)
        {
            var data = _context.Suppliers.Where(x => x.SupplierID == Model.SupplierID).FirstOrDefault();
            if (data != null)
            {
                data.ContactName = Model.ContactName;
                data.CompanyName = Model.CompanyName;
                data.Addresss = Model.Addresss;
                data.Email=Model.Email; 
                data.Phone = Model.Phone;   
                _context.SaveChanges();
            }

            return RedirectToAction("indexSupplier");
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var data = _context.Products.Where(x => x.ProductID == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult EditProduct(Product Model)
        {
            var data = _context.Products.Where(x => x.ProductID == Model.ProductID).FirstOrDefault();
            if (data != null)
            {
                data.ProductName = Model.ProductName;
                data.CostPerKg = Model.CostPerKg;
                data.Category = Model.Category;
                data.SupplierID = Model.SupplierID;
               
                _context.SaveChanges();
            }

            return RedirectToAction("indexProduct");
        }

        
        [HttpGet]
        public ActionResult EditStock(int id)
        {
            var data = _context.Stocks.Where(x => x.StockID == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult EditStock(Stock Model)
        {
            var data = _context.Stocks.Where(x => x.StockID == Model.StockID).FirstOrDefault();
            if (data != null)
            {
                data.Availabilityy = Model.Availabilityy;
                data.ProductID = Model.ProductID;
                
                _context.SaveChanges();
            }

            return RedirectToAction("indexStock");
        }

        [HttpGet]
        public ActionResult EditPayment(int id)
        {
            var data = _context.Payments.Where(x => x.PaymentID == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult EditPayment(Payment Model)
        {
            var data = _context.Payments.Where(x => x.PaymentID == Model.PaymentID).FirstOrDefault();
            if (data != null)
            {
                data.PaymentAmount = Model.PaymentAmount;
                data.PaymentDate = Model.PaymentDate;
                data.ProductID = Model.ProductID;
                
                _context.SaveChanges();
            }

            return RedirectToAction("indexPayment");
        }

        [HttpGet]
        public ActionResult EditCustomerSupplier(int id)
        {
            var data = _context.CustomerSuppliers.Where(x => x.CSID == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult EditCustomerSupplier(CustomerSupplier Model)
        {
            var data = _context.CustomerSuppliers.Where(x => x.CSID == Model.CSID).FirstOrDefault();
            if (data != null)
            {
                data.CSName = Model.CSName;
                data.CSAddress = Model.CSAddress;
                data.PhoneNo = Model.PhoneNo;
                data.Emailad = Model.Emailad;
                data.PaymentID = Model.PaymentID;
                _context.SaveChanges();
            }

            return RedirectToAction("indexCustomerSupplier");
        }

        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            var data = _context.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult EditCustomer(Customer Model)
        {
            var data = _context.Customers.Where(x => x.CustomerID == Model.CustomerID).FirstOrDefault();
            if (data != null)
            {
                data.CustomerName = Model.CustomerName;
                data.CustomerAddress = Model.CustomerAddress;
                data.PhoneNum = Model.PhoneNum;
                data.Emaill = Model.Emaill;
                data.PaymentID = Model.PaymentID;
                _context.SaveChanges();
            }

            return RedirectToAction("indexCustomer");
        }

    }
}