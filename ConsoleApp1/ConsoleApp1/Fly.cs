using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	public interface Fly
	{
		public void Fly();
	}

	public class CannotFly:Fly
	{
		public void Fly()
		{
			Console.WriteLine("I can not fly.");
		}
	}

	public class SwingFly:Fly
	{
		public void Fly()
		{
			Console.WriteLine("Fly with Swing!");
		}
	}
}
