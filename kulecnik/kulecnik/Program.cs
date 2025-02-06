/*
 * Created by SharpDevelop.
 * User: fictum
 * Date: 13.03.2018
 * Time: 12:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;
using System.Collections.Generic;

namespace kulecnik
{
	class Program
	{
		public static Random rnd = new Random();
		public static List<Kulicka> kulicky = new List<Kulicka>();
		
		// ------------- MAIN ---------------
		public static void Main(string[] args)
		{
			
			
			// TODO: po hodne cyklech preci jen pribyde nova radka - PROC??
			
			
			Console.Title = ">>> KULECNIK <<<";
			Console.CursorVisible = false;
			Console.BufferHeight = Console.WindowHeight; // odstrani scrollbar
			
			GenerujKulicky(10);
			
			// ------ HLAVNI CYKLUS PROGRAMU ------
			while(true)
			{
				Thread.Sleep(100);
				Console.Clear();
					
				foreach(Kulicka k in kulicky){
					k.Vykresli();
					k.PohniSe();
				}
			}
		}
		
		public static void GenerujKulicky(int pocet){
			for(int i=0; i<pocet; i++){
				PridejKulicku();
			}
		}
		
		public static void PridejKulicku(){
			int[] nums = new int[4];
			
			nums[0] = rnd.Next(Console.WindowWidth);
			nums[1] = rnd.Next(Console.WindowHeight);
			nums[2] = rnd.Next(-1,2); // je horni hranice skutecne mimo?
			nums[3] = rnd.Next(-1,2);
			
			kulicky.Add(new Kulicka(nums[0], nums[1], nums[2], nums[3]));
		}
	}
}