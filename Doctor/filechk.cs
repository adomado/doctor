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
            string[] Prog_files = { "PartnerToolbar.config", "AdomadoBar_1.0.2.dll", "AdoMadoBarUser.config", "app.config", "Interop.SHDocVw.dll", "Microsoft.mshtml.dll", "Newtonsoft.Json.Net20.dll", "RegisterAdoMado.exe", "SpicIE.dll", "UnInstallAdoMado.exe", "UnInstaller.exe", "wait.html", "Chrome\\Adomado.crx", "IE\\config.txt", "Updater\\AdomadoUpdater.exe", "Firefox\\install.rdf" };
            string[] reg = {"AdoMadoApiKey","AdomadoToolbarId","CurrentUser","CurrentVersion","Guid" };
            installer_tests init = new installer_tests();
            string p = init.program_files(err_list,Prog_files,messages);
            string r = init.registry_chk(err_list,reg,Registry_Values_lbl,messages);
            string b = init.browser_chk(Registry_Values_lbl,messages);
            
            if ((p == "Success")&&(r == "Success")&&(b=="Success"))
            {
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
            Registry_Values_lbl.Text = "";
            string[] reg = { "AdoMadoApiKey", "AdomadoToolbarId", "CurrentUser", "CurrentVersion", "Guid" };
            uninstaller_tests init = new uninstaller_tests();
            installer_tests init1 = new installer_tests(); //same function call as installer just to read the registry
            string p = init.program_files(err_list,messages);
            string r = init1.registry_chk(err_list, reg, Registry_Values_lbl,messages);
            string b = init1.browser_chk(Registry_Values_lbl, messages);
            if ((p == "Success") && (r == "Fail")&& (b=="Fail"))
            {
                list_head_lbl.Visible = false;
                messages.Visible = true;
                message_lbl.Visible = true;
                Reg_lbl.Visible = true;
                messages.Items.Insert(0, "Uninstaller Test SUCCESSFUL!");
                MessageBox.Show("Uninstaller Test SUCCESSFUL!");
                
            }
            else
            {
                Registry_Values_lbl.Visible = true;
                list_head_lbl.Visible = true;
                message_lbl.Visible = true;
                Reg_lbl.Visible = true;
                MessageBox.Show("Uninstaller Test completed. \n RESULT : Some files/entries still present");
                MessageBox.Show("Check the lists for tracked files/entries");
                err_list.Visible = true;
            } 
        }

        
        
    }

    class installer_tests : filechk 
    {
       public string program_files(ListBox error_list,string[] progFiles_val, ListBox err_messages) //checks for existence of necessary files in Program Files
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
               return ("fail");
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

       public string browser_chk(Label regShow, ListBox err_messages)
       {
           RegistryKey reg1 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Mozilla\\Firefox\\Extensions\\");
           RegistryKey reg2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Google\\Chrome\\Extensions\\");
           RegistryKey reg3;
           int flag = 0;
           int count = 0;
           object regVal_chrome;
           object regVal_firefox;
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
               if (count == 2)
                   return ("Success");
               else
                   return ("Fail");
       
           
       }

       }

    

    class uninstaller_tests : filechk
    {
        public string program_files(ListBox error_list,ListBox err_message) //checks for exisitance of any remaining files in Program Files/AdoMado
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
