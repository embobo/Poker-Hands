using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerHands;
using System.Web;

namespace PokerHandsAPI
{
    public class HttpHandler : IHttpHandler
    {
        public void ProcessRequest (HttpContext context)
        {
            // todo
        }

        public bool IsReusable
        {
            get
            {
                // todo
                return false;
            }
        }
    }
}
