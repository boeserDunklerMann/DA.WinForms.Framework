using System;
using System.Reflection;
using System.Windows.Forms;

namespace DA.WinForms.Framework
{
	/// <ChangeLog>
	/// <Create Datum="07.11.2020" Entwickler="DA" />
	/// </ChangeLog>
	/// <summary>
	/// Klasse zum Erstellen von WinForms-Data-Bindings
	/// Class for creating WinForms-data-bindings
	/// </summary>
	/// <typeparam name="T">type of datasource</typeparam>
	public sealed class BindingCreator<T>
	{
		private readonly object _dataSource;
		/// <ChangeLog>
		/// <Create Datum="07.11.2020" Entwickler="DA" />
		/// </ChangeLog>
		public BindingCreator(object dataSource)
		{
			_dataSource = dataSource;
		}

		/// <ChangeLog>
		/// <Create Datum="07.11.2020" Entwickler="DA" />
		/// </ChangeLog>
		/// <summary>Creates the Binding</summary>
		/// <param name="propertyName">the properties name in the dataobject</param>
		/// <param name="isCurrency">is this a currency-value (for formatting purposes)</param>
		public Binding CreateBinding(string propertyName, bool isCurrency = false)
		{
			PropertyInfo pi = ReflectoringCache.GetPropertyInfo(typeof(T), propertyName);
			Binding retval = null;
			if ((pi != null) &&
				(Nullable.GetUnderlyingType(pi.PropertyType) != null))
				retval = new Binding("Text", _dataSource, propertyName, true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
			else
				retval = new Binding("Text", _dataSource, propertyName);
			if (isCurrency)
			{
				retval.FormatString = "C";
			}
			return retval;
		}
	}
}