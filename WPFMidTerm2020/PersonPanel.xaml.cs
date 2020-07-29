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
	/// Interaction logic for PersonPanel.xaml
	/// </summary>
	public partial class PersonPanel : Window
	{
		private Person present;

		//diplaying the window
		public PersonPanel()
		{
			InitializeComponent();

			Records.ItemsSource = MainWindow.Persons;
			Records.Items.Refresh();
		}

		// showhelp displays the help information
		private void showhelp(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("This is window shows the list of people" +
				 "and options to insert, edit and delete record.Use the menu bar or right click to see the context menu.The customer id must be unique");


		}

		//quiting the application
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
			if (name.Text == "")
			{
				name.Focus();
				MessageBox.Show("Invalid Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}
			if (address.Text == "")
			{
				address.Focus();
				MessageBox.Show("Invalid address", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}
			if (email.Text == "")
			{
				email.Focus();
				MessageBox.Show("Invalid email", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}
			if (age.Text == "")
			{
				age.Focus();
				MessageBox.Show("Invalid Age", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}
			if (!(int.TryParse(age.Text, out j)))
			{
				age.Focus();
				MessageBox.Show("Invalid Age", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}
			if (j < 0)
			{
				age.Focus();
				MessageBox.Show("Invalid Age", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}
			if (birthday.Text == "")
			{
				birthday.Focus();
				MessageBox.Show("Invalid Birthday", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}



			




			Person pres = (Person)(from per in MainWindow.Persons
								   where per.Id == i
								   select per).FirstOrDefault();
			if(pres != null)
			{
				id.Focus();
				MessageBox.Show("Enter unique id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}

			MainWindow.Persons.Add(new Person(i, name.Text, address.Text,email.Text, j,birthday.Text));
			MessageBox.Show("Person record inserted", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

			Records.ItemsSource = MainWindow.Persons;
			Records.Items.Refresh();


		}


		//updating the records
		private void Update(object sender, RoutedEventArgs e)
		{
			int i = 0;
			int j = 0;

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
				if (name.Text == "")
				{
					name.Focus();
					MessageBox.Show("Invalid Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

					return;
				}
				if (address.Text == "")
				{
					address.Focus();
					MessageBox.Show("Invalid address", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

					return;
				}
				if (email.Text == "")
				{
					email.Focus();
					MessageBox.Show("Invalid email", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

					return;
				}
				if (age.Text == "")
				{
					age.Focus();
					MessageBox.Show("Invalid Age", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

					return;
				}
				if (!(int.TryParse(age.Text, out j)))
				{
					age.Focus();
					MessageBox.Show("Invalid Age", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

					return;
				}
				if (j < 0)
				{
					age.Focus();
					MessageBox.Show("Invalid Age", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

					return;
				}
				if (birthday.Text == "")
				{
					birthday.Focus();
					MessageBox.Show("Invalid Birthday", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

					return;
				}

				present.Id = i;
				present.Name = name.Text;
				present.Address = address.Text;
				present.Email = email.Text;
				present.Age = j;
				present.Birthday = birthday.Text;

				MainWindow.Persons = new List<Person>(MainWindow.Persons.Where(c => c.Id != present.Id));
				string messageBoxText = "Do you want to update the data?";
				string caption = "Message";
				MessageBoxButton button = MessageBoxButton.OKCancel;
				MessageBoxImage icon = MessageBoxImage.Information;

				MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

				if (result == MessageBoxResult.OK)
				{
					MainWindow.Persons.Add(present);

					MessageBox.Show("Person record updated", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				Records.ItemsSource = MainWindow.Persons;
				Records.Items.Refresh();

			}

		}

		//deleting record
		private void Delete(object sender, RoutedEventArgs e)
		{

			if (present != null)
			{
				MainWindow.Persons = new List<Person>(MainWindow.Persons.Where(c => c.Id != present.Id));

				string messageBoxText = "Do you want to delete the data?";
				string caption = "Message";
				MessageBoxButton button = MessageBoxButton.OKCancel;
				MessageBoxImage icon = MessageBoxImage.Information;

				MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

				if (result == MessageBoxResult.OK)
				{
					present = null;
					MessageBox.Show("Person record deleted", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				
				Records.ItemsSource = MainWindow.Persons;
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
			if(recordId >= 0 && recordId < Records.Items.Count)
			{
				present = MainWindow.Persons[recordId];
				id.Text = present.Id.ToString();
				name.Text = present.Name;
				address.Text = present.Address;
				email.Text = present.Email;
				age.Text = present.Age.ToString();
				birthday.Text = present.Birthday;
			}
		}
	}
}
