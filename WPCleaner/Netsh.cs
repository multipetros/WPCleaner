/*
 * WPCleaner Netsh Class
 * Copyright (C) 2013, Petros Kyladitis
 * 
 * This program is free software distributed under the GNU GPL 3,
 * for license details see at 'license.txt' file, distributed with
 * this project, or see at <http://www.gnu.org/licenses/>.
 */
 
using System ;
using System.Collections ;
using System.Diagnostics ;

namespace WPCleaner{
	/// <summary>
	/// Description of Netsh.
	/// </summary>
	public class Netsh{
		private ArrayList profiles ; //list of stored wlan profiles names
		
		// Consants
		private const string NETSH_EXE = "netsh" ;
		private const string SHOW_PROFILES_ARGS = "wlan show profiles" ;
		private const string DELETE_ARGS = "wlan delete profile name=" ;
		private const string LEADIN_DELIMITER = " :" ;
		private const string LEADOUT_DELIMITER = "\r\n" ;
		
		/// <summary>
		/// Default object contructor. Loading the stored profiles list.
		/// </summary>
		public Netsh(){
			profiles = new ArrayList() ;
			LoadProfiles() ;
		}
		
		/// <summary>
		/// A string array with the stored wlan profiles names
		/// </summary>
		public string[] Profiles{
			get{
				return (string[]) profiles.ToArray(typeof(string)) ;
			}
		}
		
		/// <summary>
		/// Load the stored wlan profiles names
		/// </summary>
		public void LoadProfiles(){
			profiles.Clear() ; //clear the profiles list
			
			string netshOutput = RunNetsh(SHOW_PROFILES_ARGS) ;
			
			//parse each profile name and add it to the profiles list
			int profileLeadIn = netshOutput.IndexOf(LEADIN_DELIMITER) ; //start position of the name
			int profileLeadOut ; //end position of the name
			while(profileLeadIn != -1){ //while profile leadins found
				profileLeadIn += LEADIN_DELIMITER.Length ; //find actual start pos by adding the delimeter length
				profileLeadOut = netshOutput.IndexOf(LEADOUT_DELIMITER, profileLeadIn) ;
				if(profileLeadOut != -1){ 
					//if profile leadout found extract and store the name to the list
					profiles.Add(netshOutput.Substring(profileLeadIn, profileLeadOut - profileLeadIn).Trim()) ;
				}else{
					//if no leadout found and no profile in the list throw exception
					if(profiles.Count == 0)
						throw new NoProfilesException("No wlan profiles stored") ;
				}
				//find the next profile leadin
				profileLeadIn = netshOutput.IndexOf(LEADIN_DELIMITER, profileLeadOut) ;
			}
		}
		
		/// <summary>
		/// Remove a wlan profile from the stored list
		/// </summary>
		/// <param name="name">Wlan's profile name</param>
		public void DeleteProfile(string name){
			//if the name not found in the profiles list throw a new exception
			if(profiles.IndexOf(name) == -1){
				throw new ProfileNameNotExistException("No profile called " + name + " exist at wlan profiles list") ;
			}
			RunNetsh(DELETE_ARGS + "\"" + name + "\"") ;
			profiles.Remove(name) ; //remove the profile from the profiles list
		}
		
		/// <summary>
		/// Start a hidden netsh process with the given arguments with stdout redirection
		/// </summary>
		/// <param name="args">Arguments to pass to the netsh call</param>
		/// <returns>The netsh output</returns>
		private string RunNetsh(string args){
			Process netshProc = new Process() ;
			netshProc.StartInfo.FileName = NETSH_EXE ;
			netshProc.StartInfo.Arguments = args ;
			//don't create a visible cmd window
			netshProc.StartInfo.CreateNoWindow = true ;
			netshProc.StartInfo.UseShellExecute = false ;
			//redirect the stdout from the console to program
			netshProc.StartInfo.RedirectStandardOutput = true ;
			//convert the console encoding to unicode
			netshProc.StartInfo.StandardOutputEncoding = System.Text.Encoding.GetEncoding(GetConsoleCodepage()) ;
			netshProc.Start() ;
			netshProc.WaitForExit() ;
			//read the redirected stdout string and return it
			return netshProc.StandardOutput.ReadToEnd() ;			
		}		
	
		//import kernel function to determinate system console codepage
		[System.Runtime.InteropServices.DllImport("kernel32.dll")]
		public static extern int GetSystemDefaultLCID();
		
		/// <summary>
		/// Use the external GetSystemDefaultLCID method to determinate the current console code page
		/// </summary>
		/// <returns>The current console code page number</returns>
		private int GetConsoleCodepage(){
			int lcid = GetSystemDefaultLCID();
			System.Globalization.CultureInfo sysCulture = System.Globalization.CultureInfo.GetCultureInfo(lcid);
			return sysCulture.TextInfo.OEMCodePage;			
		}
	}
	
	/// <summary>
	/// Exception class for no wlan stored profiles found
	/// </summary>
	public class NoProfilesException : Exception{
		public NoProfilesException() { }
		public NoProfilesException(string message) : base(message) { }
		public NoProfilesException(string message, Exception innerException) : base(message, innerException) { }
	}
	
	/// <summary>
	/// Exception class for stored wlan profile name not exist
	/// </summary>
	public class ProfileNameNotExistException : Exception{
		public ProfileNameNotExistException() { }
		public ProfileNameNotExistException(string message) : base(message) { }
		public ProfileNameNotExistException(string message, Exception innerException) : base(message, innerException) { }
	}
}