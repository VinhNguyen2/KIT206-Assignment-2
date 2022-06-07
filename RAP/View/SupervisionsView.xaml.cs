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
    /// Interaction logic for Supervisions.xaml
    /// </summary>
    public partial class SupervisionsView : UserControl
    {
        public SupervisionsView()
        {
            InitializeComponent();
            DataContext = ResearcherController.CurrentResearcher;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
