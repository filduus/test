/*
 * Created by SharpDevelop.
 * User: fictum
 * Date: 13.03.2018
 * Time: 12:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace kulecnik
{
	/// <summary>
	/// Description of Kulicka.
	/// </summary>
	public class Kulicka
	{
		public int X {get;set;}
		public int Y {get;set;}
		
		// hodnoty: -1, 0, 1 mohou v tomto poli vyjadrit vsechny mozne smery
		private int[] smer = {1,1}; // vychozi = smer doprava dolu
			
		public void PohniSe(){
		
			// ZMENY SMERU v pripade dosazeni sten
			// leva stena
			// ELSE IF soustava je zde SPATNE --> pokud se kulicka octne v rohu, prenastavila by se jen jedna souradnice!
			if(X==0) smer[0] = 1; 
			// prava stena
			if(X==Console.WindowWidth-1) smer[0] = -1;
			// horni stena
			if(Y==0) smer[1] = 1;
			// spodni stena
			if(Y==Console.WindowHeight-1) smer[1] = -1;

			//POHNUTI KULICKOU
			X += smer[0];
			Y += smer[1];
		}

		public void Vykresli(){
			Console.SetCursorPosition(X,Y);
			Console.Write('@');
		}
		
		public Kulicka(int x, int y, int smerX, int smerY)
		{
			X = x;
			Y = y;
			smer[0] = smerX;
			smer[1] = smerY;
		}
	}
}
