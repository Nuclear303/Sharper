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
                Console.WriteLine($"Error in line {lineNumber}: print requires 1 argument to the function, Provided {arguments.Length} arguments");
              }
              else{
                if((arguments[0].First() == '\'' && arguments[0].Last() == '\'') || (arguments[0].First() == '\"' && arguments[0].Last() == '\"')){
                  dotdata+=$"\tstring{lineNumber} db '{arguments[0].Substring(1,arguments[0].Length-2)}' \n";
                }
                else if(double.TryParse(arguments[0], out _) || arguments[0] == "True" || arguments[0] == "False"){
                  dotdata+=$"\tstring{lineNumber} db '{arguments[0]}' \n";
                }
                else{
                  Console.WriteLine($"Error in line {lineNumber}: {arguments[0]} doesn't exist in this file");
                }
              }
              break;
            }
            case "println":{
              if(arguments.Length != 1){
                Console.WriteLine($"Error in line {lineNumber}: println requires 1 argument to the function, Provided {arguments.Length} arguments");
              }
              else{
                if(((arguments[0].First() == '\'' && arguments[0].Last() == '\'') || (arguments[0].First() == '\"' && arguments[0].Last() == '\"'))){
                  dotdata+=$"\tstring{lineNumber} db '{arguments[0].Substring(1,arguments[0].Length-2)}', 0xA, 0 \n";
                }
                else if(double.TryParse(arguments[0], out _) || arguments[0] == "True" || arguments[0] == "False"){
                  dotdata+=$"\tstring{lineNumber} db '{arguments[0]}' \n";
                }
                else{
                  Console.WriteLine($"Error in line {lineNumber}: {arguments[0]} doesn't exist in this file");
                }
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
