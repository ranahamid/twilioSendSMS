using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;

namespace twilioSendSMS02.Controllers
{
 
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
            // set our AccountSid and AuthToken
            //LIVE Credentials
            string AccountSid = "ACd4eae2235f3344fb3c7fd0fdc882ba95";
            string AuthToken = "324e254745f9728347e54d21aa7a47ed";

            //TEST Credentials
            //string AccountSid = "AC88ada4471fd3a7e3d65b591b9bd8659b";
            // string AuthToken = "d74e895c280deeb4dd9951f14dcb0298";

                // instantiate a new Twilio Rest Client
                var client = new TwilioRestClient(AccountSid, AuthToken);

                // make an associative array of people we know, indexed by phone number


                var people = new Dictionary<string, string>()
                {
                  //  { "+8801717623876","Rana Hamid 01"},
                    { "+8801725620123","Rana Hamid"},
                };

            List<string> fEnumerable=new List<string>();
            
            // iterate over all our friends
            foreach (var person in people)
                {
                /*   client.SendSmsMessage("+8801717623876", person.Key,
                       string.Format("Hey {0}, Monkey Party at 6PM. Bring Bananas!", person.Value));*/

                // Send a new outgoing SMS by POSTing to the Messages resource #1#
                var sms = client.SendMessage(
                        "+19147689920", // From number, must be an SMS-enabled Twilio number
                        person.Key,     // To number, if using Sandbox see note above
                                        // message content
                                        //string.Format("Hey {0}, Monkey Party at 6PM. Bring Bananas!...LIVE Credentials", 
                        string.Format("Hey {0}, Monkey Party at 6PM. Bring Bananas!...TEST Credentials", 

                        person.Value)
                    );

                fEnumerable.Add(sms.Sid);
                 
                Response.Write(string.Format("Sent message to {0}, SID: {1}, ", person.Value,sms.Sid));
                Response.Write("Price: "+sms.Price+ "Status: "+sms.Status+ "DateSent: "+sms.DateSent+ "DateCreated: " + sms.DateCreated);
                }

                return View();
            }

          
        }

    
}