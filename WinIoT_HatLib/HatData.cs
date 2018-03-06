using System;

namespace WinIoT_HatLib
{
    /// <summary>
    /// https://github.com/raspberrypi/hats/blob/master/eeprom-format.md
    /// </summary>
    public struct HatData
    {
        public byte[] Signature;
        public byte Version;
        public byte Reserved;
        public byte[] NumAtoms;
        public byte[] EEPLen;
    }

    public struct Atom
    {
        public ushort AtomType;
        public ushort AtomIndex;
        public uint DataAndCRCLength;
        public byte[] Data;
        public byte[] CRC16;
    }

    public enum AtomTypes :ushort
    {
        Invalid = 0x0,
        VendorInfo = 0x01,
        GPIOMap = 0x02,
        LinuxDeviceTreeBlob = 0x03,
        ManufacturerData = 0x04,
    }

    public struct VendorInfo
    {
        public byte[] UUID;
        public ushort ProductId;
        public ushort ProductVersion;
        public byte VendorStringLength;
        public byte ProductStringLength;
        public string VendorString;
        public string ProductString;
    }

    public struct GPIOMap
    {
        public byte BankDrive;
        public byte Power;
        public PinFunction PinFunction;
    }
    
    [Flags]
    public enum PinFunction
    {
        PinInput = 0x0,
        PinOutput = 0x01,
        PinAlternate0 = 0x04,
        PinAlternate1 = 0x05,
        PinAlternate2 = 0x06,
        PinAlternate3 = 0x07,
        PinAlternate4 = 0x03,
        PinAlternate5 = 0x02,
        PullUp = 0x20,
        PullDown = 0x40,
        NoPull = 0x60,
        IsUsed = 0x80,
    }

    public struct DeviceTree
    {
        public byte[] Data;
    }
}