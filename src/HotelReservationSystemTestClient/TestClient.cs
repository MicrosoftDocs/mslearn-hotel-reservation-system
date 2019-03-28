using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using HotelReservationSystemTypes;

namespace HotelReservationSystemTestClient
{
    class TestClient
    {
        private readonly string clientName;
        private readonly string reservationsServiceURI;
        private readonly string reservationsServiceCollection;

        internal TestClient(string clientName)
        {
            this.clientName = clientName;
            this.reservationsServiceURI = ConfigurationManager.AppSettings["ReservationsServiceURI"];
            this.reservationsServiceCollection = ConfigurationManager.AppSettings["ReservationsServiceCollection"];
        }

        internal async void DoWork()
        {
            Random rnd = new Random();

            while (true)
            {
                var client = new HttpClient();

                try
                {
                    int reservationID = rnd.Next();
                    Console.WriteLine($"Client {clientName} making reservation {reservationID}");
                    client.BaseAddress = new Uri(this.reservationsServiceURI);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Make a dummy reservation
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, this.reservationsServiceCollection);
                    string json = JsonConvert.SerializeObject("dummy data");
                    request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error making reservation: {e.Message}");
                }

                try
                {
                    // Do a query
                    var data = await client.GetStringAsync($"{this.reservationsServiceCollection}/{rnd.Next()}");
                    var reservation = JsonConvert.DeserializeObject<CustomerReservation>(data);
                    Console.WriteLine($"Client {clientName} querying reservation: {reservation}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error retrieving reservation: {e.Message}");
                }
            }
        }
    }
}
