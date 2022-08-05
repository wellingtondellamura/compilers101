grammar TestGrammar;

expr : NUM '+' expr
     | NUM
     ;

NUM  : [0-9]+;
SUM  : '+';