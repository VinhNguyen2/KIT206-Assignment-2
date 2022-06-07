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
using RAP.Controller;
using RAP.Entity;

namespace RAP.View
{
    /// <summary>
    /// Interaction logic for PublicationListView.xaml
    /// </summary>
    public partial class PublicationListView : UserControl
    {
        public PublicationListView()
        {
            InitializeComponent();
        }

        private void FilterPublicationsButton_Clicked(object sender, RoutedEventArgs e)
        {
            int selected1;
            int selected2;

            if (ResearcherController.CurrentResearcher != null)
            {
                // lowerbound of first box becomes the beginning of time itself if first box blank, 
                if (!int.TryParse(PublicationsYearBox1.Text, out selected1))
                {
                    selected1 = DateTime.MinValue.Year;
                }

                // upperbound of second box becomes the current year if second box is blank
                if (!int.TryParse(PublicationsYearBox2.Text, out selected2))
                {
                    selected2 = DateTime.Today.Year;
                }

                PublicationsList.ItemsSource = PublicationsController.FilterBy(selected1, selected2);
            }


        }

        private void PublicationsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PublicationsYearBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PublicationsYearBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

         private void PublicationsList_YearHeaderClicked(object sender, RoutedEventArgs e)
         {
         
         }
    }
}
