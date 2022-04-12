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
        Theme CurrentTheme;
        City currentCity;
        API_Container container;


        public MainWindow()
        {
            InitializeComponent();
            CurrentTheme = new CartoonTheme();
        }

        private void GetCityInfo_Click(object sender, RoutedEventArgs e)
        {
            container = new API_Container();
            currentCity = container.call_api(CityText.Text, StateCode.Text);
            if (currentCity.temperature != null)
            {
                CurrentTemp.Text = currentCity.temperature.Item1 + "°";
                CurrentCityName.Text = currentCity.city.Item2;
                Humidity.Text = currentCity.humidity + "%";
                Sunrise.Text = currentCity.sunriseSunset.Item1 + " AM";
                Sunset.Text = currentCity.sunriseSunset.Item2 + " PM";
                Visibility.Text = currentCity.visibility + "+ Meters";
                FeelTemp.Text = currentCity.feels_like;
                Pressure.Text = currentCity.pressure + "hPa";
            }
            else
            {
                MessageBox.Show("Please enter valid City Name for the State selected");
            }

        }

        private void ModeChanger_Click(object sender, RoutedEventArgs e)
        {
            if(ModeSelector.Text == "Cartoon Mode")
            {
                CurrentTheme = new CartoonTheme();
            }
            else if(ModeSelector.Text == "Emoji Mode")
            {

            }
            else
            {
                MessageBox.Show("Please select a mode: ");
            }
        }
    }
}
