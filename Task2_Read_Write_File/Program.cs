class Program
{
    static void Main()
    {
        var file = new FileInfo(@".\Test.txt");
        FileStream stream = file.Create();

        if (file.Exists)
        {
            Console.WriteLine("FullName      :       {0}", file.FullName);
            Console.WriteLine("Name          :       {0}", file.Name);
            Console.WriteLine("CreationTime  :       {0}", file.CreationTime);
            Console.WriteLine("Attributes    :       {0}", file.Attributes);
            Console.WriteLine("LastAccessTime:       {0}", file.LastAccessTime);
            Console.WriteLine("LastWriteTime :       {0}", file.LastWriteTime);
        }
        else
        {
            Console.WriteLine("The file doesn`t exist!");
        }

        stream.Close();


        var stream2 = new FileStream("Test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

        for (int i = 0; i < 256; i++)
        {
            stream2.WriteByte((byte)i);
        }
        stream2.Close();


        var stream3 = new FileStream("Test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);


        for (int i = 0; i < 256; i++)
        {
            Console.Write(stream3.ReadByte());
        }

        stream3.Close();

        //file2.Delete();


        var memory = new MemoryStream();
        memory.Capacity = 256;

        for (int i = 0; i < 256; i++)
        {
            memory.WriteByte((byte)i);
        }
        byte[] buffer = memory.ToArray();

        foreach (byte b in buffer)
        {
            Console.WriteLine(b);
        }
        var file2 = new FileStream("Dump.dat",FileMode.Create,FileAccess.ReadWrite);
        memory.WriteTo(file2);
        
        memory.Close();
        file2.Close();
    }
}