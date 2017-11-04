using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;
using PokerHands;


namespace PokerHandsAPI
{
    /// <summary>
    /// PokerHand server.
    /// Modified from https://gist.github.com/zezba9000/75683cf170333fa9512697ce2f10311f
    /// </summary>
    public class PokerHandsHttpServer
    {
        /// <summary>
        /// Construct server with given port
        /// </summary>
        /// <param name="ip">ip</param>
        /// <param name="port">Port of the server</param>
        public PokerHandsHttpServer(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }

        /// <summary>
        /// Construct server with given port on local host
        /// </summary>
        /// <param name="port">Port of the server</param>
        public PokerHandsHttpServer(int port)
        {
            this.ip = "localhost";
            this.port = port;
        }

        /// <summary>
        /// Construct server with open port on localhost
        /// </summary>
        public PokerHandsHttpServer()
        {
            this.ip = "localhost";
            // get empty port
            TcpListener ll = new TcpListener(IPAddress.Loopback, 0);
            ll.Start();
            this.port = ((IPEndPoint)ll.LocalEndpoint).Port;
            ll.Stop();
        }

        public void Start()
        {
            if (serverThread != null)
                throw new Exception("Web Server already active. (Call Stop first).");
            serverThread = new Thread(this.Listen);
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        public void Stop()
        {
            threadActive = false;
            // stop listener
            if (listener != null && listener.IsListening) listener.Stop();

            // kill thread
            if (serverThread != null)
            {
                serverThread.Join();
                serverThread = null;
            }

            // close listener
            if(listener != null)
            {
                listener.Close();
                listener = null;
            }
        }

        private void Process(HttpListenerContext context)
        {
            // Todo
            HttpListenerRequest request = context.Request;

            // translate request to my class
            // alright this is not a solid way to do this but I just need it to work
            // assume that the incoming request is set up as 
            // "player1=(somename)&cards=(card1,0card2,...)&player2=(...
            PokerPlayerModel p1 = new PokerPlayerModel();
            PokerPlayerModel p2 = new PokerPlayerModel();
            p1.Id = request.QueryString["player1"];
            p2.Id = request.QueryString["player2"];
            if(p1.Id == null || p1.Id == "" || p2.Id == null || p2.Id == "")
            {
                // bad query
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            p1.Cards = request.QueryString["cards1"].Split(',').ToList();
            p2.Cards = request.QueryString["cards2"].Split(',').ToList();
            if(p1.Cards.Count < 1 || p2.Cards.Count < 1 
                || p1.Cards.Count != p2.Cards.Count)
            {
                // bad query
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            // process my class and get result
            WinnerSummary[] winners = WinnerEvaluator.GetWinnerOfTwo(p1, p2).ToArray();
            string responseString = "<HTML><BODY><ul>";
            foreach(WinnerSummary winner in winners)
            {
                responseString += "li" + winner.ID + " " + winner.Hand + " winning card: " + winner.WinningCard + "</li>";
            }
            responseString += "</ul></BODY></HTML>";

            // wrap result as HttpResponse and return
            HttpListenerResponse response = context.Response;

            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            // get response stream and write response to it
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            //close the output stream
            output.Close();
            //stop listener
            listener.Stop();
            
            
        }

        private void Listen()
        {
            threadActive = true;

            // start listener
            try
            {
                listener = new HttpListener();
                listener.Prefixes.Add(string.Format("http://{0}:{1}/",ip,port));
                listener.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
                threadActive = false;
                return;
            }
            
            // wait for requests
            while(threadActive)
            {
                try
                {
                    HttpListenerContext context = listener.GetContext();
                    if (!threadActive) break;
                    Process(context);
                }
                catch (HttpListenerException e)
                {
                    // TODO label what this code is
                    if (e.ErrorCode != 955) Console.WriteLine("ERROR: " + e.Message);
                    threadActive = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                    threadActive = false;
                }
            }
        }

        private void Initialize(string path, string ip, int port)
        {
            this.path = path;
            this.ip = ip;
            this.port = port;
        }

        private Thread serverThread;
        private volatile bool threadActive;

        private string ip;
        private string path;
        private HttpListener listener;

        /// <summary>
        /// Gets the port this server is using
        /// </summary>
        public int Port
        {
            get { return port; }
            private set { }
        }
        private int port;
    }
}
