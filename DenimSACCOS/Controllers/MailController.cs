using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using DenimSACCOS.Models;

namespace DenimSACCOS.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index(Mail _objModelMail)
        {
            ViewBag.IsEmailSent = false;
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();

                mail.To.Add("krennovatest@gmail.com");
                mail.From = new MailAddress(_objModelMail.Email);

                mail.Subject = "Enquiry";
                mail.Body = "Hello <b>Admin</b>,<br/><br/>A new Mail has been Received on Oxygen Altitude Home.<br/><br/><b>" + mail.Subject + ".</b><br/><br/>" + "From:&nbsp;" + _objModelMail.Name + ".<br/>Email:&nbsp; " + _objModelMail.Email + ".<br/>Contact #:&nbsp; " + _objModelMail.Mobile + ".<br/><br/>" + _objModelMail.Body + "<br/><br/>Thanks.<br/>";

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("krennovatest@gmail.com", "test@123#");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                ModelState.Clear();
                ViewBag.IsEmailSent = true;
                return View("../Home/Contact");

            }
            else
            {
                ViewBag.IsEmailSent = false;
                return View("../Home/Contact");
            }

        }
    }
}