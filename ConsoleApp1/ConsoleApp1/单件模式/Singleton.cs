using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
	public class Singleton
	{
		//private static Singleton uniqueSingleton;
		private static Singleton uniqueSingleton = new Singleton();
		private Singleton() { }
		
		//如果使用多线程的话，可能会产生两个实例
		//同时同步会造成性能下降严重
		//public static Singleton GetInstance()
		//{
		//	lock(uniqueSingleton)
		//	{
		//		if (uniqueSingleton == null)
		//		{
		//			uniqueSingleton = new Singleton();
		//		}
		//		return uniqueSingleton;
		//	}
		//}

		//急切实例化的方法
		public static Singleton GetInstance()
		{
			return uniqueSingleton;
		}
	}
}
