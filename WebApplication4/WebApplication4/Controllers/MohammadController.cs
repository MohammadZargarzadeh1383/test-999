using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MohammadController : ControllerBase
    {

        string TimeFirst = DateTime.Now.ToString("HH:mm:ss");

        [HttpGet("Start")]
        public IActionResult GetTime()
        {
            TimeFirst = DateTime.Now.ToString("HH:mm:ss");
            return Ok(new { message = "زمان ورود شما.", Time = TimeFirst });
        }
        [HttpGet("End")]
        public IActionResult GetSecondTime()
        {
            string TimeSecond = DateTime.Now.ToString("HH:mm:ss");
            TimeSpan t1 = TimeSpan.Parse(TimeFirst);
            TimeSpan t2 = TimeSpan.Parse(TimeSecond);
            string diffrenttime = (t2 - t1).ToString();
            string filePath = @"C:\Users\MOHAMADREZA\Desktop\output.txt";
            System.IO.File.WriteAllText(filePath, diffrenttime);
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                TimeSpan t3 = TimeSpan.Parse(diffrenttime);
                TimeSpan t4 = TimeSpan.Parse(line);
                string diffrenttime2 = (t3 + t4).ToString();
                System.IO.File.WriteAllText(filePath, "");
                System.IO.File.WriteAllText(filePath, diffrenttime2);
                return Ok(new
                {
                    message = "زمان خروج شما.",
                    Time = TimeSecond,
                    message2 = "کل زمان شما",
                    time2 = diffrenttime2,
                });
            }

        }
    }
}
