using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;


namespace wtc_3_forms
{
	public partial class Form1 : Form
	{
		public string			inputString		= "";
		public string[]			exts			= "pdf|txt|rtf|html|htm".Split('|');
		public Panel[]			panels			= new Panel[5];
		public FileContainer	fc				= new FileContainer();

		public Form1()
		{
			InitializeComponent();

			Load += Form1_Load;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
#region DEBUG
#if DEBUG
			//Testing in debug mode!
			test();
#endif
#endregion
			panels = new Panel[]
			{
				p_Text,
				p_List,
				p_PDF,
				p_Save,
				p_Settings
			};
		}

		public void test()
		{
			Console.WriteLine("Debug started - WTC v3 WinForms...");
			bool nofile = false;
			if (!Directory.Exists("test")) { Directory.CreateDirectory("test"); nofile = true; }
			if (nofile || !File.Exists(@"test\iris.html")) { File.WriteAllText(@"test\iris.html", Properties.Resources.iris_html); Console.WriteLine("File 'iris.html' copied to 'test'..."); }
			if (nofile || !File.Exists(@"test\iris.txt")) { File.WriteAllText(@"test\iris.txt", Properties.Resources.iris_txt); Console.WriteLine("File 'iris.txt' copied to 'test'..."); }
			if (nofile || !File.Exists(@"test\iris.rtf")) { File.WriteAllText(@"test\iris.rtf", Properties.Resources.iris_rtf); Console.WriteLine("File 'iris.rtf' copied to 'test'..."); }
			if (nofile || !File.Exists(@"test\iris.pdf")) { File.WriteAllBytes(@"test\iris.pdf", Properties.Resources.iris_pdf); Console.WriteLine("File 'iris.pdf' copied to 'test'..."); }


			c_File cf = new c_File() { FilePath = @"test\iris.pdf" };
			cf.initializeFile();
			Console.WriteLine("-|OUTPUT pdf|-->" + cf.FileTextContents);
			Console.WriteLine(cf.ToFullString());


			c_File cf1 = new c_File() { FilePath = @"test\iris.txt" };
			cf1.initializeFile();
			Console.WriteLine("-|OUTPUT txt|-->" + cf1.FileTextContents);
			Console.WriteLine(cf1.ToFullString());


			c_File cf2 = new c_File() { FilePath = @"test\iris.rtf" };
			cf2.initializeFile();
			Console.WriteLine("-|OUTPUT rtf|-->" + cf2.FileTextContents);
			Console.WriteLine(cf2.ToFullString());


			c_File cf3 = new c_File() { FilePath = @"test\iris.html" };
			cf3.initializeFile();
			Console.WriteLine("-|OUTPUT html|-->" + cf3.FileTextContents);
			Console.WriteLine(cf3.ToFullString());
		}

		private void btn_ChangePanels(object sender, EventArgs e)
		{
			string s = (sender as ToolStripButton).Tag.ToString().Split(';')[0];
			c_Utilities.showOnePanel(Convert.ToInt32(s), panels);
		}
		
		private void Form1_DragEnter(object sender, DragEventArgs e)
		{
			IEnumerable<string> ss = from x in e.Data.GetFormats() where x is "Text" || x is "FileName" select x;
			if(ss.Count() > 0) { e.Effect = DragDropEffects.All; }
			else { e.Effect = DragDropEffects.None; }
		}

		private void Form1_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if (e.EscapePressed) { e.Action = DragAction.Cancel; }
		}

		private void Form1_DragDrop(object sender, DragEventArgs e)
		{
			if (e.AllowedEffect != DragDropEffects.None)
			{
				var b = e.Data.GetDataPresent(DataFormats.FileDrop, false);
				var c = e.Data.GetDataPresent(DataFormats.Text, false);
				
				List<string> files = new List<string>();

				if (b)
				{
					string[] v = e.Data.GetData(DataFormats.FileDrop, false) as string[];
					if (v != null)
					{
						foreach (string s in v)
						{
							if (exts.Contains(c_Utilities.getExtension(s))){ files.Add(s); }
						}
						
						if(files.Count > 0) { fc.AddRange(c_Utilities.handleFiles(files)); }
					}
				}
				else if (c)
				{
					inputString = e.Data.GetData(DataFormats.Text, false) as string;
				}
				else
				{
					e.Effect = DragDropEffects.None;
				}
			}
		}
	}
}
