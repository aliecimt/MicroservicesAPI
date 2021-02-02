using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeetingBookingAPI.Models
{
    public class MeetingBooking
    {
        private Guid meetingId;
        [Key]
        public Guid MeetingId
        {
            get
            {
                return meetingId;
            }
            set
            {
                if (value!=null)
                    meetingId = Guid.NewGuid();
                else
                    meetingId = value;
            }
        }
       // public System.Guid MeetingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Purpose { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> MeetingDtm { get; set; }
        public string Country { get; set; }
    }

    public class Response
    {  
        public string Status { get; set; }  
        public string Message { get; set; }  
    }  
}