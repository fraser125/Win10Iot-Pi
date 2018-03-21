# Win10Iot-Pi
This is a Raspberry Pi Hat code library for "Windows IoT (Internet of Things) 10".
I want to make the following clear:
* This code repository is for Windows IoT 10, version "Windows 10 Fall Creators Update (10.0; Build 16299) or higher
* **NOT for Linux/Mono** (i.e. Raspbian, Ubuntu, etc.)
* Win 10 Iot Raspberry Pi - Pin limitations
  * Hat Identifier pins 0, 1 not available
  * USART0 (14,15) is available, but pins are not usable for GPIO.
  * Pins 4,5,17 may have some limitations, I'm still trying to confirm.

## Discoverable Interfaces
The is a collection of code snippets that are built in to the .NET IoT framework for determining what features or settings are available without additional code.

## Example projects 
They are just some simple examples of using the code found in the "WinIoT_HatLib"

## WinIoT_HatLib

### GPIO [Status Board Pro](https://thepihut.com/products/status-board-pro) & [Status Board Zero](https://thepihut.com/products/status-board-zero)
This is a great board, simple gpio, nice functionality, should be really easy to use in Linux.

**I cannot** recommend it for use with Windows IoT at this time. Because of the Win IoT GPIO pins that are unavailable, too many features don't work as expected. 

### LED Display Driver [MAX7219](https://datasheets.maximintegrated.com/en/ds/MAX7219-MAX7221.pdf) [ZeroSeg](https://thepihut.com/products/zeroseg)
The ZeroSeg is a simple display for numbers and some letters ('H','L','P','E'). It uses SPI0 communication and GPIO 17,26 for the 2 buttons. 
This implementation is kind of minimal, as I use it in personal projects this may improve.

### 16 Channel PWM [PCA9685](https://www.nxp.com/docs/en/data-sheet/PCA9685.pdf) [Servo PWM PiZero](https://thepihut.com/products/servo-pwm-pizero) & [Adafruit PWM/Servo HAT](https://thepihut.com/products/adafruit-16-channel-pwm-servo-hat-for-raspberry-pi-mini-kit)
This implemenation is not tested at this time.

## Future Hats to support
### [Automation HAT](https://shop.pimoroni.com/products/automation-hat) & [Automation pHAT](https://shop.pimoroni.com/products/automation-phat) - [Pin Reference](https://pinout.xyz/pinout/automation_hat) GPIO & [ADS1015](http://www.ti.com/product/ADS1015) & SPI
### [Blinkt!](https://thepihut.com/products/blinkt) APA102
### [Button Shim](https://shop.pimoroni.com/products/button-shim) APA102 & [TCA9554A](http://www.ti.com/lit/ds/symlink/tca9554a.pdf)
### [Enviro pHAT](https://shop.pimoroni.com/products/enviro-phat) [BMP280](https://ae-bst.resource.bosch.com/media/_tech/media/datasheets/BST-BMP280-DS001-19.pdf) & TCS3472 & [LSM303D](http://www.st.com/resource/en/datasheet/lsm303d.pdf) & [ADS1015](http://www.ti.com/product/ADS1015)
### [Explorer Hat Pro](https://shop.pimoroni.com/products/explorer-hat) ADS1015 & CAP1208 & GPIO
### [Explorer pHat](https://shop.pimoroni.com/products/explorer-phat) ADS1015 & GPIO
### [Four Letter pHAT](https://shop.pimoroni.com/products/four-letter-phat) [HT16K33](http://www.holtek.com/documents/10179/116711/HT16K33v120.pdf)
### [OnOff SHIM](https://thepihut.com/products/onoff-shim) GPIO
### [Pan-Tilt Hat](https://thepihut.com/products/pan-tilt-hat) [Pinout](https://pinout.xyz/pinout/pan_tilt_hat) PIC16F1503 Custom Firmware
### [Scroll pHAT](https://thepihut.com/products/scroll-phat) [IS31FL3730](http://www.issi.com/WW/pdf/31FL3730.pdf)
### [Touch pHAT](https://thepihut.com/products/touch-phat) [CAP1166](http://ww1.microchip.com/downloads/en/DeviceDoc/CAP1166.pdf)

## Additional References
### [Microsoft Hardware Compabitility List](https://docs.microsoft.com/en-us/windows/iot-core/learn-about-hardware/HardwareCompatList)
