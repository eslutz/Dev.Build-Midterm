using System;
using System.Collections.Generic;

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

		//Methods
		//Override the ToString to correctly format the object output.
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

		//EditMovie method takes arguments for field to be edited and the replacement value when called.  All input validated before calling the method.
		public bool EditMovie(string selectedField, string newValue)
		{
			bool converted = true;
			//Based to the passed argument, determines which field to edit.
			switch (selectedField)
			{
				//Replaces title with the new title.
				case "title":
					Title = newValue;
					break;
				//Replaces genre with new value.  Ignoring the case of the passed string, parses it to a MovieGenre enum value.
				case "genre":
					//Genre = (MovieGenre)Enum.Parse(typeof(MovieGenre), newValue, true);
					converted = Enum.TryParse(typeof(MovieGenre), newValue, out object convertedValue);
					Genre = (MovieGenre)convertedValue;
					
					break;
				//Replaces director with the new director.
				case "director":
					Director = newValue;
					break;
				//Replaces the runtime.  Parses the passed string as an integer.
				case "runtime":
					Runtime = int.Parse(newValue);
					break;
				//Replaces the release year.  Parses the passed string as an integer.
				case "year":
					ReleaseYear = int.Parse(newValue);
					break;
				//Clears the current cast list.  Splits the formatted string that was passed into an array that can then be accessed and added to the cast list.
				case "cast":
					Cast.Clear();
					string[] newCast = newValue.Split(", ");
					foreach (string castMember in newCast)
					{
						Cast.Add(castMember);
					}
					break;
				//Replaces description with the new description.
				case "description":
					Description = newValue;
					break;
			}
			return converted;
		}
	}
}