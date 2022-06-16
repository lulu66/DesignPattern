using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	//让火鸡充当一只猴子
	public class Monkey
	{
		public virtual void MonkeySpeak()
		{
			Console.WriteLine("Monkey gi gi gi.");
		}
		public virtual void MonkeyWalk()
		{
			Console.WriteLine("I can walk on the tree.");
		}
	}

	public class Turkey
	{
		public void Gobble()
		{
			Console.WriteLine("Gobble, google.");
		}
		public void Fly()
		{
			Console.WriteLine("I can fly with a short distance.");
		}
	}

	public class MonkeyAdaptor : Monkey
	{
		protected Turkey turkey;

		public MonkeyAdaptor(Turkey turkey)
		{
			this.turkey = turkey;
		}
		public override void MonkeySpeak()
		{
			turkey.Gobble();
		}

		public override void MonkeyWalk()
		{
			turkey.Fly();
		}
	}
}
