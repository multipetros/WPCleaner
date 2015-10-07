/*
 * WPCleaner Main Form Class Designer
 * Copyright (C) 2013, Petros Kyladitis
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
 
namespace WPCleaner{
	partial class MainForm{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.listBoxProfiles = new System.Windows.Forms.ListBox();
			this.buttonReload = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.buttonAbout = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBoxProfiles
			// 
			this.listBoxProfiles.FormattingEnabled = true;
			this.listBoxProfiles.Location = new System.Drawing.Point(12, 12);
			this.listBoxProfiles.Name = "listBoxProfiles";
			this.listBoxProfiles.Size = new System.Drawing.Size(282, 134);
			this.listBoxProfiles.TabIndex = 1;
			this.listBoxProfiles.SelectedIndexChanged += new System.EventHandler(this.ListBoxProfilesSelectedIndexChanged);
			// 
			// buttonReload
			// 
			this.buttonReload.Image = ((System.Drawing.Image)(resources.GetObject("buttonReload.Image")));
			this.buttonReload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonReload.Location = new System.Drawing.Point(12, 152);
			this.buttonReload.Name = "buttonReload";
			this.buttonReload.Size = new System.Drawing.Size(83, 28);
			this.buttonReload.TabIndex = 2;
			this.buttonReload.Text = "Reload";
			this.buttonReload.UseVisualStyleBackColor = true;
			this.buttonReload.Click += new System.EventHandler(this.ButtonReloadClick);
			// 
			// buttonDelete
			// 
			this.buttonDelete.Enabled = false;
			this.buttonDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Image")));
			this.buttonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDelete.Location = new System.Drawing.Point(101, 152);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(83, 28);
			this.buttonDelete.TabIndex = 3;
			this.buttonDelete.Text = "Delete";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
			// 
			// buttonAbout
			// 
			this.buttonAbout.Image = ((System.Drawing.Image)(resources.GetObject("buttonAbout.Image")));
			this.buttonAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonAbout.Location = new System.Drawing.Point(234, 152);
			this.buttonAbout.Name = "buttonAbout";
			this.buttonAbout.Size = new System.Drawing.Size(60, 28);
			this.buttonAbout.TabIndex = 4;
			this.buttonAbout.Text = "About";
			this.buttonAbout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonAbout.UseVisualStyleBackColor = true;
			this.buttonAbout.Click += new System.EventHandler(this.ButtonAboutClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(308, 188);
			this.Controls.Add(this.buttonAbout);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.buttonReload);
			this.Controls.Add(this.listBoxProfiles);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "WLAN Profile Cleaner";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ResumeLayout(false);
			//
			//Tooltips
			//
			System.Windows.Forms.ToolTip tip = new System.Windows.Forms.ToolTip() ;
			tip.SetToolTip(this.buttonAbout, "Show info about this program") ;
			tip.SetToolTip(this.buttonDelete, "Delete the selected WLAN profile") ;
			tip.SetToolTip(this.buttonReload, "Reload the list with stored WLAN profiles") ;
		}
		private System.Windows.Forms.Button buttonAbout;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.Button buttonReload;
		private System.Windows.Forms.ListBox listBoxProfiles;
	}
}