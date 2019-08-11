/* 
 * File:   UartLoadApp.h
 * Author: dell
 *
 * Created on July 18, 2019, 10:07 PM
 */

#ifndef UARTLOADAPP_H
#define	UARTLOADAPP_H

#ifdef	__cplusplus
extern "C" {
#endif

#ifndef TRUE
	#define TRUE  1
#endif

#ifndef FALSE
	#define FALSE 0
#endif

#define SW_VERSION_L 0
#define SW_VERSION_H 0

#define APPLICATION_ADDRESS 0x8000
#define FLASH_APP1_ADDR		0x08002000  	//???????????(???FLASH)
#define APPUPDATE_FLAG    0x5aa5

#define FLASH_IAP_ADDR		0x08000000  	//iap??????(???FLASH)
		
#define APP_CONFIG_ADDR 		0X08001FFC	//????

#define PROTUES_TYPE                (0)         //0Modbus??
#define MODBUS_BOOTStart_ADDR       (33)    //BOOT???????
#define MODBUS_BOOTSTATE_LEN        (9)
#define MODBUS_BOOTEnd_ADDR         (MODBUS_BOOTStart_ADDR + MODBUS_BOOTSTATE_LEN - 1)

#define MODBUS_CMD_ADDR             (MODBUS_BOOTStart_ADDR + MODBUS_BOOTSTATE_LEN)
#define MODBUS_CMD_LEN              (2)

#define MODBUS_LOAD_ADDR            (MODBUS_CMD_ADDR + MODBUS_CMD_LEN)
#define MODBUS_LOAD_LEN             (1028)


#define RX_BUF_LENGTH           (200)
#define TX_BUF_LENGTH           (50)
//#define SECTION_LENGTH          (1024)

//??BUF??
#define ADDR_SELF    			110        //UART2??MODBUS???????

//???
#define READ_CODE    			0x03        //???     
#define WRITE_SINGLE_CODE		0x06        //?????
#define WRITE_CODE   			0x10        //?????

#define  BOOT_VERSION               (0x300)            /*Boot?????*/
//#define  PRO_ENTRY_POINT     	    (0x197b)        	/*????????*/
//#define  BOOT_ENRTY_POINT    	    (0x10fb)        	/*Boot??????*/
//#define  PROGRAME_FLASH_START       (0x1900)    		/*????????*/
//#define  PROGRAME_FLASH_END         (0xdbff)       	    /*????????*/ 
 
//#define  BOOT_PRO_FLAG       		(0x5AA5)         	/*??????*/
//#define PROGRAME_FLASH_START  (0x1900)     /*????????*/
//#define PROGRAME_FLASH_END    (0xdbff)     /*????????*/   

//#define PROGRAME_CRC_START    (0x1900)      /*??????????*/
//#define PROGRAME_CRC_END      (0x1D00)      /*??????????*/  
//#define PROGRAME_CRC_LENGTH (PROGRAME_CRC_END - PROGRAME_CRC_START)     //????

#define BOOT_VERSION        (0x300)         /*Boot?????*/
#define BOOT_TRANS_FLAG     (0x5AA5)        /*????*/
#define BOOT_PRO_FLAG       (0x5AA5)        /*??????*/
#define BOOT_PRO_TRY_FLAG   (0x5AA5)        /*???????*/

//#define PRO_ENTRY_POINT     (0x197b)        /*????????*/
//#define BOOT_ENRTY_POINT    (0x10fb)        /*Boot??????*/

//=============================================================================================
//??????
//=============================================================================================
typedef enum _BOOT_STATE_INFO
{
    e_PRO_TYPE     = 0,            //????
    e_DEVICE_TYPE  = 1,            //????
    e_DEVICE_NUM   = 2,            //???
    e_CHIP_TYPE    = 3,            //????
    e_SOFT_VERSION = 4,             //?????
    e_BOOT_VERSION = 5,             //BOOT???
    e_CANLOAD_STATE = 6,            //????
    e_RUN_STATE     = 7,            //????
    e_LOADING_NUM   = 8,            //???????
    e_CANLOAD_BUF_NUM = 9           //?????
}E_BOOT_STATE;

typedef enum _MCU_TYPE_
{
    e_FREESCALE_DZ60 = 0,       //????
    e_FREESCALE_XEQ512 = 1,
    e_COMTEX_TM4C129ENDPT = 2,
}E_MCU_TYPE;

typedef enum _RUNMODEL_ENUM_
{
    e_TRANSMIT_MODEL = 0,    //????
    e_CANLOAD_MODEL = 1,     //????
    e_PROGRAME_MODEL = 2,    //????????   
}E_RUNMODEL;

typedef enum _RUNMODEL_STATE_
{
    e_LOADTRANSMIT_STATE    = 0,            /*?????????*/
    e_PROTRANSMIT_STATE     = 1,            /*????????*/
    e_CANLOADREADY_OK       = 2,            /*????*/
    e_CANLOADREADY_FAIL     = 3,            /*??????*/
   // e_CANLOADPRE_OK         = 4,            /*????*/
    e_CANLOADTRANSMITING    = 5,            /*????*/   
    e_CANLOADTRANSMIT_FAIL  = 6,            /*????*/
 //   e_CANLOADTRANSMIT_OK    = 7,            /*????*/
    e_CANLOADFLASH_FAIL     = 8,            /*????*/
    e_CANLOADFLASH_OK       = 9,             /*????*/
    e_PRORUN_STATE          = 10,           /*????????*/
}E_RUNMODEL_STATE;

typedef enum _MESSAGE_TYPE_
{
    e_Cmd_IntoTransmit      = 0xE0,                 /*??????*/
    e_Cmd_ExitTransmit      = 0xE1,                 /*??????*/
    e_Cmd_Reset             = 0xE2,                 /*????*/
    e_Cmd_IntoLoad          = 0xE3,                 /*????*/
    e_Cmd_ExitLoad          = 0xE4,                 /*????*/
    e_Cmd_FinishLoad        = 0xE5,                 /*????*/
}E_MESSAGE_TYPE;

typedef enum _BOOT_FLAG_ADDR_               /*?????0xD600*/
{
    e_BOOT_TRANSMIT_FLAG_ADDR = 6,          /*????????*/
    e_BOOT_CRC_ADDR = 8,                    /*????CRC????*/
    e_BOOT_PRO_FLAG_ADDR = 10,              /*??????*/
    e_BOOT_PRO_TRY_FLAG_ADDR = 12,          /*??????*/
    e_BOOT_PRO_VERSION_ADDR = 14,           /*???????*/ 
    e_BOOT_SOTE_VERION_ADDR = 16,           /*Boot?????????*/
    e_BOOT_NETECU_FLAG = 20,               /*??????????????*/
		e_BOOT_NET_ADDR = 22,                  /*????????*/
    e_BOOT_ECU_ADDR = 24,                  /*???????*/

}E_BOOT_FLAG_ADDR;



#ifdef	__cplusplus
}
#endif

#endif	/* UARTLOADAPP_H */

