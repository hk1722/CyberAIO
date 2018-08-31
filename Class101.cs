using System;

// Token: 0x020000BD RID: 189
internal static class Class101
{
	// Token: 0x060004ED RID: 1261 RVA: 0x0002845C File Offset: 0x0002665C
	public static void smethod_0(byte[] byte_0, int int_0, int int_1)
	{
		for (int i = 0; i < 4; i++)
		{
			int num = int_0++;
			byte_0[num] ^= (byte)(int_1 >> i * 8);
		}
	}

	// Token: 0x060004EE RID: 1262 RVA: 0x00028494 File Offset: 0x00026694
	public static void smethod_1(byte[] byte_0, int int_0, int int_1)
	{
		for (int i = 0; i < 4; i++)
		{
			if (int_0 >= byte_0.Length)
			{
				return;
			}
			int num = int_0++;
			byte_0[num] ^= (byte)(int_1 >> i * 8);
		}
	}

	// Token: 0x060004EF RID: 1263 RVA: 0x000284D0 File Offset: 0x000266D0
	public static void smethod_2(byte[] byte_0, int int_0, long long_0)
	{
		for (int i = 0; i < 8; i++)
		{
			int num = int_0++;
			byte_0[num] ^= (byte)(long_0 >> i * 8);
		}
	}
}
