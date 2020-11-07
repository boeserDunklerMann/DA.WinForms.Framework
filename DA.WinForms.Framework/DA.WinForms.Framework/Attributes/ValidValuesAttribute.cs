using System;

namespace DA.WinForms.Framework.Attributes
{
	/// <ChangeLog>
	/// <Create Datum="07.11.2020" Entwickler="DA" />
	/// </ChangeLog>
	/// <summary>
	/// Attribute for Properties, that can only have a defined set of valid attributes, used for Comboboxes (to fill their values)
	/// </summary>
	[AttributeUsage (AttributeTargets.Property, AllowMultiple =true)]
	public sealed class ValidValuesAttribute : Attribute
	{
		/// <ChangeLog>
			/// <Create Datum="07.11.2020" Entwickler="DA" />
			/// </ChangeLog>
			/// <summary>
			/// allowed Values
			/// </summary>
		public string[] ValidValues { get; private set; }

		/// <ChangeLog>
			/// <Create Datum="07.11.2020" Entwickler="DA" />
			/// </ChangeLog>
			/// <summary>
			/// Defines the valid Values for a Property
			/// </summary>
			/// <param name="validValues">Values that are possible</param>
		public ValidValuesAttribute(params string[] validValues)
		{
			ValidValues = validValues;
		}
	}
}