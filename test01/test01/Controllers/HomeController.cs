using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using test01.Models;
using MySql.Data.MySqlClient;
using System.Data;


namespace test01.Controllers {
    public class HomeController : Controller {

        public IActionResult Index() {

            Query sql = new Query();
            ViewBag.success = sql.conn_open();
            ViewBag.DT = sql.Output();


            List<Student> list = new List<Student>();
            DateTime date = DateTime.Now;
            ViewBag.Date = date;
            Student data = new Student("1", "小明", 80);
            return View(data);   
        }

        public IActionResult transcripts(string id , string name , int score) {
            Student data = new Student(id, name, score);
            return View(data);
        }

        [HttpPost]
        public IActionResult transcripts(Student model) {
            string id = model.id;
            string name = model.name;
            int score = model.score;
            Student data = new Student(id, name, score);
            return View(data);
        }


    }
}
