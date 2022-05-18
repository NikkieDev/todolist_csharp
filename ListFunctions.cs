using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class ListFunctions
    {
        private static string Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/NikkieDev Software/Todo list";
        private string _File = $@"{Folder}/list.txt";

        private static Program programObj = new Program();

        public void addToList()
        {
            string task;

            Console.WriteLine("\n\n\n\t\t\t\t\t\t\tTo Do List");
            Console.WriteLine("\t\t\t\t\t\t===========================");
            Console.Write("\t\t\t\t\t\tTask: ");
            task = Console.ReadLine();
            Console.WriteLine("\t\t\t\t\t\t===========================\n");

            if (new FileInfo(_File).Length < 1)
            {
                File.AppendAllText(_File, $"{task}");
            } else
            {
                File.AppendAllText(_File, $"\n{task}");
            }
            programObj.Menu();
        }

        public void removeFromList()
        {
            if (new FileInfo(_File).Length == 0) programObj.Menu();

            Console.Clear();
            int task;

            readFile();
            Console.Write("\t\t\t\t\t\tTask to delete (Number): ");
            task = Int32.Parse(Console.ReadLine());

            List<string> taskList = new List<string>();

            foreach (string line in File.ReadLines(_File))
            {
                taskList.Add(line);
            }

            task--;

            if (task > taskList.Count())
            {
                removeFromList();
            } else
            {
                taskList.RemoveAt(task);
            }

            File.Delete(_File);
            var _file = File.Create(_File);
            _file.Close();

            foreach (string _todo in taskList)
            {
                try
                {
                    File.AppendAllText(_File, $"{_todo}\n");
                }
                catch (IOException e)
                {
                    Console.WriteLine(e);
                }
            }

            programObj.Menu();
        }

        public void viewList()
        {
            Console.Clear();

            if (new FileInfo(_File).Length == 0)
            {
                Console.WriteLine("\n\n\n\t\t\t\t\t\t\tTo Do List");
                Console.WriteLine("\t\t\t\t\t\t===========================");
                Console.WriteLine($"\t\t\t\t\t\t      File is Empty     ");
                Console.WriteLine("\t\t\t\t\t\t===========================\n");
            }
            else
            {
                readFile();
            }
            Console.Write("\t\t\t\t\t\tPress ENTER to continue");
            Console.ReadKey();

            programObj.Menu();
        }
        public void readFile()
        {
            Console.WriteLine("\n\n\n\t\t\t\t\t\t\tTo Do List");
            Console.WriteLine("\t\t\t\t\t\t===========================");


            int i = 0;
            foreach (string line in File.ReadLines(_File))
            {
                i++;
                Console.WriteLine($"\t\t\t\t\t\t{i}. {line}");
            }

            Console.WriteLine("\t\t\t\t\t\t===========================\n");
        }
        
        public void checkFileAndFolder()
        {
            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
                System.Threading.Thread.Sleep(250);
            }

            if (!File.Exists(_File))
            {
                var file = File.Create(_File);
                Console.WriteLine("\n\n\n\t\t\t\t\t\t\tTo Do List");
                Console.WriteLine("\t\t\t\t\t\t===========================");
                Console.Write("\t\t\t\t\t\tCreating file...\n");
                Console.WriteLine("\t\t\t\t\t\t===========================\n");

                file.Close();
                Thread.Sleep(750);
            }
        }
    }
}
