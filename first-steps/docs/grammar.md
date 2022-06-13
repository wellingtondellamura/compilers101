# Parser Grammar

prog   : line | line prog
line   : stmt EOL
stmt   : in | out | atrib
in     : INPUT VAR
out    : OUTPUT VAR
atrib  : VAR AT expr
expr   : term | term SUM expr | term SUB expr 
term   : fact | fact MUL term | fact DIV term
fact   : NUM | VAR | OE expr CE



# Lexer Grammar

INPUT  : 'read'
OUTPUT : 'write'
VAR    : [a-z]+
SUM    : '+'
SUB    : '-'
MUL    : '*'
DIV    : '/'
AT     : '='
OE     : '('
CE     : ')'
EOL    : [\n\r]+