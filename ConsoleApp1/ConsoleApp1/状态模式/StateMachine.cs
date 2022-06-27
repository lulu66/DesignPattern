using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	//1.找出所有状态
	//2.创建实例变量持有目前的状态,定义每个状态的值

	//简单糖果售卖机
	public class SimpleStateMachine
	{
		static int SOLD_OUT = 0;
		static int NO_QUARTER = 1;
		static int HAS_QUARTER = 2;
		static int SOLD = 3;

		int state = SOLD_OUT;
		int count = 0;

		public SimpleStateMachine(int count)
		{
			this.count = count;
			if(count > 0)
			{
				state = NO_QUARTER;
			}
		}

		//
		public void InsertQuarter()
		{
			if(state == HAS_QUARTER)
			{
				Console.WriteLine("You can not insert another quarter.");
			}
			else if(state == SOLD_OUT)
			{
				Console.WriteLine("the mochine is sold out, you can not insert another quarter.");
			}
			else if(state == SOLD)
			{
				Console.WriteLine("Please wait, we're already giving you a candy.");
			}
			else if(state == NO_QUARTER)
			{
				state = HAS_QUARTER;
				Console.WriteLine("You inserted a quarter.");
			}
		}
	}
}
