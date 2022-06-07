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

namespace RAP.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    internal enum DetailsView { Publication, Supervisions, CumulativeCount};

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RDV.IsEnabled = false;
        }
     
        internal void UpdateResearcherDetailsView()
        {
            if (ResearcherController.CurrentResearcher != null)
            {
                // Make the details reflect newly selected researcher
                RDV.DataContext = ResearcherController.CurrentResearcher;
                RDV.IsEnabled = true;
                RDV.ShowNamesButton.IsEnabled = (RDV.SupervisionsCount.Text != "" && RDV.SupervisionsCount.Text != "0");

              
                RDV.PLV.PublicationsList.ItemsSource = PublicationsController.LoadPublicationsFor(ResearcherController.CurrentResearcher);
                RDV.PLV.PublicationsYearBox1.ItemsSource = PublicationsController.PublicationYears;
                RDV.PLV.PublicationsYearBox2.ItemsSource = PublicationsController.PublicationYears;

                // Sets to default values
                RDV.PLV.PublicationsYearBox1.SelectedIndex = 0;
                RDV.PLV.PublicationsYearBox2.SelectedIndex = 0;

                // Clear the for next time
                ODV.Content = null;
            }
        }

        
        internal void UpdateOtherDetailsView(DetailsView view)
        {
            //That allow to use the same content control to load different views
            switch (view)
            {

                case DetailsView.Publication:

                    if (!(ODV is PublicationDetailView))
                    {
                        ODV.Content = new PublicationDetailView();
                    }

                    ODV.DataContext = PublicationsController.CurrentPublication;
                    break;

                case DetailsView.Supervisions:
                    ODV.Content = new SupervisionsView();
                    break;

                case DetailsView.CumulativeCount:
                    ODV.Content = new CumulativePublicationsView();
                    break;
            }

        }
    }
}
