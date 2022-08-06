using Antlr4.Runtime;
using Grammar;

  Console.Write("Entrada: ");
  var text = Console.ReadLine();
            
  AntlrInputStream inputStream = new AntlrInputStream(text);
  TestGrammarLexer lexer = new TestGrammarLexer(inputStream);
  BufferedTokenStream tokenStream = new BufferedTokenStream(lexer);
  TestGrammarParser parser = new TestGrammarParser(tokenStream);
  
  var tree = parser.atrib();
  
