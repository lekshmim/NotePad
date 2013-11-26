using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace MyNotepad
{
	/// <summary>
	/// Summary description for frmNotepad.
	/// </summary>
	public class frmNotepad : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenuNotepad;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemNew;
		private System.Windows.Forms.MenuItem menuItemOpen;
		private System.Windows.Forms.MenuItem menuItemSeparator1;
		private System.Windows.Forms.MenuItem menuItemSave;
		private System.Windows.Forms.MenuItem menuItemSaveAs;
		private System.Windows.Forms.MenuItem menuItemEdit;
		private System.Windows.Forms.MenuItem menuItemCut;
		private System.Windows.Forms.MenuItem menuItemCopy;
		private System.Windows.Forms.MenuItem menuItemPast;
		private System.Windows.Forms.MenuItem menuItemSelectAll;
		private System.Windows.Forms.MenuItem menuItemFormat;
		private System.Windows.Forms.MenuItem menuItemFont;
		private System.Windows.Forms.TextBox txtBody;
		private System.Windows.Forms.OpenFileDialog dlgOpenFile;
		private System.Windows.Forms.SaveFileDialog dlgSaveFile;
		private System.Windows.Forms.FontDialog dlgFont;

		private System.Windows.Forms.ContextMenu contextMenuTxtBody;
		private System.Windows.Forms.MenuItem ContextCut;
		private System.Windows.Forms.MenuItem ContextCopy;
		private System.Windows.Forms.MenuItem ContextPaste;
		private System.Windows.Forms.MenuItem ContextSeparator1;
		private System.Windows.Forms.MenuItem ContextSelectAll;
		private System.Windows.Forms.MenuItem ContextSeparator2;
		private System.Windows.Forms.MenuItem ContextFont;

		//used on create new document to create a number on the document name like
		//"myDoc0.txt", so when you create another one it will be "myDoc1.txt"
		private int m_intDocNumber = 0; 

		//Hold the file name that created or choosed
		//for the Save action, not "Save As..."
		private string m_strFileName = "";

		//Hold the DialogResult result
		//Ok or Cancel
		private DialogResult dlgResult;

		//Stream to write to the file
		private StreamWriter m_sw;

		//Check if the file is modified or not
        private bool m_bModified = false;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private MenuItem menuItem4;
        private MenuItem menuItem5;
        private MenuItem menuItem7;
        private MenuItem menuItem6;
        private IContainer components;

		public frmNotepad()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			CheckChanged(null,null);
			base.Dispose( disposing );
		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.mainMenuNotepad = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemNew = new System.Windows.Forms.MenuItem();
            this.menuItemOpen = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator1 = new System.Windows.Forms.MenuItem();
            this.menuItemSave = new System.Windows.Forms.MenuItem();
            this.menuItemSaveAs = new System.Windows.Forms.MenuItem();
            this.menuItemEdit = new System.Windows.Forms.MenuItem();
            this.menuItemCut = new System.Windows.Forms.MenuItem();
            this.menuItemCopy = new System.Windows.Forms.MenuItem();
            this.menuItemPast = new System.Windows.Forms.MenuItem();
            this.menuItemSelectAll = new System.Windows.Forms.MenuItem();
            this.menuItemFormat = new System.Windows.Forms.MenuItem();
            this.menuItemFont = new System.Windows.Forms.MenuItem();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.contextMenuTxtBody = new System.Windows.Forms.ContextMenu();
            this.ContextFont = new System.Windows.Forms.MenuItem();
            this.ContextSeparator2 = new System.Windows.Forms.MenuItem();
            this.ContextCut = new System.Windows.Forms.MenuItem();
            this.ContextCopy = new System.Windows.Forms.MenuItem();
            this.ContextPaste = new System.Windows.Forms.MenuItem();
            this.ContextSeparator1 = new System.Windows.Forms.MenuItem();
            this.ContextSelectAll = new System.Windows.Forms.MenuItem();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.dlgFont = new System.Windows.Forms.FontDialog();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenuNotepad
            // 
            this.mainMenuNotepad.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemEdit,
            this.menuItemFormat,
            this.menuItem1,
            this.menuItem3});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemNew,
            this.menuItemOpen,
            this.menuItemSeparator1,
            this.menuItemSave,
            this.menuItemSaveAs,
            this.menuItem7,
            this.menuItem6});
            this.menuItemFile.Text = "File";
            // 
            // menuItemNew
            // 
            this.menuItemNew.Index = 0;
            this.menuItemNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.menuItemNew.Text = "&New";
            this.menuItemNew.Click += new System.EventHandler(this.menuItemNew_Click);
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Index = 1;
            this.menuItemOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuItemOpen.Text = "&Open...";
            this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
            // 
            // menuItemSeparator1
            // 
            this.menuItemSeparator1.Index = 2;
            this.menuItemSeparator1.Text = "-";
            // 
            // menuItemSave
            // 
            this.menuItemSave.Enabled = false;
            this.menuItemSave.Index = 3;
            this.menuItemSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuItemSave.Text = "&Save";
            this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // menuItemSaveAs
            // 
            this.menuItemSaveAs.Index = 4;
            this.menuItemSaveAs.Text = "Save As...";
            this.menuItemSaveAs.Click += new System.EventHandler(this.menuItemSaveAs_Click);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.Index = 1;
            this.menuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemCut,
            this.menuItemCopy,
            this.menuItemPast,
            this.menuItemSelectAll});
            this.menuItemEdit.Text = "Edit";
            // 
            // menuItemCut
            // 
            this.menuItemCut.Index = 0;
            this.menuItemCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.menuItemCut.Text = "&Cut";
            this.menuItemCut.Click += new System.EventHandler(this.menuItemCut_Click);
            // 
            // menuItemCopy
            // 
            this.menuItemCopy.Index = 1;
            this.menuItemCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.menuItemCopy.Text = "&Copy";
            this.menuItemCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
            // 
            // menuItemPast
            // 
            this.menuItemPast.Index = 2;
            this.menuItemPast.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.menuItemPast.Text = "&Paste";
            this.menuItemPast.Click += new System.EventHandler(this.menuItemPast_Click);
            // 
            // menuItemSelectAll
            // 
            this.menuItemSelectAll.Index = 3;
            this.menuItemSelectAll.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
            this.menuItemSelectAll.Text = "&Select All";
            this.menuItemSelectAll.Click += new System.EventHandler(this.menuItemSelectAll_Click);
            // 
            // menuItemFormat
            // 
            this.menuItemFormat.Index = 2;
            this.menuItemFormat.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFont});
            this.menuItemFormat.Text = "Format";
            // 
            // menuItemFont
            // 
            this.menuItemFont.Index = 0;
            this.menuItemFont.Text = "Font...";
            this.menuItemFont.Click += new System.EventHandler(this.menuItemFont_Click);
            // 
            // txtBody
            // 
            this.txtBody.ContextMenu = this.contextMenuTxtBody;
            this.txtBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBody.Location = new System.Drawing.Point(0, 0);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBody.Size = new System.Drawing.Size(480, 381);
            this.txtBody.TabIndex = 0;
            this.txtBody.TextChanged += new System.EventHandler(this.txtBody_TextChanged);
            // 
            // contextMenuTxtBody
            // 
            this.contextMenuTxtBody.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ContextFont,
            this.ContextSeparator2,
            this.ContextCut,
            this.ContextCopy,
            this.ContextPaste,
            this.ContextSeparator1,
            this.ContextSelectAll});
            // 
            // ContextFont
            // 
            this.ContextFont.Index = 0;
            this.ContextFont.Text = "Font..";
            this.ContextFont.Click += new System.EventHandler(this.menuItemFont_Click);
            // 
            // ContextSeparator2
            // 
            this.ContextSeparator2.Index = 1;
            this.ContextSeparator2.Text = "-";
            // 
            // ContextCut
            // 
            this.ContextCut.Index = 2;
            this.ContextCut.Text = "Cut";
            this.ContextCut.Click += new System.EventHandler(this.menuItemCut_Click);
            // 
            // ContextCopy
            // 
            this.ContextCopy.Index = 3;
            this.ContextCopy.Text = "Copy";
            this.ContextCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
            // 
            // ContextPaste
            // 
            this.ContextPaste.Index = 4;
            this.ContextPaste.Text = "Paste";
            this.ContextPaste.Click += new System.EventHandler(this.menuItemPast_Click);
            // 
            // ContextSeparator1
            // 
            this.ContextSeparator1.Index = 5;
            this.ContextSeparator1.Text = "-";
            // 
            // ContextSelectAll
            // 
            this.ContextSelectAll.Index = 6;
            this.ContextSelectAll.Text = "Select All";
            this.ContextSelectAll.Click += new System.EventHandler(this.menuItemSelectAll_Click);
            // 
            // dlgSaveFile
            // 
            this.dlgSaveFile.FileName = "doc1";
            // 
            // dlgFont
            // 
            this.dlgFont.FontMustExist = true;
            this.dlgFont.ScriptsOnly = true;
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2});
            this.menuItem1.Text = "View";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "Status Bar";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 4;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4,
            this.menuItem5});
            this.menuItem3.Text = "Help";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 0;
            this.menuItem4.Text = "Help Topics";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.Text = "About Notepad";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 6;
            this.menuItem6.Text = "Exit";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 5;
            this.menuItem7.Text = "-";
            // 
            // frmNotepad
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(480, 381);
            this.Controls.Add(this.txtBody);
            this.Menu = this.mainMenuNotepad;
            this.Name = "frmNotepad";
            this.Text = "C# Simple Notepad";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmNotepad());
		}


		private void txtBody_TextChanged(object sender, System.EventArgs e)
		{
			m_bModified = true;
		}
		
		private void CheckChanged(object sender, System.EventArgs e)
		{
			if(m_bModified)
			{
				dlgResult = MessageBox.Show("Do you want to save?","Note",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
				if(dlgResult == DialogResult.Yes)
				{
					menuItemSave_Click(sender,e);
				}
			}
		}
	

		#region Implementation of the File Menu Items
		private void menuItemNew_Click(object sender, System.EventArgs e)
		{
			CheckChanged(sender,e);
			m_strFileName = "";
			txtBody.Clear();
			m_bModified = false;
		}

		private void menuItemSaveAs_Click(object sender, System.EventArgs e)
		{
		
			dlgSaveFile.FileName = "mydoc" + m_intDocNumber.ToString() + ".txt";
			dlgResult = dlgSaveFile.ShowDialog();
			
			if(dlgResult == DialogResult.Cancel)
				return;

			try
			{
				m_strFileName = dlgSaveFile.FileName;
				m_sw = new StreamWriter(m_strFileName);
				m_sw.Write (txtBody.Text);
				m_sw.Close();
				menuItemSave.Enabled = true;
				m_intDocNumber++;
				m_bModified = false;
				this.Text = "C# Simple Notepad: " + m_strFileName;
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void menuItemSave_Click(object sender, System.EventArgs e)
		{
			if(m_strFileName == "")
			{
				menuItemSaveAs_Click(sender,e);
				return;
			}
			m_sw = new StreamWriter(m_strFileName);
			m_sw.Write (txtBody.Text);
			m_sw.Close();
			m_bModified = false;
		}

		private void menuItemOpen_Click(object sender, System.EventArgs e)
		{
			CheckChanged(sender,e);
			dlgResult = dlgOpenFile.ShowDialog();

			if(dlgResult == DialogResult.Cancel)
				return;

			try
			{
				m_strFileName = dlgOpenFile.FileName;
				StreamReader sr = new StreamReader(m_strFileName);
				txtBody.Text = sr.ReadToEnd();
				sr.Close();
				m_bModified = false;
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		
		#endregion


		#region Implementation of the Edit Menu Items
		private void menuItemCut_Click(object sender, System.EventArgs e)
		{
			//put the selected Text in the Clipboard
			Clipboard.SetDataObject(txtBody.SelectedText);
			txtBody.SelectedText = ""; //reamove the selected text.. So you think it has been cut
		}

		private void menuItemCopy_Click(object sender, System.EventArgs e)
		{
			txtBody.Copy();
		}

		private void menuItemPast_Click(object sender, System.EventArgs e)
		{
			txtBody.Paste();
		}

		private void menuItemSelectAll_Click(object sender, System.EventArgs e)
		{
			txtBody.SelectAll();
		}

		#endregion

		private void menuItemFont_Click(object sender, System.EventArgs e)
		{
			dlgResult = dlgFont.ShowDialog();
			if(dlgResult == DialogResult.Cancel)
				return;
			
			FontFamily fmFontName = dlgFont.Font.FontFamily;
			float fFontSize = dlgFont.Font.Size;
			FontStyle fsStyle = dlgFont.Font.Style;
			Font font;
			try
			{
				font = new Font(fmFontName,fFontSize,txtBody.Font.Style ^ fsStyle);
				txtBody.Font = font;
			}
			catch(ArgumentException)
			{
				return;
			}
		}

        private void menuItem6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
	}
}
