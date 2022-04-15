using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cartoon_Mode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        City currentCity;
        API_Container container;
        City forecastCity;
        API_Container forecastContainer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetCityInfo_Click(object sender, RoutedEventArgs e)
        {
            container = new API_Container();
            forecastContainer = new API_Container();
            currentCity = container.call_api_now(CityText.Text, StateCode.Text);
            forecastCity = forecastContainer.forecast_api(CityText.Text, StateCode.Text);
            if (currentCity.temperature != null)
            {
                if (currentCity.timezone != "0")
                {
                    double offsetHours = Convert.ToDouble(currentCity.timezone) / 60 / 60;
                    DateTime sunriseTimeUTC = DateTime.Parse(currentCity.sunriseSunset.Item1);
                    DateTime sunriseLocalTime = sunriseTimeUTC.AddHours(offsetHours);
                    Sunrise.Text = sunriseLocalTime.ToString().Remove(0, 10);
                    DateTime sunsetTimeUTC = DateTime.Parse(currentCity.sunriseSunset.Item2);
                    DateTime sunsetLocalTime = sunsetTimeUTC.AddHours(offsetHours);
                    Sunset.Text = sunsetLocalTime.ToString().Remove(0, 10);
                }
                CurrentTemp.Text = currentCity.temperature.Item1 + "°";
                CurrentCityName.Text = currentCity.city.Item2;
                Humidity.Text = currentCity.humidity + "%";
                Visibility.Text = currentCity.visibility + "+ Meters";
                FeelTemp.Text = currentCity.feels_like;
                Pressure.Text = currentCity.pressure + "hPa";
            }
            else
            {
                MessageBox.Show("Please enter valid City Name for the State selected");
            }

        }

        private void ModeButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentCity.clouds == "1" && currentCity.precipiation == "no")
            {
                if (ModeSelector.Text == "Cartoon Mode")
                {
                    CurrentWeatherImage.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Sun.png");
                }
                else
                {
                    CurrentWeatherImage.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiSun.png");
                }
            }
            else if (currentCity.precipiation == "rain")
            {
                if (ModeSelector.Text == "Cartoon Mode")
                {
                    CurrentWeatherImage.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Rain.png");
                }
                else
                {
                    CurrentWeatherImage.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiRain.png");
                }
            }
            else if (Convert.ToInt64(currentCity.clouds) > 50 && Convert.ToInt64(currentCity.clouds) < 75 && currentCity.precipiation == "rain")
            {
                if (ModeSelector.Text == "Cartoon Mode")
                {
                    CurrentWeatherImage.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/PartlyCloudy.png");
                }
                else
                {
                    CurrentWeatherImage.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiPartlyCloudy.png");
                }
            }
            else
            {
                if (ModeSelector.Text == "Cartoon Mode") {
                    CurrentWeatherImage.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/PartlyCloudy.png");
                }
                else
                {
                    CurrentWeatherImage.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiPartlyCloudy.png");
                } 
            }
            if(ModeSelector.Text == "Cartoon Mode")
            {
                HumidityPic.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Humidity.png");
                SunrisePic.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Sunrise.png");
                SunsetPic.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Sunset.png");
                VisibilityPic.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Visibility.png");
                FeelLikePic.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Feel_Like.png");
                PressurePic.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Barometer.png");
            }
            else
            {
                HumidityPic.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiHumidity.png");
                SunrisePic.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiSunrise.png");
                SunsetPic.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiSunset.png");
                FeelLikePic.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiFeelLike.png");
                VisibilityPic.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiVisibility.png");
                PressurePic.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiBarometer.png");
            }
            if(forecastCity.clouds == "1" && forecastCity.precipiation == "no")
            {
                if(ModeSelector.Text == "Cartoon Mode")
                {
                    ForecastPic1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Sun.png");
                }
                else
                {
                    ForecastPic1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiSun.png");
                }
            }
            else if(forecastCity.precipiation == "yes")
            {
                if (ModeSelector.Text == "Cartoon Mode")
                {
                    ForecastPic2.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Rain.png");
                }
                else
                {
                    ForecastPic2.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiRain.png");
                }
            }
        }
    }
}
