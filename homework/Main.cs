using Moravia.Homework.Factories;
using Moravia.Homework.Storages;

namespace Moravia.Homework
{
    public class Document
    {
        public string? Title { get; set; }
        public string? Text { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // #1 issue: The filenames are hardcoded, it should be atleast parse from args (input)
            // var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\SourceFiles\\Document1.xml");
            // var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\TargetFiles\\Document1.json");
            // try
            // {
            //     FileStream sourceStream = File.Open(sourceFileName, FileMode.Open);
            // #2 issue: StreamReader is disposable and the resources are not release.
            //     var reader = new StreamReader(sourceStream);
            //     string input = reader.ReadToEnd();
            // }
            // catch (Exception ex)
            // {
            // #3 issue: Return more specific exception. The best way atleast some global application/project exception 
            // #4 issue: origin exception not bubble to new exception
            //     throw new Exception(ex.Message);
            // }
            // #5 issue: Should be wrap to try/catch
            // var xdoc = XDocument.Parse(input);
            // var doc = new Document
            // {
            //     Title = xdoc.Root.Element("title").Value,
            //     Text = xdoc.Root.Element("text").Value
            // };
            // #6 issue: next lines should be also in try/catch
            // var serializedDoc = JsonConvert.SerializeObject(doc);
            // #7 issue: If file exists it will append data to the end of file. 
            // var targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write);
            // #8 issue: same like #2
            // var sw = new StreamWriter(targetStream);
            // sw.Write(serializedDoc);

            try
            {
                string sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\files\\source.xml");
                string targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\files\\destination.xml");

                ISerializerFactory serializerFactory = new SerializerFactory();
                IStorageFactory storageFactory = new StorageFactory(serializerFactory);

                IStorage sourceStorage = storageFactory.FromFile(sourceFileName);
                IStorage targetStorage = storageFactory.FromFile(targetFileName);

                var doc = sourceStorage.Load<Document>();

                doc.Title = "new title";
                doc.Text = "Updated description.";

                targetStorage.Save(doc);
            }
            catch (Exception ex)
            {
                // some logs...
                Console.WriteLine("Program failed.");
            }
        }
    }
}