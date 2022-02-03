using PortsDAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PortsDAL.Handlers
{
    public class JsonHandler : IContextHandler
    {
        string _filePath;
        public JsonHandler(string filePath)
        {
            _filePath = filePath;
            Init();
        }

        public List<DbPort> Ports { get; set; }

        void Init()
        {
            Read();
        }

        void Read()
        {
            var json = File.ReadAllText(_filePath);
            Ports = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DbPort>>(json);
        }

        public void Save()
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(Ports, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_filePath, output);
        }

    }
}
