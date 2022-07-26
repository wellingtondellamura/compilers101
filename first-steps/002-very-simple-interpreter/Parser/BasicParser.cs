using VerySimpleInterpreter.Lexer;

namespace VerySimpleInterpreter.Parser
{
    public class BasicParser
    {
        private BasicLexer _lexer;
        private Token _lookAhead;
        public BasicParser(BasicLexer lexer)
        {
            _lexer = lexer;
        }

        public void Match(ETokenType type)
        {
            if (_lookAhead.Type == type)
                _lookAhead = _lexer.GetNextToken();
            else
                Error("Expected "+type+" - Found "+_lookAhead.Type);
        }

        public void Error(String msg)
        {
            Console.WriteLine("#Error on _____");
            Console.WriteLine("Line "+_lexer.Line);
            Console.WriteLine("Column "+_lexer.Column);
            Console.WriteLine("________________");
            Console.WriteLine(msg);
            Console.WriteLine("________________");
        }

        /*


atrib  : VAR AT expr
expr   : termY
Y      : vazio | + expr | - expr
term   : factZ
Z      : vazio | * term | / term
fact   : NUM | VAR | OE expr CE
        */

        public void Prog() // prog   : lineX
        {
            Line();
            X();
        }

        public void X() //X : EOF | prog
        {
            if (_lookAhead.Type == ETokenType.EOF)
                Match(ETokenType.EOF);
            else
                Prog();
        }

        public void Line() // line   : stmt EOL
        {
            Stmt();
            Match(ETokenType.EOL);
        }
    
        public void Stmt() //stmt   : in | out | atrib  
        {
             if (_lookAhead.Type == ETokenType.INPUT)
                 Input();
             else if (_lookAhead.Type == ETokenType.OUTPUT)
                 Output();
             else if (_lookAhead.Type == ETokenType.VAR)
                 Atrib();
             else
                Error("");
        }

        public void Input() // in     : INPUT VAR
        {
            Match(ETokenType.INPUT);
            Match(ETokenType.VAR);
        }

        public void Output() // out    : OUTPUT VAR
        {
            Match(ETokenType.OUTPUT);
            Match(ETokenType.VAR);
        }

    }
}