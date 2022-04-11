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
            container = new API_Container();
        }

        private void GetCityInfo_Click(object sender, RoutedEventArgs e)
        {
            currentCity = container.call_api(CityText.Text, StateCode.Text);
            CurrentTemp.Text = currentCity.temperature.Item1 + "°";
            CurrentCityName.Text = currentCity.city.Item2;
            Humidity.Text = currentCity.humidity + "%";
            Sunrise.Text = currentCity.sunriseSunset.Item1 + " AM";
            Sunset.Text = currentCity.sunriseSunset.Item2 + " PM";
            if (Convert.ToInt32(currentCity.visibility) > 10000)
            {
                Visibility.Text = currentCity.visibility + "+ Meters";
            }
            else
            {
                Visibility.Text = currentCity.visibility + " Meters";
            }
            FeelTemp.Text = currentCity.temperature.Item1;
            Pressure.Text = currentCity.pressure + "hPa";

        }

        private void ModeChanger_Click(object sender, RoutedEventArgs e)
        {
            if(ModeSelector.Text == "Cartoon Mode")
            {
                CurrentTheme = new CartoonTheme();
            }else if(ModeSelector.Text == "Emoji Mode")
            {

            }
            else
            {
                MessageBox.Show("Please select a mode");
            }
        }
    }
}
