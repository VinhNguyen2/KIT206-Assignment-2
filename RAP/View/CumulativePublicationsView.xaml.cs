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
using RAP.Database;
namespace RAP.View
{
    /// <summary>
    /// Interaction logic for CumulativePublicationsView.xaml
    /// </summary>
    public partial class CumulativePublicationsView : UserControl
    {
        public CumulativePublicationsView()
        {
            InitializeComponent();
           // CumulativeCountList.ItemsSource = ERDAdapter.fetchPublicationCounts(from: Date, to: Date);
        }
    }
}
