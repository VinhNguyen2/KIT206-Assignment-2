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

namespace RAP.View
{
    /// <summary>
    /// Interaction logic for ResearcherDetailsView.xaml
    /// </summary>
    public partial class ResearcherDetailsView : UserControl
    {
        public ResearcherDetailsView()
        {
            InitializeComponent();
        }

        private void ShowNamesButton_Clicked(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).UpdateOtherDetailsView(DetailsView.Supervisions);
        }

        private void CumulativeCountButton_Clicked(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).UpdateOtherDetailsView(DetailsView.CumulativeCount);
        }
    }
}
