using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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
	/// Interaction logic for SportsTeam.xaml
	/// </summary>
	public partial class SportsTeams : Window
	{
		private Sport present;
		
		//dislaying the sports window
		public SportsTeams()
		{
			InitializeComponent();
			Records.ItemsSource = MainWindow.Sports;
			Records.Items.Refresh();
		}

		//fucntion to provide help information from the window
		private void showhelp(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("This is window shows the list of SportsTeam" +
				 "and options to insert, edit and delete record.Use the menu bar or right click to see the context menu.The customer id must be unique");


		}

		// quiting the information from the window
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

		//inserting the record
		private void Insert(object sender, RoutedEventArgs e)
		{

			int i = 0;

			int j = 0;
			
			


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
			if (sportsTeam.Text == "")
			{
				sportsTeam.Focus();
				MessageBox.Show("Invalid Team Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}
			if (city.Text == "")
			{
				city.Focus();
				MessageBox.Show("Invalid Actor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}

			Sport cust = (Sport)(from customer in MainWindow.Sports
									   where customer.Id == i
									   select customer).FirstOrDefault();
			if (cust != null)
			{
				id.Focus();
				MessageBox.Show("Enter unique id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}


			MainWindow.Sports.Add( new Sport(i, j, sportsTeam.Text, city.Text));
			MessageBox.Show("Sports Tream record inserted", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
			Records.ItemsSource = MainWindow.Sports;
			Records.Items.Refresh();

		}

		
		//updating the record
		private void Update(object sender, RoutedEventArgs e)
		{
			int i = 0;

			int j = 0;
			

			if (present!= null)
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
				if (sportsTeam.Text == "")
				{
					sportsTeam.Focus();
					MessageBox.Show("Invalid Team Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

					return;
				}
				if (city.Text == "")
				{
					city.Focus();
					MessageBox.Show("Invalid Actor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

					return;
				}

				present.Id = i;
				present.PersonId = j;
				present.Team = sportsTeam.Text;
				present.City = city.Text;

				
				MainWindow.Sports = new List<Sport>(MainWindow.Sports.Where(c => c.Id != present.Id));

				string messageBoxText = "Do you want to update the data?";
				string caption = "Message";
				MessageBoxButton button = MessageBoxButton.OKCancel;
				MessageBoxImage icon = MessageBoxImage.Information;

				MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

				if (result == MessageBoxResult.OK)
				{

					MainWindow.Sports.Add(present);

					MessageBox.Show("Sports record updated", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				else if (result == MessageBoxResult.Cancel)
				{
					
					Records.ItemsSource = MainWindow.Sports;
					Records.Items.Refresh();
				}

			}

		}

		//deleting the record
		private void Delete(object sender, RoutedEventArgs e)
		{
			

			if (present != null)
			{

				MainWindow.Sports = new List<Sport>(MainWindow.Sports.Where(c => c.Id != present.Id));

				string messageBoxText = "Do you want to delete the data?";
				string caption = "Message";
				MessageBoxButton button = MessageBoxButton.OKCancel;
				MessageBoxImage icon = MessageBoxImage.Information;

				MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

				if (result == MessageBoxResult.OK)
				{
					present = null;
					MessageBox.Show("Sports record deleted", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				else if(result == MessageBoxResult.Cancel)
			   {
					
					Records.ItemsSource = MainWindow.Sports;
					Records.Items.Refresh();
				}
			}

			else
			{
				MessageBox.Show("Please select record first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;

			}


		}
		//diplaying the record in the list box
		private void Records_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			int recordId = Records.SelectedIndex;
			if (recordId >= 0 && recordId < Records.Items.Count)
			{
				present= MainWindow.Sports[recordId];
				id.Text = present.Id.ToString();
				personId.Text = present.PersonId.ToString();
				sportsTeam.Text = present.Team;
				city.Text = present.City;
				
			}
		}
	}
}
