using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace DA.WinForms.Framework
{
	/// <ChangeLog>
	/// <Create Datum="07.11.2020" Entwickler="DA" />
	/// <Change Datum="08.11.2020" Entwickler="DA">ClearAllBindings added</Change>
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

		/// <ChangeLog>
		/// <Create Datum="07.11.2020" Entwickler="DA" />
		/// </ChangeLog>
		/// <summary>Creates the Binding</summary>
		/// <param name="propertyName">the properties name in the dataobject</param>
		/// <param name="control">the Control to which the property should bound to</param>
		/// <param name="isCurrency">is this a currency-value (for formatting purposes)</param>
		public void CreateBinding(string propertyName, Control control, bool isCurrency = false)
		{
			string controlsPropertyName = FindControlsPropertyName(control);
			if (controlsPropertyName != null)
			{
				PropertyInfo pi = ReflectoringCache.GetPropertyInfo(typeof(T), propertyName);
				Binding binding = null;
				if ((pi != null) &&
					(Nullable.GetUnderlyingType(pi.PropertyType) != null))
					binding = new Binding(controlsPropertyName, _dataSource, propertyName, true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
				else
					binding = new Binding(controlsPropertyName, _dataSource, propertyName);
				if (isCurrency)
				{
					binding.FormatString = "C";
				}
				control.DataBindings.Add(binding);
			}
		}

		/// <summary>
		/// Finds a senseful Property of a control which we can bind
		/// </summary>
		/// <param name="control"></param>
		/// <returns>the propertyname as string</returns>
		private string FindControlsPropertyName(Control control)
		{
			if ((control is TextBox)
				|| (control is ComboBox)
				)
				return "Text";
			if (control is CheckBox)
				return "Checked";
			return null;
		}

		/// <ChangeLog>
		/// <Create Datum="08.11.2020" Entwickler="DA" />
		/// </ChangeLog>
		/// <summary>
		/// Clears all bindings of a controls childcontrols
		/// </summary>
		public static void ClearAllBindings(Control parentControlToClear)
		{
			GetControlsAll(parentControlToClear).ToList().ForEach(c => c.DataBindings.Clear());
		}

		/// <ChangeLog>
		/// <Create Datum="08.11.2020" Entwickler="DA" />
		/// </ChangeLog>
		/// <summary>
		/// Retrieves all Controls, containig in a Form
		/// </summary>
		/// <param name="control"></param>
		/// <returns>List of all Controls</returns>
		public static IEnumerable<Control> GetControlsAll(Control control)
		{
			var controls = control.Controls.Cast<Control>();
			return controls.SelectMany(ctrl => GetControlsAll(ctrl))
						   .Concat(controls)
						   .Where(c => c.GetType() != typeof(ControlCollection));
		}
	}
}