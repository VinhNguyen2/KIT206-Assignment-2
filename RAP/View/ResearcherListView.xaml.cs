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
    /// Interaction logic for ResearcherListView.xaml
    /// </summary>
    public partial class ResearcherListView : UserControl
    {
        public ResearcherListView()
        {
            ResearcherController.LoadResearcher();
            InitializeComponent();
            ResearcherFilter.SelectedIndex = 0;
        }

        private void ResearcherFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ResearcherList.ItemsSource = ResearcherController.FilterBy(EmploymentLevel.AllLevel);

        }

        private void ResearcherList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResearcherController.LoadResearcherDetails(ResearcherList.SelectedItem);
            ((MainWindow)Application.Current.MainWindow).UpdateResearcherDetailsView();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
                ResearcherList.ItemsSource = ResearcherController.FilterByName(SearchBox.Text);
            
        }

        
    }
}
