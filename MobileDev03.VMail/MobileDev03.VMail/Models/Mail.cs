using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Essentials;

namespace MobileDev03.VMail.Models
{
    public class Mail
    {
        public Mail(string sender, string recipient, string subject, string body, ObservableCollection<FileResult> attachments) {
            Sender = sender;
            Recipient = recipient;
            Subject = subject;
            Body = body;
            Attachments = attachments;
            CreationDate = DateTime.Now;

            //Conditional Format
            IsFavorite = true;
        }

        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; }

        public char RecipientInitial => Recipient.ToUpper()[0];

        public string FormattedCreationDate {
            get {
                if (CreationDate.Date == DateTime.Now.Date) {
                    return CreationDate.ToString("hh:mm tt");
                }
                else if (CreationDate.Year == DateTime.Now.Year) {
                    return CreationDate.ToString("MMM dd");
                }

                return CreationDate.ToString("dd/MM/yyyy");
            }
        }
        public bool IsFavorite { get; set; }
        public string FavoriteIcon => IsFavorite ? "StarFilledIcon" : "StarIcon";

        public bool HasAttachments => Attachments.Count != 0;
        public ObservableCollection<FileResult> Attachments { get; set; }
    }
}
