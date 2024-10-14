using DSA;

Console.Write(Constants.EnterClassNameMSG);
string? className = Console.ReadLine();

//Validattion
if(className!=null && Validate.IsQuestionExists(className)){
    var obj = Activator.CreateInstance(assemblyName:Constants.assembly,typeName:Constants.assembly+"."+className);
    BaseQuestion? question = obj?.Unwrap() as BaseQuestion;
    question?.Handle();
}
else{
    Console.WriteLine(Constants.ValidationMSG);
}