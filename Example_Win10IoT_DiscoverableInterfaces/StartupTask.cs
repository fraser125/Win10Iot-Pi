using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.ApplicationModel.Background;
using Windows.Devices.Enumeration;
using Windows.Devices.Gpio;
using Windows.Devices.I2c;
using Windows.Devices.Input;
using Windows.Devices.SerialCommunication;
using Windows.Devices.Spi;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace Example_Win10IoT_DiscoverableInterfaces
{
    public sealed class StartupTask : IBackgroundTask
    {
        private BackgroundTaskDeferral deferredTask;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            deferredTask = taskInstance.GetDeferral();
            DiscoverDevicesInput();
            return;
            GpioConfiguration();
            GpioTestInputButtons();
            GpioTestOutputLEDs();
            DiscoverSPI();
            DiscoverI2C();
            DiscoverSerial();

            // 
            // TODO: Insert code to perform background work
            //
            // If you start any asynchronous methods here, prevent the task
            // from closing prematurely by using BackgroundTaskDeferral as
            // described in http://aka.ms/backgroundtaskdeferral
            //
        }

        private void DiscoverDevicesInput()
        {
            var keyboardCapabilities = new KeyboardCapabilities();
            Debug.WriteLine("Keyboard Present: {0}", keyboardCapabilities.KeyboardPresent == 1 ? "Yes" : "No");

            var mouseCapabilities = new MouseCapabilities();
            Debug.WriteLine("Mouse Present:{0}  Number of Buttons:{1}  Swapped:{2}", mouseCapabilities.MousePresent == 1 ? "Yes" : "No", mouseCapabilities.NumberOfButtons, mouseCapabilities.SwapButtons == 1 ? "Yes" : "No");
            Debug.WriteLine("\t Horizontal Wheel:{0} Vertical Wheel:{1}", mouseCapabilities.HorizontalWheelPresent == 1 ? "Yes" : "No", mouseCapabilities.VerticalWheelPresent == 1 ? "Yes" : "No");

            var touch = new TouchCapabilities();
            Debug.WriteLine("Touch Present: {0}  Number of Contacts: {1}", touch.TouchPresent == 1 ? "Yes" : "Now", touch.Contacts);

            var pointers = PointerDevice.GetPointerDevices();
            if (pointers != null && pointers.Count > 0)
                foreach (PointerDevice pointer in pointers)
                {
                    Debug.WriteLine("Pointer Device Type:{0}  Integrated:{1}", pointer.PointerDeviceType, pointer.IsIntegrated);
                    Debug.WriteLine("\t Contacts", pointer.MaxContacts, pointer.MaxPointersWithZDistance);
                    Debug.WriteLine("\t", pointer.PhysicalDeviceRect, pointer.ScreenRect);
                    foreach (PointerDeviceUsage pointerDeviceUsage in pointer.SupportedUsages)
                    {
                        //Debug.WriteLine("",  );
                    }
                }
        }

        private async void DiscoverSPI()
        {
            string query = SpiDevice.GetDeviceSelector();
            var spiDeviceInformation = await DeviceInformation.FindAllAsync(query);
            foreach (DeviceInformation deviceInformation in spiDeviceInformation)
            {
                string name = deviceInformation.Id.Substring(deviceInformation.Id.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                Debug.WriteLine("Name:{0}  Default:{1}  Enabled:{2}  Device Kind:{3}  Location:{4}", name, deviceInformation.IsDefault,
                    deviceInformation.IsEnabled, deviceInformation.Kind, deviceInformation.EnclosureLocation);
                Debug.WriteLine("\tPairing - Can Pair:{0}  Is Paired:{1}  Protection Level:{2}", deviceInformation.Pairing.CanPair, deviceInformation.Pairing.IsPaired, deviceInformation.Pairing.ProtectionLevel);

                Debug.WriteLine("\tProperties");
                foreach (KeyValuePair<string, object> property in deviceInformation.Properties)
                {
                    Debug.WriteLine("\t\t{0}  -  {1}", property.Key, property.Value);
                }

                SpiBusInfo busInfo = SpiDevice.GetBusInfo(deviceInformation.Id);
                if (busInfo != null)
                    Debug.WriteLine("\t CS Pin Count:{0}  Max Clock:{1}  Min Clock:{2}  Data Bit Lengths:{3}", busInfo.ChipSelectLineCount, busInfo.MaxClockFrequency, busInfo.MinClockFrequency, string.Join(",", busInfo.SupportedDataBitLengths));

                SpiDevice spiDevice = await SpiDevice.FromIdAsync(deviceInformation.Id, new SpiConnectionSettings(0));
                if (spiDevice != null)
                    Debug.WriteLine("\t Default Settings - Clock:{0}  SPI Mode:{1}  Sharing Mode:{2}  Data Bit Length:{3}", spiDevice.ConnectionSettings.ClockFrequency, spiDevice.ConnectionSettings.Mode, spiDevice.ConnectionSettings.SharingMode, spiDevice.ConnectionSettings.DataBitLength);
            }
        }

        private async void DiscoverI2C()
        {
            string query = I2cDevice.GetDeviceSelector();
            var i2CDeviceInformation = await DeviceInformation.FindAllAsync(query);
            foreach (DeviceInformation deviceInformation in i2CDeviceInformation)
            {
                string name = deviceInformation.Id.Substring(deviceInformation.Id.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                Debug.WriteLine("Name:{0}  Default:{1}  Enabled:{2}  Device Kind:{3}  Location:{4}", name, deviceInformation.IsDefault,
                    deviceInformation.IsEnabled, deviceInformation.Kind, deviceInformation.EnclosureLocation);

                Debug.WriteLine("\tProperties");
                foreach (KeyValuePair<string, object> property in deviceInformation.Properties)
                {
                    Debug.WriteLine("\t\t{0}  -  {1}", property.Key, property.Value);
                }

                I2cDevice i2cDevice = await I2cDevice.FromIdAsync(deviceInformation.Id, new I2cConnectionSettings(0));
                if (i2cDevice != null)
                    Debug.WriteLine("\tBus Speed:{0}  Slave Address:{1}  Sharing Mode:{2}", i2cDevice.ConnectionSettings.BusSpeed, i2cDevice.ConnectionSettings.SlaveAddress, i2cDevice.ConnectionSettings.SharingMode);
            }
        }

        private async void DiscoverSerial()
        {
            string query = SerialDevice.GetDeviceSelector();
            var serialDeviceInformation = await DeviceInformation.FindAllAsync(query);
            foreach (DeviceInformation deviceInformation in serialDeviceInformation)
            {
                string name = deviceInformation.Id.Substring(deviceInformation.Id.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                Debug.WriteLine("Name:{0}  Default:{1}  Enabled:{2}  Device Kind:{3}  Location:{4}", name, deviceInformation.IsDefault,
                    deviceInformation.IsEnabled, deviceInformation.Kind, deviceInformation.EnclosureLocation);

                Debug.WriteLine("\tProperties");
                foreach (KeyValuePair<string, object> property in deviceInformation.Properties)
                {
                    Debug.WriteLine("\t\t{0}  -  {1}", property.Key, property.Value);
                }

                SerialDevice serialDevice = await SerialDevice.FromIdAsync(deviceInformation.Id);
                if (serialDevice != null)
                {
                    Debug.WriteLine("\t Port:{0}  USB VID:{1:X4}  USB PID:{2:X4}", serialDevice.PortName, serialDevice.UsbVendorId, serialDevice.UsbProductId);
                    Debug.WriteLine("\t Baud:{0}  Data Bits:{1}  Parity:{2}  Stop Bits:{3}", serialDevice.BaudRate, serialDevice.DataBits, serialDevice.Parity, serialDevice.StopBits);
                    Debug.WriteLine("\t Handshake:{0}  Timeout:{1}ms", serialDevice.Handshake, serialDevice.WriteTimeout.Milliseconds);
                }
            }
        }

        private void GpioConfiguration()
        {
            GpioController gpio = GpioController.GetDefault();
            int[] pins = new int[30];

            for (int idx = 0; idx < 30; idx++)
            {
                pins[idx] = idx;
            }

            pins[28] = 35; // RPi2 Only
            pins[29] = 47; // RPi2 Only

            for (int pinId = 0; pinId < pins.Length; pinId++)
            {
                List<GpioPinDriveMode> supported = new List<GpioPinDriveMode>();
                if (gpio.TryOpenPin(pins[pinId], GpioSharingMode.SharedReadOnly, out GpioPin pin, out _))
                {
                    foreach (GpioPinDriveMode driveMode in Enum.GetValues(typeof(GpioPinDriveMode)))
                    {
                        // test driveMode for Pin Details
                        if (pin.IsDriveModeSupported(driveMode))
                        {
                            supported.Add(driveMode);
                        }
                    }
                }
            }
        }

        private void GpioTestOutputLEDs()
        {
            GpioController gpio = GpioController.GetDefault();
            int[] pins = new int[30];

            for (int idx = 0; idx < 30; idx++)
            {
                pins[idx] = idx;
            }

            pins[28] = 35; // RPi2 Only
            pins[29] = 47; // RPi2 Only

            for (int pinId = 0; pinId < pins.Length; pinId++)
            {
                if (gpio.TryOpenPin(pins[pinId], GpioSharingMode.Exclusive, out GpioPin pin, out _))
                {
                    foreach (GpioPinDriveMode driveMode in Enum.GetValues(typeof(GpioPinDriveMode)))
                    {
                        // test driveMode for Pin Details
                        if (pin.IsDriveModeSupported(driveMode))
                        {
                            if (driveMode == GpioPinDriveMode.Output)
                            {
                                pin.Write(GpioPinValue.High);
                                pin.SetDriveMode(driveMode);
                            }
                        }
                    }
                }
            }
        }

        private void GpioTestInputButtons()
        {
            GpioController gpio = GpioController.GetDefault();
            int[] pins = new int[30];

            for (int idx = 0; idx < 30; idx++)
            {
                pins[idx] = idx;
            }

            pins[28] = 35; // RPi2 Only
            pins[29] = 47; // RPi2 Only

            for (int pinId = 0; pinId < pins.Length; pinId++)
            {
                if (gpio.TryOpenPin(pins[pinId], GpioSharingMode.Exclusive, out GpioPin pin, out _))
                {
                    foreach (GpioPinDriveMode driveMode in Enum.GetValues(typeof(GpioPinDriveMode)))
                    {
                        // test driveMode for Pin Details
                        if (pin.IsDriveModeSupported(driveMode))
                        {
                            if (driveMode == GpioPinDriveMode.InputPullUp)
                            {
                                pin.SetDriveMode(driveMode);
                                pin.ValueChanged += Pin_ValueChanged1;
                            }
                        }
                    }
                }
            }
        }

        private void Pin_ValueChanged1(GpioPin sender, GpioPinValueChangedEventArgs args)
        {

        }
    }
}
