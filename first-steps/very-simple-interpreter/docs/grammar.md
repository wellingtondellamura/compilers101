

prog   : line | line prog
line   : stmt EOL
stmt   : in | out | atrib
in     : INPUT VAR
out    : OUTPUT VAR
atrib  : VAR AT expr
expr   : term | term + expr | term - expr 
term   : fact | fact * term | fact / term
fact   : NUM | VAR | OE expr CE

EOL    : [\n\r]+
INPUT  : 'read'
OUTPUT : 'write'
VAR    : [a-z]+
AT     : '='
OE     : '('
CE     : ')'
SUM    : '+'
SUB    : '-'
DIV    : '/'
MULT   : '*'