using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeetingBookingAPI.Models;


namespace MeetingBookingAPI.Controllers
{
    [RoutePrefix("Api/Hooks")]
    public class HooksController : Controller
    {
        // GET: Hooks
       
        public ActionResult Index()
        {
            return View();
        }


        MeetingDB DB = new MeetingDB();

        [HttpPost]
        public object CreateMeeting(MeetingBooking e)
        {
            try
            {
                if (e.MeetingId != null)
                {
                    ScheduleMeeting em = new ScheduleMeeting();
                    em.FirstName = e.FirstName;

                    em.LastName = e.LastName;

                    em.Purpose = e.Purpose;

                    em.Description = e.Description;

                    em.MeetingDtm = e.MeetingDtm.Value.ToUniversalTime();
                    
                    em.Country = e.Country;

                    DB.ScheduleMeetings.Add(em);

                    DB.SaveChanges();

                    return new Response
                    {
                        Status = "Success",
                        Message = "Data save Successfully"

                    };

                }

                else

                {

                    var obj = DB.ScheduleMeetings.Where(x => x.MeetingId == e.MeetingId).ToList().FirstOrDefault();

                    if (obj.MeetingId !=null)

                    {
                        obj.FirstName = e.FirstName;

                        obj.LastName = e.LastName;

                        obj.Purpose = e.Purpose;

                        obj.Description = e.Description;

                        obj.MeetingDtm = e.MeetingDtm;

                        DB.SaveChanges();

                        return new Response
                        {
                            Status = "Updated",
                            Message = "Updated Successfully"
                        };

                    }

                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };

        }

        [Route("GetUserDetailsById")]  
        [HttpGet]  
        public object GetUserDetailsById(Guid id)
        {
           
               var  obj = DB.ScheduleMeetings.Where(x => x.MeetingId == id).ToList().FirstOrDefault();
                obj.MeetingDtm = obj.MeetingDtm.Value.ToLocalTime();
           
            return obj;
        }
        [Route("GetUserDetails")]
        [HttpGet]
        public object GetUserDetails()
        {
            var timeZones = TimeZoneInfo.GetSystemTimeZones();
            var obj = DB.ScheduleMeetings.ToList();
            foreach (var item in obj)
            {
                item.MeetingDtm = item.MeetingDtm.Value.ToLocalTime();
            }

            return obj;
        }

    }
}