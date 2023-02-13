using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using Moravia.Homework.Serializers;
using Moravia.Homework.Storages;

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
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\files\\source.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\files\\destination.xml");

            var jsonSerializer = new JsonSerializer();
            var xmlSerializer = new Serializers.XmlSerializer();
            var storage1 = new FileStorage(sourceFileName, xmlSerializer);
            var storage2 = new FileStorage(targetFileName, xmlSerializer);
            
            var doc = storage1.Load<Document>();

            doc.Title = "new title";
            doc.Text = "Updated description.";

            storage2.Save(doc); 
        }
    }
}