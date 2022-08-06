grammar TestGrammar;


atrib: VAR '=' expr
     ;
expr : NUM '+' expr 
     | NUM '-' expr
     | NUM          
     ;

NUM  : [0-9]+;
SUM  : '+';
SUB  : '-';
VAR  : [a-zA-Z]+;
IF   : [iI][fF];