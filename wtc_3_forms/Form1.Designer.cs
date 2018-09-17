namespace wtc_3_forms
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.ss_Status = new System.Windows.Forms.StatusStrip();
			this.ts_Tools = new System.Windows.Forms.ToolStrip();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.ts_Switcher = new System.Windows.Forms.ToolStrip();
			this.btn_TS_TextValue = new System.Windows.Forms.ToolStripButton();
			this.btn_TS_ListView = new System.Windows.Forms.ToolStripButton();
			this.btn_TS_PDFView = new System.Windows.Forms.ToolStripButton();
			this.btn_TS_Save = new System.Windows.Forms.ToolStripButton();
			this.btn_TS_Settings = new System.Windows.Forms.ToolStripButton();
			this.p_Text = new System.Windows.Forms.Panel();
			this.rtb_TextValue = new System.Windows.Forms.RichTextBox();
			this.p_PDF = new System.Windows.Forms.Panel();
			this.p_Save = new System.Windows.Forms.Panel();
			this.p_Settings = new System.Windows.Forms.Panel();
			this.p_List = new System.Windows.Forms.Panel();
			this.btn_ToolBar_Options = new System.Windows.Forms.ToolStripButton();
			this.btn_ToolBar_Help = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.p_About = new System.Windows.Forms.Panel();
			this.p_FileDrag = new System.Windows.Forms.Panel();
			this.p_Help = new System.Windows.Forms.Panel();
			this.p_Logs = new System.Windows.Forms.Panel();
			this.ts_Tools.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.ts_Switcher.SuspendLayout();
			this.p_Text.SuspendLayout();
			this.SuspendLayout();
			// 
			// ss_Status
			// 
			this.ss_Status.Location = new System.Drawing.Point(0, 428);
			this.ss_Status.Name = "ss_Status";
			this.ss_Status.Size = new System.Drawing.Size(800, 22);
			this.ss_Status.TabIndex = 0;
			// 
			// ts_Tools
			// 
			this.ts_Tools.BackColor = System.Drawing.Color.Transparent;
			this.ts_Tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts_Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_ToolBar_Help,
            this.btn_ToolBar_Options,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
			this.ts_Tools.Location = new System.Drawing.Point(0, 0);
			this.ts_Tools.Name = "ts_Tools";
			this.ts_Tools.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.ts_Tools.Size = new System.Drawing.Size(800, 25);
			this.ts_Tools.TabIndex = 1;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.p_Logs);
			this.splitContainer1.Panel1.Controls.Add(this.p_Help);
			this.splitContainer1.Panel1.Controls.Add(this.p_FileDrag);
			this.splitContainer1.Panel1.Controls.Add(this.p_About);
			this.splitContainer1.Panel1.Controls.Add(this.ts_Switcher);
			this.splitContainer1.Panel1.Controls.Add(this.p_Text);
			this.splitContainer1.Panel1.Controls.Add(this.p_PDF);
			this.splitContainer1.Panel1.Controls.Add(this.p_Save);
			this.splitContainer1.Panel1.Controls.Add(this.p_Settings);
			this.splitContainer1.Panel1.Controls.Add(this.p_List);
			this.splitContainer1.Size = new System.Drawing.Size(800, 403);
			this.splitContainer1.SplitterDistance = 596;
			this.splitContainer1.TabIndex = 2;
			// 
			// ts_Switcher
			// 
			this.ts_Switcher.BackColor = System.Drawing.Color.Transparent;
			this.ts_Switcher.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts_Switcher.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_TS_TextValue,
            this.btn_TS_ListView,
            this.btn_TS_PDFView,
            this.btn_TS_Save,
            this.btn_TS_Settings});
			this.ts_Switcher.Location = new System.Drawing.Point(0, 0);
			this.ts_Switcher.Name = "ts_Switcher";
			this.ts_Switcher.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.ts_Switcher.Size = new System.Drawing.Size(596, 25);
			this.ts_Switcher.TabIndex = 5;
			this.ts_Switcher.Text = "ts_Tools";
			// 
			// btn_TS_TextValue
			// 
			this.btn_TS_TextValue.Image = ((System.Drawing.Image)(resources.GetObject("btn_TS_TextValue.Image")));
			this.btn_TS_TextValue.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_TS_TextValue.Margin = new System.Windows.Forms.Padding(6, 1, 0, 2);
			this.btn_TS_TextValue.Name = "btn_TS_TextValue";
			this.btn_TS_TextValue.Size = new System.Drawing.Size(81, 22);
			this.btn_TS_TextValue.Tag = "0;{{BTN_TS_TEXT_VALUE}}";
			this.btn_TS_TextValue.Text = "Text Value";
			this.btn_TS_TextValue.Click += new System.EventHandler(this.btn_ChangePanels);
			// 
			// btn_TS_ListView
			// 
			this.btn_TS_ListView.Image = ((System.Drawing.Image)(resources.GetObject("btn_TS_ListView.Image")));
			this.btn_TS_ListView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_TS_ListView.Name = "btn_TS_ListView";
			this.btn_TS_ListView.Size = new System.Drawing.Size(85, 22);
			this.btn_TS_ListView.Tag = "1;{{BTN_TS_LISTED_DATA}}";
			this.btn_TS_ListView.Text = "Listed Data";
			this.btn_TS_ListView.ToolTipText = "List View";
			this.btn_TS_ListView.Click += new System.EventHandler(this.btn_ChangePanels);
			// 
			// btn_TS_PDFView
			// 
			this.btn_TS_PDFView.Image = ((System.Drawing.Image)(resources.GetObject("btn_TS_PDFView.Image")));
			this.btn_TS_PDFView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_TS_PDFView.Name = "btn_TS_PDFView";
			this.btn_TS_PDFView.Size = new System.Drawing.Size(76, 22);
			this.btn_TS_PDFView.Tag = "2;{{BTN_TS_PDF}}";
			this.btn_TS_PDFView.Text = "View PDF";
			this.btn_TS_PDFView.Click += new System.EventHandler(this.btn_ChangePanels);
			// 
			// btn_TS_Save
			// 
			this.btn_TS_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_TS_Save.Image")));
			this.btn_TS_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_TS_Save.Name = "btn_TS_Save";
			this.btn_TS_Save.Size = new System.Drawing.Size(78, 22);
			this.btn_TS_Save.Tag = "3;{{BTN_TS_SAVE}}";
			this.btn_TS_Save.Text = "Save Data";
			this.btn_TS_Save.Click += new System.EventHandler(this.btn_ChangePanels);
			// 
			// btn_TS_Settings
			// 
			this.btn_TS_Settings.Image = ((System.Drawing.Image)(resources.GetObject("btn_TS_Settings.Image")));
			this.btn_TS_Settings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_TS_Settings.Name = "btn_TS_Settings";
			this.btn_TS_Settings.Size = new System.Drawing.Size(69, 22);
			this.btn_TS_Settings.Tag = "4;{{BTN_TS_SETTINGS}}";
			this.btn_TS_Settings.Text = "Settings";
			this.btn_TS_Settings.Click += new System.EventHandler(this.btn_ChangePanels);
			// 
			// p_Text
			// 
			this.p_Text.BackColor = System.Drawing.Color.AntiqueWhite;
			this.p_Text.Controls.Add(this.rtb_TextValue);
			this.p_Text.Location = new System.Drawing.Point(29, 44);
			this.p_Text.Name = "p_Text";
			this.p_Text.Size = new System.Drawing.Size(50, 50);
			this.p_Text.TabIndex = 0;
			this.p_Text.Tag = "0;{{PANEL_TEXT_VALUE}}";
			this.p_Text.Visible = false;
			// 
			// rtb_TextValue
			// 
			this.rtb_TextValue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtb_TextValue.Location = new System.Drawing.Point(0, 0);
			this.rtb_TextValue.Name = "rtb_TextValue";
			this.rtb_TextValue.Size = new System.Drawing.Size(50, 50);
			this.rtb_TextValue.TabIndex = 0;
			this.rtb_TextValue.Text = "";
			// 
			// p_PDF
			// 
			this.p_PDF.BackColor = System.Drawing.Color.Coral;
			this.p_PDF.Location = new System.Drawing.Point(29, 156);
			this.p_PDF.Name = "p_PDF";
			this.p_PDF.Size = new System.Drawing.Size(50, 50);
			this.p_PDF.TabIndex = 4;
			this.p_PDF.Tag = "2;{{PANEL_SHOW_PDF}}";
			this.p_PDF.Visible = false;
			// 
			// p_Save
			// 
			this.p_Save.BackColor = System.Drawing.SystemColors.ControlLight;
			this.p_Save.Location = new System.Drawing.Point(85, 100);
			this.p_Save.Name = "p_Save";
			this.p_Save.Size = new System.Drawing.Size(50, 50);
			this.p_Save.TabIndex = 3;
			this.p_Save.Tag = "3;{{PANEL_SAVE}}";
			this.p_Save.Visible = false;
			// 
			// p_Settings
			// 
			this.p_Settings.BackColor = System.Drawing.Color.Honeydew;
			this.p_Settings.Location = new System.Drawing.Point(85, 44);
			this.p_Settings.Name = "p_Settings";
			this.p_Settings.Size = new System.Drawing.Size(50, 50);
			this.p_Settings.TabIndex = 2;
			this.p_Settings.Tag = "4;{{PANEL_SETTINGS}}";
			this.p_Settings.Visible = false;
			// 
			// p_List
			// 
			this.p_List.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.p_List.Location = new System.Drawing.Point(29, 100);
			this.p_List.Name = "p_List";
			this.p_List.Size = new System.Drawing.Size(50, 50);
			this.p_List.TabIndex = 1;
			this.p_List.Tag = "1;{{PANEL_LISTED_DATA}}";
			this.p_List.Visible = false;
			// 
			// btn_ToolBar_Options
			// 
			this.btn_ToolBar_Options.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_ToolBar_Options.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btn_ToolBar_Options.Image = ((System.Drawing.Image)(resources.GetObject("btn_ToolBar_Options.Image")));
			this.btn_ToolBar_Options.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_ToolBar_Options.Name = "btn_ToolBar_Options";
			this.btn_ToolBar_Options.Size = new System.Drawing.Size(23, 22);
			this.btn_ToolBar_Options.Text = "toolStripButton1";
			// 
			// btn_ToolBar_Help
			// 
			this.btn_ToolBar_Help.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_ToolBar_Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btn_ToolBar_Help.Image = ((System.Drawing.Image)(resources.GetObject("btn_ToolBar_Help.Image")));
			this.btn_ToolBar_Help.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_ToolBar_Help.Name = "btn_ToolBar_Help";
			this.btn_ToolBar_Help.Size = new System.Drawing.Size(23, 22);
			this.btn_ToolBar_Help.Text = "toolStripButton2";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "toolStripButton1";
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton2.Text = "toolStripButton2";
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton3.Text = "toolStripButton3";
			// 
			// p_About
			// 
			this.p_About.BackColor = System.Drawing.Color.LightCyan;
			this.p_About.Location = new System.Drawing.Point(85, 156);
			this.p_About.Name = "p_About";
			this.p_About.Size = new System.Drawing.Size(50, 50);
			this.p_About.TabIndex = 6;
			this.p_About.Tag = "5;{{PANEL_ABOUT}}";
			this.p_About.Visible = false;
			// 
			// p_FileDrag
			// 
			this.p_FileDrag.BackColor = System.Drawing.Color.LightYellow;
			this.p_FileDrag.Location = new System.Drawing.Point(29, 347);
			this.p_FileDrag.Name = "p_FileDrag";
			this.p_FileDrag.Size = new System.Drawing.Size(50, 50);
			this.p_FileDrag.TabIndex = 7;
			this.p_FileDrag.Tag = "10;{{PANEL_FILEDRAG}}";
			this.p_FileDrag.Visible = false;
			// 
			// p_Help
			// 
			this.p_Help.BackColor = System.Drawing.Color.LightPink;
			this.p_Help.Location = new System.Drawing.Point(141, 156);
			this.p_Help.Name = "p_Help";
			this.p_Help.Size = new System.Drawing.Size(50, 50);
			this.p_Help.TabIndex = 7;
			this.p_Help.Tag = "6;{{PANEL_HELP}}";
			this.p_Help.Visible = false;
			// 
			// p_Logs
			// 
			this.p_Logs.BackColor = System.Drawing.Color.MediumOrchid;
			this.p_Logs.Location = new System.Drawing.Point(141, 100);
			this.p_Logs.Name = "p_Logs";
			this.p_Logs.Size = new System.Drawing.Size(50, 50);
			this.p_Logs.TabIndex = 8;
			this.p_Logs.Tag = "6;{{PANEL_LOGS}}";
			this.p_Logs.Visible = false;
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.ts_Tools);
			this.Controls.Add(this.ss_Status);
			this.Name = "Form1";
			this.Text = "WorkTimeCalc 3";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.Form1_QueryContinueDrag);
			this.ts_Tools.ResumeLayout(false);
			this.ts_Tools.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ts_Switcher.ResumeLayout(false);
			this.ts_Switcher.PerformLayout();
			this.p_Text.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip ss_Status;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel p_Text;
		private System.Windows.Forms.RichTextBox rtb_TextValue;
		private System.Windows.Forms.Panel p_PDF;
		private System.Windows.Forms.Panel p_Save;
		private System.Windows.Forms.Panel p_Settings;
		private System.Windows.Forms.Panel p_List;
		private System.Windows.Forms.ToolStrip ts_Switcher;
		private System.Windows.Forms.ToolStrip ts_Tools;
		private System.Windows.Forms.ToolStripButton btn_TS_TextValue;
		private System.Windows.Forms.ToolStripButton btn_TS_ListView;
		private System.Windows.Forms.ToolStripButton btn_TS_PDFView;
		private System.Windows.Forms.ToolStripButton btn_TS_Save;
		private System.Windows.Forms.ToolStripButton btn_TS_Settings;
		private System.Windows.Forms.ToolStripButton btn_ToolBar_Options;
		private System.Windows.Forms.ToolStripButton btn_ToolBar_Help;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.Panel p_About;
		private System.Windows.Forms.Panel p_FileDrag;
		private System.Windows.Forms.Panel p_Help;
		private System.Windows.Forms.Panel p_Logs;
	}
}

