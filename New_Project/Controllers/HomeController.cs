using New_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace New_Project.Controllers
{
    public class HomeController : Controller
    {
        private masterEntities db = new masterEntities();
        public ActionResult Index( )
        {
           
            using (var context = new masterEntities())
            {
                var dbNames = context.Database.SqlQuery<string>(
                   " Select name from sys.databases WHERE name NOT IN('master', 'tempdb', 'model', 'msdb'); ").ToList();



                


                @ViewBag.Data = dbNames;

            }
            


            return View();
        }

        [HttpPost]
        public ActionResult GetTableInfo(string databaseName)
        {
            using (var context = new masterEntities())
            {


                var Tables = context.Database.SqlQuery<string>(
                    "SELECT TABLE_NAME FROM "+ databaseName.ToString() +".INFORMATION_SCHEMA.TABLES").ToList();
              
                @ViewBag.Data1 = Tables;




            }

            return View();
        }


        [HttpGet]
        public JsonResult AjaxGetCall(string TableName)
        {
            using (var context = new masterEntities())
            {


                var TableNames = @ViewBag.Data1;
            };
            return Json(TableName, JsonRequestBehavior.AllowGet);
        }




    }
}