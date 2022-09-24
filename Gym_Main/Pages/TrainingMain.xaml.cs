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
	/// TrainingMain.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class TrainingMain : Page
	{
		public TrainingMain()
		{
			InitializeComponent();
		}

		private void tbExit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			System.Windows.Window.GetWindow(this).Close();
		}

		private void tbMin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
		}

		private void tbMax_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
		}
	}
}
