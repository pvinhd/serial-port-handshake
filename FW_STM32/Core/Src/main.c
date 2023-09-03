/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.c
  * @brief          : Main program body
  ******************************************************************************
  * @attention
  *
  * <h2><center>&copy; Copyright (c) 2022 STMicroelectronics.
  * All rights reserved.</center></h2>
  *
  * This software component is licensed by ST under BSD 3-Clause license,
  * the "License"; You may not use this file except in compliance with the
  * License. You may obtain a copy of the License at:
  *                        opensource.org/licenses/BSD-3-Clause
  *
  ******************************************************************************
  */
/* USER CODE END Header */
/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "usart.h"
#include "gpio.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include <stdio.h>
#include <string.h>
#include <stdbool.h>
/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */

/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */
#define MAX_LEN 18
/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */

/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/

/* USER CODE BEGIN PV */
uint8_t *subString(uint8_t *s, int pos, int index);
bool StrCompare (uint8_t *pBuff, uint8_t *Sample, uint8_t nSize);
bool WriteCom(uint8_t *pBuff, uint8_t nSize);
bool ReadComm(uint8_t *pBuff, uint8_t nSize);
bool serialProcess(void);

/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
/* USER CODE BEGIN PFP */

/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/
/* USER CODE BEGIN 0 */
uint8_t nRxData[MAX_LEN];
uint8_t nTxData[MAX_LEN];
uint8_t strCommand[4];
uint8_t strOpt[3];
uint8_t strData[8];

bool bDataAvailable = false;
uint8_t STX[]= {0x02U};
uint8_t ETX[]= {0x03U};
uint8_t ACK[]= {0x06U}; 
uint8_t SYN[]= {0x16U};

uint8_t led_control;

uint8_t *subString(uint8_t *s, int pos, int index)
{
  uint8_t *t = &s[pos];
  s[pos - 1] = '\0';
  for (int i = index; i<(strlen((char*)t)+1); i++)
  {
    t[i] = '\0';
  }
  return t;
}

bool StrCompare (uint8_t *pBuff, uint8_t *Sample, uint8_t nSize)
{
  for (int i =0 ; i <nSize; i++)
  {
    if(pBuff[i] != Sample[i])
    {
      return false;
    }
  }

  return true;
}

bool WriteCom(uint8_t *pBuff, uint8_t nSize)
{
  return HAL_UART_Transmit(&huart1, pBuff, nSize, 1000);
}


bool ReadComm(uint8_t *pBuff, uint8_t nSize)
{
  if((pBuff[0] == STX[0] && (pBuff[17] == ETX[0])))
  {
    memcpy(strCommand, subString(pBuff, 1,4), 4);
    memcpy(strOpt, subString(pBuff, 5,3), 3);
    memcpy(strData, subString(pBuff, 8,8), 8);

    bDataAvailable = true;
  }
  else
  {
    bDataAvailable = false;
  }
  return bDataAvailable;
}

