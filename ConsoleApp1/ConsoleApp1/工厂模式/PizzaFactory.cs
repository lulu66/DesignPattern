using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
	//各种不同的pizza
	public abstract class Pizza
	{
		protected string name;
		protected string dough;
		protected string sauce;
		protected ArrayList toppings = new ArrayList();
		public virtual void Prepare()
		{
			Console.WriteLine("Preparing " + name);
			Console.WriteLine("Tossing dough..." + dough);
			Console.WriteLine("Adding sauce..." + sauce);
			for(int i=0; i<toppings.Count; i++)
			{
				Console.WriteLine(" " + toppings[i]);
			}
		}
		public virtual void Bake()
		{
			Console.WriteLine("Bake for 25 minutes at 350...");
		}
		public virtual void Cut()
		{
			Console.WriteLine("Cutting the pizza...");
		}
		public virtual void Box()
		{
			Console.WriteLine("Boxing the pizza...");
		}

		public virtual string GetName()
		{
			return name;
		}
	}

	public class CheesePizza:Pizza
	{
		public CheesePizza()
		{
			name = "cheese pizza";
			dough = "Thin crust dough";
			sauce = "Marianra sauce";
			toppings.Add("Grated reggiano cheese");
		}
	}

	public class ClamPizza : Pizza
	{
		public ClamPizza()
		{
			name = "clam pizza";
			dough = "thick crust dough";
			sauce = "clam sauce";
			toppings.Add("clam blablabla");
		}

		public override void Cut()
		{
			Console.WriteLine("cutting the pizza into square slices.");
		}
	}

	public class VeggiePizza : Pizza
	{
		public VeggiePizza()
		{
			name = "Veggie pizza";
			dough = "Veggie crust dough";
			sauce = "Veggie sauce";
			toppings.Add("Veggie blablabla");
		}
	}

	public abstract class PizzaStore
	{
		public abstract Pizza CreatePizza(string type);


		public Pizza OrderPizza(string type)
		{
			Pizza pizza = null;
			pizza = CreatePizza(type);
			pizza.Prepare();
			pizza.Bake();
			pizza.Cut();
			pizza.Box();
			return pizza;

		}
	}

	public class NYPizzaStore : PizzaStore
	{
		public override Pizza CreatePizza(string type)
		{
			Pizza pizza = null;

			if (type.Equals("cheese"))
			{
				pizza = new CheesePizza();
			}
			else if (type.Equals("clam"))
			{
				pizza = new ClamPizza();
			}
			else if (type.Equals("veggie"))
			{
				pizza = new VeggiePizza();
			}
			return pizza;
		}
	}

	public class ChicagoPizzaStore : PizzaStore
	{
		public override Pizza CreatePizza(string type)
		{
			Pizza pizza = null;

			if (type.Equals("cheese"))
			{
				pizza = new CheesePizza();
			}
			else if (type.Equals("clam"))
			{
				pizza = new ClamPizza();
			}
			else if (type.Equals("veggie"))
			{
				pizza = new VeggiePizza();
			}
			return pizza;
		}
	}

	public class CaliforniaPizzaStore : PizzaStore
	{
		public override Pizza CreatePizza(string type)
		{
			Pizza pizza = null;

			if (type.Equals("cheese"))
			{
				pizza = new CheesePizza();
			}
			else if (type.Equals("clam"))
			{
				pizza = new ClamPizza();
			}
			else if (type.Equals("veggie"))
			{
				pizza = new VeggiePizza();
			}
			return pizza;
		}
	}
}
