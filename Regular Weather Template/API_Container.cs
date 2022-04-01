using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Regular_Weather_Template
{
    

    class API_Container
    {
        WebClient client;
        public string response;


        public API_Container()
        {
            client = new WebClient();

            response = client.UploadString("https://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&appid={9473bff65614e52a5f6d38c9cb5649b8}","POST data");

        }
    }
}
