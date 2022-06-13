using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	public interface Quack
	{
		public void Quack();
	}

	public class ZiziQuack:Quack
	{
		public void Quack()
		{
			Console.WriteLine("Zi zi zi zi......");
		}
	}

	public class MiumiuQuack:Quack
	{
		public void Quack()
		{
			Console.WriteLine("Miu miu miu miu......");
		}
	}
	
}
