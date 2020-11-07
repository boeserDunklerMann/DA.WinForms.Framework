using System;
using System.Collections.Generic;
using System.Text;

namespace DA.WinForms.Framework
{
	/// <ChangeLog>
	/// <Create Datum="07.11.2020" Entwickler="DA" />
	/// </ChangeLog>
	/// <summary>
	/// Interface for controls that are bindable
	/// </summary>
	public interface IBindableControl
	{
		/// <ChangeLog>
		/// <Create Datum="07.11.2020" Entwickler="DA" />
		/// </ChangeLog>
		/// <summary>
		/// Builds the databindings
		/// </summary>
		void Bind();

		/// <summary>
		/// the datasource for binding
		/// </summary>
		public Model.DataClassBase DataSource { get; set; }
	}
}