﻿using System;

namespace D2XXHelper
{

	public enum FT_ERROR
	{
		// Token: 0x04000057 RID: 87
		FT_NO_ERROR,
		// Token: 0x04000058 RID: 88
		FT_INCORRECT_DEVICE,
		// Token: 0x04000059 RID: 89
		FT_INVALID_BITMODE,
		// Token: 0x0400005A RID: 90
		FT_BUFFER_SIZE
	}
	public enum FT_DEVICE
	{
		// Token: 0x040000B4 RID: 180
		FT_DEVICE_BM,
		// Token: 0x040000B5 RID: 181
		FT_DEVICE_AM,
		// Token: 0x040000B6 RID: 182
		FT_DEVICE_100AX,
		// Token: 0x040000B7 RID: 183
		FT_DEVICE_UNKNOWN,
		// Token: 0x040000B8 RID: 184
		FT_DEVICE_2232,
		// Token: 0x040000B9 RID: 185
		FT_DEVICE_232R,
		// Token: 0x040000BA RID: 186
		FT_DEVICE_2232H,
		// Token: 0x040000BB RID: 187
		FT_DEVICE_4232H,
		// Token: 0x040000BC RID: 188
		FT_DEVICE_232H,
		// Token: 0x040000BD RID: 189
		FT_DEVICE_X_SERIES,
		// Token: 0x040000BE RID: 190
		FT_DEVICE_4222H_0,
		// Token: 0x040000BF RID: 191
		FT_DEVICE_4222H_1_2,
		// Token: 0x040000C0 RID: 192
		FT_DEVICE_4222H_3,
		// Token: 0x040000C1 RID: 193
		FT_DEVICE_4222_PROG,
		// Token: 0x040000C2 RID: 194
		FT_DEVICE_FT900,
		// Token: 0x040000C3 RID: 195
		FT_DEVICE_FT930,
		// Token: 0x040000C4 RID: 196
		FT_DEVICE_UMFTPD3A,
		// Token: 0x040000C5 RID: 197
		FT_DEVICE_2233HP,
		// Token: 0x040000C6 RID: 198
		FT_DEVICE_4233HP,
		// Token: 0x040000C7 RID: 199
		FT_DEVICE_2232HP,
		// Token: 0x040000C8 RID: 200
		FT_DEVICE_4232HP,
		// Token: 0x040000C9 RID: 201
		FT_DEVICE_233HP,
		// Token: 0x040000CA RID: 202
		FT_DEVICE_232HP,
		// Token: 0x040000CB RID: 203
		FT_DEVICE_2232HA,
		// Token: 0x040000CC RID: 204
		FT_DEVICE_4232HA
	}
	public enum FT_STATUS
	{
		// Token: 0x04000044 RID: 68
		FT_OK,
		// Token: 0x04000045 RID: 69
		FT_INVALID_HANDLE,
		// Token: 0x04000046 RID: 70
		FT_DEVICE_NOT_FOUND,
		// Token: 0x04000047 RID: 71
		FT_DEVICE_NOT_OPENED,
		// Token: 0x04000048 RID: 72
		FT_IO_ERROR,
		// Token: 0x04000049 RID: 73
		FT_INSUFFICIENT_RESOURCES,
		// Token: 0x0400004A RID: 74
		FT_INVALID_PARAMETER,
		// Token: 0x0400004B RID: 75
		FT_INVALID_BAUD_RATE,
		// Token: 0x0400004C RID: 76
		FT_DEVICE_NOT_OPENED_FOR_ERASE,
		// Token: 0x0400004D RID: 77
		FT_DEVICE_NOT_OPENED_FOR_WRITE,
		// Token: 0x0400004E RID: 78
		FT_FAILED_TO_WRITE_DEVICE,
		// Token: 0x0400004F RID: 79
		FT_EEPROM_READ_FAILED,
		// Token: 0x04000050 RID: 80
		FT_EEPROM_WRITE_FAILED,
		// Token: 0x04000051 RID: 81
		FT_EEPROM_ERASE_FAILED,
		// Token: 0x04000052 RID: 82
		FT_EEPROM_NOT_PRESENT,
		// Token: 0x04000053 RID: 83
		FT_EEPROM_NOT_PROGRAMMED,
		// Token: 0x04000054 RID: 84
		FT_INVALID_ARGS,
		// Token: 0x04000055 RID: 85
		FT_OTHER_ERROR
	}
}