using System;
using System.Threading;
using Windows.Devices.I2c;

namespace WinIoT_HatLib
{
    /// <summary>
    /// Basically a Windows IoT rewrite of https://github.com/adafruit/Adafruit-PWM-Servo-Driver-Library
    /// </summary>
    public sealed class PCA9685 : IHat
    {
        public byte Address { get; private set; }
        private readonly I2cConnectionSettings settings;
        private I2cDevice device;

        public HatData RegistrationData { get; set; }
        public string Name { get; set; }
        public bool IsReady { get; set; }

        public PCA9685(string name) : this(name, 0x40)
        {

        }

        public PCA9685(string name, byte address)
        {
            Name = name;
            Address = address;
            settings = new I2cConnectionSettings(Address) { BusSpeed = I2cBusSpeed.FastMode };
        }

        public async void Begin()
        {
            var controller = await I2cController.GetDefaultAsync();
            device = controller.GetDevice(settings);
            Reset();
            SetPWMFrequency(1000);
        }

        public void Reset()
        {
            device.Write(new byte[] { (byte)Reg.Mode1, 0x80 });
            Thread.Sleep(10);
        }

        public void SetPWMFrequency(decimal freq)
        {
            freq = freq * 0.9m;
            decimal prescallevel = 25000000;
            prescallevel /= 4096;
            prescallevel /= freq;
            prescallevel -= 1;

            byte prescale = (byte)Math.Floor(prescallevel + 0.5m);

            byte oldMode = ReadByte(Reg.Mode1);
            byte newMode = (byte)((oldMode & 0x7F) | 0x10);
            WriteByte(Reg.Mode1, newMode);
            WriteByte(Reg.Prescale, prescale);
            WriteByte(Reg.Mode1, oldMode);
            Thread.Sleep(5);
            WriteByte(Reg.Mode1, (byte)(oldMode | 0xA0));
        }

        public void SetPWM(byte num, ushort on, ushort off)
        {
            byte register = (byte)(Reg.Led0OnL + 4 * num);
            device.Write(new[] { register, (byte)on, (byte)(on >> 8), (byte)off, (byte)(off >> 8) });
        }

        public void SetPin(byte num, ushort val)
        {
            SetPin(num, val, false);
        }

        public void SetPin(byte num, ushort val, bool invert)
        {
            val = (ushort)Math.Min(val, 4095u);
            if (invert)
            {
                if (val == 0)
                {
                    SetPWM(num, 4096, 0);
                }
                else if (val == 4095)
                {
                    SetPWM(num, 0, 4096);
                }
                else
                {
                    SetPWM(num, 0, (ushort)(4095 - val));
                }
            }
            else
            {
                if (val == 4095)
                {
                    SetPWM(num, 4096, 0);
                }
                else if (val == 0)
                {
                    SetPWM(num, 0, 4096);
                }
                else
                {
                    SetPWM(num, 0, val);
                }
            }
        }

        private byte ReadByte(Reg addr)
        {
            byte[] result = new byte[1];
            device.Write(new[] { (byte)addr });
            device.Read(result);
            return result[0];
        }

        private void WriteByte(Reg addr, byte data)
        {
            device.Write(new[] { (byte)addr, data });
        }


        public bool IsConnected()
        {
            throw new NotImplementedException();
        }
    }

    internal enum Reg
    {
        Mode1 = 0,
        Mode2 = 1,
        SubAdr1,
        SubAdr2,
        SubAdr3,
        AllCallAdr,

        Led0OnL,
        Led0OnH,
        Led0OffL,
        Led0OffH,
        Led1OnL,
        Led1OnH,
        Led1OffL,
        Led1OffH,

        Led2OnL,
        Led2OnH,
        Led2OffL,
        Led2OffH,
        Led3OnL,
        Led3OnH,
        Led3OffL,
        Led3OffH,

        Led4OnL,
        Led4OnH,
        Led4OffL,
        Led4OffH,
        Led5OnL,
        Led5OnH,
        Led5OffL,
        Led5OffH,

        Led6OnL,
        Led6OnH,
        Led6OffL,
        Led6OffH,
        Led7OnL,
        Led7OnH,
        Led7OffL,
        Led7OffH,

        Led8OnL,
        Led8OnH,
        Led8OffL,
        Led8OffH,
        Led9OnL,
        Led9OnH,
        Led9OffL,
        Led9OffH,

        Led10OnL,
        Led10OnH,
        Led10OffL,
        Led10OffH,
        Led11OnL,
        Led11OnH,
        Led11OffL,
        Led11OffH,

        Led12OnL,
        Led12OnH,
        Led12OffL,
        Led12OffH,
        Led13OnL,
        Led13OnH,
        Led13OffL,
        Led13OffH,

        Led14OnL,
        Led14OnH,
        Led14OffL,
        Led14OffH,
        Led15OnL,
        Led15OnH,
        Led15OffL,
        Led15OffH,

        AllLedOnL = 250,
        AllLedOnH,
        AllLedOffL,
        AllLedOffH,
        Prescale,
        TestMode
    }
}
