using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace wtc_3_forms
{
	public partial class Form1 : Form
	{
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
			
			
			rtb_TextValue.Text = c_PdfReader.readPdfDocument(@"C:\Users\WolfyD\Desktop\iris__1_130_HU_2018-08-01_2018-08-31.pdf");
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


	}
}