bool serialProcess(void)
{
  uint8_t nIndex = 0;

  if(bDataAvailable == true)
  {
  if(StrCompare(strCommand, (uint8_t *)"MOVL", 4))
  {
    memcpy(nTxData + nIndex, STX, 1);
    nIndex += 1;
    memcpy(nTxData + nIndex, strCommand, 4);
    nIndex+=4;
    memcpy(nTxData + nIndex, strOpt, 3);
    nIndex += 3;
    memcpy(nTxData + nIndex, strData, 8);
    nIndex+=8;
    memcpy(nTxData + nIndex, ACK, 1);
    nIndex += 1;
    memcpy(nTxData + nIndex, ETX, 1);

    WriteCom(nTxData, MAX_LEN);
  }

  else if(StrCompare(strCommand, (uint8_t *)"GPOS", 4))
  {
    memcpy(nTxData + nIndex, STX, 1);
    nIndex += 1;
    memcpy(nTxData + nIndex, strCommand, 4);
    nIndex+=4;
    memcpy(nTxData + nIndex, strOpt, 3);
    nIndex += 3;
    memcpy(nTxData + nIndex, strData, 8);
    nIndex+=8;
    memcpy(nTxData + nIndex, ACK, 1);
    nIndex += 1;
    memcpy(nTxData + nIndex, ETX, 1);

    WriteCom(nTxData, MAX_LEN);
  }

  else if(StrCompare(strCommand, (uint8_t *)"GVEL", 4))
  {
    memcpy(nTxData + nIndex, STX, 1);
    nIndex += 1;
    memcpy(nTxData + nIndex, (uint8_t *) strCommand, 4);
    nIndex+=4;
    memcpy(nTxData + nIndex, (uint8_t *) strOpt, 3);
    nIndex += 3;
    memcpy(nTxData + nIndex, (uint8_t *) strData, 8);
    nIndex+=8;
    memcpy(nTxData + nIndex, ACK, 1);
    nIndex += 1;
    memcpy(nTxData + nIndex, ETX, 1);
    nIndex += 1;

    WriteCom(nTxData, MAX_LEN);
  }

    else if(StrCompare(strCommand, (uint8_t *)"GSTT", 4))
  {
    memcpy(nTxData + nIndex, STX, 1);
    nIndex += 1;
    memcpy(nTxData + nIndex, (uint8_t *) strCommand, 4);
    nIndex+=4;
    memcpy(nTxData + nIndex, (uint8_t *) strOpt, 3);
    nIndex += 3;
    memcpy(nTxData + nIndex, (uint8_t *) strData, 8);
    nIndex+=8;
    memcpy(nTxData + nIndex, (uint8_t *) ACK, 1);
    nIndex += 1;
    memcpy(nTxData + nIndex, ETX, 1);
    nIndex += 1;
    
    WriteCom(nTxData, MAX_LEN);
  }
  
	else if(StrCompare(strCommand, (uint8_t *)"RESS", 4))
  {
	 led_control = 1;
    memcpy(nTxData + nIndex, STX, 1);
    nIndex += 1;
    memcpy(nTxData + nIndex, (uint8_t *) strCommand, 4);
    nIndex+=4;
    memcpy(nTxData + nIndex, (uint8_t *) strOpt, 3);
    nIndex += 3;
    memcpy(nTxData + nIndex, (uint8_t *) strData, 8);
    nIndex+=8;
    memcpy(nTxData + nIndex, (uint8_t *) ACK, 1);
    nIndex += 1;
    memcpy(nTxData + nIndex, ETX, 1);
    nIndex += 1;
    
    WriteCom(nTxData, MAX_LEN);
  }
  
  else if(StrCompare(strCommand, (uint8_t *)"SETT", 4))
  {
	led_control = 2;
    memcpy(nTxData + nIndex, STX, 1);
    nIndex += 1;
    memcpy(nTxData + nIndex, (uint8_t *) strCommand, 4);
    nIndex+=4;
    memcpy(nTxData + nIndex, (uint8_t *) strOpt, 3);
    nIndex += 3;
    memcpy(nTxData + nIndex, (uint8_t *) strData, 8);
    nIndex+=8;
    memcpy(nTxData + nIndex, (uint8_t *) ACK, 1);
    nIndex += 1;
    memcpy(nTxData + nIndex, ETX, 1);
    nIndex += 1;
    
    WriteCom(nTxData, MAX_LEN);
  }
  
  else if(StrCompare(strCommand, (uint8_t *)"TOGG", 4))
  {
	led_control =3;
    memcpy(nTxData + nIndex, STX, 1);
    nIndex += 1;
    memcpy(nTxData + nIndex, (uint8_t *) strCommand, 4);
    nIndex+=4;
    memcpy(nTxData + nIndex, (uint8_t *) strOpt, 3);
    nIndex += 3;
    memcpy(nTxData + nIndex, (uint8_t *) strData, 8);
    nIndex+=8;
    memcpy(nTxData + nIndex, (uint8_t *) ACK, 1);
    nIndex += 1;
    memcpy(nTxData + nIndex, ETX, 1);
    nIndex += 1;
    
    WriteCom(nTxData, MAX_LEN);
  }
  
    else 
  {
    memcpy(nTxData + nIndex, STX, 1);
    nIndex += 1;
    memcpy(nTxData + nIndex, (uint8_t *) "NULL", 4);
    nIndex+=4;
    memcpy(nTxData + nIndex, (uint8_t *) strOpt, 3);
    nIndex += 3;
    memcpy(nTxData + nIndex, (uint8_t *) strData, 8);
    nIndex+=8;
    memcpy(nTxData + nIndex, ACK, 1);
    nIndex += 1;
    memcpy(nTxData + nIndex, ETX, 1);
    nIndex += 1;
    
    WriteCom(nTxData, MAX_LEN);
  }

  bDataAvailable = false;
}


	if(led_control == 1)
		{
		HAL_GPIO_WritePin(GPIOC, GPIO_PIN_13, GPIO_PIN_SET);
		}
		
	if(led_control == 2)
		{
		HAL_GPIO_WritePin(GPIOC, GPIO_PIN_13, GPIO_PIN_RESET);
		}
	if(led_control == 3)
		{
		HAL_GPIO_TogglePin(GPIOC, GPIO_PIN_13);
		HAL_Delay(500);
		}
	return true;
}		

void HAL_UART_RxCpltCallback(UART_HandleTypeDef *huart)
{
  if(huart ->Instance == huart1.Instance)
  {
    ReadComm(nRxData, MAX_LEN);
    HAL_UART_Receive_IT(&huart1, (uint8_t*)nRxData, MAX_LEN);
  }
}

/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void)
{
  /* USER CODE BEGIN 1 */

  /* USER CODE END 1 */

  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* USER CODE BEGIN Init */

  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */

  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_USART1_UART_Init();
  /* USER CODE BEGIN 2 */
  HAL_UART_Receive_IT(&huart1, (uint8_t *)nRxData, MAX_LEN);
  /* USER CODE END 2 */

  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
  while (1)
  {
    /* USER CODE END WHILE */

    /* USER CODE BEGIN 3 */
    serialProcess();
  }
  /* USER CODE END 3 */
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};

  /** Initializes the RCC Oscillators according to the specified parameters
  * in the RCC_OscInitTypeDef structure.
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSE;
  RCC_OscInitStruct.HSEState = RCC_HSE_ON;
  RCC_OscInitStruct.HSEPredivValue = RCC_HSE_PREDIV_DIV1;
  RCC_OscInitStruct.HSIState = RCC_HSI_ON;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSE;
  RCC_OscInitStruct.PLL.PLLMUL = RCC_PLL_MUL9;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }

  /** Initializes the CPU, AHB and APB buses clocks
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV2;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV1;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_2) != HAL_OK)
  {
    Error_Handler();
  }
}

/* USER CODE BEGIN 4 */








/* USER CODE END 4 */

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */
  __disable_irq();
  while (1)
  {
  }
  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */
