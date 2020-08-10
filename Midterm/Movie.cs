using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm
{
	public enum MovieGenre
	{
		Action,
		Comedy,
		Documentary,
		Drama,
		Horror,
		SciFi,
		Thriller
	}

	public class Movie
	{
		//Private fields.
		private string _title;
		private string _mainActor;
		private MovieGenre _genre;
		private string _director;

		//Properties.
		public string Title
		{
			get { return _title; }
			private set { _title = value; }
		}

		public string MainActor
		{
			get { return _mainActor; }
			private set { _mainActor = value; }
		}

		public MovieGenre Genre
		{
			get { return _genre; }
			private set { _genre = value; }
		}

		public string Director
		{
			get { return _director; }
			private set { _director = value; }
		}

		//Constructor.
		public Movie(string title, string actor, MovieGenre genre, string director)
		{
			Title = title;
			MainActor = actor;
			Genre = genre;
			Director = director;
		}
	}
}
