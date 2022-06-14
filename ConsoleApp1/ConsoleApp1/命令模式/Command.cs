using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	public class Light
	{
		public void On()
		{
			Console.WriteLine("Light is on!");
		}
	}

	public class GarageDoor
	{
		public void On()
		{
			Console.WriteLine("Garage Door is On!");
		}
	}
	public interface Command
	{
		public void Execute();
	}

	public class LightOnCommand:Command
	{
		protected Light light;
		public LightOnCommand(Light light)
		{
			this.light = light;
		}

		public void Execute()
		{
			light.On();
		}
	}

	public class GarageDoorOpenCommand:Command
	{
		GarageDoor garageDoor;
		public GarageDoorOpenCommand(GarageDoor door)
		{
			garageDoor = door;
		}

		public void Execute()
		{
			garageDoor.On();
		}
	}
	public class SimpleRemoteControl
	{
		Command slot;
		public SimpleRemoteControl() { }
		public void SetCommand(Command command)
		{
			slot = command;
		}

		public void ButtonWasPressed()
		{
			slot.Execute();
		}
	}
}
