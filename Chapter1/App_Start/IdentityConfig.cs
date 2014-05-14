using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using Twilio;

namespace Chapter1
{
    /// <summary>
    /// Two factor auth
    /// </summary>
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            string AccountSid = "your account id";
            string AuthToken = "your AuthToken";
            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            var messages = twilio.SendMessage("twilio number", message.Destination, message.Body);
            return Task.FromResult(0);
        }
    }
}