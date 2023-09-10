using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using System.IO;
using Newtonsoft.Json;

namespace SampleHierarchies.Data
{
    public class Settings : ISettings   
    {
        public string? Version { get; set; }
        public string? ConsoleColor { get; set; }
        public string? FileName { get; set; }
        //ctor
        public Settings() 
        {
            FileName = "ColorSettings.json";
        }
        //Deserialize Method
        public void ReadFromJson(string menu)//Read settings from json file and changes console color 
        {
            if (File.Exists(FileName))
            {
                string content = File.ReadAllText(FileName);
                dynamic deserializedObj = JsonConvert.DeserializeObject(content);
                if (deserializedObj[menu] != null) 
                {
                    Console.ForegroundColor = deserializedObj[menu];
                }
            }
        }

    }       
}
