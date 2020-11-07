using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;

namespace DA.WinForms.Framework
{
	/// <ChangeLog>
	/// <Create Datum="07.11.2020" Entwickler="DA" />
	/// </ChangeLog>
	/// <summary>
	/// Fills all Comboboxes of a control with <see cref="Attributes.ValidValuesAttribute"/>
	/// </summary>
	public static class ComboboxFiller
	{
		/// <ChangeLog>
		/// <Create Datum="07.11.2020" Entwickler="DA" />
		/// </ChangeLog>
		/// <summary>
		/// Fill all Comboboxes with ValidValues (after the comboboxes were bound!)
		/// </summary>
		public static void Fill(Control parentControl)
		{
			GetAllComboboxes(parentControl).Where(cbo => cbo.DataBindings.Count > 0).Select(c => new { ComboBox = c, Binding = c.DataBindings[0] })
				.ToList().ForEach(cb =>
			{
				PropertyInfo pi = cb.Binding.DataSource.GetType().GetProperties()
					.First(cbPropInfo => cbPropInfo.Name == cb.Binding.BindingMemberInfo.BindingMember);
				Attributes.ValidValuesAttribute vatt = pi.GetCustomAttribute<Attributes.ValidValuesAttribute>();
				if (vatt != null)
					cb.ComboBox.DataSource = vatt.ValidValues;
				cb.Binding.ReadValue();
			});
		}

		/// <ChangeLog>
		/// <Create Datum="07.11.2020" Entwickler="DA" />
		/// </ChangeLog>
		/// <summary>
		/// Finds all Comboboxes in control
		/// </summary>
		/// <param name="control">the parent control</param>
		/// <returns></returns>
		private static IEnumerable<ComboBox> GetAllComboboxes(Control control)
		{
			var ctls = control.Controls.Cast<Control>();
			return ctls.SelectMany(c => GetAllComboboxes(c))
					   .Concat(ctls)
					   .OfType<ComboBox>();
		}
	}
}