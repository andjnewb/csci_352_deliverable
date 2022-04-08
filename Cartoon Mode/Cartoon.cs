using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Cartoon_Mode
{

    public interface Theme
    {
        string getSource();
    }

    public class CartoonTheme : Theme
    {
        string CurrentWeatherSource;
        string precipation;
        List<string> Forecast;
        public CartoonTheme()
        {
            if (precipation == "Sunny")
            {
                CurrentWeatherSource = "/Images/Sun.png";
            }
                
            
        }

        public string getSource()
        {
            return CurrentWeatherSource;
        }
    }
}
