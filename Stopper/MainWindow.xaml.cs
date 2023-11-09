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
using System.Windows.Threading;

namespace Stopper
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// Stopwatch osztályt használva a megoldás
	///					|
	///					|
	///					V
	/*public partial class MainWindow : Window
	{
		DispatcherTimer timer = new DispatcherTimer();
		Stopwatch stopwatch = new Stopwatch();
		string currentTime = string.Empty;

		public MainWindow()
		{
			InitializeComponent();
			timer.Tick += new EventHandler(dt_Tick);
			timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
			idoLabel.Content = String.Format("{0:00}:{1:00}:{2:00}",0, 0, 0 / 10);
		}

		private void dt_Tick(object? sender, EventArgs e)
		{
			if(stopwatch.IsRunning)
			{
				TimeSpan timeSpan = stopwatch.Elapsed;
				currentTime = String.Format("{0:00}:{1:00}:{2:00}",
				timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
				idoLabel.Content = currentTime;
			}
		}

		private void startBtn_Click(object sender, RoutedEventArgs e)
		{
			if(stopwatch.IsRunning)
			{
				stopwatch.Stop();
				startBtn.Content = "Start";
				resetBtn.Content = "Reset";
			}
			else
			{
				stopwatch.Start();
				timer.Start();
				startBtn.Content = "Stop";
				resetBtn.Content = "Köridő";
			}
			

		}

		private void resetBtn_Click(object sender, RoutedEventArgs e)
		{
			if (stopwatch.IsRunning)
			{
				korIdoListBox.Items.Add(currentTime);
			}
			else
			{
				stopwatch.Reset();
				korIdoListBox.Items.Clear();
				idoLabel.Content = String.Format("{0:00}:{1:00}:{2:00}", 0, 0, 0);
			}
		}
	}*/
	public partial class MainWindow : Window
	{
		DispatcherTimer timer = new DispatcherTimer();
		TimeSpan eltelt = TimeSpan.Zero;
		DateTime inditas = DateTime.Now;
		TimeSpan eddig = TimeSpan.Zero; 
		bool fut = false;
		string currentTime = string.Empty;

		public MainWindow()
		{
			InitializeComponent();
			timer.Tick += new EventHandler(dt_Tick);
			timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
			idoLabel.Content = String.Format("{0:00}:{1:00}:{2:00}", 0, 0, 0 / 10);
		}

		private void dt_Tick(object? sender, EventArgs e)
		{
			eltelt = DateTime.Now - inditas + eddig; 
			if (fut)
			{
				TimeSpan timeSpan = eltelt;
				currentTime = String.Format("{0:00}:{1:00}:{2:00}",
				timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
				idoLabel.Content = currentTime;
			}
		}

		private void startBtn_Click(object sender, RoutedEventArgs e)
		{
			if (fut)
			{
				timer.Stop();
				eddig = eltelt;
				startBtn.Content = "Start";
				resetBtn.Content = "Reset";
				fut = false;
			}
			else
			{
				timer.Start();
				fut = true;
				inditas = DateTime.Now;
				startBtn.Content = "Stop";
				resetBtn.Content = "Köridő";
			}


		}

		private void resetBtn_Click(object sender, RoutedEventArgs e)
		{
			if (fut)
			{
				korIdoListBox.Items.Add(currentTime);
			}
			else
			{
				eltelt = TimeSpan.Zero;
				eddig = TimeSpan.Zero;
				korIdoListBox.Items.Clear();
				idoLabel.Content = String.Format("{0:00}:{1:00}:{2:00}", 0, 0, 0);
			}
		}
	}
}
