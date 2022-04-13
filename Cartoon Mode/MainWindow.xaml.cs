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


        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetCityInfo_Click(object sender, RoutedEventArgs e)
        {
            container = new API_Container();
            currentCity = container.call_api_now(CityText.Text, StateCode.Text);
            if (currentCity.temperature != null)
            {
                CurrentTemp.Text = currentCity.temperature.Item1 + "°";
                CurrentCityName.Text = currentCity.city.Item2;
                Humidity.Text = currentCity.humidity + "%";
                Sunrise.Text = currentCity.sunriseSunset.Item1.Remove(0, 11) + " AM";
                Sunset.Text = currentCity.sunriseSunset.Item2 + " PM";
                Visibility.Text = currentCity.visibility + "+ Meters";
                FeelTemp.Text = currentCity.feels_like;
                Pressure.Text = currentCity.pressure + "hPa";
                if (currentCity.clouds == "1" && currentCity.precipiation == "no")
                {
                    if (ModeSelector.Text == "Cartoon Mode")
                    {
                        String stringPath = "/Images/Sun.png";
                        Uri imageUri = new Uri(stringPath, UriKind.Relative);
                        BitmapImage imageBitmap1 = new BitmapImage(imageUri);
                        CurrentWeatherImage.Source = imageBitmap1;
                        CurrentWeatherImage.Uid = "1";
                    }
                    else
                    {
                        String stringPath = "/Images/EmojiSun.png";
                        Uri imageUri = new Uri(stringPath, UriKind.Relative);
                        BitmapImage imageBitmap = new BitmapImage(imageUri);
                        CurrentWeatherImage.Source = imageBitmap;
                    }
                }
                else if (currentCity.precipiation == "rain")
                {
                    String stringPath = "/Images/Rain.png";
                    Uri imageUri = new Uri(stringPath, UriKind.Relative);
                    BitmapImage imageBitmap2 = new BitmapImage(imageUri);
                    CurrentWeatherImage.Source = imageBitmap2;
                }
                else if (Convert.ToInt64(currentCity.clouds) > 50 && Convert.ToInt64(currentCity.clouds) < 75 && currentCity.precipiation == "rain")
                {
                    String stringPath = "/Images/PartlyCloudy.png";
                    Uri imageUri = new Uri(stringPath, UriKind.Relative);
                    BitmapImage imageBitmap3 = new BitmapImage(imageUri);
                    CurrentWeatherImage.Source = imageBitmap3;
                }
                else
                {
                    String stringPath = "/Images/EmojiSun.png";
                    Uri imageUri = new Uri(stringPath, UriKind.Relative);
                    BitmapImage imageBitmap4 = new BitmapImage(imageUri);
                    CurrentWeatherImage.Source = imageBitmap4;
                }
            }
            else
            {
                MessageBox.Show("Please enter valid City Name for the State selected");
            }

        }
    }
}
