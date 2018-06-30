using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace INIsConf
{
    
public class  Ini
{
    public const string Current = "Current";
    protected const string SrcInisConf = "SrcInisConf";
    
    public class CWhatIsChange : IEquatable<CWhatIsChange>
    {
        public string Configuration;
        public string FullFileName;
        
        public string Section;
        public string Key;
        public string Value;
        public string Description;
        public string RunExeName;


        public string ModifiedSection;
        public string ModifiedKey;
        public string ModifiedValue;
        public string ModifiedDescription;


        public CWhatIsChange()
        {
            Configuration="";
            FullFileName = "";
            RunExeName="";

            Section = "";
            Key = "";
            Value = "";
            Description = "";

            ModifiedSection = "";
            ModifiedKey = "";
            ModifiedValue = "";
            ModifiedDescription = "";
        }
      

        public bool Equals(CWhatIsChange other)
        {
            
            if (Object.ReferenceEquals(other, null)) return false;            
            if (Object.ReferenceEquals(this, other)) return true;           
            return FullFileName.Equals(other.FullFileName);
        }
                

        public override int GetHashCode()
        {

            int hashProductName = FullFileName == null ? 0 : FullFileName.GetHashCode();
            int hashProductCode = FullFileName.GetHashCode();
            return hashProductName ^ hashProductCode;
        }

    }



    [Serializable]
    public class CConfiguration
    {
        [XmlAttribute]
        public string ConfigurationName;
        [XmlAttribute]
        public string RunExeName;
        public List<CFile> Files = new List<CFile>();
        
    }



    [Serializable]
    public class CFile
    {
        [XmlAttribute]
        public string Filename;
        public List<CSection> Sections = new List<CSection>();
    }
    [Serializable]
    public class CSection
    {
        [XmlAttribute]
        public string SectionName;        
        public List<CKeyValue> KeyValue = new List<CKeyValue>();

    }
    [Serializable]
    public class CKeyValue
    {
        [XmlAttribute]
        public string Key;
        [XmlAttribute]
        public string Value;
        [XmlAttribute]
        public string Description;
    }

    /// <summary>
    /// Read from xml
    /// </summary>
    public static List<CConfiguration> LoadConfigurationsFromXml(string xmlname)
    {
        List<CConfiguration> Conf = new List<CConfiguration>();

        try
        {
            using (Stream fSteam = new FileStream(xmlname, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<CConfiguration>));
                Conf = (List<CConfiguration>)xmlFormat.Deserialize(fSteam);
            }

        }
        catch(Exception e)
        {
            throw new Exception("Read err" + xmlname +"("+e+")");
 
        }
        return Conf;
    }


    /// <summary>
    /// save date to xml
    /// </summary>
    public static void SeaveConfigurationsToXml(List<CConfiguration> Conf, string xmlname)
    {
        try
        {
            using (Stream fSteam = new FileStream(xmlname, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<CConfiguration>));
                xmlFormat.Serialize(fSteam, Conf);
            }
        }
        catch (Exception e)
        {
            throw new Exception("write err to " + xmlname + "(" + e + ")");
        }
    }


    /// <summary>
    /// read pach for connfig from MODULES.INI
    /// </summary>
    public static string LoadPathConfigurations(string Path)
    {        
        string[] lines = File.ReadAllLines(Path);
        
        foreach (string line in lines)
        {
            string dataString = line.Trim();
            
            if (dataString.Contains(SrcInisConf))
            {
                int pos = dataString.IndexOf("=");
                return dataString.Substring(pos + 1, dataString.Length - pos - 1).Trim();
            }
        }

        return null;
    }


    /// <summary>
    /// load to  current conf
    /// </summary>
    public static List<CConfiguration> GetCurrentConfiguration(List<CConfiguration> AllConfigurations)
    {

        List<Ini.CConfiguration> AllConfigurationsTmp = new List<Ini.CConfiguration>();

        foreach (Ini.CConfiguration C in AllConfigurations)
        {
            AllConfigurationsTmp.Add(C);
            if (C.ConfigurationName == Current)
            {
                AllConfigurationsTmp[AllConfigurationsTmp.Count() - 1].Files = GetConfigurationCFiles(C);                 
            }


        }

        return AllConfigurationsTmp;
    }

    /// <summary>
    /// return  config list 
    /// </summary>
    public static List<CFile> GetConfigurationCFiles(CConfiguration Configuration)
    {        
        List<CFile> Files = new List<CFile>();

        foreach (CFile C in Configuration.Files)
        {
            Files.Add(LoadDataFrominiFile(@C.Filename));
        }
        return Files;

    }

    /// <summary>
    /// rerurn files conf list 
    /// </summary>
    public static List<string> GetConfigurationFilesList(CConfiguration Configuration)
    {
        List<string> files = new List<string>();

        foreach (CFile f in Configuration.Files)
        {
            files.Add(f.Filename);
        }
        return files;

    }


        /// <summary>
        /// return first config from list config by name
        /// </summary>
        public static CConfiguration FindConfiguration(string ConfigName, List<CConfiguration> Configurations)
    {       
        foreach (CConfiguration C in Configurations)
        {
            if (C.ConfigurationName == ConfigName)
            {
                return C;

            }
        }

        return null;
    }

    /// <summary>
    /// read full date from ini
    /// </summary>
    protected static CFile LoadDataFrominiFile(string fileName)
    {
        CFile Fileini = new CFile();
        Fileini.Filename = fileName;
        Fileini.Sections = new List<CSection>();       

        Encoding enc = Encoding.GetEncoding(1251);

        string[] lines = File.ReadAllLines(fileName, enc);

        int i = 0;
        
        while (i < lines.Count())
        {
            string dataString = lines[i].Trim();
            if (string.IsNullOrEmpty(dataString)) continue;
            if ((dataString.StartsWith("[")) && (dataString.EndsWith("]")))
            {
                CSection Cection = new CSection();
                Cection.SectionName = dataString;
                i++;
                dataString = lines[i].Trim();
                Cection.KeyValue = new List<CKeyValue>();                
                while (!dataString.StartsWith("["))
                {
                    CKeyValue KeyValue = new CKeyValue();
                    
                    if (dataString.StartsWith(";"))
                    {
                        KeyValue.Description = dataString;
                        i++;
                        dataString = lines[i].Trim();
                    }
                    
                    if (dataString.Contains("="))
                    {
                        
                        int pos = dataString.IndexOf("=");                        
                        string key = dataString.Substring(0, pos).Trim();
                        string value = "";
                        if ((pos + 1) < dataString.Length)
                        {
                            value = dataString.Substring(pos + 1, dataString.Length - pos - 1).Trim();
                        }

                        // save date to colection
                        KeyValue.Key = key;
                        KeyValue.Value = value;

                    }


                    Cection.KeyValue.Add(KeyValue);
                    i++;
                    
                    if (i < lines.Count())
                    {
                        dataString = lines[i].Trim();
                    }
                    else
                    {
                        break;
                    }
                }
                Fileini.Sections.Add(Cection);
            }
        }
        return Fileini;

    }


    /// <summary>
    /// save config to file
    /// </summary>
    public static void SaveConfigurationToFiles(CConfiguration Configuration)
    {
        foreach (CFile F in Configuration.Files)
        {
            Encoding enc = Encoding.GetEncoding(1251);

            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@F.Filename, false, enc))
                {
                    foreach (CSection S in F.Sections)
                    {
                        file.WriteLine(S.SectionName);
                        foreach (CKeyValue KVD in S.KeyValue)
                        {
                            if (KVD.Description != null)
                                file.WriteLine(KVD.Description);
                            file.WriteLine(KVD.Key + "=" + KVD.Value);
                        }
                    }
                }
            }
            catch (Exception e)                
            {
                throw new Exception("write err: " + @F.Filename + "(" + e + ")");
            }
        }
    }

    

    /// <summary>
    /// upd configurations by Changes 
    /// </summary>
    public static List<CConfiguration> ChangeInConfigurations(CWhatIsChange Changes, List<CConfiguration> Configurations)
    {
        List<CConfiguration> OUTConfigs = new List<CConfiguration>();
        foreach (CConfiguration C in Configurations)
        {
            CConfiguration Config = new CConfiguration();
            if (C.ConfigurationName == Changes.Configuration)
            {
                Config.RunExeName = Changes.RunExeName;
                Config.ConfigurationName = Changes.Configuration;
                Config.Files = new List<CFile>();
                Config.Files = ChangeInFiles(Changes, C.Files);
            }
            else
            {
                Config = C;
            }
            OUTConfigs.Add(Config);
        }
        return OUTConfigs;
    }

    /// <summary>
    /// upd  CFile by Changes 
    /// </summary>
    
    protected static List<CFile> ChangeInFiles(CWhatIsChange Changes, List<CFile> Files)
    {
        List<CFile> OUTFile = new List<CFile>();
        foreach (CFile F in Files)
        {
            CFile File = new CFile();
            if (F.Filename == Changes.FullFileName)
            {
                File.Filename = Changes.FullFileName;
                File.Sections = new List<CSection>();
                File.Sections = ChangeInSection(Changes, F.Sections);
            }
            else
            {
                File = F;
            }

            OUTFile.Add(File);
        }
        return OUTFile;

    }

    /// <summary>
    /// upb CSection by Changes 
    /// </summary>
    protected static List<CSection> ChangeInSection(CWhatIsChange Changes, List<CSection> Sections)
    {
        List<CSection> OUTSection = new List<CSection>();

        foreach (CSection C in Sections)
        {
            CSection Section = new CSection();

            if (C.SectionName == Changes.Section)
            {
                Section.SectionName = Changes.ModifiedSection;
                Section.KeyValue = new List<CKeyValue>();
                Section.KeyValue = ChangeKeyValue(Changes, C.KeyValue);
            }
            else
            {
                Section = C;
            }
            OUTSection.Add(Section);

        }
        return OUTSection;
    }

    /// <summary>
    /// upb kes and value in CKeysValues by Changes 
    /// </summary>
    protected static List<CKeyValue> ChangeKeyValue(CWhatIsChange Changes, List<CKeyValue> KeysValues)
    {
        List<CKeyValue> OUTKeysValues = new List<CKeyValue>();
        foreach (CKeyValue KVD in KeysValues)
        {
            CKeyValue KeyValueDesc = new CKeyValue();
            
            if (KVD.Key == Changes.Key)
            {
                KeyValueDesc.Key = Changes.ModifiedKey;
                KeyValueDesc.Value = Changes.ModifiedValue;
                if (Changes.Description != null)
                {                    
                    if ((Changes.ModifiedDescription != null) && ( Changes.ModifiedDescription != ""))
                    if (!Changes.ModifiedDescription.StartsWith(";"))
                    {
                        KeyValueDesc.Description = ";" + Changes.ModifiedDescription;
                    }
                    else
                    {
                        KeyValueDesc.Description = Changes.ModifiedDescription;
                    }
                }                
            }
            else
            {
                KeyValueDesc = KVD;
            }

            OUTKeysValues.Add(KeyValueDesc);
        }

        return OUTKeysValues;
    }

    /// <summary>
    /// clone config
    /// </summary>
    public static CConfiguration CopyConfiguration(string ConfigNewName, CConfiguration Configuration)
    {
        CConfiguration Config = new CConfiguration();
        Config.ConfigurationName = ConfigNewName;
        Config.RunExeName = Configuration.RunExeName;
        Config.Files = new List<CFile>();
        foreach (CFile F in Configuration.Files)
        {
            Config.Files.Add(F);
        }

        return Config;
    }


    /// <summary>
    /// del first conf by name, return list without this conf
    /// </summary>
    public static List<CConfiguration> DelConfiguration(string ConfigName, List<CConfiguration> Configurations)
    {
        try
        {
            if (ConfigName != Current)
            {
                List<CConfiguration> Configs = new List<CConfiguration>();
                foreach (CConfiguration C in Configurations)
                {
                    if (C.ConfigurationName != ConfigName)
                    {
                        Configs.Add(C);
                    }
                }
                return Configs;
            }
        }
        catch
        {
            return null;
        }

        return null;
    }


}
}