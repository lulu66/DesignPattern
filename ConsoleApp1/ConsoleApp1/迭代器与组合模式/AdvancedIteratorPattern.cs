using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ConsoleApp1
{
	//组合模式
	public abstract class MenuComponent
	{
		public virtual void Add(MenuComponent menuComponent) { }
		public virtual void Remove(MenuComponent menuComponent) { }
		public virtual MenuComponent GetChild(int i) { return null; }

		public virtual string GetName() { return ""; }
		public virtual string GetDescription() { return ""; }
		public virtual float GetPrice() { return 0.0f; }
		public virtual bool IsVegetarian() { return false; }

		public virtual void Print() { }
	}

	public class MenuItem2:MenuComponent
	{
		protected string name;
		protected string description;
		protected bool bVegitable;
		protected float price;

		public MenuItem2(string name, string description, bool isVeg, float price)
		{
			this.name = name;
			this.description = description;
			this.bVegitable = isVeg;
			this.price = price;
		}

		public override string GetName()
		{
			return name;
		}

		public override string GetDescription()
		{
			return description;
		}

		public override float GetPrice()
		{
			return price;
		}

		public override bool IsVegetarian()
		{
			return bVegitable;
		}

		public override void Print()
		{
			Console.WriteLine(" " + GetName());
			if(IsVegetarian())
			{
				Console.WriteLine(" is vegitable. ");

			}
			Console.WriteLine(" " + GetPrice());
			Console.WriteLine(" " + GetDescription());
		}
	}

	public class Menu2:MenuComponent
	{
		ArrayList menuComponents = new ArrayList();
		string name;
		string description;

		public Menu2(string name, string desc)
		{
			this.name = name;
			this.description = desc;
		}

		public override void Add(MenuComponent menuComponent)
		{
			menuComponents.Add(menuComponent);
		}

		public override void Remove(MenuComponent menuComponent)
		{
			menuComponent.Remove(menuComponent);
		}

		public override MenuComponent GetChild(int i)
		{
			return (MenuComponent)menuComponents[i];
		}

		public override string GetName()
		{
			return name;
		}

		public override string GetDescription()
		{
			return description;
		}

		public override void Print()
		{
			Console.WriteLine(" " + GetName());
			Console.WriteLine(" " + GetDescription());
			var itorator = menuComponents.GetEnumerator();
			while(itorator.MoveNext())
			{
				MenuComponent component = (MenuComponent)itorator.Current;
				component.Print();
			}
		}
	}

	public class Waitress2
	{
		MenuComponent allMenus;
		public Waitress2(MenuComponent menu)
		{
			allMenus = menu;
		}

		public void PrintMenu()
		{
			allMenus.Print();
		}
	}
}
