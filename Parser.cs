using static System.Diagnostics.Debug;
namespace Sharper{ 
  
  public class Tokenizer{
    public static string dotdata = string.Empty;
    
    public static Dictionary<int, string[]> Tokenize(){
      
      Dictionary<int, string[]> dict = new Dictionary<int, string[]>();
      if(Runner.filePath is not null){
        string? line;
        StreamReader sr = new StreamReader(Runner.filePath);
        line = sr.ReadLine();
        int lineNumber = 0;
        while(line is not null){
          lineNumber++;
          dict[lineNumber] = line.Split(' ');
          string operation = dict[lineNumber][0];
          string[] arguments = dict[lineNumber].Skip(1).ToArray();
          switch(operation){
            case "print":{
              if(arguments.Length != 1){
                Console.WriteLine($"Error in line {lineNumber}: Print requires 1 argument to the function, Provided {arguments.Length} arguments");
              }
              else{
                dotdata+=$"\tstring{lineNumber} db '{arguments[0]}' \n";
              }
              break;
            }
            case "println":{
              if(arguments.Length != 1){
                Console.WriteLine($"Error in line {lineNumber}: Print requires 1 argument to the function, Provided {arguments.Length} arguments");
              }
              else{
                dotdata+=$"\tstring{lineNumber} db '{arguments[0]}', 0xA, 0 \n";
              }
              break;
            }
          }
              
                  
            line = sr.ReadLine();
        }
      }
      return dict;
    }
  }

}