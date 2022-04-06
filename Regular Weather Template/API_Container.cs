using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;

namespace Regular_Weather_Template
{
    struct City
    {
        
    }

    class API_Container
    {
        WebClient client;
        public XmlDocument doc;
        string URL_string = @"https://api.openweathermap.org/data/2.5/weather?q=";






        public API_Container()
        {
            client = new WebClient();
            doc = new XmlDocument();


            doc.PreserveWhitespace = true;

        }

        public string call_api(string cityName, string stateCode)
        {
            URL_string += cityName + "," + stateCode + "&mode=xml" + "&units=imperial" + "&appid=9473bff65614e52a5f6d38c9cb5649b8";
            

            doc.Load(@URL_string);
            return URL_string;
        }

        
    }
}
