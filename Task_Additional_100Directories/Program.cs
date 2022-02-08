using System.IO;
class Program
{
    static void GetDirInfo (string path)
    {
        var directory = new DirectoryInfo(path);

        if (directory.Exists)
        {
            Console.WriteLine("FullName      :       {0}", directory.FullName);
            Console.WriteLine("Name          :       {0}", directory.Name);
            Console.WriteLine("Parent        :       {0}", directory.Parent);
            Console.WriteLine("CreationTime  :       {0}", directory.CreationTime);
            Console.WriteLine("Attributes    :       {0}", directory.Attributes);
            Console.WriteLine("Root          :       {0}", directory.Root);
            Console.WriteLine("LastAccessTime:       {0}", directory.LastAccessTime);
            Console.WriteLine("LastWriteTime :       {0}", directory.LastWriteTime);
        }
        else
        {
            Console.WriteLine("The directory doesn`t exist!");
        }
        Console.ReadLine();
    }
    static void GetFilesDir(string path)
    {
        var directory = new DirectoryInfo(path);
        if (directory.Exists)
        {
            FileInfo[] arrFiles = directory.GetFiles(path);
            Console.WriteLine($"There are {arrFiles.Length} files.");
            foreach (FileInfo file in arrFiles)
            {
                Console.WriteLine("Name          :       {0}", file.Name);
                Console.WriteLine("Length        :       {0}", file.Length);
                Console.WriteLine("CreationTime  :       {0}", file.CreationTime);
                Console.WriteLine("Attributes    :       {0}", file.Attributes.ToString());
            }
        }
        else
        {
            Console.WriteLine("The directory doesn`t exist!");
            
        }
        
    }

    static void GetNameDrives()
    {
        string[] drives = Directory.GetLogicalDrives();

        foreach (string drive in drives)
        {
           Console.WriteLine(drive);
        }

    }
    static void Main()
    {
        // GetDirInfo(@"C:\Windows\assembly");
        // GetFilesDir(@".");

        var directory = new DirectoryInfo(@"D:\TestDir");

        Console.WriteLine(directory.FullName);
        for (int i = 0; i < 2; i++)
        {
            directory.CreateSubdirectory("Folder_" + i.ToString());
        }

        try
        {
            //Directory.Delete(directory.FullName, true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


        GetNameDrives();
        Console.ReadLine();
    }
}