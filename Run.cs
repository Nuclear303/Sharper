using Newtonsoft.Json;

using System.Diagnostics;

namespace Sharper{
    public class Runner{
        public static string? filePath;
        public static int Run(string path){
            filePath = path;
            string fileName = path.Split('/').Last();
            string ext = fileName.Split(".")[1];
            if(ext != "shr"){
                return -1;
            }
            Tokenizer.Tokenize();
            using StreamWriter sw = new StreamWriter($"./{fileName.Split('.')[0]}.asm",false);
            sw.Write("section .data\n");
            sw.WriteLine(Tokenizer.dotdata);
            string[] textToWrite = Tokenizer.dotdata.Split("\n");
            
            sw.WriteLine("section .text");
            sw.WriteLine("\tglobal _start");
            sw.WriteLine("_start:");
            foreach (var line in textToWrite)
            {
                if(line != string.Empty){
                    string stringName = line.Split(" ")[0];
                    string value = line.Split(" ")[2].Substring(1, line.Split(" ")[2].Length - 2);
                    if(stringName != string.Empty){
                        sw.WriteLine("\tmov rax, 1");         
                        sw.WriteLine("\tmov rdi, 1");         
                        sw.WriteLine($"\tmov rsi, {stringName.Trim()}");
                        sw.WriteLine($"\tmov rdx, {value.Length}");         
                        sw.WriteLine("\tsyscall\n");
                    }     
                }
                 
            }
            
            sw.WriteLine("\tmov rax, 60");
            sw.WriteLine("\tmov edi, 0");
            sw.WriteLine("\tsyscall");
            sw.Close();


            return 0;
        }
    }
}
