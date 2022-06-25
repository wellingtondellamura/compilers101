using System;

namespace vst
{
    public enum ETokenType 
    {
        SUM, SUB, OPEN, CLOSE, NUM, VAR, EOF
    }

    public class Token
    {
        public ETokenType Type {get;set;}
        public Int32 Value {get;set;}

        public Token(ETokenType type, Int32 value = 0)
        {
            Type = type;
            Value = value;
        }
    }

    public class Program
    {
        static string _input;
        static int _position = -1;
        static Token _lookahead;
        static Token nextToken()
        {
            char peek;
            _position++;
            if (_position < _input.Length-1)
                peek = _input[_position];
            else
                return new Token(ETokenType.EOF);
            switch (peek){
                case '+': return new Token(ETokenType.SUM);
                case '-': return new Token(ETokenType.SUB);
                case '(': return new Token(ETokenType.OPEN);
                case ')': return new Token(ETokenType.CLOSE);
            }
            if (Char.IsDigit(peek))
                return new Token(ETokenType.NUM);
            if (Char.IsLetter(peek))
                return new Token(ETokenType.VAR);
            
            //erro léxico
            return new Token(ETokenType.EOF);
        }

        static void error(string message)
        {
            Console.WriteLine("Erro! "+ message);
            Environment.Exit(0);
        }

        static void match(ETokenType type)
        {
            Console.WriteLine("match " + _lookahead.Type);
            if (_lookahead.Type == type)
                _lookahead = nextToken();
            else
                error("Token inválido");
        }

        static void E() //E  ::= TR
        {
            Console.WriteLine("E " + _lookahead.Type);
            T();
            R();
        }
        static void R() //R  ::= + E | - E | ε
        {
            Console.WriteLine("R " + _lookahead.Type);
            if (_lookahead.Type == ETokenType.SUM)
            {
                match(ETokenType.SUM);
                E();
            } 
            else if (_lookahead.Type == ETokenType.SUB)
            {
                match(ETokenType.SUB);
                E();
            } else if (_lookahead.Type != ETokenType.EOF)
            {
               error("Símbolo inesperado em R");
            }
        }        
        static void T() //T  ::= ( E ) | NUM | VAR
        {
            Console.WriteLine("T " + _lookahead.Type);
            if (_lookahead.Type == ETokenType.OPEN)
            {       
                match(ETokenType.OPEN);         
                E();
                match(ETokenType.CLOSE);
            } 
            else if (_lookahead.Type == ETokenType.NUM)
            {
                match(ETokenType.NUM);
                
            } 
            else if (_lookahead.Type == ETokenType.VAR)
            {
                match(ETokenType.VAR);
            }
        }


        public static void Main(string[] args)
        {
            Console.WriteLine("Insira a expressão");
            _input = Console.ReadLine();
            _lookahead = nextToken();
            E();
            Console.WriteLine("Sucesso");
        }
    }
}