using VerySimpleInterpreter.Lexer;
using VerySimpleInterpreter;

Console.WriteLine("Hello, World!");

var st = new SymbolTable();
var basicLexer = new BasicLexer("docs/example.lang", st);

Token t = null;
do {
    t = basicLexer.GetNextToken();
    Console.WriteLine(t.Type);
} while (t.Type != ETokenType.EOF);
