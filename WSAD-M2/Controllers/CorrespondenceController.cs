using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSAD_M2.Models.ViewModels.Correspondence;

namespace WSAD_M2.Controllers
{
    public class CorrespondenceController : Controller
    {
        // GET: Correspondence
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactEmailViewModel contactMessage)
        {   
            //Validate Contact message Input

            if (contactMessage == null)
            {
                ModelState.AddModelError("", "No message provided.");
                return View();
            }

            if (string.IsNullOrWhiteSpace(contactMessage.Name) ||
                string.IsNullOrWhiteSpace(contactMessage.Email) ||
                string.IsNullOrWhiteSpace(contactMessage.Message))
            {
                ModelState.AddModelError("", "All fields are required");
                return View();
            }

            //Create an email message object

            System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();

            //Populate the object

            email.To.Add("hartinmg@mail.uc.edu");
            email.From = new System.Net.Mail.MailAddress(contactMessage.Email);
            email.Subject = "This is our Correspondence";
            email.Body = string.Format("Name: {0}\r\n Message: {1}", 
                contactMessage.Name, contactMessage.Message);
            email.IsBodyHtml = false;

            //Set up SMTP Client (to send the email message)

            System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();
            smtpClient.Host = "smtp.fuse.net";

            //Send Message

            smtpClient.Send(email);

            //Notify the user that the message was sent
            return View("emailConfirmation");
        }
    }
}