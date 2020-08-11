using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
		//Private fields
		private string _title;
		private MovieGenre _genre;
		private string _director;
		private int _releaseYear;
		private int _runtime;
		private List<string> _cast;
		private string _description;

		//Properties
		public string Title
		{
			get { return _title; }
			private set { _title = value; }
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

		public int ReleaseYear
		{
			get { return _releaseYear; }
			private set { _releaseYear = value; }
		}

		public int Runtime
		{
			get { return _runtime; }
			private set { _runtime = value; }
		}

		public List<string> Cast
		{
			get { return _cast; }
			private set { _cast = value; }
		}

		public string Description
		{
			get { return _description; }
			private set { _description = value; }
		}

		//Constructor
		public Movie(string title, MovieGenre genre, string director, int releaseYear, int runtimeMinutes, List<string> cast, string description)
		{
			Title = title;
			Genre = genre;
			Director = director;
			ReleaseYear = releaseYear;
			Runtime = runtimeMinutes;
			Cast = cast;
			Description = description;
		}

		//Method
		public override string ToString()
		{
			string fullCast = "";
			if (Cast.Count > 2)
			{
				for (int index = 0; index < Cast.Count - 1; index++)
				{
					fullCast += $"{Cast[index]}, ";
				}
				fullCast += $"& {Cast[Cast.Count - 1]}";
			}
			else if (Cast.Count == 2)
			{
				fullCast = $"{Cast[0]} & {Cast[1]}";
			}
			else if (Cast.Count == 1)
			{
				fullCast += Cast[0];
			}
			else
			{
				fullCast = "No cast available.";
			}
			return $"{Title,-40}|{Genre,-12}|{Director,-20}|{Runtime,-8}|{ReleaseYear,-6}|{fullCast,-66}|{Description}";
		}
	}
}
