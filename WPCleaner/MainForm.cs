/*
 * WPCleaner Main Form Class
 * Copyright (C) 2013, Petros Kyladitis
 * 
 * This program is free software distributed under the GNU GPL 3,
 * for license details see at 'license.txt' file, distributed with
 * this project, or see at <http://www.gnu.org/licenses/>.
 */
 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WPCleaner{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form{
		public MainForm(){
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		
		private Netsh profiles ;
		private bool noProfiles ; //used to determinate if no profiles found
		
		void MainFormLoad(object sender, EventArgs e){
			LoadProfiles() ; //load profiles when form load
		}
		
		void ButtonReloadClick(object sender, EventArgs e){
			listBoxProfiles.Items.Clear() ; //clear the list before add the new profiles
			LoadProfiles() ;
		}
		
		void LoadProfiles(){
			try{
				if(profiles == null)
					profiles = new Netsh() ;
				else
					profiles.LoadProfiles() ;
				listBoxProfiles.Items.AddRange(profiles.Profiles) ;
				listBoxProfiles.SetSelected(0, true) ;
				noProfiles = false ;
			}
			//on errors set noProfiles to true and add apropriate 
			//error message as item to the names list
			catch(System.ComponentModel.Win32Exception){
				noProfiles = true ;
				listBoxProfiles.Items.Add(" -- netsh tool not at your system --") ;
			}
			catch(NoProfilesException){
				noProfiles = true ;
				listBoxProfiles.Items.Add(" -- No WLAN profiles found --") ;
			}	
		}
		
		void ButtonDeleteClick(object sender, EventArgs e){
			try{
				profiles.DeleteProfile(listBoxProfiles.SelectedItem.ToString()) ; // for deletion demo add coms to the begin
			}catch(Exception exc){
				MessageBox.Show(exc.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error) ;
				listBoxProfiles.Items.Clear() ;
				LoadProfiles() ;
				return ;
			}
			//remove the selected item from the list and set selected the item below
			//if selected item is the last, set selected the item above
			int selected = listBoxProfiles.SelectedIndex ;
			listBoxProfiles.Items.RemoveAt(listBoxProfiles.SelectedIndex) ;
			if(selected > 0 && selected < listBoxProfiles.Items.Count)
				listBoxProfiles.SetSelected(selected, true) ;
			else if(selected == listBoxProfiles.Items.Count && listBoxProfiles.Items.Count > 0)
				listBoxProfiles.SetSelected(listBoxProfiles.Items.Count-1, true) ;
			else if(selected == 0 && listBoxProfiles.Items.Count >= 1)
				listBoxProfiles.SetSelected(0, true) ;
		}
		
		void ListBoxProfilesSelectedIndexChanged(object sender, EventArgs e){
			//if nothing selected from the list, or there are no profiles found disable the delete button
			if(listBoxProfiles.SelectedIndex == -1 || noProfiles)
				buttonDelete.Enabled = false ;
			else
				buttonDelete.Enabled = true ;
		}
		
		void ButtonAboutClick(object sender, EventArgs e){
			MessageBox.Show("WLAN Profile Cleaner - version 1.0\nCopyright (c) 2013, Petros Kyladitis\n\nThis program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.\n\nThis program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.\n\nYou should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.","About WPCleaner...", MessageBoxButtons.OK, MessageBoxIcon.Information) ;
		}
	}
}