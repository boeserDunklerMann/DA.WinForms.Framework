using System;
using System.Collections.Generic;

namespace DA.WinForms.Framework.Commons
{
	/// <ChangeLog>
	/// <Create Datum="09.11.2020" Entwickler="DA" />
	/// </ChangeLog>
	/// <summary>
	/// Manages bindings between interface and implementations
	/// </summary>
	public static class DependencyContainer
	{
		private static HashSet<Tuple<Type, Type>> _container;
		private static int _containerCounter = 0;

		static DependencyContainer()
		{
			_container = new HashSet<Tuple<Type, Type>>();
		}

		/// <summary>
		/// Gets the implementation for a interface
		/// </summary>
		/// <typeparam name="TInterface">the interface</typeparam>
		/// <returns>the implementation</returns>
		public static TInterface GetObject<TInterface>()
		{
			if (0 == _containerCounter)
				CreateBindings();
			foreach (Tuple<Type, Type> bindings in _container)
			{
				if (bindings.Item1.Equals(typeof(TInterface)))
				{
					return (TInterface)Activator.CreateInstance(bindings.Item2, true);
				}
			}
			return default(TInterface);
		}

		/// <summary>
		/// Creates the list of all interface-implementation-associations
		/// </summary>
		internal static void CreateBindings()
		{
			// TODO: get this from a config
			//Bind(typeof(Contracts.IDatabase), typeof(Dba.MongoDb.BookService));
			Bind(typeof(Contracts.IDatabase), typeof(Dba.CouchDb.BookService));
		}

		internal static void Bind(Type interfaceType, Type implementation)
		{
			_container.Add(new Tuple<Type, Type>(interfaceType, implementation));
			_containerCounter++;
		}

		/// <summary>
		/// Disposes the implementations
		/// </summary>
		public static void Dispose()
		{/*
			if (_container != null)
			{
				foreach (Tuple<Type, Type> binding in _container)
				{
					object obj = Activator.CreateInstance(binding.Item2, true);
					if (obj is IDisposable)
						((IDisposable)obj).Dispose();
				}
			}*/
		}
	}
}
