namespace WinIoT_HatLib
{
    public interface IHat
    {
        HatData RegistrationData { get; set; }
        string Name { get; set; }
        bool IsReady { get; set; }
        bool IsConnected();
    }
}
