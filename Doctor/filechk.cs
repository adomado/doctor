using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace Doctor
{
    public partial class filechk : Form
    {
        public filechk()
        {
            InitializeComponent();
        }

        private void installerTest_btn_Click(object sender, EventArgs e)
        {
            err_list.Items.Clear();
            messages.Items.Clear();
            load_text.Visible = false;
            Registry_Values_lbl.Text = "";
            err_list.Visible = true;
            string[] Prog_files = { "PartnerToolbar.config", "AdomadoBar_1.0.2.dll", "AdoMadoBarUser.config", "app.config", "Interop.SHDocVw.dll", "Microsoft.mshtml.dll", "Newtonsoft.Json.Net20.dll", "RegisterAdoMado.exe", "SpicIE.dll", "UnInstallAdoMado.exe", "UnInstaller.exe", "wait.html", "Chrome\\Adomado.crx", "IE\\config.txt", "Updater\\AdomadoUpdater.exe", "Firefox\\install.rdf" };
            string[] reg = {"AdoMadoApiKey","AdomadoToolbarId","CurrentUser","CurrentVersion","Guid" };
            installer_tests init = new installer_tests();
            string p = init.files(err_list,Prog_files,messages);  //invokes the function to check program files, returns "Success" or "Fail" depending on the conditions
            string r = init.registry_chk(err_list, reg, Registry_Values_lbl, messages); //invokes the function to check registry entries made by AdoMado installer, returns "Success" or "Fail" depending on the conditions
            string b = init.browser_chk(err_list,Registry_Values_lbl, messages);    //invokes the function to check browser extensions , returns "Success" or "Fail" depending on the conditions
            
            if ((p == "Success")&&(r == "Success")&&(b=="Success"))    //if all the 3 tests are a success, then only whole test is a success, otherwise show error
            {
                pop2.Visible = false;
                pop1.Visible = true;
                pop1.Image = global::ChkTest.Properties.Resources.right;
                err_list.Visible = false;                
                Registry_Values_lbl.Visible = true;
                messages.Visible = true;
                message_lbl.Visible = true;
                Registry_Values_lbl.Visible = true;
                Reg_lbl.Visible = true;
                MessageBox.Show("Installer Test SUCCESSFUL!");
                messages.Items.Insert(0, "Installer Test SUCCESSFUL!");
                                
            }
            else
            {
                pop2.Visible = false;
                pop1.Visible = true;
                pop1.Image= global::ChkTest.Properties.Resources.wrong;
                
                
                
                messages.Items.Insert(0,"Installer test UNSUCCESSFUL"); 
                Registry_Values_lbl.Visible = true;
                list_head_lbl.Visible = true;
                messages.Visible = true;
                message_lbl.Visible = true;
                Reg_lbl.Visible = true;
                MessageBox.Show("Installer Test complete.\nRESULT : Some files/entries missing");
                MessageBox.Show("Check the list for missing files/entries");
                err_list.Visible = true;
            } 
        }

        private void uninstallerTest_btn_Click(object sender, EventArgs e)
        {
            err_list.Items.Clear();
            messages.Items.Clear();
            load_text.Visible = false;
            Reg_lbl.Visible = false;
            Registry_Values_lbl.Visible  = false;
            err_list.Visible = true;
            Registry_Values_lbl.Text = "";
            string[] reg = { "AdoMadoApiKey", "AdomadoToolbarId", "CurrentUser", "CurrentVersion", "Guid" };
            uninstaller_tests init = new uninstaller_tests();
            installer_tests init1 = new installer_tests();     //object of installer_test class to use 'registry_chk' and 'browser_chk' functions  
            string p = init.files(err_list,messages);  //function invoked to check any remains of AdoMado in uninstaller
            string r = init1.registry_chk(err_list, reg, Registry_Values_lbl,messages); //function invoked to check any remaing registry entries
            string b = init1.browser_chk(err_list, Registry_Values_lbl, messages);   //function invodked to check if any remaining browser extension
            if ((p == "Success") && (r == "Fail")&& (b=="Fail"))  //note that since the same function is being used to check registry and browser extension as in installer test, so a "Fail" here is actually a "Success" for uninstaller
            {                                                     //since after uninstalltion, registry entries and browser extensions will result in 'null', so a Faliure here is a success for uninstaller

                pop1.Visible = false;
                pop2.Visible = true;
                pop2.Image = global::ChkTest.Properties.Resources.right;
                err_list.Visible = false;
                list_head_lbl.Visible = false;                    //hence the uninstaller test is successful
                messages.Visible = true;
                message_lbl.Visible = true;
                Reg_lbl.Visible = false;
                messages.Items.Insert(0, "Uninstaller Test SUCCESSFUL!");
                MessageBox.Show("Uninstaller Test SUCCESSFUL!");
                
            }
            else
            {
                pop1.Visible = false;
                pop2.Visible = true;
                pop2.Image = global::ChkTest.Properties.Resources.wrong;
                
                Registry_Values_lbl.Visible = true;
                list_head_lbl.Visible = true;
                message_lbl.Visible = true;
                Reg_lbl.Visible = true;
                MessageBox.Show("Uninstaller Test completed. \n RESULT : Some files/entries still present");
                MessageBox.Show("Check the lists for tracked files/entries");
                messages.Items.Insert(0, "Uninstaller test UNSUCCESSFUL");
                err_list.Visible = true;
            } 
        }

        
        
    }

    class installer_tests : filechk     //class containing all the functions for installer test
    {
       public string files(ListBox error_list,string[] progFiles_val, ListBox err_messages) //checks for existence of necessary files in Program Files
        {
           int flag = 0;
           foreach (string val in progFiles_val)
            {
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\AdoMado\" + val))
                {

                    flag = 1;
                    error_list.Items.Add(val);
                    
                }
                               
            }
           if (flag == 1)
           {
               error_list.Items.Insert(0, "Following files were not found : ");
               err_messages.Items.Add("Program files are missing");
               return ("Fail");
           }
           else
           {
               return ("Success");
               
           } 
        }

       public string registry_chk(ListBox list, string[] reg_val, Label regShow, ListBox err_messages) //checks for registry entries made by AdoMado(initiated by both installer and uninstaller)
       {
           RegistryKey reg1 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\AdoMado\\AdoMado\\");
           object regVal;
           if(reg1!=null)
           foreach (string val in reg_val)
           {
               regVal = reg1.GetValue(val);
               regShow.Text += "\n\n" + val + " : " + regVal;
           }
          
           if (reg1 == null)
           {
               err_messages.Items.Add("Registry entries returned null");
               regShow.Text += "\n\nRegistry entries that returned null :\nSOFTWARE\\AdoMado\\AdoMado\\";
               return ("Fail");
           }
           else
           {
               return ("Success");
           }

           
                
       }

       public string browser_chk(ListBox err, Label regShow, ListBox err_messages)  //checks the existence of browser extensions
       {
           //RegistryKey reg1 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Mozilla\\Firefox\\Extensions\\");
           RegistryKey reg2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Google\\Chrome\\Extensions\\");
           RegistryKey reg3;
           int flag = 0;
           int count = 0;
           int profile_flag =0;
           object regVal_chrome;
           string[] profiles_chk = System.IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Mozilla\Firefox\Profiles");
           err.Items.Add("FIREFOX:");
           foreach (var dir in profiles_chk)
           {
               if (Directory.Exists(dir + @"\extensions\support@adomado.com"))
               {
                   count = 1;
                   regShow.Text += "\n\n" + dir;
               }
               else
               {
                   err.Items.Add(dir + @"\extensions\support@adomado.com");
                   profile_flag = 1;
               }
           }
           /* object regVal_firefox;
            regVal_firefox = reg1.GetValue("support@adomado.com");
           if(regVal_firefox!=null)
           {
               regShow.Text += "\n\nFIREFOX : \nsupport@adomado.com : " + regVal_firefox;
               count++;
           }
           if (regVal_firefox == null)
           {
               err_messages.Items.Add("Firefox extensions are empty");
               regShow.Text+="\n\nFirefox Extensions returns null : \nSOFTWARE\\Mozilla\\Firefox\\Extensions\\";
               
           }
           */
           
          foreach(string chromeExt in reg2.GetSubKeyNames())
          {
              reg3=Registry.LocalMachine.OpenSubKey("SOFTWARE\\Google\\Chrome\\Extensions\\" + chromeExt);
              foreach(string extVal in reg3.GetValueNames())
              {
                regVal_chrome = reg3.GetValue(extVal);
                   if (regVal_chrome.ToString() == (Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\AdoMado\\Chrome\\AdoMado.crx"))
                   {
                       regShow.Text += "\n\nCHROME : \nID : " +chromeExt + "\nPath : " + regVal_chrome;
                       flag = 1;
                       count++;
                   }
                   if (flag == 1)
                   {
                       regShow.Text += "\nVersion : " + reg3.GetValue("version").ToString();
                       flag = 2;
                       
                   }


               }
           }
               if (flag == 0)
               {
                   err_messages.Items.Add("Chrome extension is empty");
                   regShow.Text+="\n\nChrome Extensions returns null :\nSOFTWARE\\Google\\Chrome\\Extensions\\<chromeID>\\";
                   
               }
               if ((count == 2)&&(profile_flag==0))
                   return ("Success");
               else
                   return ("Fail");
       
           
       }

       }

    

    class uninstaller_tests : filechk  //class containg checks for the uninstaller tests, rest of the functions for uninstaller tests are actually taken from installer_tests class
    {
        public string files(ListBox error_list,ListBox err_message) //checks for exisitance of any remaining files in Program Files/AdoMado
        {
           int flag = 0;
           
          if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\AdoMado"))
           {
                flag = 1;
                String[] subDirectories;
                String[] subFiles;
                subDirectories = System.IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\AdoMado\");
                subFiles = System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\AdoMado\");
                foreach (var subdir in subDirectories)
                {
                    error_list.Items.Add(subdir);
                }
                foreach (var subfil in subFiles)
                {
                    error_list.Items.Add(subfil);
                }
                    
            }
                
          if (flag == 1)
           {
               error_list.Items.Insert(0, "Following Program files were not cleaned : ");
               err_message.Items.Add("Program files entries still present");
               return("Fail");
           }
           else
           {
               return("Success");
           }

           
        }
    }
}
