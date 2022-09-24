using Gym_Main.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
	/// MainWindow.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class MainWindow : System.Windows.Window
	{
		int iFlag_Page = 0;

		public MainWindow()
		{
			InitializeComponent();
			NextBt.Visibility = Visibility.Hidden;
			btPrevious.Visibility = Visibility.Hidden;

		}

		private void btnHome_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			MainGrid.Content = new TrainingMain();
			btnPage.Text = "🏠";
			NextBt.Visibility = Visibility.Hidden;
			btPrevious.Visibility = Visibility.Hidden;
		}
		private void btnSELECT_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			MainGrid.Content = new TrainingSelect();
			btnPage.Text = "🏋";
			NextBt.Visibility = Visibility.Visible;
			btPrevious.Visibility = Visibility.Hidden;
			iFlag_Page = 0;
		}

		private void btnINFO_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			MainGrid.Content = new TrainingInfo();
			btnPage.Text = "📽";
			NextBt.Visibility = Visibility.Hidden;
			btPrevious.Visibility = Visibility.Hidden;
		}

		private void btnTRAINING_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			MainGrid.Content = new TrainingReport();
			btnPage.Text = "🏆";
			NextBt.Visibility = Visibility.Hidden;
			btPrevious.Visibility = Visibility.Hidden;
		}
		private void btnSetting_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			MainGrid.Content = new TrainingSetting();
			btnPage.Text = "⚙️";
			NextBt.Visibility = Visibility.Hidden;
			btPrevious.Visibility = Visibility.Hidden;
		}

		#region Mainbutton Text Bold Control

		private void textbold1(object sender, MouseEventArgs e)
		{
			btnHOME.FontWeight = FontWeights.UltraBold;

		}

		private void textbold2(object sender, MouseEventArgs e)
		{
			btnSELECT.FontWeight = FontWeights.Bold;
		}

		private void textbold3(object sender, MouseEventArgs e)
		{
			btnINFO.FontWeight = FontWeights.Bold;
		}

		private void textbold4(object sender, MouseEventArgs e)
		{
			btnTRAINING.FontWeight = FontWeights.Bold;
		}

		private void textbold5(object sender, MouseEventArgs e)
		{
			btnSetting.FontWeight = FontWeights.Bold;
		}

		private void textnormal1(object sender, MouseEventArgs e)
		{
			btnHOME.FontWeight = FontWeights.Normal;
		}

		private void textnormal2(object sender, MouseEventArgs e)
		{
			btnSELECT.FontWeight = FontWeights.Normal;
		}

		private void textnormal3(object sender, MouseEventArgs e)
		{
			btnINFO.FontWeight = FontWeights.Normal;
		}

		private void textnormal4(object sender, MouseEventArgs e)
		{
			btnTRAINING.FontWeight = FontWeights.Normal;
		}

		private void textnormal5(object sender, MouseEventArgs e)
		{
			btnSetting.FontWeight = FontWeights.Normal;
		}
		#endregion

		private void toNextPage(object sender, RoutedEventArgs e)
		{
			if (iFlag_Page == 0)
			{
				iFlag_Page = 1;
				MainGrid.Content = new TrainingPrepare();
			}
			else if (iFlag_Page == 1)
			{
				iFlag_Page = 2;
				;
				MainGrid.Content = new TrainingSection();
			}
			else MainGrid.Content = new TrainingMain();

			prevBtshow();
			nextBtshow();
		}

		private void toPreviousPage(object sender, MouseButtonEventArgs e)
		{
			if (iFlag_Page == 1)
			{
				iFlag_Page = 0;
				MainGrid.Content = new TrainingSelect();
			}

			else if (iFlag_Page == 2)
			{
				iFlag_Page = 1;
				MainGrid.Content = new TrainingPrepare();
			}

			else MainGrid.Content = new TrainingMain();

			prevBtshow();
			nextBtshow();
		}

		private void prevBtshow()
		{
			if (iFlag_Page == 0)
				btPrevious.Visibility = Visibility.Hidden;
			else if (iFlag_Page == 1)
				btPrevious.Visibility = Visibility.Visible;
			else if (iFlag_Page == 2)
				btPrevious.Visibility = Visibility.Visible;
		}

		private void nextBtshow()
		{
			if (iFlag_Page == 0)
				NextBt.Visibility = Visibility.Visible;
			else if (iFlag_Page == 1)
				NextBt.Visibility = Visibility.Visible;
			else if (iFlag_Page == 2)
				NextBt.Visibility = Visibility.Hidden;
		}

		private void handMouse(object sender, RoutedEventArgs e)
		{
			try
			{
				Process.Start(@"AivirualMouseHolistic.py");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
