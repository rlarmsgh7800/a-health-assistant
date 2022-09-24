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


using OpenCvSharp;
//using OpenCvSharp.WpfExtensions;
using OpenCvSharp.Extensions;
using System.Threading;
using Size = System.Windows.Size;
using System.Drawing;
using System.ComponentModel;



namespace Wpf_Cam
{
	/// <summary>
	/// MainWindow.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class MainWindow : System.Windows.Window
	{
        VideoCapture cap;
        WriteableBitmap wb;
		int frameWidth = 2560;
		int frameHeight = 1080;
        bool loop = false;

		public MainWindow()
		{
			InitializeComponent();
			frameWidth = (int)SystemParameters.PrimaryScreenWidth;    // 시스템 파라미터에 ( 화면 값을 가져옴)
			frameHeight = (int)SystemParameters.PrimaryScreenHeight;

			Application.Current.MainWindow.Height = frameHeight;
			Application.Current.MainWindow.Width = frameWidth;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			if (InitWebCamera())
			{
			}
			else
			{
			}
		}

		private bool InitWebCamera()
		{
			try
			{
				cap = VideoCapture.FromCamera(CaptureDevice.Any, 0);
				cap.FrameWidth = 1024;
				cap.FrameHeight = 576;
				cap.Open(0);
				wb = new WriteableBitmap(cap.FrameWidth, cap.FrameHeight, 50, 50, PixelFormats.Bgr24, null);
				image.Source = wb;

				return true;
			}
			catch
			{
				return false;
			}
		}
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			loop = false;
			if (cap.IsOpened())
			{
				cap.Dispose();
			}
		}

		private void button_Click_1(object sender, RoutedEventArgs e)
		{
			Mat frame = new Mat();
			loop = true;
			while (loop)
			{
				if (cap.Read(frame))
				{
					WriteableBitmapConverter.ToWriteableBitmap(frame, wb);
					image.Source = wb;
				}

				int c = Cv2.WaitKey(10);
				if (c != -1)
					break;

			}

		}
	}
}
