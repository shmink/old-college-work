 include 'emu8086.inc' ;Needed for the print function
 
  
 PRINTN 'Wake Up!' ; Prints text to screen
 PRINTN 'Time for breakfast' ; Prints text to screen 
 MOV BL, 0     ;Makes the BL register 0
 INC BL        ;Increment BL register
 CMP BL, 10    ;Compare BL to 10 
 JG TEXTLUNCH  ;If BL = 10 go to label TEXTLUNCH
 
 TEXTLUNCH:    ;Label for jumping to
 PRINTN 'Time for lunch' ;Print text to screen
 
 CMP BL, 30   ;Compare BL to 30
 JG TEXTDINNER  ;If BL = 30 go to label TEXTDINNER
 
 TEXTDINNER:   ;Label for jumping to
 PRINTN 'Time for dinner' ;Prints text to screen 
 
 CMP BL, 80   ;Comapre BL to 80
 JG TEXTSLEEP  ;IfBL = 80 jump to label TEXTSLEEP
 
 TEXTSLEEP:  ;Label for jumping to
 PRINTN 'Time for bed' ;Prints text to screen

 END  ;Ends the program