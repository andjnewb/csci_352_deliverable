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
using System.Xml;

namespace Regular_Weather_Template
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        API_Container container;
        public MainWindow()
        {
            InitializeComponent();
            container = new API_Container();
            //aPI_Container.call_api();

           // XmlNodeList elemList = aPI_Container.doc.GetElementsByTagName("city");
           // XmlAttributeCollection xmlAttributeList = elemList.Item(0).Attributes;
            //test_text.Text = xmlAttributeList.Count.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TemperatureTextBlock.Text = container.call_api(CityNameTextBox.Text, "US-TN");

            if (StateSelectionBox.Text != null && CityNameTextBox.Text.Length != 0)
            {
                City city = container.call_api(CityNameTextBox.Text, StateSelectionBox.Text);
                TemperatureTextBlock.Text = "Temp(fahrenheit):" + city.temperature.Item1;
                CoordsTextBlock.Text = "Coordinates(longitude/latitude):" + city.coords.Item1 + ", " + city.coords.Item2;
                SunriseSunset_TextBlock.Text = "Sunrise/Sunset:" + city.sunriseSunset.Item1 + "," + city.sunriseSunset.Item2;
                Humidity_TextBlock.Text = "Humidity(%): " + city.humidity;
                PressureTextBlock.Text = "Pressure(hPa):" + city.pressure;
                WindSpeedTextBlock.Text = "Windspeed(m/s):" + city.windSpeed;
                CloudTextBlock.Text = "Clouds:" + city.clouds;
                VisibilityTextBlock.Text = "Visibility(meters):" + city.visibility;
                PrecipitationTextBlock.Text = "Precipitation:" + city.precipiation;
                LastUpdateTextBlock.Text = "Last Updated:" + city.lastUpdate;

            }
            

            
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
