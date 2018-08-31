using System;

// Token: 0x020000CF RID: 207
internal sealed class Class110
{
	// Token: 0x0600056D RID: 1389 RVA: 0x00002D14 File Offset: 0x00000F14
	private Class110()
	{
	}

	// Token: 0x0600056E RID: 1390 RVA: 0x00005887 File Offset: 0x00003A87
	internal static void smethod_0(uint uint_0, byte[] byte_0, int int_0)
	{
		byte_0[int_0] = (byte)uint_0;
		byte_0[++int_0] = (byte)(uint_0 >> 8);
		byte_0[++int_0] = (byte)(uint_0 >> 16);
		byte_0[++int_0] = (byte)(uint_0 >> 24);
	}

	// Token: 0x0600056F RID: 1391 RVA: 0x000058BA File Offset: 0x00003ABA
	internal static uint smethod_1(byte[] byte_0, int int_0)
	{
		return (uint)((int)byte_0[int_0] | (int)byte_0[++int_0] << 8 | (int)byte_0[++int_0] << 16 | (int)byte_0[++int_0] << 24);
	}
}
