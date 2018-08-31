using System;
using System.IO;

// Token: 0x02000017 RID: 23
internal sealed class Class9
{
	// Token: 0x0600008B RID: 139 RVA: 0x000030F9 File Offset: 0x000012F9
	private static Stream smethod_0()
	{
		return (Stream)Class62.smethod_0().method_232(Class62.smethod_1(), "rr;nMqYT1G", null);
	}

	// Token: 0x0600008C RID: 140 RVA: 0x00003115 File Offset: 0x00001315
	private static int smethod_1()
	{
		return (int)Class62.smethod_0().method_232(Class62.smethod_1(), "rr;m<qYT1G", null);
	}

	// Token: 0x0600008D RID: 141 RVA: 0x00003136 File Offset: 0x00001336
	private static byte[] smethod_2()
	{
		return (byte[])Class62.smethod_0().method_232(Class62.smethod_1(), "rr;mUqYT1G", null);
	}

	// Token: 0x0600008E RID: 142 RVA: 0x00003152 File Offset: 0x00001352
	private static byte[] smethod_3()
	{
		return (byte[])Class62.smethod_0().method_232(Class62.smethod_1(), "rr;opqYSY8", null);
	}

	// Token: 0x0600008F RID: 143 RVA: 0x0000316E File Offset: 0x0000136E
	public static void smethod_4(string string_0, byte[] byte_0, int int_0, int int_1)
	{
		if (Class9.stream_0 == null)
		{
			Class9.stream_0 = Class9.smethod_0();
		}
		Class9.smethod_9(Class9.smethod_11(string_0), byte_0, int_0, int_1);
	}

	// Token: 0x06000090 RID: 144 RVA: 0x0000AB2C File Offset: 0x00008D2C
	public static byte[] smethod_5(string string_0)
	{
		if (Class9.stream_0 == null)
		{
			Class9.stream_0 = Class9.smethod_0();
		}
		long num = Class9.smethod_11(string_0);
		byte[] array = new byte[4];
		Class9.smethod_9(num, array, 0, 4);
		int num2 = Class15.smethod_4(array, 0);
		Array.Clear(array, 0, array.Length);
		byte[] array2 = new byte[num2];
		Class9.smethod_9(num + 4L, array2, 0, num2);
		return array2;
	}

	// Token: 0x06000091 RID: 145 RVA: 0x0000AB8C File Offset: 0x00008D8C
	private static Class47 smethod_6(out bool bool_0)
	{
		bool_0 = true;
		if (Class9.class47_0 != null)
		{
			return Class9.class47_0;
		}
		if (Class9.class136_0 != null)
		{
			bool_0 = false;
			return Class9.class136_0.method_8();
		}
		Class136 @class = Class9.smethod_8();
		Class47 class2 = @class.method_8();
		if (class2.vmethod_0())
		{
			Class9.class47_0 = class2;
			@class.Dispose();
		}
		else
		{
			Class9.class136_0 = @class;
			bool_0 = false;
		}
		return class2;
	}

	// Token: 0x06000092 RID: 146 RVA: 0x0000ABEC File Offset: 0x00008DEC
	private static int smethod_7()
	{
		if (Class9.nullable_0 != null)
		{
			return Class9.nullable_0.Value;
		}
		bool flag;
		Class47 @class = Class9.smethod_6(out flag);
		Class9.nullable_0 = new int?(@class.vmethod_1());
		if (!flag)
		{
			@class.Dispose();
		}
		return Class9.nullable_0.Value;
	}

	// Token: 0x06000093 RID: 147 RVA: 0x0000318F File Offset: 0x0000138F
	private static Class136 smethod_8()
	{
		return (Class136)Class62.smethod_0().method_232(Class62.smethod_1(), "rr;n0qYU-b", null);
	}

	// Token: 0x06000094 RID: 148 RVA: 0x0000AC3C File Offset: 0x00008E3C
	private static void smethod_9(long long_0, byte[] byte_0, int int_0, int int_1)
	{
		object[] object_ = new object[]
		{
			long_0,
			byte_0,
			int_0,
			int_1
		};
		Class62.smethod_0().method_203(Class62.smethod_1(), "rr;m:qYU6e", object_);
	}

	// Token: 0x06000095 RID: 149 RVA: 0x0000AC84 File Offset: 0x00008E84
	private static void smethod_10(long long_0, byte[] byte_0)
	{
		object[] object_ = new object[]
		{
			long_0,
			byte_0
		};
		Class62.smethod_0().method_203(Class62.smethod_1(), "rr;ohqYTjZ", object_);
	}

	// Token: 0x06000096 RID: 150 RVA: 0x0000ACBC File Offset: 0x00008EBC
	private static long smethod_11(string string_0)
	{
		object[] object_ = new object[]
		{
			string_0
		};
		return (long)Class62.smethod_0().method_232(Class62.smethod_1(), "rr;mLqYU!^", object_);
	}

	// Token: 0x04000063 RID: 99
	[ThreadStatic]
	private static Stream stream_0;

	// Token: 0x04000064 RID: 100
	[ThreadStatic]
	private static Class136 class136_0;

	// Token: 0x04000065 RID: 101
	[ThreadStatic]
	private static Class47 class47_0;

	// Token: 0x04000066 RID: 102
	private static int? nullable_0;
}
