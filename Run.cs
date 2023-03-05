namespace Sharper{
    public class Runner{
        public static void Dump(string value){
            Console.Write(value);
        }
        public static int Run(string path){
            string? line;
            string[]? op;
            string[] fullPath = path.Split('/');
            string fileName = path.Split('/').Last();
            string ext = fileName.Split(".")[1];
            Array.Resize(ref fullPath, fullPath.Length - 1);
            string location = string.Join("/", fullPath);
            if(ext != "shr"){
                return -1;
            }

            using StreamWriter sw = new StreamWriter($"{location}/{fileName}.asm");

            

            StreamReader sr = new StreamReader(path);
            line = sr.ReadLine();
            int lineNumber = 0;
            while(line is not null){
                lineNumber++;
                op = line.Split(' ', 2, StringSplitOptions.None);
                switch(op[0]){
                    case "print": {
                        try{
                            if(op[1] == ""){
                                Console.WriteLine("ERROR: Brak zawartego argumentu funkcji w linii {0}",lineNumber);
                                return -1;
                            }
                            Dump(op[1]);    
                        }catch(IndexOutOfRangeException){
                            Console.WriteLine("ERROR: Brak zawartego argumentu funkcji w linii {0}",lineNumber);
                            return -1;
                        }
                        
                        break;
                    }
                    case "println":{
                        try{
                            if(op[1] == ""){
                                Console.WriteLine("ERROR: Brak zawartego argumentu funkcji {0} w linii {1}",op[0],lineNumber);
                                return -1;
                            }
                            Dump(op[1]+"\n");    
                        }catch(IndexOutOfRangeException){
                            Console.WriteLine("ERROR: Brak zawartego argumentu funkcji {0} w linii {1}",op[0],lineNumber);
                            return -1;
                        }
                        break;
                        }
                }
                line = sr.ReadLine();
            }
            sw.Close();
            return 0;
        }
    }
}
