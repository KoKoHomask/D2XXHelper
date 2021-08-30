using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace D2XXHelper
{
    class D2XX_Linux: ID2XXFunction
    {
        const string DLLPath = "libftd2xx.so";

        [DllImport(DLLPath, EntryPoint = "FT_CreateDeviceInfoList")]
        static extern FT_STATUS pFT_CreateDeviceInfoList(ref uint numdevs);

        [DllImport(DLLPath, EntryPoint = "FT_GetDeviceInfoDetail")]
        static extern FT_STATUS pFT_GetDeviceInfoDetail(uint index, ref uint flags, ref FT_DEVICE chiptype, ref uint id, ref uint locid, byte[] serialnumber, byte[] description, ref IntPtr ftHandle);

        [DllImport(DLLPath, EntryPoint = "FT_Open")]
        static extern FT_STATUS pFT_Open(uint index, ref IntPtr ftHandle);
        [DllImport(DLLPath, EntryPoint = "FT_OpenEx")]
        static extern FT_STATUS pFT_OpenEx(string devstring, uint dwFlags, ref IntPtr ftHandle);

        [DllImport(DLLPath, EntryPoint = "FT_OpenExLoc")]
        static extern FT_STATUS pFT_OpenExLoc(uint devloc, uint dwFlags, ref IntPtr ftHandle);

        [DllImport(DLLPath, EntryPoint = "FT_SetDataCharacteristics")]
        static extern FT_STATUS pFT_SetDataCharacteristics(IntPtr ftHandle, byte uWordLength, byte uStopBits, byte uParity);

        [DllImport(DLLPath, EntryPoint = "FT_SetFlowControl")]
        static extern FT_STATUS pFT_SetFlowControl(IntPtr ftHandle, ushort usFlowControl, byte uXon, byte uXoff);
        [DllImport(DLLPath, EntryPoint = "FT_SetBaudRate")]
        static extern FT_STATUS pFT_SetBaudRate(IntPtr ftHandle, uint dwBaudRate);

        [DllImport(DLLPath, EntryPoint = "FT_SetTimeouts")]
        static extern FT_STATUS pFT_SetTimeouts(IntPtr ftHandle, uint dwReadTimeout, uint dwWriteTimeout);

        [DllImport(DLLPath, EntryPoint = "FT_Close")]
        static extern FT_STATUS pFT_Close(IntPtr ftHandle);


        [DllImport(DLLPath, EntryPoint = "FT_SetBitMode")]
        static extern FT_STATUS pFT_SetBitMode(IntPtr ftHandle, byte ucMask, byte ucMode);

        [DllImport(DLLPath, EntryPoint = "FT_Read")]
        static extern FT_STATUS pFT_Read(IntPtr ftHandle, byte[] lpBuffer, uint dwBytesToRead, ref uint lpdwBytesReturned);
        [DllImport(DLLPath, EntryPoint = "FT_Write")]
        static extern FT_STATUS pFT_Write(IntPtr ftHandle, byte[] lpBuffer, uint dwBytesToWrite, ref uint lpdwBytesWritten);
        [DllImport(DLLPath, EntryPoint = "FT_SetRts")]
        static extern FT_STATUS pFT_SetRts(IntPtr ftHandle);

        [DllImport(DLLPath, EntryPoint = "FT_ClrRts")]
        static extern FT_STATUS pFT_ClrRts(IntPtr ftHandle);

        [DllImport(DLLPath, EntryPoint = "FT_SetDtr")]
        static extern FT_STATUS pFT_SetDtr(IntPtr ftHandle);
        [DllImport(DLLPath, EntryPoint = "FT_ClrDtr")]
        static extern FT_STATUS pFT_ClrDtr(IntPtr ftHandle);

        public FT_STATUS tFT_SetRts(IntPtr ftHandle)
        {
            return pFT_SetRts(ftHandle);
        }

        public FT_STATUS tFT_ClrRts(IntPtr ftHandle)
        {
            return pFT_ClrRts(ftHandle);
        }

        public FT_STATUS tFT_SetDtr(IntPtr ftHandle)
        {
            return pFT_SetDtr(ftHandle);
        }

        public FT_STATUS tFT_ClrDtr(IntPtr ftHandle)
        {
            return pFT_ClrDtr(ftHandle);
        }


        public FT_STATUS tFT_Write(IntPtr ftHandle, byte[] lpBuffer, uint dwBytesToWrite, ref uint lpdwBytesWritten)
        {
            return pFT_Write(ftHandle, lpBuffer, dwBytesToWrite, ref lpdwBytesWritten);
        }
        public FT_STATUS tFT_Read(IntPtr ftHandle, byte[] lpBuffer, uint dwBytesToRead, ref uint lpdwBytesReturned)
        {
            return pFT_Read(ftHandle, lpBuffer, dwBytesToRead, ref lpdwBytesReturned);
        }
        public FT_STATUS tFT_CreateDeviceInfoList(ref uint numdevs)
        {
            return pFT_CreateDeviceInfoList(ref numdevs);
        }

        public FT_STATUS tFT_GetDeviceInfoDetail(uint index, ref uint flags, ref FT_DEVICE chiptype, ref uint id, ref uint locid, byte[] serialnumber, byte[] description, ref IntPtr ftHandle)
        {
            return pFT_GetDeviceInfoDetail(index, ref flags, ref chiptype, ref id, ref locid, serialnumber, description, ref ftHandle);
        }
        public FT_STATUS tFT_Open(uint index, ref IntPtr ftHandle)
        {
            return pFT_Open(index, ref ftHandle);
        }
        public FT_STATUS tFT_OpenEx(string devstring, uint dwFlags, ref IntPtr ftHandle)
        {
            return pFT_OpenEx(devstring, dwFlags, ref ftHandle);
        }

        public FT_STATUS tFT_SetDataCharacteristics(IntPtr ftHandle, byte uWordLength, byte uStopBits, byte uParity)
        {
            return pFT_SetDataCharacteristics(ftHandle, uWordLength, uStopBits, uParity);
        }

        public FT_STATUS tFT_SetFlowControl(IntPtr ftHandle, ushort usFlowControl, byte uXon, byte uXoff)
        {
            return pFT_SetFlowControl(ftHandle, usFlowControl, uXon, uXoff);
        }

        public FT_STATUS tFT_SetBaudRate(IntPtr ftHandle, uint dwBaudRate)
        {
            return pFT_SetBaudRate(ftHandle, dwBaudRate);
        }
        public FT_STATUS tFT_SetTimeouts(IntPtr ftHandle, uint dwReadTimeout, uint dwWriteTimeout)
        {
            return pFT_SetTimeouts(ftHandle, dwReadTimeout, dwWriteTimeout);
        }
        public FT_STATUS tFT_SetBitMode(IntPtr ftHandle, byte ucMask, byte ucMode)
        {
            return pFT_SetBitMode(ftHandle, ucMask, ucMode);
        }
        public FT_STATUS tFT_OpenExLoc(uint devloc, uint dwFlags, ref IntPtr ftHandle)
        {
            return pFT_OpenExLoc(devloc, dwFlags, ref ftHandle);
        }

        public FT_STATUS tFT_Close(IntPtr ftHandle)
        {
            return pFT_Close(ftHandle);
        }
    }
}
