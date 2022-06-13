using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	public abstract class Duck
	{
		public string DuckName { get; set; }
		public Quack MyQuack;
		public Fly MyFly;
		public abstract void Display();
		public abstract void PerformQuack();
		public abstract void PerformFly();

		public void SetQuack(Quack quack)
		{
			MyQuack = quack;
		}

		public void SetFly(Fly fly)
		{
			MyFly = fly;
		}
	}

	public class NormalDuck : Duck
	{
		public override void Display()
		{
			Console.WriteLine("I am a normal duck!");
		}

		public override void PerformFly()
		{
			throw new NotImplementedException();
		}

		public override void PerformQuack()
		{
			throw new NotImplementedException();
		}
	}

	public class SilentDuck : Duck
	{

		public SilentDuck(string name)
		{
			DuckName = name;

		}
		public override void Display()
		{
			Console.WriteLine("I am a silent duck!");
		}

		public override void PerformQuack()
		{
			MyQuack.Quack();
		}

		public override void PerformFly()
		{
			MyFly.Fly();
		}
	}

	public class WoodenDuck : Duck
	{
		public WoodenDuck(string name)
		{
			DuckName = name;

			
		}
		public override void Display()
		{
			Console.WriteLine("I am a wooden duck!");
		}

		public override void PerformFly()
		{
			MyFly.Fly();
		}

		public override void PerformQuack()
		{
			MyQuack.Quack();
		}
	}

}
