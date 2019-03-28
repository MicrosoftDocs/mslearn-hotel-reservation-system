using System;
using System.Threading;
using System.Threading.Tasks;

namespace HotelReservationSystemTestClient
{
    public class TestClientsDriver
    {
        public ManualResetEvent runCompleteEvent = new ManualResetEvent(false);
        private int numClients;

        public TestClientsDriver(int numClients)
        {
            this.numClients = numClients;
        }

        public void Run(CancellationToken token)
        {
            var rnd = new Random();

            for (int clientNum = 0; clientNum < this.numClients; clientNum++)
            {
                string clientName = $"Client{clientNum}";

                var client = new TestClient(clientName);
                Task.Factory.StartNew(() => client.DoWork());
            }

            while (!token.IsCancellationRequested)
            {
                // Run until the user stops the clients by pressing Enter
            }

            this.runCompleteEvent.Set();
        }

        public void WaitForEnter(CancellationTokenSource tokenSource)
        {
            Console.WriteLine("Press Enter to stop clients");
            Console.ReadLine();
            tokenSource.Cancel();
        }
    }
}
