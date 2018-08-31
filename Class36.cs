using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

// Token: 0x02000041 RID: 65
internal static class Class36
{
	// Token: 0x0600017D RID: 381 RVA: 0x00010710 File Offset: 0x0000E910
	internal static long smethod_0()
	{
		if (Assembly.GetCallingAssembly() == typeof(Class36).Assembly && Class36.smethod_1())
		{
			long result;
			lock (Class36.class37_0)
			{
				long num = Class36.class37_0.method_0();
				if (num == 0L)
				{
					Assembly executingAssembly = Assembly.GetExecutingAssembly();
					List<byte> list = new List<byte>();
					AssemblyName assemblyName;
					try
					{
						assemblyName = executingAssembly.GetName();
					}
					catch
					{
						assemblyName = new AssemblyName(executingAssembly.FullName);
					}
					byte[] array = assemblyName.GetPublicKeyToken();
					if (array != null && array.Length == 0)
					{
						array = null;
					}
					if (array != null)
					{
						list.AddRange(array);
					}
					list.AddRange(Encoding.Unicode.GetBytes(assemblyName.Name));
					int num2 = Class36.smethod_3(typeof(Class36));
					int num3 = Class36.Class40.smethod_0();
					list.Add((byte)(num2 >> 8));
					list.Add((byte)(num3 >> 8));
					list.Add((byte)(num2 >> 16));
					list.Add((byte)(num3 >> 16));
					list.Add((byte)(num2 >> 24));
					list.Add((byte)num3);
					list.Add((byte)num2);
					list.Add((byte)(num3 >> 24));
					int count = list.Count;
					ulong num4 = 0UL;
					for (int num5 = 0; num5 != count; num5++)
					{
						num4 += (ulong)list[num5];
						num4 += num4 << 20;
						num4 ^= num4 >> 12;
						list[num5] = 0;
					}
					num4 += num4 << 6;
					num4 ^= num4 >> 22;
					num4 += num4 << 30;
					num = (long)num4;
					num ^= 4443295120935712978L;
					Class36.class37_0.method_1(num);
				}
				result = num;
			}
			return result;
		}
		return 0L;
	}

	// Token: 0x0600017E RID: 382 RVA: 0x00003AB8 File Offset: 0x00001CB8
	private static bool smethod_1()
	{
		return Class36.smethod_2();
	}

	// Token: 0x0600017F RID: 383 RVA: 0x000108F4 File Offset: 0x0000EAF4
	private static bool smethod_2()
	{
		StackTrace stackTrace = new StackTrace();
		StackFrame frame = stackTrace.GetFrame(3);
		MethodBase methodBase = (frame == null) ? null : frame.GetMethod();
		Type type = (methodBase == null) ? null : methodBase.DeclaringType;
		return type != typeof(RuntimeMethodHandle) && type != null && type.Assembly == typeof(Class36).Assembly;
	}

	// Token: 0x06000180 RID: 384 RVA: 0x00003AC4 File Offset: 0x00001CC4
	private static int smethod_3(Type type_0)
	{
		return type_0.MetadataToken;
	}

	// Token: 0x040000DA RID: 218
	private static Class36.Class37 class37_0 = new Class36.Class37();

