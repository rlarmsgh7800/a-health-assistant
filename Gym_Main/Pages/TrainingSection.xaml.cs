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
using System.Net;
using System.Net.Sockets;
using System.Threading;

using OpenCvSharp;
using OpenCvSharp.WpfExtensions;


namespace Gym_Main
{
	/// <summary>
	/// TrainingSection.xaml에 대한 상호 작용 논리
	/// </summary>
	/// 
	public partial class TrainingSection : Page
	{
		VideoCapture cap;
		WriteableBitmap wb;
		bool loop = false;

		public TrainingSection()
		{
			InitializeComponent();

		}

		private void InitCamera()
		{
			try
			{
				cap = VideoCapture.FromCamera(0, VideoCaptureAPIs.ANY);

				cap.Open(0);

				wb = new WriteableBitmap(cap.FrameWidth, cap.FrameHeight, 1, 1, PixelFormats.Bgr24, null);
				selectback_image.Source = wb;
			}
			catch
			{
			}
		}

        private void CamRun_Click(object sender, MouseButtonEventArgs e)
        {
			Mat frame = new Mat();

			try
			{
				cap = VideoCapture.FromCamera(0, VideoCaptureAPIs.ANY);

				cap.Open(0);

				wb = new WriteableBitmap(cap.FrameWidth, cap.FrameHeight, 1, 1, PixelFormats.Bgr24, null);
				selectback_image.Source = wb;
			}
			catch
			{
				
			}

			loop = true;
			while (loop)
			{
				if (cap.Read(frame))
				{
					WriteableBitmapConverter.ToWriteableBitmap(frame, wb);
					selectback_image.Source = wb;
				}

				int c = Cv2.WaitKey(30);
				if (c != -1)
					break;
			}
		}

        private void ExerciseEnd(object sender, RoutedEventArgs e)
        {
			try
            {
				loop = false;
				if (cap.IsOpened())
				{
					cap.Dispose();
				}
			}
            catch
            {

            }
        }
	}
}