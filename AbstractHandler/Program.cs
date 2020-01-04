using System;
using System.Collections.Generic;
using System.IO;

namespace AbstractHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            string repead;
            List<string> fileList = new List<string>() { "myPassword.txt", "salary.xml", "macroVirus.doc" };

            do
            {
                Console.WriteLine("Folder content D:\\ \n");
                foreach (string element in fileList)
                {
                    Console.WriteLine(element);
                }

                Console.WriteLine("\nEnter file name:");
                string file = Console.ReadLine();
                string extension = Path.GetExtension(file);

                var documentHandler = fileFormat(extension);
                if (documentHandler == null)
                {
                    Console.WriteLine("Unsupported file format");
                    Console.WriteLine("Start again? (y/n)");
                    repead = Console.ReadLine();                    
                    continue;
                }

                if (fileList.Contains(file))
                {
                    documentHandler.Open(file);
                    Console.WriteLine("Want to make changes?");
                    string yesNo = Console.ReadLine();
                    makeChanges(yesNo, documentHandler);
                }
                else
                {
                    Console.WriteLine("File does not exist, want to create? (y/n)");
                    string answer = Console.ReadLine();
                    if (answer == "y" || answer == "Y")
                    {
                        documentHandler.Create(file);
                        fileList.Add(file);
                        Console.WriteLine("Want to make changes?");
                        string yesNo = Console.ReadLine();
                        makeChanges(yesNo, documentHandler);
                    }
                    else
                    {
                        Console.WriteLine("Open another file? (y/n)");
                        answer = Console.ReadLine();
                        if (answer == "n") return;
                    }
                }
                Console.WriteLine("Start again? (y/n)");
                repead = Console.ReadLine();
            } while (repead == "y" || repead == "Y");
        }

        static AbstractHandler fileFormat(string extension)
        {
            AbstractHandler result = null;
            if (extension == ".xml")
            {
                result = new XMLHandler();
            }
            else if (extension == ".txt")
            {
                result = new TXTHandler();
            }
            else if (extension == ".doc")
            {
                result = new DOCHandler();
            }

            return result;
        }

        static void makeChanges(string yesNo, AbstractHandler documentHandler)
        {
            if (yesNo == "y" || yesNo == "Y")
            {
                documentHandler.Change();
                documentHandler.Save();
            }
            else Console.WriteLine("Document closed");
        }
    }

    public abstract class AbstractHandler
    {
        public abstract void Open(string file);
        public abstract void Create(string file);
        public abstract void Change();
        public abstract void Save();
    }

    public class XMLHandler: AbstractHandler
    {
        public override void Open(string file)
        {
            Console.WriteLine("\nxml file {0} open", file);
        }
        public override void Create(string file)
        {
            Console.WriteLine("\nxml file {0} created", file);
        }
        public override void Change()
        {
            Console.WriteLine(".xml file is changed");
        }
        public override void Save()
        {
            Console.WriteLine("Changes are saved for .xml file");
        }
    }
    public class TXTHandler : AbstractHandler
    {
        public override void Open(string file)
        {
            Console.WriteLine("\ntxt file {0} open", file);
        }
        public override void Create(string file)
        {
            Console.WriteLine("\ntxt file {0} created", file);
        }
        public override void Change()
        {
            Console.WriteLine(".txt file is changed");
        }
        public override void Save()
        {
            Console.WriteLine("Changes are saved for .txt file");
        }
    }
    public class DOCHandler : AbstractHandler
    {
        public override void Open(string file)
        {
            Console.WriteLine("\ndoc file {0} open", file);
        }
        public override void Create(string file)
        {
            Console.WriteLine("\ndoc file {0} created", file);
        }
        public override void Change()
        {
            Console.WriteLine(".doc file is changed");
        }
        public override void Save()
        {
            Console.WriteLine("Changes are saved for .doc file");
        }
    }    
}
