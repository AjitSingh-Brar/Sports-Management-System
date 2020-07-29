using System;
using System.Collections.Generic;
using System.Text;

namespace WPFMidTerm2020
{
	class Personality  //class name defined
	{
		// fields  /Global Variable
		private int _id;
		private int _personId;
		private int _shoeSize;
		private String _movie;
		private String _actor;


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

		public int ShoeSize
		{
			get => _shoeSize;
			set => _shoeSize = value;
		}

		public String Movie
		{
			get => _movie;
			set => _movie = value;
		}
		public String Actor
		{
			get => _actor;
			set => _actor = value;
		}

		//default constructor created
		public Personality()
		{

			Id = 0;
			PersonId = 0;
			ShoeSize = 0;
			Movie = "";
			Actor = "";

		}

		//parameterised Constructor
		public Personality(int id, int personId, int shoeSize, String movie,String actor)
		{

			Id = id;
			PersonId = personId;
			ShoeSize = shoeSize;
			Movie = movie;
			Actor = actor;

		}

		//ToString method
		public override string ToString()
		{

			string personalityinfo = String.Format("ID:{0} PersonId:{1}  SportTeam:{2} City:{3} ", Id.ToString().PadRight(10), PersonId.ToString().PadRight(10), ShoeSize.ToString().PadRight(10), Movie.PadRight(10), Actor.PadRight(10));
			return personalityinfo;

		}
	}
}
