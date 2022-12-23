namespace FFILES
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> dirs = new List<string>();
            int pos3 = 0;
          
            while (true)
            {
                int a = 0;
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                {
                    Console.SetCursorPosition(3, a);
                    Console.WriteLine($"{drive.Name} - доступного места: {drive.AvailableFreeSpace}");
                    dirs.Add(drive.Name.Split("\\")[0]);
                    a++;
                }
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Fakes.Dirs($"{dirs[pos3]}\\");
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (pos3 == drives.Length - 1)
                    {
                        Menu.Update(pos3, false);
                    }
                    else
                    {
                        Menu.Update(pos3 += 1, false);
                    }
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (pos3 != 0)
                    {
                        Menu.Update(pos3 -= 1, true);
                    }
                    else
                    {
                        Menu.Update(pos3, true);
                    }
                }
            }
        }
    }
}