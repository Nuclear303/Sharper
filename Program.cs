using System;
namespace Sharper{
    public class Sharper{
        public static void Main(string[] args){
            if(args.Length != 0){
                switch(args[0]){
                    case "-h": case "--help":{
                        Console.WriteLine("Kompilator Sharper:\n Opcje kompilatora: \n -h [--help] - pomoc \n -v [--version] - wersja \n -o [--output] - wyjscie \n -c [--compile] - kompilacja \n -e [--execute] - uruchomienie");
                        break;
                    }
                    case "-v": case "--version":{
                        Console.WriteLine("Kompilator Sharper: 0.0.1");
                        break;
                    }
                    case "-o": case "--output":{
                        Console.WriteLine("Kompilator Sharper: 0.0.1");
                        break;
                    }
                    case "-c": case "--compile":{
                        Runner.Run(args[1]);
                        break;
                    }
                    case "-e": case "--execute":{
                        Runner.Run(args[1]);
                        break;
                    }
                    default:{
                        Console.WriteLine("Nieznana opcja. Jeżeli chcesz uzyskać pomoc użyj -h lub --help");
                        break;
                    }
                }
                
            }
        }
    }
}
