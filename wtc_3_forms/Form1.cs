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
		public string inputString = "";
		public string[] exts = "pdf|txt|rtf|html|htm".Split('|');
		Panel[] panels = new Panel[5];

		public Form1()
		{
			InitializeComponent();

			Load += Form1_Load;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			panels = new Panel[]
			{
				p_Text,
				p_List,
				p_PDF,
				p_Save,
				p_Settings
			};

			test();
			//rtb_TextValue.Text = c_PdfReader.readPdfDocument(@"C:\Users\WolfyD\Desktop\iris__1_130_HU_2018-08-01_2018-08-31.pdf");
		}

		public void test()
		{
			c_File cf = new c_File() { FilePath = @"C:\Users\WolfyD\Desktop\iris__1_130_HU_2018-08-01_2018-08-31.pdf" };
			cf.initializeFile();
			Console.WriteLine(cf.ToString());


			c_File cf1 = new c_File() { FilePath = @"C:\Users\WolfyD\Desktop\headers\List of file formats - Wikipedia.htm" };
			cf1.initializeFile();
			Console.WriteLine(cf1.ToString());
		}

		private void btn_ChangePanels(object sender, EventArgs e)
		{
			string s = (sender as ToolStripButton).Tag.ToString().Split(';')[0];
			showOnePanel(Convert.ToInt32(s));
		}

		public void showOnePanel(int selector)
		{
			hideAllPanels();
			Panel p = panels[selector];
			
			p.Dock = DockStyle.Fill;
			p.Show();
		}

		public void hideAllPanels()
		{
			foreach (Panel panel in panels)
			{
				panel.Hide();
				panel.Dock = DockStyle.None;
			}
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

		//TODO: Make tool that gets format from file header bytes
		public string getExtension(string filename)
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

		public void handleFiles(List<string> files)
		{
			foreach(string s in files)
			{
				if (s.ToLower().EndsWith(".txt"))		{ }
				else if (s.ToLower().EndsWith(".html")
					||	 s.ToLower().EndsWith(".htm"))	{ }
				else if (s.ToLower().EndsWith(".rtf"))	{ }
				else if (s.ToLower().EndsWith(".pdf"))	{ }
			}
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
							if (exts.Contains(getExtension(s))){ files.Add(s); }
						}
						
						if(files.Count > 0) { handleFiles(files); }
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
