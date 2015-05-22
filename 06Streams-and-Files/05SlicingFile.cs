using System;
using System.IO;
using System.Collections.Generic;
namespace _05SlicingFile
{
    class Program
    {
        private static List<string> files = new List<string>();
        private static string sourceFile;
        private static int numberofParts;

        static void Main()
        {
            numberofParts = 2;
            sourceFile = @"../../../pic.jpg";
            string folderPath = @"../../../";
            Slice(sourceFile, numberofParts);
            Assemble(files, folderPath);
        }

        public static void Slice(string SourceFile, int nFiles)
        {
            FileStream originFile = new FileStream(SourceFile, FileMode.Open, FileAccess.Read);
            using (originFile)
            {
                int SizeofEachFile = (int)Math.Ceiling((double)originFile.Length / nFiles);

                for (int i = 0; i < nFiles; i++)
                {
                    string baseFileName = Path.GetFileNameWithoutExtension(SourceFile);
                    string Extension = Path.GetExtension(SourceFile);

                    string fileName = Path.GetDirectoryName(SourceFile) + "\\" + baseFileName + i + Extension;
                    files.Add(fileName);
                    FileStream outputFile = new FileStream(fileName, FileMode.Create, FileAccess.Write);

                    int byteCounter = 0;
                    while (byteCounter <= SizeofEachFile)
                    {
                        using (outputFile)
                        {
                            byte[] buffer = new byte[4096];
                            while (true)
                            {
                                int readedByte = originFile.Read(buffer, 0, buffer.Length);
                                if (readedByte == 0) break;
                                outputFile.Write(buffer, 0, readedByte);
                            }
                        }
                        byteCounter++;
                    }
                }
            }
        }
        private static void Assemble(List<string> files, string destinationDirectory)
        {
            for (int i = 0; i < numberofParts; i++)
            {
                FileStream input = new FileStream(files[i], FileMode.Open);
                FileStream merged = new FileStream(destinationDirectory + "asembledFile.jpg", FileMode.Append);
                using (input)
                {
                    using (merged)
                    {
                        byte[] buffer = new byte[input.Length * numberofParts];
                        while (true)
                        {
                            int readedByte = input.Read(buffer, 0, buffer.Length);
                            if (readedByte == 0) break;
                            merged.Write(buffer, 0, readedByte);
                        }
                    }
                }
            }
        }

    }
}
