using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	public interface State
	{
		public void InsertQuarter();
		public void EjectQuarter();
		public void TurCrank();
		public void Dispense();

	}

	public class NoQuarterState : State
	{
		protected GumballMachine gumballMachine;
		public NoQuarterState(GumballMachine gumballMachine)
		{
			this.gumballMachine = gumballMachine;
		}
		public void Dispense()
		{
			Console.WriteLine("You need to pay first.");
		}

		public void EjectQuarter()
		{
			Console.WriteLine("You have not inserted a quarter.");
		}

		public void InsertQuarter()
		{
			gumballMachine.SetState(gumballMachine.GetHasQuarterState());
			Console.WriteLine("You inserted a quarter.");
		}

		public void TurCrank()
		{
			Console.WriteLine("You turned, but there's no quarter.");
		}
	}

	public class SoldState : State
	{
		protected GumballMachine gumballMachine;
		public SoldState(GumballMachine gumballMachine)
		{
			this.gumballMachine = gumballMachine;
		}
		public void Dispense()
		{
			gumballMachine.ReleaseBall();
			if(gumballMachine.GetCount() > 0)
			{
				gumballMachine.SetState(gumballMachine.GetNoQuarterState());
			}
			else
			{
				Console.WriteLine("Oh, there is no gumballs in machine.");
				gumballMachine.SetState(gumballMachine.GetSoldOutState()) ;
			}
		}

		public void EjectQuarter()
		{
			Console.WriteLine("You can not ieject quater now, we are solding....");
		}

		public void InsertQuarter()
		{
			Console.WriteLine("Please wait, we already given you a gumball.");
		}

		public void TurCrank()
		{
			Console.WriteLine("turning twice doesn't get you another gumball.");
		}
	}

	public class HasQuarterState : State
	{
		protected GumballMachine gumballMachine;
		protected Random randomNum;
		public HasQuarterState(GumballMachine gumballMachine)
		{
			this.gumballMachine = gumballMachine;
			randomNum = new Random();
		}

		public void Dispense()
		{
			Console.WriteLine("You need to turn crank.");
		}

		public void EjectQuarter()
		{
			gumballMachine.SetState(gumballMachine.GetNoQuarterState());
			Console.WriteLine("Ok, we turn back your quarter.");
		}

		public void InsertQuarter()
		{
			Console.WriteLine("You already inserted quarter.");
		}

		public void TurCrank()
		{
			int winner = randomNum.Next(1, 10);
			if(winner == 6 && gumballMachine.GetCount() > 1)
			{
				gumballMachine.SetState(gumballMachine.GetWinnerState());
			}
			else
			{
				gumballMachine.SetState(gumballMachine.GetSoldState());
				Console.WriteLine("Ok, Please wating, we are solding...");
			}
		}
	}

	public class SoldOutState : State
	{
		protected GumballMachine gumballMachine;
		public SoldOutState(GumballMachine gumballMachine)
		{
			this.gumballMachine = gumballMachine;
		}
		public void Dispense()
		{
			Console.WriteLine("out of gumballs.");
		}

		public void EjectQuarter()
		{
			Console.WriteLine("there is no quarter left.");
		}

		public void InsertQuarter()
		{
			Console.WriteLine("sorry, gumballs is sold out.");
		}

		public void TurCrank()
		{
			Console.WriteLine("sorry, gumballs is sold out.");
		}
	}
	public class WinnerState:State
	{
		protected GumballMachine gumballMachine;
		public WinnerState(GumballMachine gumballMachine)
		{
			this.gumballMachine = gumballMachine;
		}

		public void Dispense()
		{
			Console.WriteLine("You are winner! Congradulations!!");
			gumballMachine.ReleaseBall();
			if(gumballMachine.GetCount() == 0)
			{
				gumballMachine.SetState(gumballMachine.GetSoldOutState());
				Console.WriteLine("Sold Out!");
			}
			else
			{
				gumballMachine.ReleaseBall();
				if(gumballMachine.GetCount() > 0)
				{
					gumballMachine.SetState(gumballMachine.GetNoQuarterState());
				}
				else
				{
					gumballMachine.SetState(gumballMachine.GetSoldOutState());
					Console.WriteLine("Sold Out!");

				}
			}
		}

		public void EjectQuarter()
		{
			Console.WriteLine("You have turned crank, can not eject quarter.");

		}

		public void InsertQuarter()
		{
			Console.WriteLine("Please wait, we already given you a gumball.");
		}

		public void TurCrank()
		{
			Console.WriteLine("turning twice doesn't get you another gumball.");
		}
	}
	public class GumballMachine
	{
		State noQuaterState;
		State hasQuaterState;
		State soldState;
		State soldOutState;
		State winnerState;
		State curState;

		int count = 0;
		public GumballMachine(int numberOfGumballs)
		{
			count = numberOfGumballs;
			noQuaterState = new NoQuarterState(this);
			hasQuaterState = new HasQuarterState(this);
			soldState = new SoldState(this);
			soldOutState = new SoldOutState(this);
			winnerState = new WinnerState(this);
			curState = soldOutState;
			if(count > 0)
			{
				curState = noQuaterState;
			}
		}

		public void InsertQuarter()
		{
			curState.InsertQuarter();
		}

		public void EjectQuarter()
		{
			curState.EjectQuarter();
		}

		public void TurnCrank()
		{
			curState.TurCrank();
			curState.Dispense();
		}

		public void SetState(State state)
		{
			curState = state;
		}

		public void ReleaseBall()
		{
			Console.WriteLine("A gumball comes rolling out the slot...");
			if(count!=0)
			{
				count -= 1;
			}
		}
		public int GetCount()
		{
			return count;
		}
		public State GetNoQuarterState()
		{
			return noQuaterState;
		}

		public State GetHasQuarterState()
		{
			return hasQuaterState;
		}

		public State GetSoldState()
		{
			return soldState;
		}

		public State GetSoldOutState()
		{
			return soldOutState;
		}

		public State GetWinnerState()
		{
			return winnerState;
		}

		public void ReFill(int count)
		{
			this.count = count;
			curState = noQuaterState;
		}
	}
}
