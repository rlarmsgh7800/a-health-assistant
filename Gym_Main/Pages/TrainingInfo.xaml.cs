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

namespace Gym_Main
{
	/// <summary>
	/// TrainingInfo.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class TrainingInfo : Page
	{
        
        
		public TrainingInfo()
		{
			InitializeComponent();
 

        }
        private void ExerciseSelect00(object sender, MouseButtonEventArgs e)
        {
            wb.Navigate("https://www.youtube.com/watch?v=ytGaGIn3SjE");
         
        }
        private void ExerciseSelect01(object sender, MouseButtonEventArgs e)
        {

            wb.Navigate("https://www.youtube.com/watch?v=U3HlEF_E9fo");
        }

        private void ExerciseSelect02(object sender, MouseButtonEventArgs e)
        {

            wb.Navigate("https://www.youtube.com/watch?v=IODxDxX7oi4p");
        }

        private void ExerciseSelect03(object sender, MouseButtonEventArgs e)
        {

            wb.Navigate("https://www.youtube.com/watch?v=xCykac8elPw");
        }

        private void ExerciseSelect04(object sender, MouseButtonEventArgs e)
        {

            wb.Navigate("https://www.youtube.com/watch?v=x2IWl3wT8Zc");
        }

    }
}
