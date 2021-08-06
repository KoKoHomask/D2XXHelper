using System;
using System.Collections.Generic;
using System.Text;

namespace D2XXHelper
{
    interface ID2XXFunction
    {
        FT_STATUS tFT_CreateDeviceInfoList(ref uint numdevs);
        FT_STATUS tFT_GetDeviceInfoDetail(uint index, ref uint flags, ref FT_DEVICE chiptype, ref uint id, ref uint locid, byte[] serialnumber, byte[] description, ref IntPtr ftHandle);
        FT_STATUS tFT_Open(uint index, ref IntPtr ftHandle);
        FT_STATUS tFT_OpenEx(string devstring, uint dwFlags, ref IntPtr ftHandle);
        FT_STATUS tFT_OpenExLoc(uint devloc, uint dwFlags, ref IntPtr ftHandle);
        FT_STATUS tFT_SetDataCharacteristics(IntPtr ftHandle, byte uWordLength, byte uStopBits, byte uParity);
        FT_STATUS tFT_SetFlowControl(IntPtr ftHandle, ushort usFlowControl, byte uXon, byte uXoff);
        FT_STATUS tFT_SetBaudRate(IntPtr ftHandle, uint dwBaudRate);
        FT_STATUS tFT_SetTimeouts(IntPtr ftHandle, uint dwReadTimeout, uint dwWriteTimeout);
        FT_STATUS tFT_Close(IntPtr ftHandle);
        FT_STATUS tFT_Write(IntPtr ftHandle, byte[] lpBuffer, uint dwBytesToWrite, ref uint lpdwBytesWritten);
        FT_STATUS tFT_Read(IntPtr ftHandle, byte[] lpBuffer, uint dwBytesToRead, ref uint lpdwBytesReturned);
        FT_STATUS tFT_SetBitMode(IntPtr ftHandle, byte ucMask, byte ucMode);
    }
}
