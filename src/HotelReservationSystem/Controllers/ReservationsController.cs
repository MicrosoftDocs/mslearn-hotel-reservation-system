﻿using HotelReservationSystemTypes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        // GET: api/Reservations
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {  };
        }

        // GET: api/Reservations/ReservationID
        [HttpGet("{reservationid}", Name = "Get")]
        public CustomerReservation Get(int reservationid)
        {
            // Pretend to do some work
            Thread.SpinWait(int.MaxValue / 500);

            // Return dummy data
            return new CustomerReservation
            {
                ReservationID = reservationid,
                CustomerID = $"{new Random().Next()}",
                HotelID = $"Hotel {new Random().Next()}",
                Checkin = DateTime.Now.AddDays(10),
                Checkout = DateTime.Now.AddDays(10 + new Random().NextDouble() * 100),
                NumberOfGuests = new Random().Next(5) + 1,
                ReservationComments = getRandomString(new Random().Next(1000))
            };
        }

        // POST: api/Reservations
        [HttpPost]
        public void Post([FromBody] string value)
        {
            // Pretend to do some work
            Thread.SpinWait(int.MaxValue / 100);
        }

        // PUT: api/Reservations/ReservationID
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            // Pretend to do some work
            Thread.SpinWait(int.MaxValue / 100);
        }

        // DELETE: api/ApiWithActions/ReservationID
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Pretend to do some work
            Thread.SpinWait(int.MaxValue / 50);
        }

        private static Random random = new Random();

        private static string getRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
