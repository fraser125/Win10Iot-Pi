using System;
using Windows.Devices.Gpio;

namespace WinIoT_HatLib
{
    /// <summary>
    /// LED's and Buttons work automatically after constructor.
    /// Breakout pins, require additional (normal) setup
    /// </summary>
    /// <remarks>Due to limitations of Windows IoT, this board has limited functionality.
    /// 5 Line Pi Status
    /// Line 0 = Nothing. No Red LED, No Green LED, No Button
    /// Line 1 = Red LED Good, Green LED Good, No Button (Button not working is a bug of some kind)
    /// Line 2 = Red LED Good, Green LED Good, No Button
    /// Line 3 = Red LED Good, Green LED Good, Button Works!
    /// Line 4 = Red LED Good, Green LED Good, Button Works!
    /// 3 Line Pi Status
    /// Line 0 = Nothing. No Red LED, No Green LED
    /// Line 1 = Red LED Good, Green LED Good
    /// Line 2 = Red LED Good, Green LED Good
    /// Breakout Pins probably work but I don't care.
    /// Setting the wrong Line count, just keeps the Line 3,4 pins from being re-usable.
    /// </remarks>
    public sealed class StatusBoard : IHat
    {
        private readonly GpioPin[] greenLEDs;
        private readonly GpioPin[] redLEDs;

        public GpioPin[] Buttons { get; }
        public GpioPin[] BreakOutPins { get; set; }

        public string Name { get; }

        public StatusBoard(string name, int lines)
        {
            if (lines != 3 && lines != 5)
                throw new ArgumentException("Invalid Lines Parameter, must be 3 or 5");

            GpioPin pin;
            int[] greenLEDPins = { 17, 22, 9, 5, 13 }; // 17, Line 1 doesn't work :(
            int[] redLEDPins = { 4, 27, 10, 11, 6 }; // 4, Line 1 doesn't work :(
            int[] buttonsPins = { 14, 19, 15, 26, 18 }; // 14, 15, Line 1, 3 don't work
            int[] breakoutPins = { 21, 20, 16, 12 };

            Name = name;
            GpioController gpio = GpioController.GetDefault();
            greenLEDs = new GpioPin[lines];
            redLEDs = new GpioPin[lines];
            for (int idx = 0; idx < greenLEDPins.Length; idx++)
            {
                if (gpio.TryOpenPin(greenLEDPins[idx], GpioSharingMode.Exclusive, out pin, out _))
                {
                    pin.Write(GpioPinValue.Low);
                    pin.SetDriveMode(GpioPinDriveMode.Output);
                    greenLEDs[idx] = pin;
                }
                if (gpio.TryOpenPin(redLEDPins[idx], GpioSharingMode.Exclusive, out pin, out _))
                {
                    pin.Write(GpioPinValue.Low);
                    pin.SetDriveMode(GpioPinDriveMode.Output);
                    redLEDs[idx] = pin;
                }
            }

            if (lines == 5)
            {
                Buttons = new GpioPin[lines];
                for (int idx = 0; idx < buttonsPins.Length; idx++)
                {
                    if (gpio.TryOpenPin(buttonsPins[idx], GpioSharingMode.Exclusive, out pin, out _))
                    {
                        pin.SetDriveMode(GpioPinDriveMode.InputPullUp);
                        pin.DebounceTimeout = TimeSpan.FromMilliseconds(200);
                        Buttons[idx] = pin;
                    }
                }
            }

            BreakOutPins = new GpioPin[breakoutPins.Length];
            for (int idx = 0; idx < breakoutPins.Length; idx++)
            {
                if (gpio.TryOpenPin(breakoutPins[idx], GpioSharingMode.Exclusive, out pin, out _))
                {
                    BreakOutPins[idx] = pin;
                }
            }
        }

        public void SetLED(byte index, LEDColor color)
        {
            if (index > greenLEDs.Length - 1)
                return;

            switch (color)
            {
                case LEDColor.Green:
                    {
                        greenLEDs[index].Write(GpioPinValue.High);
                    }
                    break;
                case LEDColor.Red:
                    {
                        redLEDs[index].Write(GpioPinValue.High);
                    }
                    break;
                case LEDColor.Off:
                    {
                        greenLEDs[index].Write(GpioPinValue.Low);
                        redLEDs[index].Write(GpioPinValue.Low);
                    }
                    break;
                case LEDColor.Both:
                    {
                        greenLEDs[index].Write(GpioPinValue.High);
                        redLEDs[index].Write(GpioPinValue.High);
                    }
                    break;
            }
        }

        public HatData RegistrationData { get; set; }
        public bool IsReady { get; set; }
        string IHat.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsConnected()
        {
            throw new NotImplementedException();
        }
    }

    public enum LEDColor
    {
        Off,
        Green,
        Red,
        Both
    }
}