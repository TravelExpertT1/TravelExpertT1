using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelExpert.Models;

namespace TravelExpert.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly TravelExpertsContext _context;

        public CustomerController(TravelExpertsContext context)
        {
            _context = context;
        }

        // GET: Customer
        
        public async Task<IActionResult> Index()
        {
            int CustomerID = (int)HttpContext.Session.GetInt32("CustomerId");
            //int w = 1;

          //  var travelExpertsContext = _context.Bookings.Include(b => b.Customer).Include(b => b.Package).Include(b => b.TripType);
          //  int w = 1;

           

          //  List<Booking> listBookings;
           // listBookings = _context.Bookings.ToList();

            var model = from x in _context.Bookings.ToList()
                        join y in _context.Packages.ToList() on x.PackageId equals y.PackageId
                        where (int)x.CustomerId == CustomerID
                        orderby y.PkgStartDate
                        select new ViewModelCustBook { booking = x, package = y };

            return View(model);
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Package)
                .Include(b => b.TripType)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustEmail");
            ViewData["PackageId"] = new SelectList(_context.Packages, "PackageId", "PkgName");
            ViewData["TripTypeId"] = new SelectList(_context.TripTypes, "TripTypeId", "TripTypeId");
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,BookingDate,BookingNo,TravelerCount,CustomerId,TripTypeId,PackageId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustEmail", booking.CustomerId);
            ViewData["PackageId"] = new SelectList(_context.Packages, "PackageId", "PkgName", booking.PackageId);
            ViewData["TripTypeId"] = new SelectList(_context.TripTypes, "TripTypeId", "TripTypeId", booking.TripTypeId);
            return View(booking);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }


            var model = from x in _context.Bookings.ToList()
                        join y in _context.Packages.ToList() on x.PackageId equals y.PackageId
                        where (int)x.BookingId == id
                        
                        select new ViewModelCustBook { booking = x, package = y };
           // var booking = await _context.Bookings.FindAsync(id);

            //  ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustEmail", booking.CustomerId);
            // ViewData["PackageId"] = new SelectList(_context.Packages, "PackageId", "PkgName", booking.PackageId);
            //  ViewData["TripTypeId"] = new SelectList(_context.TripTypes, "TripTypeId", "TripTypeId", booking.TripTypeId);



            return View(booking);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("BookingId,BookingDate,BookingNo,TravelerCount,CustomerId,TripTypeId,PackageId")] Booking booking)

       public async Task<IActionResult> Edit(int id, Booking booking)
        {

            var newbooking = await _context.Bookings.FindAsync(id);
            newbooking.TravelerCount = booking.TravelerCount;
            
            //if (id != booking.BookingId)
           // {
           //     return NotFound();
           // }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newbooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(newbooking.BookingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //var i = 1;
                return RedirectToAction(nameof(Index));
            }
         //   ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustEmail", booking.CustomerId);
          //  ViewData["PackageId"] = new SelectList(_context.Packages, "PackageId", "PkgName", booking.PackageId);
         //   ViewData["TripTypeId"] = new SelectList(_context.TripTypes, "TripTypeId", "TripTypeId", booking.TripTypeId);
            return View(booking);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Package)
                .Include(b => b.TripType)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);

            /*
            var model = from x in _context.Bookings.ToList()
                        join y in _context.BookingDetails.ToList() on x.BookingId equals y.PackageId
                        where (int)x.CustomerId == CustomerID
                        select new ViewModelCustBook { booking = x, package = y };



            var delBookingdetails = await _context.Bookings.FindAsync(id);
            */
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
