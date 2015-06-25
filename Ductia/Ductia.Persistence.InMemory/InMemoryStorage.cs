using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Ductia.Domain;

namespace Ductia.Persistence.InMemory
{
	internal static class InMemoryStorage
	{

		private static List<Book> _books;
		private static List<GradePiece> _gradePieces;
		private static List<Grade> _grades;

		static InMemoryStorage()
		{
			var _pieces = new PieceCollection()
			{
				new Piece {Title = "Il Barbiere di Siviglia"},
				new Piece {Title = "Some Water Music"},
				new Piece {Title = "The Music for the Royal Fireworks"},
				new Piece {Title = "Mikado"},
				new Piece {Title = "Nimrod"},
				new Piece {Title = "The Planets"},
				new Piece {Title = "Water Music"},
				new Piece {Title = "The Playful Pony"},
				new Piece {Title = "Mango Tango"},
			};

			_books = new List<Book>
			{
				new Book
				{
					Id = Guid.NewGuid(),
					Title = "Some title",
					Publisher = "Acme ltd.",
					Isbn = "47859375",
					Pieces = new List<Piece>
					{
						_pieces["Il Barbiere di Siviglia"],
						_pieces["Water Music"],
						_pieces["The Music for the Royal Fireworks"],
						_pieces["Mikado"],
						_pieces["Nimrod"]
					}
				},
				new Book
				{
					Id = Guid.NewGuid(),
					Title = "Some other title",
					Publisher = "Pub ltd",
					Isbn = "485347895",
					Pieces = new List<Piece>
					{
						_pieces["The Planets"],
						_pieces["Some Water Music"],
						_pieces["The Playful Pony"],
						_pieces["Mango Tango"]
					}
				},
			};


			_grades = new List<Grade>
			{
				new Grade()
				{
					Level = 1,
					Instrument = Instrument.Flute,
					Pieces = new List<GradePiece>
					{
						new GradePiece()
						{
							List = PieceList.A,
							Piece = _pieces["Il Barbiere di Siviglia"]
						},
						new GradePiece()
						{
							List = PieceList.A,
							Piece = _pieces["Water Music"]
						},
						new GradePiece()
						{
							List = PieceList.A,
							Piece = _pieces["The Music for the Royal Fireworks"]
						},
						new GradePiece()
						{
							List = PieceList.B,
							Piece = _pieces["Mikado"]
						},
						new GradePiece()
						{
							List = PieceList.B,
							Piece = _pieces["Nimrod"]
						},
						new GradePiece()
						{
							List = PieceList.B,
							Piece = _pieces["The Planets"]
						},
						new GradePiece()
						{
							List = PieceList.C,
							Piece = _pieces["Water Music"]
						},
						new GradePiece()
						{
							List = PieceList.C,
							Piece = _pieces["The Playful Pony"]
						},
						new GradePiece()
						{
							List = PieceList.C,
							Piece = _pieces["Mango Tango"]
						}

					}
				}
			};
		}


		public static IEnumerable<Book> Books
		{
			get { return _books; }
		}

		public static IEnumerable<GradePiece> GradePieces
		{
			get { return _gradePieces; }
		}
	}
}
