using System;
using System.IO;

namespace ToDoList
{
    class Program
    {
        public static ListFunctions listfunctionsObj = new ListFunctions();
        private static Program programObj = new Program();

        private int _option;

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\t\t\t\t\t\t\tTo Do List");
            Console.WriteLine("\t\t\t\t\t\t===========================");
            Console.WriteLine("\t\t\t\t\t\t||    1. Add Item        ||");
            Console.WriteLine("\t\t\t\t\t\t||    2. Delete Item     ||");
            Console.WriteLine("\t\t\t\t\t\t||    3. View List       ||");
            Console.WriteLine("\t\t\t\t\t\t||    4. Exit            ||");
            Console.WriteLine("\t\t\t\t\t\t===========================\n");
            Console.Write("\t\t\t\t\t\tSelect your option: ");

            var option = Console.ReadLine();

            if (option != "")
            {
                _option = Int32.Parse(option);
            }

            while (_option > 4|| _option <= 0)
            {
                Menu();
            }

            programObj.checkOption(_option);
        }

        void checkOption(int _option)
        {
            switch (_option)
            {
                case 1:
                    listfunctionsObj.addToList();
                    break;
                case 2:
                    listfunctionsObj.removeFromList();
                    break;
                case 3:
                    listfunctionsObj.viewList();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }

        static void Main(string[] args)
        {
            listfunctionsObj.checkFileAndFolder();
            programObj.Menu();
        }
    }
}