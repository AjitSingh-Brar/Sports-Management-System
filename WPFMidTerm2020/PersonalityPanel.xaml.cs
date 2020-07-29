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
	/// Interaction logic for PersonalityPanel.xaml
	/// </summary>
	public partial class PersonalityPanel : Window
	{
		private Personality present;

		//displaying the window
		public PersonalityPanel()
		{
			InitializeComponent();
			Records.ItemsSource = MainWindow.Personalitys;
			Records.Items.Refresh();
		}

		//showhelp method display help information
		private void showhelp(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("This is main menu of the application." +
				"You must use the buttons below to navigate to the categories");
		}


		//quiting record
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
			int k = 0;


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
			if (shoeSize.Text == "")
			{
				shoeSize.Focus();
				MessageBox.Show("Invalid ShoeSize", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}
			if (!(int.TryParse(shoeSize.Text, out k)))
			{
				shoeSize.Focus();
				MessageBox.Show("Invalid Shoe Size", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			if (k < 0)
			{
				shoeSize.Focus();
				MessageBox.Show("Invalid Shoe Size", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			if (favouriteActor.Text == "")
			{
				favouriteMovie.Focus();
				MessageBox.Show("Invalid Movie", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}
			if (favouriteActor.Text == "")
			{
				favouriteActor.Focus();
				MessageBox.Show("Invalid Actor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}

			Personality cust = (Personality)(from customer in MainWindow.Personalitys 
											 where customer.Id == i
									   select customer).FirstOrDefault();
			if (cust != null)
			{
				id.Focus();
				MessageBox.Show("Enter unique id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}
			MainWindow.Personalitys.Add(new Personality(i,j,k, favouriteMovie.Text, favouriteActor.Text));
			MessageBox.Show("Personality record inserted", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
			Records.ItemsSource = MainWindow.Personalitys;
			Records.Items.Refresh();

		}

		// updating record
		private void Update(object sender, RoutedEventArgs e)
		{
			int i = 0;

			int j = 0;
			int k = 0;
			if(present != null)
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
				if (shoeSize.Text == "")
				{
					shoeSize.Focus();
					MessageBox.Show("Invalid ShoeSize", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

					return;
				}
				if (!(int.TryParse(shoeSize.Text, out k)))
				{
					shoeSize.Focus();
					MessageBox.Show("Invalid Shoe Size", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}
				if (k < 0)
				{
					shoeSize.Focus();
					MessageBox.Show("Invalid Shoe Size", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}

				if (favouriteActor.Text == "")
				{
					favouriteMovie.Focus();
					MessageBox.Show("Invalid Movie", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

					return;
				}
				if (favouriteActor.Text == "")
				{
					favouriteActor.Focus();
					MessageBox.Show("Invalid Actor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

					return;
				}

				present.Id = i;
				present.PersonId = j;
				present.ShoeSize = k;
				present.Movie = favouriteMovie.Text;
				present.Actor = favouriteActor.Text;

				MainWindow.Personalitys = new List<Personality>(MainWindow.Personalitys.Where(c => c.Id != present.Id));

				string messageBoxText = "Do you want to update the data?";
				string caption = "Message";
				MessageBoxButton button = MessageBoxButton.OKCancel;
				MessageBoxImage icon = MessageBoxImage.Information;

				MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

				if (result == MessageBoxResult.OK)
				{

					MainWindow.Personalitys.Add(present);
					MessageBox.Show("Personality updated", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
				}

				else if (result == MessageBoxResult.Cancel)
				{
					Records.ItemsSource = MainWindow.Personalitys;
					Records.Items.Refresh();
				}

			}


		}

		//deleting method
		private void Delete(object sender, RoutedEventArgs e)
		{

			if (present!= null)
			{

				MainWindow.Personalitys = new List<Personality>(MainWindow.Personalitys.Where(c => c.Id != present.Id));
				string messageBoxText = "Do you want to delete the data?";
				string caption = "Message";
				MessageBoxButton button = MessageBoxButton.OKCancel;
				MessageBoxImage icon = MessageBoxImage.Information;

				MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

				if (result == MessageBoxResult.OK)
				{


					present = null;
					MessageBox.Show("Personality record deleted", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
				}

				Records.ItemsSource = MainWindow.Personalitys;
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
				present= MainWindow.Personalitys[recordId];
				id.Text = present.Id.ToString();
				personId.Text = present.PersonId.ToString();
				shoeSize.Text = present.ShoeSize.ToString();
				favouriteMovie.Text = present.Movie;
				favouriteActor.Text = present.Actor;


			}
		}
	}
}
