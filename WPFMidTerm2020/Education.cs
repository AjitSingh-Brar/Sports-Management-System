using System;
using System.Collections.Generic;
using System.Text;

namespace WPFMidTerm2020
{
	class Education  // classname Education 
	{

		//fields / global variable
		private int _id;
		private int _personId;
		private String _courseName;
		private double _grade;
		private String _comments;


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

		public String CourseName
		{
			get => _courseName;
			set => _courseName = value;
		}

		public Double Grade
		{
			get => _grade;
			set => _grade = value;
		}

		public String Comments
		{
			get => _comments;
			set => _comments = value;
		}

		//default constructor
		public Education()
		{

			Id = 0;
			PersonId = 0;
			CourseName = "";
			Grade = 0.0;
			Comments = "";

		}

		//parameterised constructor
		public Education(int id, int personId, String courseName, double grade, String comments)
		{

			Id = id;
			PersonId = personId;
			CourseName = courseName;
			Grade = grade;
			Comments = comments;

		}

		//ToString method
		public override string ToString()
		{
			string educationinfo = String.Format("ID:{0} PersonId:{1}  CourseName:{2} CourseGrade:{3} Comments:{4} ", Id.ToString().PadRight(10), PersonId.ToString().PadRight(10), CourseName.PadRight(10), Grade.ToString().PadRight(10), Comments.PadRight(10));
			return educationinfo;

		}
	}
}
