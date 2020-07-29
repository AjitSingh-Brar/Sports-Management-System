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

namespace WPFMidTerm2020
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		private static List <Person> person = new List<Person>();

		private static List<Sport> sport = new List<Sport>();

		private static List<Personality> personality = new List<Personality>();

		private static List<Education> education = new List<Education>();

		private static Dictionary<int, List<Person>> data = new Dictionary<int, List<Person>>();
		private static Dictionary<int, List<Personality>> data1 = new Dictionary<int, List<Personality>>();
		private static Dictionary<int, List<Sport>> data2 = new Dictionary<int, List<Sport>>();
		private static Dictionary<int, List<Education>> data3 = new Dictionary<int, List<Education>>();

		internal static List< Person> Persons {
			get => person;
			set => person = value;
		}

		internal static List<Sport> Sports
		{
			get => sport;
			set => sport = value;

		}

		internal static List<Personality> Personalitys
		{
			get => personality;
			set => personality = value;

		}

		internal static List<Education> Educations
		{

			get => education;
			set => education = value;

		}

		public MainWindow()
		{
			InitializeComponent();

			person.Add( new Person(1, "Tom Cruise", "264  Drinnan St,Grande Prairie", "tom123@gmail.com", 20, "14th Februrary 2002"));
			person.Add(new Person(2, "Robert Drowny Jr", "4249  th St,Grande Prairie", "robert321@gmail.com", 30, "20th November 2002"));
			person.Add(new Person(3, "Chris Hemsworth", "4000  George Street,Peterborough", "chris343@gmail.com", 36, "15th December 2002"));
			person.Add(new Person(4, "Sushant Singh Rajput", "1254  Tolmie St,St Jacobs", "sushant13@gmail.com", 37, "10th January 2002"));
			person.Add(new Person(5, "Ruby Park", "123 Fallen Oak Crt", "rubypak23@gmail.com", 26, "13th May 2000"));


			sport.Add(new Sport(1,11,"Knights","Los Angles"));
			sport.Add(new Sport(2,12, "Super Kings", "Delhi"));
			sport.Add(new Sport(3,13, "Royals", "New York"));
			sport.Add(new Sport(4,14, "Hawkers", "London"));
			sport.Add(new Sport(5,15, "Snippers", "Paris"));


			personality.Add(new Personality(1, 11,10, "Mission Impossible:Fallout", "Tom Cruise"));
			personality.Add(new Personality(2, 12,9, "Jumanji 2", "Chris Hemsworth"));
			personality.Add(new Personality(3, 13,11, "Avengers: Infinity War", "Robert Drowning"));
			personality.Add(new Personality(4, 14,8, "Fast & Furious 9", "Ben Diesel"));
			personality.Add(new Personality(5, 15,7, "Jurassic World", "Irfan Khan"));

			education.Add(new Education(1, 11, ".Net Technologies", 95.5, "It was good"));
			education.Add(new Education(2, 12, "Data Structures & C", 92.0, "It was very interesting to learn"));
			education.Add(new Education(3, 13, "IT Project & PMP", 96.2, "Course is giving knowledge the basic concepts of PMP"));
			education.Add(new Education(4, 14, "Advance Relational Database", 85.6, "Course gives the exact knowledge of Advanced Database"));
			education.Add(new Education(5, 15, "General Elective", 84.6, "Creative learnig from the elective "));

			
			

		}

		private void showhelp(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("This is main menu of the application." +
				"You must use the buttons below to navigate to the categories");
		}

		private void Quit(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void PersonInfo(object sender, RoutedEventArgs e)
		{
			try
			{
				PersonPanel p1 = new PersonPanel();
				data.Add(1,person);
				p1.Show();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error has occured");
			}
		}

		private void PersonalityInfo(object sender, RoutedEventArgs e)
		{
			try
			{
				PersonalityPanel p2 = new PersonalityPanel();
				data1.Add(1, personality);
				p2.Show();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error has occured");
			}

		}
		private void SportsTeamInfo(object sender, RoutedEventArgs e)
		{
			try
			{
				SportsTeams p2 = new SportsTeams();
				data2.Add(1, sport);
				p2.Show();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error has occured");
			}

		}
		private void EducationInfo(object sender, RoutedEventArgs e)
		{
			try
			{
				EducationPanel p4 = new EducationPanel();
				data3.Add(1, education);
				p4.Show();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error has occured");
			}
		}
	}
}
