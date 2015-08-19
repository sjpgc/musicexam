using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Ductia.Domain;

namespace Ductia.Persistence.InMemory
{
	internal static class InMemoryStorage
	{

		private static List<Book> _books;
		private static List<GradePiece> _gradePieces;
		private static List<Grade> _grades;
		private static List<ExamBoard> _boards; 

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

			var book1 = new Book
			{
				Id = Guid.NewGuid(),
				Title = "Some title",
				Publisher = "Acme ltd.",
				Isbn = "47859375"
			}
				.AddPiece(_pieces["Il Barbiere di Siviglia"])
				.AddPiece(_pieces["Water Music"])
				.AddPiece(_pieces["The Music for the Royal Fireworks"])
				.AddPiece(_pieces["Mikado"])
				.AddPiece(_pieces["Nimrod"]);

			var book2 = new Book
			{
				Id = Guid.NewGuid(),
				Title = "Some other title",
				Publisher = "Pub ltd",
				Isbn = "485347895",

			}
				.AddPiece(_pieces["The Planets"])
				.AddPiece(_pieces["Some Water Music"])
				.AddPiece(_pieces["The Playful Pony"])
				.AddPiece(_pieces["Mango Tango"]);
			
			_books = new List<Book>
			{
				book1,
				book2
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
							Piece = _pieces["The Music for the Royal Fireworks"]
						},
						new GradePiece()
						{
							List = PieceList.B,
							Piece = _pieces["Nimrod"]
						},
						new GradePiece()
						{
							List = PieceList.C,
							Piece = _pieces["The Playful Pony"]
						}
					}
				},
				new Grade()
				{
					Level = 2,
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
							Piece = _pieces["The Music for the Royal Fireworks"]
						},
						new GradePiece()
						{
							List = PieceList.B,
							Piece = _pieces["Nimrod"]
						},
						new GradePiece()
						{
							List = PieceList.C,
							Piece = _pieces["Water Music"]
						},
						new GradePiece()
						{
							List = PieceList.C,
							Piece = _pieces["Mango Tango"]
						}
					}
				}
			};

			_boards = new BoardCollection()
			{
				new ExamBoard {Name = "ABRSM", Grades = new List<Grade>{_grades[0]}},
				new ExamBoard {Name = "Trinity", Grades = new List<Grade>{_grades[1]} }
			};
		}

		public static IEnumerable<ExamBoard> Boards
		{
			get { return _boards; }
		} 

		public static IEnumerable<Book> Books
		{
			get { return _books; }
		}

		public static IEnumerable<GradePiece> GradePieces
		{
			get { return _gradePieces; }
		}

		public static IList<Grade> Grades
		{
			get { return _grades; }
		}
		
	}
}
