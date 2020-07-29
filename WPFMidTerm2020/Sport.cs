using System;
using System.Collections.Generic;
using System.Text;

namespace WPFMidTerm2020
{
	class Sport    // sports class
	{
		// fields / global variables
		private int _id;
		private int _personId;
		private String _team;
		private String _city;


		//Property defined
		public int Id                    
		{

			get => _id;
			set => _id = value;

		}

		public int PersonId
		{
			get => _personId;
			set => _personId = value;
		}

		public String Team
		{
			get => _team;
			set => _team = value;
		}

		public String City
		{
			get => _city;
			set => _city = value;
		}

		//default constructor
		public Sport()
		{

			Id = 0;
			PersonId = 0;
			Team = "";
			City = "";

		}
		//Parameterised Constructor
		public Sport(int id, int personId,String team, String city) 
		{

			Id = id;
			PersonId = personId;
			Team = team;
			City = city;

		}

		//ToString
		public override string ToString()
		{
			string sportteaminfo = String.Format("ID:{0} PersonId:{1}  SportTeam:{2} City:{3} ", Id.ToString().PadRight(10), PersonId.ToString().PadRight(10), Team.PadRight(10), City.PadRight(10));
			return sportteaminfo;

		}
	}
}
