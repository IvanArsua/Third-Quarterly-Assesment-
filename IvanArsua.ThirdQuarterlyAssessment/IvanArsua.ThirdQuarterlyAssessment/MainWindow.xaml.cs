using Microsoft.Maps.MapControl.WPF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace IvanArsua.ThirdQuarterlyAssessment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Map.Center = new Microsoft.Maps.MapControl.WPF.Location(37.806029, -122.407007);
            List<string> municipalities = new List<string>()
            {
                "Dinalupihan",
                "Davao City",
                "Angeles City",
                "Brooke's Point",
                "Olongapo City"

            };
            cbo_Municipalities.ItemsSource = municipalities;
            
            
        }
        private void Map_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;

            Point mousePosition = e.GetPosition(this);

            Location pinLocation = Map.ViewportPointToLocation(mousePosition);

            Pushpin pin = new Pushpin();
            pin.Location = pinLocation;
            pin.MouseDown += Map_PinOnclickEvent;
            Map.Children.Add(pin);
        }
        private void Map_PinOnclickEvent(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            e.Handled = true;
            Pushpin pin = sender as Pushpin;
            MessageBox.Show("Lat:" + pin.Location.Latitude + " Long:" + pin.Location.Longitude);
        }

        private void cbo_Municipalities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          // Problem to Fix: When everytime the program starst Dinalupihan is already Selected in the combo box 
          if (cbo_Municipalities.SelectedIndex == 0)
          {
             Map.Center = new Microsoft.Maps.MapControl.WPF.Location(14.8781, 120.4546);
             Map.ZoomLevel = 13;
          }
          if (cbo_Municipalities.SelectedIndex == 1)
          {
            Map.Center = new Microsoft.Maps.MapControl.WPF.Location(7.130099278801634, 125.42804470063739);
            Map.ZoomLevel = 11;
          }
          if (cbo_Municipalities.SelectedIndex == 2)
          {
             Map.Center = new Microsoft.Maps.MapControl.WPF.Location(15.160460231120194, 120.60047399746576);
             Map.ZoomLevel = 12;
          }
          if (cbo_Municipalities.SelectedIndex == 3)
          {
             Map.Center = new Microsoft.Maps.MapControl.WPF.Location(8.827339952813013, 117.83041789939554);
             Map.ZoomLevel = 11;
          }
          if (cbo_Municipalities.SelectedIndex == 4)
          {
            Map.Center = new Microsoft.Maps.MapControl.WPF.Location(14.834821290849918, 120.2820978394843);
            Map.ZoomLevel = 12;
          }

        }
    }
}
