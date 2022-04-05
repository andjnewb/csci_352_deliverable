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
        public MainWindow()
        {
            InitializeComponent();
            API_Container aPI_Container = new API_Container();
            aPI_Container.call_api();

            XmlNodeList elemList = aPI_Container.doc.GetElementsByTagName("city");
            XmlAttributeCollection xmlAttributeList = elemList.Item(0).Attributes;
            test_text.Text = xmlAttributeList.Count.ToString();
        }
        private void test_text_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
