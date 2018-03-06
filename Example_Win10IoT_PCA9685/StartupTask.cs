using Windows.ApplicationModel.Background;
using WinIoT_HatLib;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace Example_Win10IoT_PCA9685
{
    public sealed class StartupTask : IBackgroundTask
    {
        private BackgroundTaskDeferral deferredTask;
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            deferredTask = taskInstance.GetDeferral();

            PCA9685 pwmController = new PCA9685("PWM Example");
            pwmController.SetPWMFrequency(50);
            // 
            // TODO: Insert code to perform background work
            //
            // If you start any asynchronous methods here, prevent the task
            // from closing prematurely by using BackgroundTaskDeferral as
            // described in http://aka.ms/backgroundtaskdeferral
            //
        }
    }
}
