using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

//可以为各种对象集合实现迭代器
namespace ConsoleApp1
{

	public class MenuItem
	{
		string name;
		string description;
		bool bVegetarian;
		float price;

		public MenuItem(string name, string desc, bool bVeg, float price)
		{
			this.name = name;
			this.description = desc;
			this.bVegetarian = bVeg;
			this.price = price;
		}

		public string GetName()
		{
			return name;
		}

		public string GetDescription()
		{
			return description;
		}

		public bool IsVegetarian()
		{
			return bVegetarian;
		}

		public float Price()
		{
			return price;
		}
	}

	public interface Iterator
	{
		public bool HasNext();
		public Object Next();
	}

	public class DinerMenuIterator : Iterator
	{
		MenuItem[] items;
		int position;

		public DinerMenuIterator(MenuItem[] items)
		{
			this.items = items;
			position = 0;
		}

		public bool HasNext()
		{
			if(position >= items.Length || items[position] == null)
			{
				return false;
			}
			return true;
		}

		public object Next()
		{
			MenuItem item = items[position];
			position++;
			return item;
		}
	}

	public class PancakeMenuIterator : Iterator
	{
		ArrayList items;
		int position;

		public PancakeMenuIterator(ArrayList items)
		{
			this.items = items;
			position = 0;
		}

		public bool HasNext()
		{
			if (position >= items.Count || items[position] == null)
			{
				return false;
			}
			return true;
		}

		public object Next()
		{
			MenuItem item = (MenuItem)items[position];
			position++;
			return item;
		}
	}


	public interface IMenu
	{
		public Iterator CreateIterator();
	}
	public class DinerMenu:IMenu
	{
		MenuItem[] items;
		static int MAX_ITEMS = 10;
		int numOfItems = 0;

		public DinerMenu()
		{
			items = new MenuItem[MAX_ITEMS];
			AddItem("Cake1", "Nice Cake1", true, 2.99f);
			AddItem("Cake2", "Nice Cake2", true, 1.99f);
			AddItem("Cake3", "Nice Cake3", true, 2.5f);
			AddItem("Cake4", "Nice Cake4", true, 0.99f);
		}

		public void AddItem(string name, string desc, bool bVeg, float price)
		{
			MenuItem item = new MenuItem(name, desc, bVeg, price);
			if(numOfItems >= MAX_ITEMS)
			{
				Console.WriteLine("Menu is full! Can not add menu.");
				return;
			}
			items[numOfItems++] = item;
		}

		//返回一个迭代器
		public Iterator CreateIterator()
		{
			return new DinerMenuIterator(items);
		}
	}

	public class PancakeHouseMenu : IMenu
	{
		ArrayList menuItems;
		public PancakeHouseMenu()
		{
			menuItems = new ArrayList();
			AddItem("PancakeHouse Cake1", "PancakeHouse Nice Cake1", true, 2.1f);
			AddItem("PancakeHouse Cake2", "PancakeHouse Nice Cake2", true, 1.2f);
			AddItem("PancakeHouse Cake3", "PancakeHouse Nice Cake3", true, 2.88f);
			AddItem("PancakeHouse Cake4", "PancakeHouse Nice Cake4", true, 6.99f);
		}

		public void AddItem(string name, string desc, bool bVeg, float price)
		{
			MenuItem item = new MenuItem(name, desc, bVeg, price);
			menuItems.Add(item);
		}

		public Iterator CreateIterator()
		{
			return new PancakeMenuIterator(menuItems);
		}
	}

	public class Witress
	{
		DinerMenu dinerMenu;
		PancakeHouseMenu pancakeHouseMenu;

		public Witress(DinerMenu dinerMenu, PancakeHouseMenu pancakeHouseMenu)
		{
			this.dinerMenu = dinerMenu;
			this.pancakeHouseMenu = pancakeHouseMenu;
		}

		public void PrintMenu()
		{
			Iterator dinerIterator = dinerMenu.CreateIterator();
			Iterator pancakeIterator = pancakeHouseMenu.CreateIterator();
			Console.WriteLine("----Start Print Menu----");
			Print(dinerIterator);
			Print(pancakeIterator);
		}

		public void Print(Iterator itorator)
		{
			while(itorator.HasNext())
			{
				MenuItem item = (MenuItem)itorator.Next();
				Console.WriteLine(item.GetName() + " , " + item.GetDescription() + " , " + item.IsVegetarian() + " , " + item.Price());
			}
		}
	}
}
