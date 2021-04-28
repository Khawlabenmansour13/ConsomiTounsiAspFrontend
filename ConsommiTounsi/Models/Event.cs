using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models
{





    public class Event
    {

        public virtual List<Donation> Donations { get; set; }
        public virtual List<Advertisement> Advertisements { get; set; }
        public virtual Jackpot Jackpot { get; set; }
        public virtual List<Participation> Participations { get; set; }
        public virtual List<Notification> Notifications { get; set; }

        public virtual List<Meeting> Meeting { get; set; }


        public virtual List<Sponsoring> Sponsoring { get; set; }

        public virtual UserConsomi ManagerEvent { get; set; }

        [JsonProperty("idEvent")]

        public int IdEvent { get; set; }

        [JsonProperty("title")]

        public string Title { get; set; }
        [JsonProperty("startDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]

        public DateTime StartDate { get; set; }

        [JsonProperty("endDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]

        public DateTime EndDate { get; set; }

        [JsonProperty("description")]

        public string Description { get; set; }
        public bool Status { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("image")]

        public byte[] Image { get; set; }

        [JsonProperty("priceTicket")]
        public float PriceTicket { get; set; }
        public float CollAmount { get; set; }


        public int ParticipantsNbr { get; set; }


        [JsonProperty("numberOfPlaces")]
        public int NumberOfPlaces { get; set; }
        public bool EarlyParticipants { get; set; }
        [JsonProperty("nbrTicketEarlyParticipants")]

        public int NbrTicketEarlyParticipants { get; set; }
        public int Views { get; set; }

        [JsonProperty("discountPercentage")]
        public float DiscountPercentage { get; set; }
        public CategoryEvent CategoryEvent { get; set; }


        public Event()
        {

        }
        public Event(List<Donation> donations, List<Advertisement> advertisements, Jackpot jackpot, List<Participation> participations, List<Notification> notifications, List<Meeting> meeting, List<Sponsoring> sponsoring, UserConsomi managerEvent, int idEvenement, string title, DateTime date, DateTime hour, string description, bool status, string address, byte[] image, float ticketPrice, float collAmount, int participantsNbr, int numberOfPlaces, bool earlyParticipants, int nbrTicketEarlyParticipants, int views, float discountPercentage, CategoryEvent category)
        {
            Donations = donations;
            Advertisements = advertisements;
            Jackpot = jackpot;
            Participations = participations;
            Notifications = notifications;
            Meeting = meeting;
            Sponsoring = sponsoring;
            ManagerEvent = managerEvent;
            IdEvent = idEvenement;
            Title = title;
            StartDate = date;
            EndDate = hour;
            Description = description;
            Status = status;
            Address = address;
            Image = image;
            PriceTicket = ticketPrice;
            CollAmount = collAmount;
            ParticipantsNbr = participantsNbr;
            NumberOfPlaces = numberOfPlaces;
            EarlyParticipants = earlyParticipants;
            NbrTicketEarlyParticipants = nbrTicketEarlyParticipants;
            Views = views;
            DiscountPercentage = discountPercentage;
            CategoryEvent = category;
        }
  
    public override string ToString()
    {
        return base.ToString();
    }
    }
}











