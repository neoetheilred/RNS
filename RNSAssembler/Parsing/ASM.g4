grammar ASM;

asm: base commands EOF ;
base: num_list '\r\n';
commands: ((label | command) '\r\n')* ;
label: LABEL':' ;
command: arithmetic | control_flow | stack | tdc ;
arithmetic: cmd=(ADD | SUB | MUL | DIV | MOD | CMP | NEG) ;
control_flow: cmd=(JMP | JEQ | JNE | JLT | JGT | JLE | JGE ) LABEL ;
tdc : TDC ;
num_list : '{' NUMBER+ '}' ;
stack : 
	PUSH (NUMBER | num_list) #pushNum
	| POP reg=('A' | 'B') #popReg
	| PUSHR #pushR 
	| DUP #dup ;

NUMBER : [0-9]+;
ADD : 'ADD';
SUB : 'SUB';
MUL : 'MUL';
MOD : 'MOD';
DIV : 'DIV';
CMP : 'CMP';
TDC : 'TDC';
PUSH : 'PUSH';
PUSHR: 'PUSHR';
POP : 'POP' ;
JMP : 'JMP' ;
JNE : 'JNE' ;
JEQ : 'JEQ' ;
JLT : 'JLT' ;
JGT : 'JGT' ;
JLE : 'JLE' ;
JGE : 'JGE' ;
DUP : 'DUP' ;
NEG : 'NEG' ;

LABEL : [A-Z][A-Z0-9]* ;

WS : [ \r\n\t] -> skip ;
COMMENT : ';'~[\r\n]* -> skip ;