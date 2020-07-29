using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFMidTerm2020
{
	/// <summary>
	/// Interaction logic for EducationPanel.xaml
	/// </summary>
	public partial class EducationPanel : Window
	{
		private Education present;  
		
		//displaying window
		public EducationPanel()
		{
			InitializeComponent();
			Records.ItemsSource = MainWindow.Educations;
			Records.Items.Refresh();

		}

		//help window display
		private void showhelp(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("This is main menu of the application." +
				"You must use the buttons below to navigate to the categories");
		}

		//Quit method
		private void Quit(object sender, RoutedEventArgs e)
		{
			string messageBoxText = "Do you want to quit?";
			string caption = "Message";
			MessageBoxButton button = MessageBoxButton.OKCancel;
			MessageBoxImage icon = MessageBoxImage.Information;

			MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

			if (result == MessageBoxResult.OK)
			{
				Application.Current.Shutdown();
			}
		}


		//inserting record
		private void Insert(object sender, RoutedEventArgs e)
		{
			int i = 0;

			int j = 0;
			double k = 0;



			if (id.Text == "")
			{
				id.Focus();
				MessageBox.Show("Invalid id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			if (!(int.TryParse(id.Text, out i)))
			{
				id.Focus();
				MessageBox.Show("Invalid id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			if (i < 0)
			{
				id.Focus();
				MessageBox.Show("Invalid id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			if (personId.Text == "")
			{
				personId.Focus();
				MessageBox.Show("Invalid Person Id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}
			if (!(int.TryParse(personId.Text, out j)))
			{
				personId.Focus();
				MessageBox.Show("Invalid Person id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			if (j < 0)
			{
				personId.Focus();
				MessageBox.Show("Invalid Person Id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			if ( courseName.Text == "")
			{
				courseName.Focus();
				MessageBox.Show("Invalid Course Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}
			if (courseGrade.Text == "")
			{
				courseGrade.Focus();
				MessageBox.Show("Invalid Course Grade", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}
			if (!(double.TryParse(courseGrade.Text, out k)))
			{
				courseGrade.Focus();
				MessageBox.Show("Invalid Course Grade", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			if (k < 0)
			{
				courseGrade.Focus();
				MessageBox.Show("Invalid Couse Grade", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			if (comments.Text == "")
			{
				comments.Focus();
				MessageBox.Show("Invalid Comments", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}
			Education cust = (Education)(from customer in MainWindow.Educations
										 where customer.Id == i
										 select customer).FirstOrDefault();
			if (cust != null)
			{
				error.Content = "Customer id must be unique!";
				return;
			}



			MainWindow.Educations.Add(new Education(i, j, courseName.Text, Convert.ToDouble(courseGrade.Text),comments.Text));
			MessageBox.Show("Education record inserted", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
			Records.ItemsSource = MainWindow.Educations;
			Records.Items.Refresh();

		}

		//Updating record
		private void Update(object sender, RoutedEventArgs e)
		{
			int i = 0;

			int j = 0;
			double k = 0;

			if (present != null)
			{
				if (id.Text == "")
				{
					id.Focus();
					MessageBox.Show("Invalid id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}
				if (!(int.TryParse(id.Text, out i)))
				{
					

					id.Focus();
					MessageBox.Show("Invalid id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}
				if (i < 0)
				{
					id.Focus();
					MessageBox.Show("Invalid id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}
				if (personId.Text == "")
				{
					personId.Focus();
					MessageBox.Show("Invalid Person Id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

					return;
				}
				if (!(int.TryParse(personId.Text, out j)))
				{
					personId.Focus();
					MessageBox.Show("Invalid Person id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}
				if (j < 0)
				{
					personId.Focus();
					MessageBox.Show("Invalid Person Id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}
				if (courseName.Text == "")
				{
					courseName.Focus();
					MessageBox.Show("Invalid Course Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

					return;
				}
				if (courseGrade.Text == "")
				{
					courseGrade.Focus();
					MessageBox.Show("Invalid Course Grade", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

					return;
				}
				if (!(double.TryParse(courseGrade.Text, out k)))
				{
					courseGrade.Focus();
					MessageBox.Show("Invalid Course Grade", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}
				if (k < 0)
				{
					courseGrade.Focus();
					MessageBox.Show("Invalid Couse Grade", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}

				if (comments.Text == "")
				{
					comments.Focus();
					MessageBox.Show("Invalid Comments", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

					return;
				}

				present.Id = i;
				present.PersonId = j;
				present.CourseName = courseName.Text;
				present.Grade = k;
				present.Comments = comments.Text;

				MainWindow.Educations = new List<Education>(MainWindow.Educations.Where(c => c.Id != present.Id));

				string messageBoxText = "Do you want to update the data?";
				string caption = "Message";
				MessageBoxButton button = MessageBoxButton.OKCancel;
				MessageBoxImage icon = MessageBoxImage.Information;

				MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

				if (result == MessageBoxResult.OK)
				{
					MainWindow.Educations.Add(present);
					MessageBox.Show("Education updated", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
				}

				else if (result == MessageBoxResult.Cancel)
				{
					Records.ItemsSource = MainWindow.Educations;
					Records.Items.Refresh();
				}

			}
			else
			{
				MessageBox.Show("Please select record", "Error", MessageBoxButton.OK, MessageBoxImage.Error);


			}


		}

		//deleting recording
		private void Delete(object sender, RoutedEventArgs e)
		{
			if (present != null)
			{
				
				MainWindow.Educations = new List<Education>(MainWindow.Educations.Where(c => c.Id != present.Id));

				string messageBoxText = "Do you want to delete the data?";
				string caption = "Message";
				MessageBoxButton button = MessageBoxButton.OKCancel;
				MessageBoxImage icon = MessageBoxImage.Information;

				MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

				if (result == MessageBoxResult.OK)
				{
					present = null;
					MessageBox.Show("Education record deleted", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				Records.ItemsSource = MainWindow.Educations;
				Records.Items.Refresh();
			}

			else
			{
				MessageBox.Show("Please select record first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;

			}

		}

		//displaying in the listbox
		private void Records_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

			int recordId = Records.SelectedIndex;
			if (recordId >= 0 && recordId < Records.Items.Count)
			{
				present = MainWindow.Educations[recordId];
				id.Text = present.Id.ToString();
				personId.Text = present.PersonId.ToString();
				courseName.Text = present.CourseName;
				courseGrade.Text = present.Grade.ToString();
				comments.Text = present.Comments;


			}
		}
	}
}
