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
using Gym_Main;

namespace Gym_Main
{
	/// <summary>
	/// TrainingSelect.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class TrainingSelect : Page
	{
        public static string g_SBackgroundPath = "";
        public static int g_ISeletedItem = 0;

        public TrainingSelect()
		{
			InitializeComponent();
		}

        private void ExerciseSelect00(object sender, MouseButtonEventArgs e)
        {
            g_ISeletedItem = 0;

            g_SBackgroundPath = "/source/SourceSelect/Deadlift.jpg";

            ExerciseSelected();
        }

        private void ExerciseSelect01(object sender, MouseButtonEventArgs e)
        {

            g_ISeletedItem = 1;

            g_SBackgroundPath = "/source/SourceSelect/Squat.jpg";

            ExerciseSelected();
        }

        private void ExerciseSelect02(object sender, MouseButtonEventArgs e)
        {
            g_ISeletedItem = 2;

            g_SBackgroundPath = "/source/SourceSelect/Push_up.jpg";

            ExerciseSelected();
        }

        private void ExerciseSelect03(object sender, MouseButtonEventArgs e)
        {

            g_ISeletedItem = 3;

            g_SBackgroundPath = "/source/SourceSelect/Dumbbell_arm.jpg";

            ExerciseSelected();
        }

        private void ExerciseSelect04(object sender, MouseButtonEventArgs e)
        {

            g_ISeletedItem = 4;

            g_SBackgroundPath = "/source/SourceSelect/Yoga.jpg";

            ExerciseSelected();
        }

        private void ExerciseSelected()
        {

            ImageSourceConverter imgConv = new ImageSourceConverter();
            string path = "pack://application:,,"+ g_SBackgroundPath;
            ImageSource imgSrc = (ImageSource)imgConv.ConvertFromString(path);
            selectback_image.Source = imgSrc;


        }

        private void ExerciseSelected03(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
