#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <p24fxxxx.h>
#include "BSPUART.h"
#include "UartLoadApp.h"
//#include "DataRecord.h"
//#include "InnerFlash.h"

//=============================================================================================
//??????
//=============================================================================================
static u8 flashdata[50]={0};
static u8 gFlashBuf[2048]={0};
u32 ReadytoUploadAddr=0;
u32 totalsize=0;	//????
u16 totalframe=0;		//???
u16 totalflashframe=0;	//?flash??
u16 curframesize=0;	//?????128??????128??
u8  gIsFullFlash2048=0;
u8  gIsFullFrame128=0;
u8 gCurFlashFrame=0;
u8 gCurSize=0;
u32 gTranSize=0;
u16 curframe=0;
u8 gUpdataComplete[2]={0x5a,0xa5};
u16 gUpdateLoadSecNum = 0;                      //??????
u32 gRcvCRC32=0xffffffff;
u32 gCalcCRC32=0xffffffff;
u16 gIndex=0;
u32 crc32data=0;

//u32 FLASHAPPBASEADDR=0x8003000;
/*-------------?????????Buf-------------*/
u8 gRxBuf[300] = {0};

u16 gRxlength = 0;
u8 gRxFlag = 0;
u8 gTxBuf[TX_BUF_LENGTH] = {0};

static u16 CalcCheckSum(u8 *chkbuf, u16 len)
{ 
//	u16  uIndex;            //?????
	u16  temp_code=0;
	
	while (len)
	{
    temp_code+= chkbuf[len-1];
		len--;
	}
	
	return(temp_code);
	
}
static uint32_t CRC32_MPEG_2(uint32_t crc32,u8 data[], int length)
{
		u16 i;
		u32 crc = 0xffffffff, j = 0;
	
		crc=crc32;

		while ((length--) != 0)
		{
				crc ^= (u32)data[j] << 24;
				j++;
				for (i = 0; i < 8; ++i)
				{
						if ((crc & 0x80000000) != 0)
								crc = (crc << 1) ^ 0x04C11DB7;
						else
								crc <<= 1;
				}
		}
		return crc;
}
  
