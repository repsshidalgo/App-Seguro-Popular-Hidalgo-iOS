using Foundation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSeguroPopularHidalgo.iOS
{
    public class TokenRegistration
    {
        static private NSData token;

        public NSData Token
        {
            get { return token; }
            set { token = value; }
        }

    }
}
