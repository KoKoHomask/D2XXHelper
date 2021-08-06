using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace D2XXHelper
{
	public class FT_EXCEPTION : Exception
	{
		// Token: 0x06000146 RID: 326 RVA: 0x00008B6B File Offset: 0x00006D6B
		public FT_EXCEPTION()
		{
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00008B73 File Offset: 0x00006D73
		public FT_EXCEPTION(string message) : base(message)
		{
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00008B7C File Offset: 0x00006D7C
		public FT_EXCEPTION(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00008B86 File Offset: 0x00006D86
		protected FT_EXCEPTION(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