static void ReplyToPC(u8 *pdata,u8 len)
{
   // u16 txlength = 0;
    u16 i = 0;
    u16 crc = 0;
    
    gTxBuf[0] = 0x3a;          //????
    gTxBuf[1] = 0x16;          //??? 
    gTxBuf[2] = 0xf0; 
    gTxBuf[3] = len;                 //??Byte
    	
    for(i = 0;i < len;i++)
    {
        gTxBuf[i+4] =pdata[i+1];    				 	
    }
    
    crc = CalcCheckSum(&gTxBuf[1],len+3);	
    
    gTxBuf[len+4] = (u8)(crc & 0xff);
    gTxBuf[len+5] = (u8)((crc >> 8) & 0xff);
	
    gTxBuf[len+6] = 0x0d;
    gTxBuf[len+7] = 0x0a;
    (void)SCISendDataOnISR(gTxBuf,len+8);  
}
static void Hello_GetFWInfo()
{
    static u8 sTxbuf[50]={0};
     
    sTxbuf[0]=0x10;     //??
    sTxbuf[1]=0xf5;     //??
    sTxbuf[2]=SW_VERSION_L;
    sTxbuf[3]=SW_VERSION_H;
    sTxbuf[4]=gTranSize;
    sTxbuf[5]=gTranSize>>8;
    sTxbuf[6]=gTranSize>>16;
    sTxbuf[7]=gIndex;
    sTxbuf[8]=gIndex>>8;
    sTxbuf[9]=crc32data;
    sTxbuf[10]=crc32data>>8;
    sTxbuf[11]=crc32data>>16;
    sTxbuf[12]=crc32data>>24;
    sTxbuf[13]=0xff;
    sTxbuf[14]=0xff;
    sTxbuf[15]=0xff;
    sTxbuf[16]=0xff;
    sTxbuf[17]=0xff;
  
     ReplyToPC(sTxbuf,17);
  //  SCISendDataOnISR(sTxbuf,18);
}
static void Hello_SendFWInfo()
{    
    static u8 sTxbuf[50]={0};     
    sTxbuf[0]=0x02;	
    sTxbuf[1]=0xf6;	
    sTxbuf[2]=0x00;
      
     ReplyToPC(sTxbuf,2);
  
}
static void Hello_SendFWData()
{    
    static u8 sTxbuf[50]={0};     
    sTxbuf[0]=0x02;	
    sTxbuf[1]=0xf7;	
    sTxbuf[2]=0x00;
      
     ReplyToPC(sTxbuf,2);
  
}
static u8 UartRcvMsgDeal(void)
{  
		u16 i=0;
		u8 head=0;
		u8 address=0;
		u8 cmd=0;
		u8 len=0;		
		u32 crc32=0;			//CRC32
		u8 bootcmd=0;	
	//	static u8 sTxbuf[50]={0};
	
		head=gRxBuf[0];
		address=gRxBuf[1];		
		bootcmd=gRxBuf[2];
		len=gRxBuf[3];
		cmd=gRxBuf[4];
		
	if(head != 0x3a||address!=0x16||gRxBuf[len+6]!=0x0d||gRxBuf[len+7]!=0x0a)   // 
	{
	    return FALSE;
	}  	 
	switch(cmd)
	{ 
			case 0xf2:   		//??????
 
			break;	
			case 0xf3:   		//mcu??
            
			 
			break;
			case 0xf4:     	//???app       
//					FLASH_If_Erase(0x8010000);
				//	flashResult = FLASH_If_Write(0x8010000,gUpdataComplete,2);   
			//		NVIC_SystemReset();  
			break;	
			case 0xf5:   		//??????
                Hello_GetFWInfo();
                (*((void(*)(void))0x4000))();        //??0x4000
              
			break;	
			case 0xf6:   		//??????
   
				totalsize=gRxBuf[7]+(gRxBuf[8]<<8)+(gRxBuf[9]<<16);
				totalframe=gRxBuf[10]+(gRxBuf[11]<<8);
				gRcvCRC32=gRxBuf[12]+(gRxBuf[13]<<8)+(gRxBuf[14]<<16)+(gRxBuf[15]<<24);;
				ReadytoUploadAddr=0;
				gTranSize=0;
                if(totalsize%2048==0)
                {
                    gIsFullFlash2048=1; 		//?????
                    totalflashframe=totalsize/2048;
                }
                else
                {
                  totalflashframe=totalsize/2048+1;
                    gIsFullFlash2048=0;	 	//???????2048
                }
			
                if(totalsize%128==0)
                {
                    gIsFullFrame128=1; 
                    totalframe=totalsize/128;
                }
                else
                {
                    totalframe=totalsize/128+1;
                    gIsFullFrame128=0;	 
                }
                Hello_SendFWInfo();
             
			break;	
            
			case 0xf7:   												 
			gCurSize=gRxBuf[3];                                         // ???
			curframe=gRxBuf[5]+(gRxBuf[6]<<8);                          //????? 	
			gIndex++;
			if(gIndex==curframe+2)
			{
			 		gTranSize+=gCurSize-3;								//?????? 
					crc32data=CRC32_MPEG_2(crc32data,&gRxBuf[7],gCurSize-3);
			} 
			memcpy(&gFlashBuf[(curframe%16)*128],&gRxBuf[7],gCurSize-3); //??gRxBuf?gFlashBuf
	 
			if(gIsFullFlash2048==1)                                      //  hex???2048???
			{						
				if(gCurFlashFrame<totalflashframe)      
				{	
						if((curframe+1)%8==0)
						{							
						//		FLASH_If_Erase(0x8003000+ReadytoUploadAddr);
						//		flashResult = FLASH_If_Write(ReadytoUploadAddr+0x8003000,gFlashBuf,2048);  
								gCurFlashFrame+=1;
								memset(gFlashBuf,0,2048);
								ReadytoUploadAddr+=0x800;
						}
				}
			
			}
			else                            //  hex????2048???
			{			
					if(gCurFlashFrame<totalflashframe)          //???????????
					{		
							if((curframe+1)%16==0)		//0~15 ?1?flash??   ??????curframe ==15
							{		
								//	FLASH_If_Erase(0x8003000+ReadytoUploadAddr);
								//	flashResult = FLASH_If_Write(ReadytoUploadAddr+0x8003000,gFlashBuf,2048);  
									gCurFlashFrame+=1;
									memset(gFlashBuf,0xff,2048);
									ReadytoUploadAddr+=0x800;
							}
							else if(curframe==totalframe-1)
							{
								//	FLASH_If_Erase(0x8003000+ReadytoUploadAddr);
							//		flashResult = FLASH_If_Write(ReadytoUploadAddr+0x8003000,gFlashBuf,2048);  
									gCurFlashFrame+=1;
								//	memset(gFlashBuf,0,2048);
									//ReadytoUploadAddr+=0x800;
							}
					}
			}		
            Hello_SendFWData();
			break;	
	   
	    default:
	        break;
	}
	
	return (FALSE);
}
     
void UartCanLoaderTask(void)
{
	u16 crc = 0;
	u16 RxCrc = 0;
	static u32 sTime = 0;
	
//????????
//	if(USART_GetFlagStatus(USART2, USART_FLAG_RXNE))
    if(U1STA&(1<<0)==(1<<0))
	{	    	//?RDRE
	//	USART_ClearFlag(USART2, USART_FLAG_RXNE);  
	//	gRxBuf[gRxlength] = USART_ReceiveData(USART2) ;
        gRxBuf[gRxlength] =U1RXREG;
		gRxlength++;
		
		if(gRxlength >= RX_BUF_LENGTH)		//??????buf??????????????????130+8
		{		
			gRxlength = 0;
		}		
		gRxFlag  = 1;
		sTime = 0;
	}
	else
	{
		sTime++;	
	}

	if((gRxFlag == 1) && (sTime >= 20000))//??????????
	{		
		gRxFlag = 0;	
		sTime = 0;
		//CRC??
		if(gRxlength >= 8)		//???????8 
		{			
			crc = CalcCheckSum((gRxBuf+1),(gRxlength - 5));	
									
			RxCrc = gRxBuf[gRxlength - 3];
			RxCrc = (RxCrc << 8) + gRxBuf[gRxlength-4];
		}

		if(crc == RxCrc)
		{		 
			UartRcvMsgDeal();
		}
		gRxlength = 0;
	}
}