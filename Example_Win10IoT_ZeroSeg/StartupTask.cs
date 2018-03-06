using Windows.ApplicationModel.Background;
using WinIoT_HatLib;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace Example_Win10IoT_ZeroSeg
{
    public sealed class StartupTask : IBackgroundTask
    {
        private BackgroundTaskDeferral deferredTask;
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            deferredTask = taskInstance.GetDeferral();
            ZeroSeg seg = new ZeroSeg("ZeroSeg - Example");
            seg.ConnectSPI();
            while (!seg.IsReady) { }
            seg.SetText("01234567");
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
