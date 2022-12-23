using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFILES
{
    internal static class Fakes
    {
        public static void Dirs(string path)
        {
            Console.Clear();
            int inText = 0;
            Menu Menu2 = new Menu(inText);
            while (true)
            {
                int inText2 = 0;
                string[] dirs = Directory.GetFileSystemEntries(path);
                foreach (string item in dirs)
                {
                    DateTime dateTime = Directory.GetCreationTime(item);
                    if (Path.HasExtension(item))
                    {
                        Console.SetCursorPosition(3, inText2);
                        string[] all = item.Split("\\");
                        string Item = all[all.Length - 1];
                        Console.Write(Item.Replace(Path.GetExtension(item), ""));
                        Console.SetCursorPosition(60, inText2);
                        Console.Write(dateTime);
                        Console.SetCursorPosition(100, inText2);
                        Console.Write(Path.GetExtension(item));
                        inText2++;
                    }
                    else
                    {
                        string[] all = item.Split("\\");
                        string Item = all[all.Length - 1];
                        Console.SetCursorPosition(3, inText2);
                        Console.Write(Item);
                        Console.SetCursorPosition(60, inText2);
                        Console.Write(dateTime);
                        inText2++;
                    }
                }
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    dirs.DefaultIfEmpty();
                    Open(dirs[inText]);
                    break;
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    break;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (inText == dirs.Length - 1)
                    {
                        Menu.Update(inText, false);
                    }
                    else
                    {
                        Menu.Update(inText += 1, false);
                    }
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (inText != 0)
                    {
                        Menu.Update(inText -= 1, true);
                    }
                    else
                    {
                        Menu.Update(inText, true);
                    }
                }
            }
        }


        private static void Open(string npath)
        {
            if (Directory.Exists(npath))
            {
                Console.Clear();
                Dirs(npath);
            }
            else if (File.Exists(npath))
            {
                Process.Start(new ProcessStartInfo { FileName = npath, UseShellExecute = true });
            }
        }
    }
}
