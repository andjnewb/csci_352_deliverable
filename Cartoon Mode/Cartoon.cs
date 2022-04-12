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
        API_Container container2 = new API_Container();
        public CartoonTheme()
        {
           
        }



        public string getSource()
        {
            return CurrentWeatherSource;
        }

        
    }
}
