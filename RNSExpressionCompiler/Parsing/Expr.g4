grammar Expr;

r : expr EOF ;

expr 
	: '-' expr #unaryMinus
	| expr op=('*'|'/') expr #multiplication
	| expr op=('+'|'-') expr #addition
	| '(' expr ')' #parentheses
	| NUM #atomNum
	| modList #rnsNum
	;

modList : '{' NUM+ '}' ; 

NUM : [0-9]+ ;
WS : [ \r\n\t] -> skip ;