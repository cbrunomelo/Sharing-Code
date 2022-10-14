using PasswordGenerator.core;

Console.WriteLine("choose password length");

short size = Convert.ToInt16(Console.ReadLine());

Console.WriteLine("include Special Chars? y/n");

var option1 = YesOrNo();

Console.WriteLine();
Console.WriteLine("Upper Case? y/n");

var option2 = YesOrNo();


Console.WriteLine();
var password = Password.Generate(size, option1, option2);
Console.WriteLine($"Your Password: {password}");



static bool YesOrNo()
   => char.ToLower(Console.ReadKey().KeyChar) == 'y' ? true :false;
