// See https://aka.ms/new-console-template for more information
using very_simple_interpreter.Lexer;

Console.WriteLine("Hello, World!");

BasicLexer basicLexer = new BasicLexer("docs/example.lang");
var t = basicLexer.GetNextToken();
Console.WriteLine(t.Type);

