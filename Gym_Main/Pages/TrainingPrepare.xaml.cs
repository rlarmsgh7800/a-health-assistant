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

namespace Gym_Main.Pages
{
    /// <summary>
    /// TrainingPrepare.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 

    public partial class TrainingPrepare : Page
    {
        public static string g_STimes = "12";
        public static string g_SSet = "3";


        public TrainingPrepare()
        {
            InitializeComponent();

            txtTimes.Text = g_STimes;
            txtSet.Text = g_SSet;
        }

        private void downTimesTXT(object sender, MouseButtonEventArgs e)
        {
            txtTimes.Text = (int.Parse(txtTimes.Text)-1).ToString();

        }

        private void upTimesTXT(object sender, MouseButtonEventArgs e)
        {
            txtTimes.Text = (int.Parse(txtTimes.Text) + 1).ToString();
        
        }

        private void downSetTXT(object sender, MouseButtonEventArgs e)
        {
            txtSet.Text = (int.Parse(txtSet.Text) - 1).ToString();

        }

        private void upSetTXT(object sender, MouseButtonEventArgs e)
        {
            txtSet.Text = (int.Parse(txtSet.Text) + 1).ToString();

        }

        private void resetTS(object sender, RoutedEventArgs e)
        {
            txtTimes.Text = g_STimes;
            txtSet.Text = g_SSet;
        }
    }
}
