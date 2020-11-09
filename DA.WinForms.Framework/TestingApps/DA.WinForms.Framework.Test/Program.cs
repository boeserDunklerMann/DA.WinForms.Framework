using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA.WinForms.Framework.Test
{
	static class Program
	{
		/// <Change Datum="09.11.2020" Entwickler="DA">DependencyContainer.Dispose() added</Change>
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new BookForm());

			// cleanup the implementations in DependencyContainer
			Commons.DependencyContainer.Dispose();
		}
	}
}