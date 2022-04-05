using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;

namespace Regular_Weather_Template
{


    class API_Container
    {
        WebClient client;
        public XmlDocument doc;
        string URL_string = "https://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&appid=9473bff65614e52a5f6d38c9cb5649b8&mode=xml";

        public API_Container()
        {
            client = new WebClient();
            doc = new XmlDocument();


            doc.PreserveWhitespace = true;

        }

        public void call_api()
        {
            doc.Load(@URL_string);
        }

        
    }
}
