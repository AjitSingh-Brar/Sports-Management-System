using System;
using System.Collections.Generic;
using System.Text;

namespace WPFMidTerm2020
{
	class Person  //class name Person
	{
		//fields / global variables
		private int _id;
		private string _name;
		private string _address;
		private string _email;
		private int _age;
		private string _birthday;

		
		//Property defined

		public int Id
		{
			get => _id;
			set => _id = value;
		}

		public String Name
		{
			get => _name;
			set => _name = value;

		}
		public String Address
		{
			get => _address;
			set => _address = value;
		}

			public String Email
		{
			get => _email;
			set => _email = value;
		}

			public int Age
		{
			get => _age;
			set => _age = value;

		}
			public String Birthday
		{
			get => _birthday;
			set => _birthday = value;
		}
		//default constructor
		public Person()
		{

			Id = 0;
			Name = "";
			Address = "";
			Email = "";
			Age = 0;
			Birthday = "";

		}
		//paramterised Constructor
		public Person(int id, string name, string address, string email, int age, string birthday)
		{

			Id = id;
			Name = name;
			Address = address;
			Email = email;
			Age = age;
			Birthday = birthday;

		}

		//ToString method
		public override string ToString()
		{
			string personinfo = String.Format("ID:{0} Name:{1} Address:{2} Email:{3}  Age:{4} Birthday:{5} ", Id.ToString().PadRight(10), Name.PadRight(10),
				Address.PadRight(10), Email.PadRight(10), Age.ToString(), Birthday.PadRight(10));
			return personinfo;
		}

	}
	}
