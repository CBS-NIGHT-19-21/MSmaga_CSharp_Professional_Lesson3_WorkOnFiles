using System.IO.Compression;

class Program
{
    static void SearchFile(DirectoryInfo searchDir, string fileName)
    {
        DirectoryInfo[] dirInfo = searchDir.GetDirectories();

        foreach (DirectoryInfo directoryInfo in dirInfo)
        {
            SearchFile(directoryInfo, fileName);
        }

        FileInfo[] filesInfo = searchDir.GetFiles();

        foreach (FileInfo fileInfo in filesInfo)
        {
            if (fileInfo.Name == fileName)
            {
                Console.WriteLine(fileInfo.FullName);


                if (!File.Exists(fileName))
                {
                    string[] lines = File.ReadAllLines(fileInfo.FullName);
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
    static void GetZip(string filePath)
    {
        try
        {
            FileStream source = File.OpenRead(filePath);
            string filePathZip = Path.ChangeExtension(filePath, "zip");
            FileStream destination = File.Create(filePathZip);
            GZipStream compressor = new GZipStream(destination, CompressionMode.Compress);

            int readByte = source.ReadByte();
            while (readByte != -1)
            {
                compressor.WriteByte((byte)readByte);
                readByte = source.ReadByte();
            }

            compressor.Close();

            Console.WriteLine($"\nFile {filePathZip} has been compressed!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }



    static void Main()
    {
        DirectoryInfo searchDir = new DirectoryInfo(@"D:\Tags");

        SearchFile(searchDir, "Test.txt");

        GetZip(@"D:\Tags\Test.txt");

        //Delay
        Console.ReadLine();
    }
}
