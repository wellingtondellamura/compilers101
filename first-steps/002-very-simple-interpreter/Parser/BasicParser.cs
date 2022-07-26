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
                Error("Expected " + type + " - Found " + _lookAhead.Type);
        }

        public void Error(String msg)
        {
            Console.WriteLine("#Error on _____");
            Console.WriteLine("Line " + _lexer.Line);
            Console.WriteLine("Column " + _lexer.Column);
            Console.WriteLine("________________");
            Console.WriteLine(msg);
            Console.WriteLine("________________");
        }

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
                Error("Expected INPUT, OUTPUT or VAR");
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

        public void Atrib() // atrib  : VAR AT expr
        {
            Match(ETokenType.VAR);
            Match(ETokenType.AT);
            Expr();
        }

        public void Expr() //expr   : termY
        {
            Term();
            Y();
        }
        public void Y() //Y      : vazio | + expr | - expr
        {
            if (_lookAhead.Type == ETokenType.SUM)
            {
                Match(ETokenType.SUM);
                Expr();
            }
            else if (_lookAhead.Type == ETokenType.SUB)
            {
                Match(ETokenType.SUB);
                Expr();
            }
            else if (!TestFollow(ETokenType.CE, ETokenType.EOL))
            {
                Error("Expected SUM, SUB, CE or EOL");
            }
        }

        public void Term() //term   : factZ
        {
            Fact();
            Z();
        }
        public void Z() //Z      : vazio | * term | / term
        {
            if (_lookAhead.Type == ETokenType.MULT)
            {
                Match(ETokenType.MULT);
                Term();
            }
            else if (_lookAhead.Type == ETokenType.DIV)
            {
                Match(ETokenType.DIV);
                Term();
            }
            else if (!TestFollow(ETokenType.CE, ETokenType.EOL))
            {
                Error("Expected SUM, SUB, CE or EOL");
            }
        }
        public void Fact() //fact   : NUM | VAR | OE expr CE
        {
            if (_lookAhead.Type == ETokenType.NUM)
                Match(ETokenType.NUM);
            else if (_lookAhead.Type == ETokenType.VAR)
                Match(ETokenType.VAR);
            else if (_lookAhead.Type == ETokenType.OE)
            {
                Match(ETokenType.OE);
                Expr();
                Match(ETokenType.CE);
            }
            else
                Error("Expected NUM, VAR or OE");

        }

        private bool TestFollow(params ETokenType[] list)
        {
            return list.ToList().Exists(t => _lookAhead.Type == t);
        }

    }
}