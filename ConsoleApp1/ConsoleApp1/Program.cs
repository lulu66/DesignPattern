using System;
using System.Linq;
using System.Collections;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			//CharList charList = new CharList("Helllo, World!");
			//foreach (var c in charList)
			//{
			//	Console.WriteLine(c);
			//}

			//策略模式
			//SilentDuck duck = new SilentDuck("Silent Duck");
			//Quack MyQuack = new ZiziQuack();
			//Fly MyFly = new CannotFly();
			//duck.SetQuack(MyQuack);
			//duck.SetFly(MyFly);
			//duck.PerformQuack();
			//duck.PerformFly();

			//WoodenDuck duck2 = new WoodenDuck("Wooden Duck");
			//Quack MyQuack2 = new MiumiuQuack();
			//Fly MyFly2 = new SwingFly();
			//duck2.SetQuack(MyQuack2);
			//duck2.SetFly(MyFly2);
			//duck2.PerformQuack();
			//duck2.PerformFly();

			//观察者
			//WeatherData weather = new WeatherData();
			//CurrentConditionDisplay currentConDisplay = new CurrentConditionDisplay(weather);
			//weather.SetMeasurements(36, 128, 80);

			//装饰者
			//Beverage beverage = new Espresso();
			//Console.WriteLine(beverage.GetDescription() + " $" + beverage.Cost());

			//Beverage beverage2 = new Mocha(beverage);
			//Console.WriteLine(beverage2.GetDescription() + " $" + beverage2.Cost());

			//Beverage beverage3 = new Whip(beverage2);
			//Console.WriteLine(beverage3.GetDescription() + " $" + beverage3.Cost());

			//工厂方法模式
			NYPizzaStore nyPizzaStore = new NYPizzaStore();
			ChicagoPizzaStore chicagoPizzaStore = new ChicagoPizzaStore();

			Pizza pizza1 = null;
			Pizza pizza2 = null;
			pizza1 = nyPizzaStore.OrderPizza("cheese");
			pizza2 = chicagoPizzaStore.OrderPizza("clam");
			Console.WriteLine("pizza1 name: " + pizza1.GetName());
			Console.WriteLine("pizza2 name: " + pizza2.GetName());

		}
	}

	class CharList : IEnumerable
	{
		public string TargetStr { get; set; }

		public CharList(string str)
		{
			TargetStr = str;
		}
		public IEnumerator GetEnumerator()
		{
			//方法一
			//return new CharItorator(TargetStr);

			//方法二
			for (int index = TargetStr.Length; index > 0; index--)
			{
				yield return TargetStr[index - 1];
			}
		}
	}

	class CharItorator : IEnumerator
	{
		public string TargetStr { get; set; }

		public int Position { get; set; }

		public CharItorator(string targetStr)
		{
			this.TargetStr = targetStr;
			this.Position = this.TargetStr.Length;
		}

		public object Current
		{
			get
			{
				if(Position == -1 || Position == TargetStr.Length)
				{
					throw new InvalidOperationException();
				}
				return TargetStr[Position];
			}
		}

		public bool MoveNext()
		{
			if(Position != -1)
			{
				Position--;
			}
			return Position > -1;
		}

		public void Reset()
		{
			Position = TargetStr.Length;
		}
	}
}
