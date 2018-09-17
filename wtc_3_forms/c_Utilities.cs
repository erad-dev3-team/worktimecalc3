using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wtc_3_forms
{
	public static class c_Utilities
	{
		public static void showOnePanel(int selector, Panel[] panels)
		{
			hideAllPanels(panels);
			Panel p = panels[selector];

			p.Dock = DockStyle.Fill;
			p.Show();
		}

		public static void hideAllPanels(Panel[] panels)
		{
			foreach (Panel panel in panels)
			{
				panel.Hide();
				panel.Dock = DockStyle.None;
			}
		}

		//TODO: Make tool that gets format from file header bytes
		public static string getExtension(string filename)
		{
			if (filename.Substring(filename.LastIndexOf("\\")).Contains("."))
			{
				return filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
			}
			else
			{
				return "";
			}
		}

		public static FileContainer handleFiles(List<string> files)
		{
			FileContainer fc = new FileContainer();
			foreach (string s in files)
			{
				c_File cf = new c_File() { FilePath = s };
				cf.initializeFile();
				fc.Add(cf);
				/*
					if		(s.ToLower().EndsWith(".txt"))	{ }
					else if (s.ToLower().EndsWith(".html")
						||	 s.ToLower().EndsWith(".htm"))	{ }
					else if (s.ToLower().EndsWith(".rtf"))	{ }
					else if (s.ToLower().EndsWith(".pdf"))	{ }
				*/
			}

			return fc;
		}
	}
}
