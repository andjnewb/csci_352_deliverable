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
            CityText.Text = "Martin";
            StateCode.SelectedItem = "TN";
            GetCity();
        }

        private void GetCityInfo_Click(object sender, RoutedEventArgs e)
        {
            GetCity();
        }
        private void GetCity()
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
                ForecastDay1.Text = Math.Round(Convert.ToDouble(forecastCity.forecastMinTemp[0])) + "°/" + Math.Round(Convert.ToDouble(forecastCity.forecastMaxTemp[0])) + "°";
                ForecastDay2.Text = Math.Round(Convert.ToDouble(forecastCity.forecastMinTemp[1])) + "°/" + Math.Round(Convert.ToDouble(forecastCity.forecastMaxTemp[1])) + "°";
                ForecastDay3.Text = Math.Round(Convert.ToDouble(forecastCity.forecastMinTemp[2])) + "°/" + Math.Round(Convert.ToDouble(forecastCity.forecastMaxTemp[2])) + "°";
                ForecastDay4.Text = Math.Round(Convert.ToDouble(forecastCity.forecastMinTemp[3])) + "°/" + Math.Round(Convert.ToDouble(forecastCity.forecastMaxTemp[3])) + "°";
                ForecastDay5.Text = Math.Round(Convert.ToDouble(forecastCity.forecastMinTemp[4])) + "°/" + Math.Round(Convert.ToDouble(forecastCity.forecastMaxTemp[4])) + "°";
                ForecastDay6.Text = Math.Round(Convert.ToDouble(forecastCity.forecastMinTemp[5])) + "°/" + Math.Round(Convert.ToDouble(forecastCity.forecastMaxTemp[5])) + "°";
                ForecastDay7.Text = Math.Round(Convert.ToDouble(forecastCity.forecastMinTemp[6])) + "°/" + Math.Round(Convert.ToDouble(forecastCity.forecastMaxTemp[6])) + "°";
            }
            ForecastPicChange();
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
            ForecastPicChange();
        }
        private void ForecastPicChange()
        {
            if(forecastCity.forecastPrecipitation.Count != 0) { 
                if (Convert.ToInt32(forecastCity.forecastClouds[0]) <= 25 && forecastCity.forecastPrecipitation[0] == "no")
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Sun.png");
                    }
                    else
                    {
                        ForecastPic1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiSun.png");
                    }
                }
                else if (forecastCity.forecastPrecipitation[0] == "yes")
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Rain.png");
                    }
                    else
                    {
                    ForecastPic1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiRain.png");
                    }
                }
                else
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("c:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/PartlyCloudy.png");
                    }
                    else
                    {
                        ForecastPic1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("c:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiPartlyCloudy.png");
                    }
                }
                if (Convert.ToInt32(forecastCity.forecastClouds[1]) <= 25 && forecastCity.forecastPrecipitation[1] == "no")
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic2.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Sun.png");
                    }
                    else
                    {
                        ForecastPic2.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiSun.png");
                    }
                }
                else if (forecastCity.forecastPrecipitation[1] == "yes")
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
                else
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic2.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("c:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/PartlyCloudy.png");
                    }
                    else
                    {
                        ForecastPic2.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("c:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiPartlyCloudy.png");
                    }
                }
                if (Convert.ToInt32(forecastCity.forecastClouds[2]) <= 25 && forecastCity.forecastPrecipitation[2] == "no")
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic3.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Sun.png");
                    }
                    else
                    {
                        ForecastPic3.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiSun.png");
                    }
                }
                else if (forecastCity.forecastPrecipitation[2] == "yes")
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic3.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Rain.png");
                    }
                    else
                    {
                        ForecastPic3.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiRain.png");
                    }
                }
                else
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic3.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("c:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/PartlyCloudy.png");
                    }
                    else
                    {
                        ForecastPic3.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("c:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiPartlyCloudy.png");
                    }
                }
                if (Convert.ToInt32(forecastCity.forecastClouds[3]) <= 25 && forecastCity.forecastPrecipitation[3] == "no")
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic4.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Sun.png");
                    }
                    else
                    {
                        ForecastPic4.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiSun.png");
                    }
                }
                else if (forecastCity.forecastPrecipitation[3] == "yes")
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic4.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Rain.png");
                    }
                    else
                    {
                        ForecastPic4.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiRain.png");
                    }
                }
                else
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic4.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("c:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/PartlyCloudy.png");
                    }
                    else
                    {
                        ForecastPic4.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("c:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiPartlyCloudy.png");
                    }
                }
                if (Convert.ToInt32(forecastCity.forecastClouds[4]) <= 25 && forecastCity.forecastPrecipitation[4] == "no")
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic5.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Sun.png");
                    }
                    else
                    {
                        ForecastPic5.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiSun.png");
                    }
                }
                else if (forecastCity.forecastPrecipitation[4] == "yes")
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic5.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Rain.png");
                    }
                    else
                    {
                        ForecastPic5.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiRain.png");
                    }
                }
                else
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic5.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("c:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/PartlyCloudy.png");
                    }
                    else
                    {
                        ForecastPic5.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("c:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiPartlyCloudy.png");
                    }
                }
                if (Convert.ToInt32(forecastCity.forecastClouds[5]) <= 25 && forecastCity.forecastPrecipitation[5] == "no")
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic6.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Sun.png");
                    }
                    else
                    {
                        ForecastPic6.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiSun.png");
                    }
                }
                else if (forecastCity.forecastPrecipitation[5] == "yes")
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic6.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Rain.png");
                    }
                    else
                    {
                        ForecastPic6.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiRain.png");
                    }
                }
                else
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic6.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("c:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/PartlyCloudy.png");
                    }
                    else
                    {
                        ForecastPic6.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("c:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiPartlyCloudy.png");
                    }
                }
                if (Convert.ToInt32(forecastCity.forecastClouds[6]) <= 25 && forecastCity.forecastPrecipitation[6] == "no")
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic7.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Sun.png");
                    }
                    else
                    {
                        ForecastPic7.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiSun.png");
                    }
                }
                else if (forecastCity.forecastPrecipitation[6] == "yes")
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic7.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/Rain.png");
                    }
                    else
                    {
                        ForecastPic7.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiRain.png");
                    }
                }
                else
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        ForecastPic7.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("c:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/PartlyCloudy.png");
                    }
                    else
                    {
                        ForecastPic7.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("c:\\Users/jospcham/source/repos/Cartoon Mode/Cartoon Mode/Images/EmojiPartlyCloudy.png");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter valid city name for state selected.");
            }
        }
    }
}
