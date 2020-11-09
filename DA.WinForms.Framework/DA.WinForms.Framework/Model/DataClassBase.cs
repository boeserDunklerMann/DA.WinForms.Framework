using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace DA.WinForms.Framework.Model
{
	/// <summary>
	/// abstrakte Basisklasse für die Modelle
	/// Die brauchen wir hier, damit wir in <see cref="ReflectoringCache"/> das Reflecton beschleunigen können
	/// </summary>
	/// <ChangeLog>
	/// <Create Datum="07.11.2020" Entwickler="DA" />
	/// </ChangeLog>
	public abstract class DataClassBase
	{
		/// <summary>
		/// List of my of properties (from derived class)
		/// </summary>
		private readonly List<PropertyInfo> _myProperties;
		public DataClassBase()
		{
			// Load propertyinfos here. They won't change in runtime
			_myProperties = GetType().GetProperties().ToList();
		}

		/// <summary>
		/// Validates our dataobject whether the props marked with <see cref="Attributes.ValidValuesAttribute"/> are valid.
		/// </summary>
		/// <returns></returns>
		public bool Validate()
		{
			bool retval = true;
			_myProperties.ForEach(pi =>
			{
				Attribute att = pi.GetCustomAttribute(typeof(Attributes.ValidValuesAttribute));
				if (att != null)
				{
					Attributes.ValidValuesAttribute vatt = att as Attributes.ValidValuesAttribute;
					object value = pi.GetValue(this);
					if (value != null &&
						(!vatt.ValidValues.ToList().Contains((string)value)))
						retval = false;
				}
			});
			return retval;
		}
	}
}
