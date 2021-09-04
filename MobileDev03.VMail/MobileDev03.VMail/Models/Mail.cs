using System;
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

            //Default values
            IsFavorite = true;
        }

        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; }
        public ObservableCollection<FileResult> Attachments { get; set; }
        public bool IsFavorite { get; set; }

        //Helper Attributes
        public char RecipientInitial {
            get => Recipient.ToUpper()[0];
            set => _ = value;
        }

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
            set => _ = value;
        }
        public string FavoriteIcon {
            get => IsFavorite ? "StarFilledIcon" : "StarIcon";
            set => _ = value;
        }

        public bool HasAttachments {
            get => Attachments.Count != 0;
            set => _ = value;
        }
    }
}
