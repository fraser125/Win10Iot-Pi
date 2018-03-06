using Windows.ApplicationModel.Background;
using Windows.Devices.Gpio;
using WinIoT_HatLib;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace Example_Win10IoT_StatusBoard
{
    public sealed class StartupTask : IBackgroundTask
    {
        private BackgroundTaskDeferral deferredTask;
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            deferredTask = taskInstance.GetDeferral();
            StatusBoard statusBoard = new StatusBoard("Status Board - Example", 5);
            statusBoard.Buttons[1].ValueChanged += StartupTask_ValueChanged;
            statusBoard.Buttons[3].ValueChanged += StartupTask_ValueChanged;
            statusBoard.Buttons[4].ValueChanged += StartupTask_ValueChanged;
            statusBoard.SetLED(0, LEDColor.Green);
            statusBoard.SetLED(1, LEDColor.Green);
            statusBoard.SetLED(2, LEDColor.Green);
            statusBoard.SetLED(3, LEDColor.Green);
            statusBoard.SetLED(4, LEDColor.Green);
            statusBoard.SetLED(0, LEDColor.Off);
            statusBoard.SetLED(1, LEDColor.Off);
            statusBoard.SetLED(2, LEDColor.Off);
            statusBoard.SetLED(3, LEDColor.Off);
            statusBoard.SetLED(4, LEDColor.Off);
            statusBoard.SetLED(0, LEDColor.Red);
            statusBoard.SetLED(1, LEDColor.Red);
            statusBoard.SetLED(2, LEDColor.Red);
            statusBoard.SetLED(3, LEDColor.Red);
            statusBoard.SetLED(4, LEDColor.Red);
            statusBoard.SetLED(0, LEDColor.Off);
            statusBoard.SetLED(1, LEDColor.Off);
            statusBoard.SetLED(2, LEDColor.Off);
            statusBoard.SetLED(3, LEDColor.Off);
            statusBoard.SetLED(4, LEDColor.Off);
            statusBoard.SetLED(0, LEDColor.Red);
            statusBoard.SetLED(1, LEDColor.Red);
            statusBoard.SetLED(2, LEDColor.Red);
            statusBoard.SetLED(3, LEDColor.Red);
            statusBoard.SetLED(4, LEDColor.Red);
            statusBoard.SetLED(0, LEDColor.Green);
            statusBoard.SetLED(1, LEDColor.Green);
            statusBoard.SetLED(2, LEDColor.Green);
            statusBoard.SetLED(3, LEDColor.Green);
            statusBoard.SetLED(4, LEDColor.Green);
            // 
            // TODO: Insert code to perform background work
            //
            // If you start any asynchronous methods here, prevent the task
            // from closing prematurely by using BackgroundTaskDeferral as
            // described in http://aka.ms/backgroundtaskdeferral
            //
        }

        private void StartupTask_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {
            
        }
    }
}
