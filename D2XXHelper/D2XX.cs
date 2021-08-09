using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
namespace D2XXHelper
{
    public class D2XX
    {
        //private IntPtr hFTD2XXDLL = IntPtr.Zero;
		private IntPtr ftHandle = IntPtr.Zero;
		ID2XXFunction d2XXFunction;
		public bool IsOpen
		{
			get
			{
				return !(this.ftHandle == IntPtr.Zero);
			}
		}
		public D2XX()
        {
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				if (Environment.Is64BitProcess)
					d2XXFunction = new D2XX_Win64();
				else
					d2XXFunction = new D2XX_Win();
			}
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
				d2XXFunction = new D2XX_Linux();
		}

        private void ErrorHandler(FT_STATUS ftStatus, FT_ERROR ftErrorCondition)
		{
			if (ftStatus != FT_STATUS.FT_OK)
			{
				switch (ftStatus)
				{
					case FT_STATUS.FT_INVALID_HANDLE:
						throw new FT_EXCEPTION("Invalid handle for FTDI device.");
					case FT_STATUS.FT_DEVICE_NOT_FOUND:
						throw new FT_EXCEPTION("FTDI device not found.");
					case FT_STATUS.FT_DEVICE_NOT_OPENED:
						throw new FT_EXCEPTION("FTDI device not opened.");
					case FT_STATUS.FT_IO_ERROR:
						throw new FT_EXCEPTION("FTDI device IO error.");
					case FT_STATUS.FT_INSUFFICIENT_RESOURCES:
						throw new FT_EXCEPTION("Insufficient resources.");
					case FT_STATUS.FT_INVALID_PARAMETER:
						throw new FT_EXCEPTION("Invalid parameter for FTD2XX function call.");
					case FT_STATUS.FT_INVALID_BAUD_RATE:
						throw new FT_EXCEPTION("Invalid Baud rate for FTDI device.");
					case FT_STATUS.FT_DEVICE_NOT_OPENED_FOR_ERASE:
						throw new FT_EXCEPTION("FTDI device not opened for erase.");
					case FT_STATUS.FT_DEVICE_NOT_OPENED_FOR_WRITE:
						throw new FT_EXCEPTION("FTDI device not opened for write.");
					case FT_STATUS.FT_FAILED_TO_WRITE_DEVICE:
						throw new FT_EXCEPTION("Failed to write to FTDI device.");
					case FT_STATUS.FT_EEPROM_READ_FAILED:
						throw new FT_EXCEPTION("Failed to read FTDI device EEPROM.");
					case FT_STATUS.FT_EEPROM_WRITE_FAILED:
						throw new FT_EXCEPTION("Failed to write FTDI device EEPROM.");
					case FT_STATUS.FT_EEPROM_ERASE_FAILED:
						throw new FT_EXCEPTION("Failed to erase FTDI device EEPROM.");
					case FT_STATUS.FT_EEPROM_NOT_PRESENT:
						throw new FT_EXCEPTION("No EEPROM fitted to FTDI device.");
					case FT_STATUS.FT_EEPROM_NOT_PROGRAMMED:
						throw new FT_EXCEPTION("FTDI device EEPROM not programmed.");
					case FT_STATUS.FT_INVALID_ARGS:
						throw new FT_EXCEPTION("Invalid arguments for FTD2XX function call.");
					case FT_STATUS.FT_OTHER_ERROR:
						throw new FT_EXCEPTION("An unexpected error has occurred when trying to communicate with the FTDI device.");
				}
			}
			if (ftErrorCondition == FT_ERROR.FT_NO_ERROR)
			{
				return;
			}
			switch (ftErrorCondition)
			{
				case FT_ERROR.FT_INCORRECT_DEVICE:
					throw new FT_EXCEPTION("The current device type does not match the EEPROM structure.");
				case FT_ERROR.FT_INVALID_BITMODE:
					throw new FT_EXCEPTION("The requested bit mode is not valid for the current device.");
				case FT_ERROR.FT_BUFFER_SIZE:
					throw new FT_EXCEPTION("The supplied buffer is not big enough.");
				default:
					return;
			}
		}

		public FT_STATUS GetDeviceList(FT_DEVICE_INFO_NODE[] devicelist)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (d2XXFunction == null) return ft_STATUS;
			uint num = 0U;
			ft_STATUS = d2XXFunction.tFT_CreateDeviceInfoList(ref num);

