using DSA;

string assembly = "DSA";
Console.Write("Please Enter a Class Name : ");
string? className = Console.ReadLine();

var obj = Activator.CreateInstance(assemblyName:assembly,typeName:assembly+"."+className);

BaseQuestion? question = obj?.Unwrap() as BaseQuestion;

question?.Handle();