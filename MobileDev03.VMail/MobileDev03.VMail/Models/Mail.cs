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

            //Conditional Format
            IsFavorite = false;
            HasAttachments = false;
        }

        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; }

        public char SenderInitial => Sender[0];

        public string FormattedCreationDate {
            get {
                if (CreationDate.Date == DateTime.Now.Date)
                    return CreationDate.ToString("hh:mm tt");
                else if(CreationDate.Year == DateTime.Now.Year)
                    return CreationDate.ToString("MMM dd");
                return CreationDate.ToString("dd/MM/yyyy");
            }
        }

        public bool IsFavorite { get; set; }

        public bool HasAttachments { get; set; }
    }
}
