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

### [Status Board Pro](https://thepihut.com/products/status-board-pro) & [Status Board Zero](https://thepihut.com/products/status-board-zero)
This is a great board, simple gpio, nice functionality, should be really easy to use in Linux.

**I cannot** recommend it for use with Windows IoT at this time. Too many features don't work as expected. 

### [ZeroSeg](https://thepihut.com/products/zeroseg)
The ZeroSeg is a simple display for numbers and some letters ('H','L','P','E'). It uses SPI0 communication and GPIO 17,26 for the 2 buttons. 
This implementation is kind of minimal, as I use it in personal projects this may improve.

### 16 Channel PWM PCA9685 [Servo PWM PiZero](https://thepihut.com/products/servo-pwm-pizero) & [Adafruit PWM/Servo HAT](https://thepihut.com/products/adafruit-16-channel-pwm-servo-hat-for-raspberry-pi-mini-kit)
This implemenation is not tested at this time.

## Future Hats to support
### [Blinkt!](https://thepihut.com/products/blinkt) APA102
### [Scroll pHAT](https://thepihut.com/products/scroll-phat) IS31FL3730
### [Touch pHAT](https://thepihut.com/products/touch-phat) CAP1166
### [OnOff SHIM](https://thepihut.com/products/onoff-shim) GPIO
### [Button Shim](https://shop.pimoroni.com/products/button-shim) APA102 & TCA9554A
### [Enviro pHAT](https://shop.pimoroni.com/products/enviro-phat) BMP280 & TCS3472 & LSM303D & ADS1015
### [Automation HAT](https://shop.pimoroni.com/products/automation-hat) & [Automation pHAT](https://shop.pimoroni.com/products/automation-phat) - [Pin Reference](https://pinout.xyz/pinout/automation_hat) GPIO & ADS1015 & SPI
### [Four Letter pHAT](https://shop.pimoroni.com/products/four-letter-phat) HT16K33
