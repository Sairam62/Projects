using DSA;

Console.Write(Constants.EnterClassNameMSG);
string? className = Console.ReadLine();

//Validattion
if(className!=null && Validate.IsQuestionExists(className)){
    var obj = Activator.CreateInstance(assemblyName:Constants.Assembly,typeName:Constants.Assembly+"."+className);
    BaseQuestion? question = obj?.Unwrap() as BaseQuestion;
    question?.Handle();
}
else{
    Console.WriteLine(Constants.ValidationMSG);
}