using System;
using System.Runtime.InteropServices;

// Token: 0x020000CA RID: 202
[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
internal static class Class107
{
	// Token: 0x06000552 RID: 1362 RVA: 0x0000575D File Offset: 0x0000395D
	internal static bool smethod_0<T>(T[] gparam_0)
	{
		if (gparam_0 == null)
		{
			throw new ArgumentNullException();
		}
		return gparam_0.Length != 0;
	}
}
