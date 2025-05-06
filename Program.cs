using Hack.io;
using Hack.io.BCSV;
using System;
using System.IO;

class BCSVTool
{
    static BCSV AddField(BCSV bcsv)
    {
        Console.Write("FieldName> ");
        string fieldName = Console.ReadLine();

        Console.Write("DataType> ");
        var field = new BCSV.Field
        {
            AutoRecalc = true,
            HashName = BCSV.StringToHash_JGadget(fieldName),
            // DataType = AskForDataType(field)
            // DataType = int.Parse(Console.ReadLine())
        };

        Console.WriteLine("Adding Field");
        bcsv.Add(field);
        return bcsv;
    }

    static void Main()
    {
        // Console.WriteLine("Creating BCSV");
        // Console.Write("BcsvFileName> ");
        Console.Write("Do you want to load a bcsv? (y/n)> ");
        var bcsv = new BCSV();
        while (true)
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "n":
                    bcsv = new BCSV();
                    break;
                case "y":
                    Console.Write("FileName>");
                    var filePath = Console.ReadLine();
                    FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    bcsv = new BCSV();
                    bcsv.Load(fileStream);
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
            if (input == "n" || input == "y") {
                break;
            }
        }

        while (true)
        {
            Console.Write("> ");
            switch (Console.ReadLine())
            {
                case "help":
                    Console.WriteLine("Commands:\nfield - add a field\nsave - save bcsv\nquit - exit");
                    break;

                case "field":
                    AddField(bcsv);
                    break;

                case "save":
                    Console.Write("BcsvPath> ");
                    string filePath = Console.ReadLine();
                    FileStream bcsvpath = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    bcsv.Save(bcsvpath);
                    Console.Write("Saved bcsv!");
                    break;

                case "quit":
                    Environment.Exit(0);
                    break;

                case "exit":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Command not found -- use 'help' for a list of commands");
                    break;
            }
        }
    }
}
