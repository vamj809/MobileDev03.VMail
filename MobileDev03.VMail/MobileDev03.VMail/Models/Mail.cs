using System;
using System.Collections.Generic;
using System.Text;

namespace MobileDev03.VMail.Models
{
    public class Mail
    {
        public Mail(string sender, string recipient, string subject, string body) {
            Sender = sender;
            Recipient = recipient;
            Subject = subject;
            Body = body;
            CreationDate = DateTime.Now;
        }

        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; }

        public char SenderInitial => Sender[0];
    }
}
