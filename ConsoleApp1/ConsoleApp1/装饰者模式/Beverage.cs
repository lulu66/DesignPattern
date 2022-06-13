using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	//饮料类
	public abstract class Beverage
	{
		protected string description = "Unknown Beverage";
		public virtual string GetDescription()
		{
			return description;
			
		}

		public abstract float Cost();
	}

	//调料类
	public abstract class CondimentDecorator:Beverage
	{
		public override string GetDescription()
		{
			return description;
		}
	}

	//一些饮料类
	public class Espresso : Beverage
	{
		public Espresso()
		{
			description = "Espresso";
		}

		public override float Cost()
		{
			return 1.99f;
		}

	}

	public class HouseBlend:Beverage
	{
		public HouseBlend()
		{
			description = "House Blend";
		}

		public override float Cost()
		{
			return 0.89f;
		}
	}

	public class DarkRoast : Beverage
	{
		public DarkRoast()
		{
			description = "Dark Roast";
		}

		public override float Cost()
		{
			return 1.32f;
		}
	}

	//一些调料类
	public class Mocha:CondimentDecorator
	{
		Beverage beverage;
		public Mocha(Beverage beverage)
		{
			this.beverage = beverage;
		}
		public override string GetDescription()
		{
			return beverage.GetDescription() + ", Mocha";
		}
		public override float Cost()
		{
			return 0.2f + beverage.Cost();
		}
	}

	public class Whip : CondimentDecorator
	{
		Beverage beverage;
		public Whip(Beverage beverage)
		{
			this.beverage = beverage;
		}
		public override string GetDescription()
		{
			return beverage.GetDescription() + ", Whip";
		}
		public override float Cost()
		{
			return 0.1f + beverage.Cost();
		}
	}
}
