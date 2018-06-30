using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace INIsConf
{
    public partial class Form1 : Form
    {
        private string Username;
        List<Ini.CConfiguration> AllConfigurations = new List<Ini.CConfiguration>();
        string ConfigPath;

        public Form1()
        {
            InitializeComponent();
            Username = GetUserName(System.Security.Principal.WindowsIdentity.GetCurrent().Name); 
            this.Text = "Configuration INI Files v 0.5 " + Username;
        }
        private string GetUserName(string Login)
        {
            int pos = Login.IndexOf("\\");            
            return Login.Substring(pos + 1);
        }

        private void buttonDelConf_Click(object sender, EventArgs e)
        {
            
            if (listBoxConf.SelectedItem != null)
            {
                DialogResult dialogResult = MessageBox.Show("delete  " + listBoxConf.SelectedItem.ToString() + "?", " conf?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    AllConfigurations = Ini.DelConfiguration(listBoxConf.SelectedItem.ToString(), AllConfigurations);
                    if (AllConfigurations != null)
                    {
                        MessageBox.Show("Conf  " + listBoxConf.SelectedItem.ToString() + " was delete");

                        try
                        {
                            Ini.SeaveConfigurationsToXml(AllConfigurations, ConfigPath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                        UpdateForm(ConfigPath,0,0,0);
                    }
                    else
                    {
                        MessageBox.Show("Some error :(");
                    }

                        

                }              
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           ToolTip toolTip1 = new ToolTip();
           toolTip1.AutoPopDelay = 2000;
           //toolTip1.InitialDelay = 1000;
           toolTip1.ReshowDelay = 500;
           toolTip1.ShowAlways = true;
           toolTip1.SetToolTip(this.listBoxConf, "doble clck to run program");

           string ConfigPathDefault;
           ConfigPath= Ini.LoadPathConfigurations("MODULES.INI")+'\\'+Username+".xml";
           if (!System.IO.File.Exists(ConfigPath))
           {
               ConfigPathDefault = Ini.LoadPathConfigurations("MODULES.INI") + '\\' + "default" + ".xml";
               if (System.IO.File.Exists(ConfigPathDefault))
               {                   
                   FirstStartApp(ConfigPathDefault);
               }
               else
               {
                   MessageBox.Show("Err read default config file  " + ConfigPathDefault);
                   Application.Exit();
               }
           }
               UpdateForm(ConfigPath,0,0,0);

            string[] args = Environment.GetCommandLineArgs();                        
            if (args.Length>1)
            {
                StartWithCommandLine(args);
            }
        }

        /// <summary>
        /// run program with  paraetrs 
        /// </summary>        
        private void StartWithCommandLine(string[] args)
        {
            foreach (Ini.CConfiguration Config in AllConfigurations)
            {
                if (args[1].ToString() == Config.ConfigurationName)
                {
                    Ini.SaveConfigurationToFiles(Config);
                    RunExe(Config.RunExeName);
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// First run
        /// </summary>
        private void FirstStartApp(string ConfigPathDefault)
        {
            
            AllConfigurations = Ini.LoadConfigurationsFromXml(ConfigPathDefault);
            AllConfigurations = Ini.GetCurrentConfiguration(AllConfigurations);

            Ini.SeaveConfigurationsToXml(AllConfigurations, ConfigPath);
            //backUP
            BackUpIni(Ini.GetConfigurationFilesList(Ini.FindConfiguration(Ini.Current, AllConfigurations)));
        }

        /// <summary>
        /// make backup
        /// </summary>
        private void BackUpIni(List<string> files)
        { 
            try
            {
                string path = Directory.GetCurrentDirectory();                
                path = path + "\\" + Username;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                foreach (string f in files)
                {
                    string[] s = f.Split('\\');
                    File.Copy(f, path +"\\"+s[s.Length-1], true);
                }
            }
            catch(Exception e)
            {
                throw new Exception("backup err " + "(" + e + ")");
            }
        }

        /// <summary>
        /// read xml, load current
        /// </summary>
        private void UpdateForm(string ConfigFile, int conf,int fil,int str)
        {            
            try
            {
                AllConfigurations = Ini.LoadConfigurationsFromXml(ConfigFile);
                AllConfigurations = Ini.GetCurrentConfiguration(AllConfigurations);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            try
            {
                listViewInI.Clear();
                listViewInI.View = View.Details;
                listViewInI.Columns.Add("Section", 150);
                listViewInI.Columns.Add("Key", 150);
                listViewInI.Columns.Add("Value", 150);
                listViewInI.Columns.Add("description", 150);
                listViewInI.FullRowSelect = true;
                listViewInI.GridLines = true;
                listViewInI.MultiSelect = false;

                listBoxConf.Items.Clear();
                listBoxFiles.Items.Clear();

                foreach (Ini.CConfiguration Config in AllConfigurations)
                {
                    listBoxConf.Items.Add(Config.ConfigurationName);
                }

                foreach (Ini.CFile file in AllConfigurations[conf].Files)
                {
                    listBoxFiles.Items.Add(file.Filename);
                }

                foreach (Ini.CSection Section in AllConfigurations[conf].Files[fil].Sections)
                {
                            listViewInI.Items.Add(new ListViewItem(new[]    
                            {                                                            
                              Section.SectionName,"","",""
                            }));

                            foreach (Ini.CKeyValue KeyValue in Section.KeyValue)
                            {
                                ListViewItem listitem = new ListViewItem(new[]    
                            {"",KeyValue.Key,KeyValue.Value,KeyValue.Description});

                                listViewInI.Items.Add(listitem);
                            }

                }

                listViewInI.Select();
                listViewInI.Items[str].Focused = true;
                listViewInI.Items[str].Selected = true;                
                listViewInI.FocusedItem = listViewInI.Items[str];
                listViewInI.EnsureVisible(str);

                SetlistViewInIEditor();

                listBoxConf.SelectedIndex = conf;
                listBoxFiles.SelectedIndex = fil;

                textBoxRunExeName.Text = AllConfigurations[conf].RunExeName;
            }
            catch
            {
                MessageBox.Show("the element not selected");
            }

        }


        private void listViewInI_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetlistViewInIEditor();
        }

        /// <summary>
        /// Get sec. from form
        /// </summary>
        private string GetRealSectionFromForm()
        {

                for (int i = listViewInI.SelectedItems[0].Index; i >= 0; i--)
                {
                    if (listViewInI.Items[i].SubItems[0].Text != "")
                    {
                        return listViewInI.Items[i].SubItems[0].Text;                   
                    }
            }
            return "";
        }


        private void SetlistViewInIEditor()
        {
            if (listViewInI.SelectedItems.Count != 0)
            {
                textBoxSection.Text = GetRealSectionFromForm();

                textBoxKey.Text = listViewInI.SelectedItems[0].SubItems[1].Text;
                textBoxValue.Text = listViewInI.SelectedItems[0].SubItems[2].Text;
                textBoxDescription.Text = listViewInI.SelectedItems[0].SubItems[3].Text;

            }
            disableKetValue();
        }


        private void disableKetValue()
        {
            textBoxKey.Enabled=true;
            textBoxValue.Enabled = true;
            textBoxDescription.Enabled = true;
            if (textBoxKey.Text == "" && textBoxValue.Text == "")
            {
                textBoxKey.Enabled = false;
                textBoxDescription.Enabled = false;
                textBoxValue.Enabled = false;
            }   
                
            
        }

        private void buttonSaveCurrent_Click(object sender, EventArgs e)
        {                        
            Ini.CWhatIsChange change = SetChange();
            if (change != null)
            {
                int conf, fil, str;
                conf = listBoxConf.SelectedIndex;
                fil= listBoxFiles.SelectedIndex;
                str = listViewInI.SelectedItems[0].Index;
                
                try
                {
                    AllConfigurations = Ini.ChangeInConfigurations(change, AllConfigurations);
                    Ini.SeaveConfigurationsToXml(AllConfigurations, ConfigPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                    SaveDataToFile();              
               
                UpdateForm(ConfigPath, conf, fil, str);
            
            }
            else
            {
                MessageBox.Show("Error search changes");
            }
        }


        /// <summary>
        /// set change in form
        /// </summary>
        private Ini.CWhatIsChange SetChange()
        {
            try
            {
                Ini.CWhatIsChange change = new Ini.CWhatIsChange();
                change.Configuration = listBoxConf.SelectedItem.ToString();
                change.FullFileName = listBoxFiles.SelectedItem.ToString();
                change.Section = GetRealSectionFromForm();

                change.Key = listViewInI.SelectedItems[0].SubItems[1].Text;
                change.Value = listViewInI.SelectedItems[0].SubItems[2].Text;
                change.Description = listViewInI.SelectedItems[0].SubItems[3].Text;
                change.RunExeName = textBoxRunExeName.Text;

                change.ModifiedSection = textBoxSection.Text;
                change.ModifiedKey = textBoxKey.Text;
                change.ModifiedValue = textBoxValue.Text;
                change.ModifiedDescription = textBoxDescription.Text;

                            return change;

            }
            catch (Exception)
            {
                return null;
            }           
        }

        private void buttonSaveConf_Click(object sender, EventArgs e)
        {

            if (textBoxNewConfName.Text != "")
            {
                if (Ini.FindConfiguration(textBoxNewConfName.Text, AllConfigurations) == null)
                {
               
                        Ini.CConfiguration Configuration = new Ini.CConfiguration();
                        Ini.CConfiguration OutConfiguration = new Ini.CConfiguration();

                        Configuration = Ini.FindConfiguration(listBoxConf.SelectedItem.ToString(), AllConfigurations);

                        OutConfiguration = Ini.CopyConfiguration(textBoxNewConfName.Text, Configuration);
                        OutConfiguration.RunExeName = textBoxRunExeName.Text;
                        AllConfigurations.Add(OutConfiguration);
                        try
                        {
                            Ini.SeaveConfigurationsToXml(AllConfigurations, ConfigPath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                        UpdateForm(ConfigPath,0,0,0);
               
                }
                else
                    MessageBox.Show("A configuration with this name already exists");
            }
            else
                MessageBox.Show("A configuration not selected or new name not specified");
        }

        private void listBoxConf_MouseDoubleClick(object sender, MouseEventArgs e)
        {          
            int conf, fil, str;
            conf = listBoxConf.SelectedIndex;
            fil = listBoxFiles.SelectedIndex;
            str = listViewInI.SelectedItems[0].Index;

                SaveDataToFile();
             
            UpdateForm(ConfigPath,conf,fil,str);           
            RunExe(textBoxRunExeName.Text);                        
        }


        private void SaveDataToFile()
        {
            try
            {
                if (listBoxConf.SelectedItem != null)
                {
                    Ini.CConfiguration Configuration = new Ini.CConfiguration();
                    Configuration = Ini.FindConfiguration(listBoxConf.SelectedItem.ToString(), AllConfigurations);
                    if (Configuration != null)
                    {
                        Ini.SaveConfigurationToFiles(Configuration);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RunExe(string Path)
        {
            string RunPath;             
            if (Path.Contains("\\"))
            {
                RunPath = Path;
            }
            else
            {
                RunPath = Directory.GetCurrentDirectory() + "\\" + Path;
            }
            try
            {                    
                Process.Start(RunPath);
            }
            catch(Exception ex)
            {
                MessageBox.Show("err run " + RunPath + ex.ToString());
            }                                
        }

        private void listBoxFiles_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBoxFiles.SelectedItems.Count != -1)
            {
                UpdateForm(ConfigPath, listBoxConf.SelectedIndex, listBoxFiles.SelectedIndex, 0);
            }
        }

        private void listBoxConf_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBoxConf.SelectedIndex != -1 )
            {
              int  fil = listBoxFiles.SelectedIndex;
               if  (listViewInI.SelectedItems.Count != 0){
                    int str = listViewInI.SelectedItems[0].Index;
                    UpdateForm(ConfigPath, listBoxConf.SelectedIndex, fil, str);
                }
            }
        }

        private void buttonApplyConf_Click(object sender, EventArgs e)
        {
            SaveDataToFile();
        }



    }
}
