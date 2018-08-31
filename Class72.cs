using System;
using System.Threading;

// Token: 0x02000082 RID: 130
internal static class Class72
{
	// Token: 0x060002DC RID: 732 RVA: 0x000046B4 File Offset: 0x000028B4
	public static Interface0 smethod_0()
	{
		return Class72.smethod_1() ?? new Class51();
	}

	// Token: 0x060002DD RID: 733 RVA: 0x00017F5C File Offset: 0x0001615C
	private static Interface0 smethod_1()
	{
		Interface0 result;
		try
		{
			Class26 @class = new Class26();
			if (!Class72.smethod_3(@class))
			{
				@class.Dispose();
				result = null;
			}
			else
			{
				result = @class;
			}
		}
		catch (Exception exception_) when (!Class72.smethod_2(exception_))
		{
			result = null;
		}
		return result;
	}

	// Token: 0x060002DE RID: 734 RVA: 0x000046C4 File Offset: 0x000028C4
	private static bool smethod_2(Exception exception_0)
	{
		return exception_0 is ThreadAbortException || exception_0 is ThreadInterruptedException;
	}

	// Token: 0x060002DF RID: 735 RVA: 0x00017FB4 File Offset: 0x000161B4
	private static bool smethod_3(Interface0 interface0_0)
	{
		byte[] array = new byte[]
		{
			0,
			130,
			byte.MaxValue
		};
		for (int i = 0; i < array.Length; i++)
		{
			byte b = array[i];
			interface0_0.imethod_2(i, ref b);
		}
		if (interface0_0.imethod_0() != array.Length)
		{
			return false;
		}
		for (int j = 0; j < array.Length; j++)
		{
			byte b2;
			interface0_0.imethod_1(j, out b2);
			if (b2 != array[j])
			{
				return false;
			}
		}
		interface0_0.imethod_3();
		return interface0_0.imethod_0() == 0;
	}
}
