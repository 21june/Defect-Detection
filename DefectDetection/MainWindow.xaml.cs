using Microsoft.Win32;
using System.Text;
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

namespace DefectDetection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
	{
		Mat inRef, inTarget, outResult;
		public MainWindow()
        {
            InitializeComponent();
			InitWidget();
		}

		/*
		 * Initialize
		 */
		private void InitWidget()
		{
			inRef = Mat.Zeros(640, 480, MatType.CV_8UC1);
			inTarget = Mat.Zeros(640, 480, MatType.CV_8UC1);
			outResult = Mat.Zeros(640, 480, MatType.CV_8UC1);
			img_ref.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(inRef);
			img_target.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(inTarget);
			img_result.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(outResult);
		}


		/*
		 * Widget Event
		 */
		private void Btn_Click(object sender, RoutedEventArgs e)
		{
			// set reference image
			if (sender.Equals(btn_ref))
			{
				string path = PickImageFile();
				if (path != null)
				{
					tbox_ref.Text = path;
					inRef = Cv2.ImRead(tbox_ref.Text, ImreadModes.Grayscale);
					img_ref.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(inRef);
				}
			}
			// set target image
			else if (sender.Equals(btn_target))
			{
				string path = PickImageFile();
				if (path != null)
				{
					tbox_target.Text = path;
					inTarget = Cv2.ImRead(tbox_target.Text, ImreadModes.Grayscale);
					img_target.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(inTarget);
				}
			}
			// start inspection
			else if (sender.Equals(btn_start))
			{

			}
		}

		// search button click... >> image file select
		private string PickImageFile()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "PNG files (*.png)|*.png|BMP files (*.bmp)|*.bmp|JPG files (*.jpg)|*.jpg|JPEG files (*.jpeg)|*.jpeg|All files (*.*)|*.*";
			if (openFileDialog.ShowDialog() == true)
			{
				return openFileDialog.FileName;
			}
			return null;
		}

		private void Algorithm()
		{
			if (radio_outlier.IsChecked == true) // Outlier
			{
				// 1. compute "histcalc" at the images (ref, target)
				// 2. then compare histogram.
				// if the results are lower than the threshold, proceed to the next step. 
				// 3. if there is a blob among the outlier pixels, these are set to 255.
			}
			else if (radio_absdiff.IsChecked == true) // Absdiff
			{
				// 1. compute a appropriate preprocess at the images (ex: blur, threshold, filter, morphology ...)
				// 2. then run "absdiff".
				// 3. find blob and display the results.
			}
		}
	}
}