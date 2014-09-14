using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace CommonProblems.Algorithm
{
	public class BacktrackRecursion
	{
		const int MAX_QUEENS_NO = 8;


		/// <summary>
		/// Problem: how to put N queens on a NxN board, so that no queen attack each other.
		/// </summary>
		public void QueensProblem()
		{
			ChessBoard board = new ChessBoard(MAX_QUEENS_NO);
			int solution = 1;
			for (int col = 0; col < board.BoardSize; col++)
			{
				if (Solve(board, col))
				{
					Console.WriteLine("sol :#{0}", solution++);
					DisplayBoard(board);
					board.Reset();
				}
			}
			Console.WriteLine("Total :{0}", solution);
		}


		/// Probs:	
		///	Place Queens on the chessboard such that none can attack each other
		/// 
		private bool Solve(ChessBoard board, int col)
		{
			if (col % board.BoardSize == 0 && col >= board.BoardSize)
			{
				return true; //reach base case
			}
			
			//loop all possible rows
			for (int rowToTry = 0; rowToTry < board.BoardSize; rowToTry++)
			{
				if (board.IsSafe(rowToTry, col))
				{
					board.PlaceQueen(rowToTry, col);
					if (Solve(board, col + 1))
					{
						return true;
					}
					else
					{
						board.RemoveQueen(rowToTry, col); //undo
					}
				}
			}
			return false;
		}

		private void DisplayBoard(ChessBoard board)
		{
			Console.WriteLine();
			for (int col = 0; col < board.BoardSize; col++)
			{
				for (int row = 0; row < board.BoardSize; row++)
				{
					if (board.IsQueenPlaced(row, col))
					{
						Console.Write(" Q");
					}
					else
					{
						Console.Write(" +");
					}
				}
				Console.WriteLine("");
			}
		}
	}

	public class ChessBoard
	{
		private bool[][] board;
		
		public ChessBoard(int size)
		{
			BoardSize = size;
			board = new bool[size][];
			for (int i = 0; i < size; i++)
			{
				board[i] = new bool[size];
			}
		}
		public int BoardSize
		{
			get;
			private set;
		}

		public bool IsQueenPlaced(int row, int col)
		{
			return (board[row][col]);
		}
		public bool IsSafe(int row, int col)
		{
			return IsRowClear(row, col)
				&& UpperDiagonalIsClear(row, col)
				&& LowerDiagonalIsClear(row, col);
		}

		bool IsRowClear(int queenRow, int queenCol)
		{
			//same row
			for (int col = 0; col < queenCol; col++)
			{
				if (IsQueenPlaced(queenRow, col))
				{
					return false;
				}
			}
			return true;
		}
		bool UpperDiagonalIsClear(int queenRow, int queenCol)
		{
			//same diagonal: Northwest direction
			for (int row = queenRow, col = queenCol; col >= 0 && row >= 0; row--, col--)
			{
				if (IsQueenPlaced(row, col))
				{
					return false;
				}
			}

			return true;
		}

		bool LowerDiagonalIsClear(int queenRow, int queenCol)
		{
			//Same diagonal: SouthWest direction
			for (int row = queenRow, col = queenCol; col >= 0 && row < BoardSize; row++, col--)
			{
				if (IsQueenPlaced(row, col))
				{
					return false;
				}
			}
			return true;
		}
		public void Reset()
		{
			for (int i = 0; i < board.Length; i++)
			{
				board[i] = new bool[board.Length];
			}
		}

		public void PlaceQueen(int row, int col)
		{
			board[row][col] = true;
		}

		public void RemoveQueen(int row, int col)
		{
			board[row][col] = false;

		}
	}
}
