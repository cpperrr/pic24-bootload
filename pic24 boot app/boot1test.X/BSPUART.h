/* 
 * File:   BSPUART.h
 * Author: Administrator
 *
 * Created on 2019?7?20?, ??10:44
 */

#ifndef BSPUART_H
#define	BSPUART_H

#ifdef	__cplusplus
extern "C" {
#endif
    
#include  "BSPTypeDef.h"


void Uart1_Init(void);
u8 SCISendDataOnISR(u8 *sendbuf,u8 size);

#ifdef	__cplusplus
}
#endif

#endif	/* BSPUART_H */

