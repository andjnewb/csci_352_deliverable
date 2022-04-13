﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;

namespace Cartoon_Mode
{
    struct City
    {
        public Tuple<string, string> city;//ID and Name
        public Tuple<string, string> coords;// Longitude and latitude
        public Tuple<string, string> sunriseSunset;//sunrise and sunset
        public Tuple<string, string, string> temperature;//Current temperature, minimum temperature, maximum temperature
        public string humidity;
        public string pressure;//in hPa
        public string windSpeed;//in m/s
        public string clouds;//Cloudy, clear sky etc
        public string visibility;//In meters
        public string precipiation;//Yes/no
        public string lastUpdate;//Time of last update
        public string feels_like;
        public string timezone;
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

        public City call_api_now(string cityName, string stateCode)
        {
            URL_string += cityName + "," + stateCode + "&mode=xml" + "&units=imperial" + "&appid=9473bff65614e52a5f6d38c9cb5649b8";
            try
            {
                doc.Load(@URL_string);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);//We should probably return a blank city here or have a flag
            }

            City newCity = new City();

            XmlElement root = doc.DocumentElement;


            if (root != null)
            {
                //Welcome to loop hell my friend.
                foreach (XmlNode node in root.ChildNodes)
                {
                    if (node.Name == "city")
                    {
                        //The coordinate node and sunrise/sunset is a child of the city node, so we gotta do it this way.
                        newCity.city = new Tuple<string, string>(node.Attributes["id"].Value, node.Attributes["name"].Value);

                        foreach (XmlNode cityChild in node.ChildNodes)
                        {
                            if (cityChild.Name == "coord")
                            {
                                newCity.coords = new Tuple<string, string>(cityChild.Attributes["lon"].Value, cityChild.Attributes["lat"].Value);
                            }

                            if (cityChild.Name == "sun")
                            {
                                newCity.sunriseSunset = new Tuple<string, string>(cityChild.Attributes["rise"].Value, cityChild.Attributes["set"].Value);
                            }
                         
                        }

                    }

                    //Imperial units
                    if (node.Name == "temperature")
                    {
                        newCity.temperature = new Tuple<string, string, string>(node.Attributes["value"].Value, node.Attributes["min"].Value, node.Attributes["max"].Value);
                    }

                    //In %
                    if (node.Name == "humidity")
                    {
                        newCity.humidity = node.Attributes["value"].Value;
                    }

                    //hPa
                    if (node.Name == "pressure")
                    {
                        newCity.pressure = node.Attributes["value"].Value;
                    }

                    //in m/s
                    if (node.Name == "wind")
                    {
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            if (child.Name == "speed")
                            {
                                newCity.windSpeed = child.Attributes["value"].Value;
                            }
                        }
                    }

                    if (node.Name == "clouds")
                    {
                        newCity.clouds = node.Attributes["value"].Value;
                    }

                    //In meters
                    if (node.Name == "visibility")
                    {
                        newCity.visibility = node.Attributes["value"].Value;
                    }

                    //yes/no
                    if (node.Name == "precipitation")
                    {
                        newCity.precipiation = node.Attributes["mode"].Value;
                    }

                    //date followed by time
                    if (node.Name == "lastupdate")
                    {
                        newCity.lastUpdate = node.Attributes["value"].Value;
                    }

                    if(node.Name == "feels_like") 
                    {
                        newCity.feels_like = node.Attributes["value"].Value;
                    }

                    if (node.Name == "timezone")
                    {
                        newCity.timezone = node.Attributes["value"].Value;
                    }
                }

            }

            else 
            {
                newCity.lastUpdate = "-1";
            }

            doc = new XmlDocument();

            return newCity;
        }

        
    }
}
