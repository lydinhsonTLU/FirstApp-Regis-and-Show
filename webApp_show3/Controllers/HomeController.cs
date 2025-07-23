using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;
using webApp_show3.Models;

namespace webApp_show3.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.loichao = "Ly Dinh Son";
        DateTime hour = DateTime.Now;
        ViewBag.loichao2 = "Bay gio la: "+ hour;

        Student stu = new Student
        {
            msv = "321",
            name = "son",
            birthday = DateTime.Now.ToString("dd/MM/yyyy"),
            gender = "Male",
            hasGraduated = true
        };

        Repo.AddStudent(stu);


        List<Student> stu1 = new List<Student>();
        Random random = new Random();

        string[] genders = { "Nam", "Nu" };

        for (int i = 0; i < 10; i++)
        {
            string RDmsv = "SV" + random.Next(1000, 9999); // Mã SV ng?u nhiên
            string RDname = "Ly Son so " + (i + 1);

            // Ngày sinh ng?u nhiên trong kho?ng 1/1/2000 ??n 31/12/2005
            DateTime start = new DateTime(2000, 1, 1);
            int range = (new DateTime(2005, 12, 31) - start).Days;
            DateTime randomBirthday = start.AddDays(random.Next(range));
            string birthday = randomBirthday.ToString("dd/MM/yyyy");

            string gender = genders[random.Next(genders.Length)];
            bool hasGraduated = random.Next(2) == 1;

            Student student = new Student
            {
                msv = RDmsv,
                name = RDname,
                birthday = birthday,
                gender = gender,
                hasGraduated = hasGraduated
            };

            Repo.AddStudent(student);
        }

        return View("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult login() { return View("login"); }

    [HttpPost]
    public IActionResult login (string name, string msv)
    {
       

        List<Student> students = Repo.GetStudents();
        

       string error = "Tai khoan hoac mat khau khong dung"; ;

        
        foreach (Student student in students)
        {
            if (student.msv == msv && student.name == name)
            {
                return View("MainScreen", students);
            }
        }
      
        return View("login",error);

    }



    public IActionResult Register() { return View(); }

    [HttpPost]
    public IActionResult Register (Student student)
    {
        if (ModelState.IsValid)
        {
            Repo.AddStudent(student);
            return View("Thanks", student);
        }else
        {
            return View("Register");
        }
    }


    public IActionResult quenMK ()
    {
        return View("quenMK");
    }

    public IActionResult logout ()
    {
        Repo.RemoveAllStudent();

        ViewBag.logout = DateTime.Now;

        return View("logout");
    }
    
}
