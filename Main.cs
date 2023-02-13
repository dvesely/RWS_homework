using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Moravia.Homework
{
    public class Document
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\files\\source.json");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\files\\destination.json");

            var jsonSerializer = new JsonSerializer();
            var storage1 = new FileStorage(sourceFileName, jsonSerializer);
            var storage2 = new FileStorage(targetFileName, jsonSerializer);
            
            var doc = storage1.Load<Document>();

            doc.Title = "new title";
            doc.Text = "Updated description.";

            storage2.Save(doc); 
        }
    }
}