			byte[] array = new byte[16];
			byte[] array2 = new byte[64];
			if (num > 0U)
			{
				if ((long)devicelist.Length < (long)((ulong)num))
				{
					FT_ERROR ftErrorCondition = FT_ERROR.FT_BUFFER_SIZE;
					this.ErrorHandler(ft_STATUS, ftErrorCondition);
				}
				for (uint num2 = 0U; num2 < num; num2 += 1U)
				{
					devicelist[(int)((UIntPtr)num2)] = new FT_DEVICE_INFO_NODE();
					ft_STATUS = d2XXFunction.tFT_GetDeviceInfoDetail(num2, ref devicelist[(int)((UIntPtr)num2)].Flags, ref devicelist[(int)((UIntPtr)num2)].Type, ref devicelist[(int)((UIntPtr)num2)].ID, ref devicelist[(int)((UIntPtr)num2)].LocId, array, array2, ref devicelist[(int)((UIntPtr)num2)].ftHandle);
					devicelist[(int)((UIntPtr)num2)].SerialNumber = Encoding.ASCII.GetString(array);
					devicelist[(int)((UIntPtr)num2)].Description = Encoding.ASCII.GetString(array2);
					int num3 = devicelist[(int)((UIntPtr)num2)].SerialNumber.IndexOf('\0');
					if (num3 != -1)
					{
						devicelist[(int)((UIntPtr)num2)].SerialNumber = devicelist[(int)((UIntPtr)num2)].SerialNumber.Substring(0, num3);
					}
					num3 = devicelist[(int)((UIntPtr)num2)].Description.IndexOf('\0');
					if (num3 != -1)
					{
						devicelist[(int)((UIntPtr)num2)].Description = devicelist[(int)((UIntPtr)num2)].Description.Substring(0, num3);
					}
				}
			}
			else
				Console.WriteLine("Failed to run function FT_CreateDeviceInfoList.");
			return ft_STATUS;
		}

		public FT_STATUS OpenByIndex(uint index)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (d2XXFunction == null)
				return ft_STATUS;

			ft_STATUS = d2XXFunction.tFT_Open(index, ref this.ftHandle);
			if (ft_STATUS == FT_STATUS.FT_OK)
			{
				byte uWordLength = 8;
				byte uStopBits = 0;
				byte uParity = 0;
				ft_STATUS = d2XXFunction.tFT_SetDataCharacteristics(this.ftHandle, uWordLength, uStopBits, uParity);
				ushort usFlowControl = 0;
				byte uXon = 17;
				byte uXoff = 19;
				ft_STATUS = d2XXFunction.tFT_SetFlowControl(this.ftHandle, usFlowControl, uXon, uXoff);
				uint dwBaudRate = 9600U;
				ft_STATUS = d2XXFunction.tFT_SetBaudRate(this.ftHandle, dwBaudRate);
			}
			return ft_STATUS;
		}
		public FT_STATUS OpenByLocation(uint location)
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (d2XXFunction == null) return ft_STATUS;
			ft_STATUS = d2XXFunction.tFT_OpenExLoc(location, 4U, ref this.ftHandle);
			if (ft_STATUS != FT_STATUS.FT_OK)
				this.ftHandle = IntPtr.Zero;
			if (this.ftHandle != IntPtr.Zero)
			{
				byte uWordLength = 8;
				byte uStopBits = 0;
				byte uParity = 0;
				d2XXFunction.tFT_SetDataCharacteristics(this.ftHandle, uWordLength, uStopBits, uParity);
				ushort usFlowControl = 0;
				byte uXon = 17;
				byte uXoff = 19;
				d2XXFunction.tFT_SetFlowControl(this.ftHandle, usFlowControl, uXon, uXoff);
				uint dwBaudRate = 9600U;
				d2XXFunction.tFT_SetBaudRate(this.ftHandle, dwBaudRate);
			}
			else
				Console.WriteLine("Failed to run function FT_OpenEx.");
			return ft_STATUS;
		}

		public FT_STATUS SetBaudRate(uint BaudRate)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (d2XXFunction == null) return result;
			if (this.ftHandle != IntPtr.Zero)
				result = d2XXFunction.tFT_SetBaudRate(this.ftHandle, BaudRate);
			else
				Console.WriteLine("Failed to run function FT_SetBaudRate.");
			return result;
		}
		public FT_STATUS SetTimeouts(uint ReadTimeout, uint WriteTimeout)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (d2XXFunction == null) return result;
			if (this.ftHandle != IntPtr.Zero)
				result = d2XXFunction.tFT_SetTimeouts(this.ftHandle, ReadTimeout, WriteTimeout);
			else
				Console.WriteLine("Failed to run function FT_SetTimeouts.");
			return result;
		}

		public FT_STATUS SetDataCharacteristics(byte DataBits, byte StopBits, byte Parity)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (d2XXFunction == null) return result;
			if (this.ftHandle != IntPtr.Zero)
				result = d2XXFunction.tFT_SetDataCharacteristics(this.ftHandle, DataBits, StopBits, Parity);
			else
				Console.WriteLine("Failed to run function FT_SetDataCharacteristics.");
			return result;
		}

		public FT_STATUS Read(byte[] dataBuffer, uint numBytesToRead, ref uint numBytesRead)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (d2XXFunction == null) return result;
			if ((long)dataBuffer.Length < (long)((ulong)numBytesToRead))
				numBytesToRead = (uint)dataBuffer.Length;
			if (this.ftHandle != IntPtr.Zero)
				result = d2XXFunction.tFT_Read(this.ftHandle, dataBuffer, numBytesToRead, ref numBytesRead);
			return result;
		}
		public FT_STATUS Write(byte[] dataBuffer, uint numBytesToWrite, ref uint numBytesWritten)
		{
			FT_STATUS result = FT_STATUS.FT_OTHER_ERROR;
			if (d2XXFunction == null) return result;
			if (this.ftHandle != IntPtr.Zero)
				result = d2XXFunction.tFT_Write(this.ftHandle, dataBuffer, numBytesToWrite, ref numBytesWritten);
			return result;
		}

		public FT_STATUS Close()
		{
			FT_STATUS ft_STATUS = FT_STATUS.FT_OTHER_ERROR;
			if (d2XXFunction == null)
				return ft_STATUS;
			ft_STATUS = d2XXFunction.tFT_Close(this.ftHandle);
			if (ft_STATUS == FT_STATUS.FT_OK)
				this.ftHandle = IntPtr.Zero;
			return ft_STATUS;
		}


	}
}
