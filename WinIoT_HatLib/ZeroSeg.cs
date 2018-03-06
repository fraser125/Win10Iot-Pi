using System;
using Windows.Devices.Enumeration;
using Windows.Devices.Gpio;
using Windows.Devices.Spi;

namespace WinIoT_HatLib
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="https://docs.microsoft.com/en-us/windows/iot-core/learn-about-hardware/pinmappings/pinmappingsrpi"/>
    public sealed class ZeroSeg : IDisposable, IHat
    {
        private SpiConnectionSettings settings;
        private DeviceInformationCollection spiDevices;
        private FontMode fontMode;
        private SpiDevice device;

        public GpioPin[] Buttons { get; }

        public void SetTestMode(bool testMode)
        {
            Transmit(new[] { (byte)Registers.DisplayTest, (byte)(testMode ? 0x01 : 0x0) });
        }

        public void SetFontMode(FontMode font)
        {
            fontMode = font;
            Transmit(new[] { (byte)Registers.DecodeMode, (byte)fontMode });
        }

        public FontMode GetFontMode()
        {
            return fontMode;
        }

        public ZeroSeg(string name)
        {
            Name = name;
            GpioController gpio = GpioController.GetDefault();
            Buttons = new GpioPin[2];
            int[] buttonPins = { 17, 26 };

            for (int idx = 0; idx < 2; idx++)
            {
                if (gpio.TryOpenPin(buttonPins[idx], GpioSharingMode.Exclusive, out var pin, out GpioOpenStatus _))
                {
                    pin.SetDriveMode(GpioPinDriveMode.InputPullUp);
                    pin.DebounceTimeout = TimeSpan.FromMilliseconds(50);
                    Buttons[idx] = pin;
                }
            }
        }

        public async void ConnectSPI()
        {
            // Use chip select line CS0, Set clock to 10MHz 
            // RPi is MSB for SPI communication
            settings = new SpiConnectionSettings(0) { ClockFrequency = 10000000, DataBitLength = 8, SharingMode = SpiSharingMode.Exclusive };

            // Get a selector string that will return our wanted SPI controller
            string aqs = SpiDevice.GetDeviceSelector("SPI0");

            // Find the SPI bus controller devices with our selector string
            spiDevices = await DeviceInformation.FindAllAsync(aqs);
            device = await SpiDevice.FromIdAsync(spiDevices[0].Id, settings);
            device.Write(new[] { (byte)Registers.ScanLimit, (byte)7 });
            device.Write(new[] { (byte)Registers.Intensity, (byte)7 });
            device.Write(new[] { (byte)Registers.DecodeMode, (byte)FontMode.BCD8 });
            Clear();
            device.Write(new[] { (byte)Registers.Shutdown, (byte)0x01 });
            IsReady = true;
        }

        public void Clear()
        {
            FontMode saveFontMode = GetFontMode();
            SetFontMode(FontMode.BCD8);
            for (byte idx = 0; idx < 8; idx++)
            {
                SetDigit(idx, 0xF);
            }
            SetFontMode(saveFontMode);
        }

        private void Transmit(byte[] cmdData)
        {
            if (cmdData != null && (cmdData.Length % 2) != 0)
            {
                return;
            }
            device.Write(cmdData);
        }

        public void SetDigit(byte position, byte val)
        {
            if (position < 8 && val < 16)
            {
                Transmit(new[] { (byte)(position + 1), val });
            }
        }

        public void SetText(string val)
        {
            byte position = 7;
            for (byte idx = 0; idx < ((val.Length > 8) ? 8 : val.Length); idx++)
            {
                byte displayChar;
                char selectedChar = val[idx];
                switch (selectedChar)
                {
                    case '0': displayChar = 0x0; break;
                    case '1': displayChar = 0x1; break;
                    case '2': displayChar = 0x2; break;
                    case '3': displayChar = 0x3; break;
                    case '4': displayChar = 0x4; break;

                    case '5': displayChar = 0x5; break;
                    case '6': displayChar = 0x6; break;
                    case '7': displayChar = 0x7; break;
                    case '8': displayChar = 0x8; break;
                    case '9': displayChar = 0x9; break;

                    case '-': displayChar = 0xA; break;
                    case 'E': displayChar = 0xB; break;
                    case 'H': displayChar = 0xC; break;
                    case 'L': displayChar = 0xD; break;
                    case 'P': displayChar = 0xE; break;

                    default:
                        displayChar = 0x0F;
                        break;
                }
                SetDigit(position, displayChar);
                position--;
            }
        }

        private void DisplayDigits(byte digitCount)
        {
            if (digitCount > 7)
                digitCount = 7;
            Transmit(new[] { (byte)Registers.ScanLimit, digitCount });
        }

        public void SetBrightness(byte intensity)
        {
            if (intensity > 0xF)
                intensity = 0xF;
            Transmit(new[] { (byte)Registers.Intensity, intensity });
        }

        public void Sleep()
        {
            Transmit(new[] { (byte)Registers.Shutdown, (byte)0x0 });
        }

        public void Wakeup()
        {
            Transmit(new[] { (byte)Registers.Shutdown, (byte)0x01 });
        }

        public void Dispose()
        {
            device.Dispose();
            device = null;
        }

        public HatData RegistrationData { get; set; }
        public string Name { get; set; }
        public bool IsReady { get; set; }

        public bool IsConnected()
        {
            throw new NotImplementedException();
        }
    }

    public enum FontMode
    {
        Raw = 0x0,
        BCD1 = 0x01,
        BCD4 = 0x0F,
        BCD8 = 0xFF,
    }

    internal enum Registers : byte
    {
        Nop = 0x0,
        Digit0 = 0x01,
        Digit1 = 0x2,
        Digit2 = 0x3,
        Digit3 = 0x4,
        Digit4 = 0x5,
        Digit5 = 0x6,
        Digit6 = 0x7,
        Digit7 = 0x8,
        DecodeMode = 0x9,
        Intensity = 0xA,
        ScanLimit = 0xB,
        Shutdown = 0xC,
        // 0xD, 0xE Not used?
        DisplayTest = 0xF,
    }
}