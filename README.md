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
### [1.12" Mono OLED 128x128 B/W](https://thepihut.com/products/1-12-mono-oled-128x128-white-black-breakout) - [Pinout](https://shop.pimoroni.com/products/breakout-garden-hat) [SSD1327](https://luma-oled.readthedocs.io/en/latest/_downloads/084d410bfa4d7b33040c2e87264d8757/SSD1327.pdf)
### [Automation HAT](https://shop.pimoroni.com/products/automation-hat) - [Pinout](https://pinout.xyz/pinout/automation_hat) - GPIO & [ADS1015](http://www.ti.com/product/ADS1015) & [SN3218](http://www.si-en.com/uploadpdf/s2011517171720.pdf)
### [Automation pHAT](https://shop.pimoroni.com/products/automation-phat) - [Pinout](https://pinout.xyz/pinout/automation_phat) - GPIO & [ADS1015](http://www.ti.com/product/ADS1015)
### [Blinkt!](https://thepihut.com/products/blinkt) - [Pinout](https://pinout.xyz/pinout/blinkt) - APA102
### [BME680](https://thepihut.com/products/bme680) - [Pinout](https://shop.pimoroni.com/products/breakout-garden-hat) - [BME680](https://ae-bst.resource.bosch.com/media/_tech/media/datasheets/BST-BME680-DS001-00.pdf)
### [Breakout Garden HAT](https://shop.pimoroni.com/products/breakout-garden-hat) - [Pinout](https://pinout.xyz/pinout/breakout_garden_hat) - I2C pass through
### [Button Shim](https://shop.pimoroni.com/products/button-shim) - [Pinout](https://pinout.xyz/pinout/button_shim) - APA102 & [TCA9554A](http://www.ti.com/lit/ds/symlink/tca9554a.pdf)
### [Display-O-Tron HAT](https://shop.pimoroni.com/products/display-o-tron-hat) - [Pinout](https://pinout.xyz/pinout/display_o_tron_hat) - [CAP1166](http://ww1.microchip.com/downloads/en/DeviceDoc/CAP1166.pdf) & [SN3218](http://www.si-en.com/uploadpdf/s2011517171720.pdf)
### [Drum HAT](https://shop.pimoroni.com/products/drum-hat) - [Pinout](https://pinout.xyz/pinout/drum_hat) - [CAP1188](http://ww1.microchip.com/downloads/en/DeviceDoc/CAP1188%20.pdf)
### [Enviro pHAT](https://shop.pimoroni.com/products/enviro-phat) - [Pinout](https://pinout.xyz/pinout/enviro_phat) - [BMP280](https://ae-bst.resource.bosch.com/media/_tech/media/datasheets/BST-BMP280-DS001-19.pdf) & [TCS3472](https://ams.com/jpn/content/download/319364/1117183/file/TCS3472_Datasheet_EN_v2.pdf) & [LSM303D](http://www.st.com/resource/en/datasheet/lsm303d.pdf) & [ADS1015](http://www.ti.com/product/ADS1015)
### [Explorer HAT Pro](https://shop.pimoroni.com/products/explorer-hat) - [Pinout](https://pinout.xyz/pinout/explorer_hat_pro) - GPIO & [ADS1015](http://www.ti.com/product/ADS1015) & [CAP1208](http://ww1.microchip.com/downloads/en/DeviceDoc/00001570C.pdf)
### [Explorer pHAT](https://shop.pimoroni.com/products/explorer-phat) - [Pinout](https://pinout.xyz/pinout/explorer_phat) - GPIO & [ADS1015](http://www.ti.com/product/ADS1015)
### [Four Letter pHAT](https://shop.pimoroni.com/products/four-letter-phat) - [Pinout](https://pinout.xyz/pinout/four_letter_phat) - [HT16K33](http://www.holtek.com/documents/10179/116711/HT16K33v120.pdf)
### [Dual G2 High-Power Motor Driver 24v14](https://www.pololu.com/product/3752) by Pololu
### [GFX HAT](https://shop.pimoroni.com/products/gfx-hat) - [Pinout](https://pinout.xyz/pinout/gfx_hat) - [SN3218](http://www.si-en.com/uploadpdf/s2011517171720.pdf) & [CAP1166](http://ww1.microchip.com/downloads/en/DeviceDoc/CAP1166.pdf) & [ST7567](https://www.newhavendisplay.com/appnotes/datasheets/LCDs/ST7567.pdf)
### [HyperPixel 4](https://shop.pimoroni.com/products/hyperpixel-4) - [Pinout](https://pinout.xyz/pinout/hyperpixel4) - [Goodix Multi-Touch]() & GPIO
### [Inky Phat](https://shop.pimoroni.com/products/inky-phat) - [Pinout](https://pinout.xyz/pinout/inky_phat) - SPI
### [LED SHIM](https://shop.pimoroni.com/products/led-shim) - [Pinout](https://pinout.xyz/pinout/led_shim) - [IS31FL3731](http://www.issi.com/WW/pdf/31FL3731.pdf)
### [Micro Dot pHAT](https://shop.pimoroni.com/products/microdot-phat) - [Pinout](https://pinout.xyz/pinout/micro_dot_phat) - [IS31FL3730](http://www.issi.com/WW/pdf/31FL3730.pdf)
### [Mote pHAT](https://shop.pimoroni.com/products/mote-phat) - [Pinout](https://pinout.xyz/pinout/mote_phat) - APA102
### [OnOff SHIM](https://thepihut.com/products/onoff-shim) GPIO
### [Pan-Tilt HAT](https://thepihut.com/products/pan-tilt-hat) - [Pinout](https://pinout.xyz/pinout/pan_tilt_hat) - PIC16F1503 Custom Firmware
### [pHat BEAT](https://shop.pimoroni.com/products/phat-beat) - [Pinout](https://pinout.xyz/pinout/phat_beat) - [I2S]() & GPIO
### [Piano HAT](https://shop.pimoroni.com/products/piano-hat) - [Pinout](https://pinout.xyz/pinout/piano_hat) - [CAP1188](http://ww1.microchip.com/downloads/en/DeviceDoc/CAP1188%20.pdf) & GPIO
### [Picade X](https://shop.pimoroni.com/products/picade-x-hat) - [Pinout](https://pinout.xyz/pinout/picade_x_hat) - I2S (Unsupported) & GPIO
### [PiGlow](https://shop.pimoroni.com/products/piglow) - [Pinout](https://pinout.xyz/pinout/piglow) - [SN3218](http://www.si-en.com/uploadpdf/s2011517171720.pdf)
### [Rainbow Hat](https://thepihut.com/products/rainbow-hat-for-android-things) - [Pinout](https://pinout.xyz/pinout/rainbow_hat) - [HT16K33](http://www.holtek.com/documents/10179/116711/HT16K33v120.pdf) & [BMP280](https://ae-bst.resource.bosch.com/media/_tech/media/datasheets/BST-BMP280-DS001-19.pdf) & [QT1070](http://ww1.microchip.com/downloads/en/DeviceDoc/Atmel-9596-AT42-QTouch-BSW-AT42QT1070_Datasheet.pdf) & APA102
### [RTC PiZero addon](https://thepihut.com/products/rtc-pizero) - [Pinout](https://pinout.xyz/pinout/rtc_pi_zero) - [DS1307](https://datasheets.maximintegrated.com/en/ds/DS1307.pdf)
### [Scroll pHAT](https://thepihut.com/products/scroll-phat) - [Pinout](https://pinout.xyz/pinout/scroll_phat) - [IS31FL3730](http://www.issi.com/WW/pdf/31FL3730.pdf)
### [Scroll pHAT HD](https://thepihut.com/products/scroll-phat) - [Pinout](https://pinout.xyz/pinout/scroll_phat_hd) - [IS31FL3731](http://www.issi.com/WW/pdf/31FL3731.pdf)
### [Skywriter HAT](https://shop.pimoroni.com/products/skywriter-hat) - [Pinout](https://pinout.xyz/pinout/skywriter_hat) - [MGC3130](http://ww1.microchip.com/downloads/en/DeviceDoc/40001667E.pdf)
### [Time of Flight](https://shop.pimoroni.com/products/vl53l1x-breakout) - [Pinout]() - [VL53L1X](https://cdn.shopify.com/s/files/1/0174/1800/files/vl53l1x.pdf)
### [Touch pHAT](https://thepihut.com/products/touch-phat) - [Pinout](https://pinout.xyz/pinout/touch_phat) - [CAP1166](http://ww1.microchip.com/downloads/en/DeviceDoc/CAP1166.pdf)

## No plans to ever support
### [Unicorn HAT] - Uses PWM tricks on a single pin
### [Unicorn pHAT] - Uses PWM tricks on a single pin
### [Unicorn HAT HD] - Uses custom commands on an ARM processor
### [Speaker pHAT] - I2S is not supported by Windows 10 IoT Core
### [pHAT DAC] - I2S is not supported by Windows 10 IoT Core
### Any Justboom products - They are awesome but "I2S is not supported by Windows 10 IoT Core"

## Additional References
### [Microsoft Hardware Compabitility List](https://docs.microsoft.com/en-us/windows/iot-core/learn-about-hardware/HardwareCompatList)
