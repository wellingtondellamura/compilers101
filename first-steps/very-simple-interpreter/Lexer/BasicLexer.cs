namespace very_simple_interpreter.Lexer
{
    public class BasicLexer
    {
        public string Filename {get; protected set;}
        private char? _peek;
        private StreamReader _reader;            

        public BasicLexer(string filename) 
        {
            Filename = filename;
            _reader = new StreamReader(Filename);
        }

        public Token GetNextToken()
        {
            if (_peek == null)
                _peek = NextChar();

            if (_peek == null)
                return new Token(ETokenType.EOF);
            
            switch (_peek) 
            {
                case '+': return new Token(ETokenType.SUM);
                case '-': return new Token(ETokenType.SUB);
                case '*': return new Token(ETokenType.MULT);
                case '/': return new Token(ETokenType.DIV);
                case '(': return new Token(ETokenType.OE);
                case ')': return new Token(ETokenType.CE);
                case '=': return new Token(ETokenType.AT);
                case '\n':
                case '\r': return new Token(ETokenType.EOL);                
            }

            if (_peek == '$')  //$[a-z]+
            {
                do {
                    _peek = NextChar();                        
                } while (Char.IsLetter(_peek.Value));
                return new Token(ETokenType.VAR);
            }

            if (_peek == 'r')  //'read'
            {
                
                return new Token(ETokenType.INPUT);
            }

            if (_peek == 'w')  //'write'
            {
                
                return new Token(ETokenType.OUTPUT);
            }
            if (Char.IsDigit(_peek.Value))
            {
                return new Token(ETokenType.NUM);
            }        
            
            return new Token(ETokenType.EOF);
        }

        private char? NextChar()
        {
            if (!_reader.EndOfStream)
                return (char?) _reader.Read();
            return null;
        }

    }
}