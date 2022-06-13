using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	public interface Subject
	{
		public void RegisterObserver(Observer o);

		public void RemoveObserver(Observer o);

		public void NotifyObservers();
	}

	public interface Observer
	{
		public void Update(float temp, float humidity, float pressure);
	}

	public interface DisplayElement
	{
		public void Display();
	}

	public class WeatherData : Subject
	{
		private ArrayList observers;
		private float temprature;
		private float humidity;
		private float pressure;

		public WeatherData()
		{
			observers = new ArrayList();
		}
		public void RegisterObserver(Observer o)
		{
			observers.Add(o);
		}

		public void RemoveObserver(Observer o)
		{
			observers.Remove(o);
		}

		public void NotifyObservers()
		{
			for(int i=0; i<observers.Count; i++)
			{
				var observer =  (Observer)observers[i];
				observer.Update(temprature, humidity, pressure);
			}
		}

		public void MeasurementsChanged()
		{
			NotifyObservers();
		}

		public void SetMeasurements(float temprature, float humidity, float pressure)
		{
			this.temprature = temprature;
			this.humidity = humidity;
			this.pressure = pressure;
			MeasurementsChanged();
		}
	}

	public class CurrentConditionDisplay : Observer, DisplayElement
	{
		private float temprature;
		private float humidity;
		private Subject weatherData;
		public CurrentConditionDisplay(Subject weatherData)
		{
			this.weatherData = weatherData;
			weatherData.RegisterObserver(this);
		}
		public void Display()
		{
			Console.WriteLine("Current Condition : " + temprature + " F degrees and " + humidity + "% humidity");
		}

		public void Update(float temp, float humidity, float pressure)
		{
			this.temprature = temp;
			this.humidity = humidity;
			Display();
		}
	}
}
