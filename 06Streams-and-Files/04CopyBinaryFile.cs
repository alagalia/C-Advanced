using System;
using System.IO;
/*Write a program that copies the contents of a binary file (e.g. image, video, etc.) to another using FileStream. You are not allowed to use the File class or similar helper classes.*/
class CopyBinaryFile
{
    static void Main()
    {
        FileStream input = new FileStream(@"..\..\..\pic.jpg", FileMode.Open);
        FileStream copy = new FileStream(@"..\..\..\copiedPic.jpg", FileMode.Create);
        using (input)
        {
            using (copy)
            {
                byte[] buffer = new byte[4096];
                while (true)
                {
                    int readedByte = input.Read(buffer, 0, buffer.Length);
                    if (readedByte == 0) break;
                    copy.Write(buffer, 0, readedByte);
                }
            }
        }
    }
}