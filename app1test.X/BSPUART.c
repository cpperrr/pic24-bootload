#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <p24fxxxx.h>
#include  "BSPTypeDef.h"


static void Uart1_Putc(u8 ch)
{ 
 
     while(U1STAbits.UTXBF == 1)
    { }
    U1TXREG = ch;
 
}

// 115200 RD3 RD2  uart1
void Uart1_Init(void)
{
    _RP22R = 3;// RD3
    _U1RXR = 23;// RD2
    
    _LATD3 = 1;             
    _TRISD2 = 1;            
    _TRISD3 = 0;            
    
    _LATD6 = 0;             
    _TRISD6 = 0;            
    
    U1MODE = 0X8808;        
    U1STA = 0X2400;         
    // 4M/(34+1) = 114285
    U1BRG = 34;            
    
   // _U1TXIP = 3;            
  //  _U1RXIP = 7;            
    _U1TXIF = 0;
	_U1RXIF = 0;
	_U1TXIE = 0;           
	_U1RXIE = 0;            
}

u8 SCISendDataOnISR(u8 *sendbuf,u8 size)
{
    uint8_t timerCount = 0;    
  	
		while(size--)
		{     
            Uart1_Putc(*sendbuf);
 
			sendbuf++;
		} 	
 	
    return (1) ;  
}

void __attribute__((__interrupt__,no_auto_psv)) _U1RXInterrupt(void)
{
    char temp = 0;
    
    do {
        temp = U1RXREG;
        // Uart1_Putc(temp);
        _U1RXIF = 0;
        if (U1STAbits.OERR) {
            U1STAbits.OERR = 0;
        } else {
            // printf("%.2X\n", temp);
            // ringbuffer_write_byte(&tmp_rbuf,temp);
            // printf("recv len = %d\n", IsTmpRingBufferAvailable());
        }
    } while (U1STAbits.URXDA);
}