	// Token: 0x02000042 RID: 66
	private sealed class Class37
	{
		// Token: 0x06000181 RID: 385 RVA: 0x00003ACC File Offset: 0x00001CCC
		internal Class37()
		{
			this.method_1(0L);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00010958 File Offset: 0x0000EB58
		internal long method_0()
		{
			if (Assembly.GetCallingAssembly() != typeof(Class36.Class37).Assembly)
			{
				return 2918384L;
			}
			if (!Class36.smethod_1())
			{
				return 2918384L;
			}
			int[] array = new int[]
			{
				0,
				0,
				0,
				-50765676
			};
			array[1] = -1775563011;
			array[2] = 108474532;
			array[0] = -468888275;
			int num = this.int_0;
			int num2 = this.int_1;
			int num3 = -1640531527;
			int num4 = -957401312;
			for (int num5 = 0; num5 != 32; num5++)
			{
				num2 -= ((num << 4 ^ num >> 5) + num ^ num4 + array[num4 >> 11 & 3]);
				num4 -= num3;
				num -= ((num2 << 4 ^ num2 >> 5) + num2 ^ num4 + array[num4 & 3]);
			}
			for (int num6 = 0; num6 != 4; num6++)
			{
				array[num6] = 0;
			}
			ulong num7 = (ulong)((ulong)((long)num2) << 32);
			return (long)(num7 | (ulong)num);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00010A40 File Offset: 0x0000EC40
		internal void method_1(long long_0)
		{
			if (Assembly.GetCallingAssembly() != typeof(Class36.Class37).Assembly)
			{
				return;
			}
			if (!Class36.smethod_1())
			{
				return;
			}
			int[] array = new int[4];
			array[1] = -1775563011;
			array[0] = -468888275;
			array[2] = 108474532;
			array[3] = -50765676;
			int num = -1640531527;
			int num2 = (int)long_0;
			int num3 = (int)(long_0 >> 32);
			int num4 = 0;
			for (int num5 = 0; num5 != 32; num5++)
			{
				num2 += ((num3 << 4 ^ num3 >> 5) + num3 ^ num4 + array[num4 & 3]);
				num4 += num;
				num3 += ((num2 << 4 ^ num2 >> 5) + num2 ^ num4 + array[num4 >> 11 & 3]);
			}
			for (int num6 = 0; num6 != 4; num6++)
			{
				array[num6] = 0;
			}
			this.int_0 = num2;
			this.int_1 = num3;
		}

		// Token: 0x040000DB RID: 219
		private int int_0;

		// Token: 0x040000DC RID: 220
		private int int_1;
	}

	// Token: 0x02000043 RID: 67
	private sealed class Class38
	{
		// Token: 0x06000185 RID: 389 RVA: 0x00010B0C File Offset: 0x0000ED0C
		internal static int smethod_0()
		{
			return Class36.Class43.smethod_2(Class36.Class43.smethod_0(Class36.Class39.smethod_0() ^ 527758446, Class36.smethod_3(typeof(Class36.Class42))), Class36.Class43.smethod_1(Class36.smethod_3(typeof(Class36.Class40)) ^ Class36.smethod_3(typeof(Class36.Class41)), -1681483524));
		}
	}

	// Token: 0x02000044 RID: 68
	private sealed class Class39
	{
		// Token: 0x06000187 RID: 391 RVA: 0x00010B68 File Offset: 0x0000ED68
		internal static int smethod_0()
		{
			return Class36.Class43.smethod_0(Class36.smethod_3(typeof(Class36.Class38)), Class36.smethod_3(typeof(Class36.Class42)) ^ Class36.Class43.smethod_1(Class36.smethod_3(typeof(Class36.Class39)), Class36.Class43.smethod_2(Class36.smethod_3(typeof(Class36.Class41)), Class36.Class42.smethod_0())));
		}
	}

	// Token: 0x02000045 RID: 69
	private sealed class Class40
	{
		// Token: 0x06000189 RID: 393 RVA: 0x00010BC8 File Offset: 0x0000EDC8
		internal static int smethod_0()
		{
			return Class36.Class43.smethod_2(Class36.Class43.smethod_1(Class36.smethod_3(typeof(Class36.Class39)), Class36.Class43.smethod_2(Class36.smethod_3(typeof(Class36.Class40)), Class36.smethod_3(typeof(Class36.Class44)))), Class36.Class41.smethod_0());
		}
	}

	// Token: 0x02000046 RID: 70
	private sealed class Class41
	{
		// Token: 0x0600018B RID: 395 RVA: 0x00010C18 File Offset: 0x0000EE18
		internal static int smethod_0()
		{
			return Class36.Class43.smethod_0(Class36.smethod_3(typeof(Class36.Class41)), Class36.Class43.smethod_2(Class36.Class43.smethod_1(Class36.smethod_3(typeof(Class36.Class44)), Class36.smethod_3(typeof(Class36.Class40))), Class36.Class43.smethod_2(Class36.smethod_3(typeof(Class36.Class38)) ^ -1375087884, Class36.Class44.smethod_0())));
		}
	}

	// Token: 0x02000047 RID: 71
	private sealed class Class42
	{
		// Token: 0x0600018D RID: 397 RVA: 0x00010C80 File Offset: 0x0000EE80
		internal static int smethod_0()
		{
			return Class36.Class43.smethod_2(Class36.smethod_3(typeof(Class36.Class42)), Class36.Class43.smethod_0(Class36.smethod_3(typeof(Class36.Class40)), Class36.Class43.smethod_1(Class36.smethod_3(typeof(Class36.Class39)), Class36.Class43.smethod_2(Class36.smethod_3(typeof(Class36.Class38)), Class36.Class43.smethod_0(Class36.smethod_3(typeof(Class36.Class44)), Class36.smethod_3(typeof(Class36.Class41)))))));
		}
	}

	// Token: 0x02000048 RID: 72
	private static class Class43
	{
		// Token: 0x0600018E RID: 398 RVA: 0x00003AE3 File Offset: 0x00001CE3
		internal static int smethod_0(int int_0, int int_1)
		{
			return int_0 ^ int_1 - 294110578;
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00003AEE File Offset: 0x00001CEE
		internal static int smethod_1(int int_0, int int_1)
		{
			return int_0 - 2035062029 ^ int_1 + -1814099450;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00003AFF File Offset: 0x00001CFF
		internal static int smethod_2(int int_0, int int_1)
		{
			return int_0 ^ (int_1 - -1593729941 ^ int_0 - int_1);
		}
	}

	// Token: 0x02000049 RID: 73
	private sealed class Class44
	{
		// Token: 0x06000192 RID: 402 RVA: 0x00003B0E File Offset: 0x00001D0E
		internal static int smethod_0()
		{
			return Class36.Class43.smethod_1(Class36.Class43.smethod_1(Class36.Class38.smethod_0(), Class36.Class43.smethod_0(Class36.smethod_3(typeof(Class36.Class44)), Class36.Class39.smethod_0())), Class36.smethod_3(typeof(Class36.Class41)));
		}
	}
}
