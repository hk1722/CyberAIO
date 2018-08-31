using System;

// Token: 0x020000BC RID: 188
internal static class Class100
{
	// Token: 0x060004EC RID: 1260 RVA: 0x0002841C File Offset: 0x0002661C
	public static bool smethod_0(int[] int_0, int[] int_1)
	{
		if (int_0 == int_1)
		{
			return true;
		}
		if (int_0 == null || int_1 == null)
		{
			return false;
		}
		if (int_0.Length != int_1.Length)
		{
			return false;
		}
		for (int i = 0; i < int_0.Length; i++)
		{
			if (int_0[i] != int_1[i])
			{
				return false;
			}
		}
		return true;
	}
}
