using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DA.WinForms.Framework
{
	/// <ChangeLog>
	/// <Create Datum="07.11.2020" Entwickler="DA" />
	/// </ChangeLog>
	/// <summary>
	/// Performance: Aufwändige Reflectorings nur 1x durchführen und dann in einem Cache ablegen
	/// </summary>
	public static class ReflectoringCache
	{
		sealed class TypeProp
		{
			public Type Type { get; set; }
			public PropertyInfo Property { get; set; }
			public TypeProp(Type type, PropertyInfo property)
			{
				Type = type;
				Property = property;
			}
		}

		private static List<TypeProp> properties;

		/// <summary>
		/// Analysiert das Assenbly, in dem sich die Klasse selbst befindet
		/// </summary>
		private static void AnalyzeAssembly()
		{
			Assembly assembly = Assembly.GetAssembly(typeof(ReflectoringCache));
			IEnumerable<Type> types = assembly.GetTypes().Where(t => typeof(DataClassBase).IsAssignableFrom(t));
			properties = new List<TypeProp>();
			foreach (Type type in types)
			{
				type.GetProperties().ToList().ForEach(p => properties.Add(new TypeProp(type, p)));
			}
		}

		/// <summary>
		/// Liefert Informationen zu einer Property
		/// </summary>
		/// <param name="type">Typ, zu dem die Property gehört</param>
		/// <param name="propName">Name der Property</param>
		/// <returns>Informationen zur Property</returns>
		public static PropertyInfo GetPropertyInfo(Type type, string propName)
		{
			if (properties == null)
				AnalyzeAssembly();
			return properties.FirstOrDefault(tp => tp.Type.FullName.Equals(type.FullName) &&
												   tp.Property.Name.Equals(propName))?.Property;
		}
	}
}