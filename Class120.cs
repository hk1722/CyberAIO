using System;
using System.Runtime.InteropServices;
using System.Text;

// Token: 0x020000DF RID: 223
internal static class Class120
{
	// Token: 0x060005D3 RID: 1491 RVA: 0x00030318 File Offset: 0x0002E518
	public static Class12 smethod_0(string string_0)
	{
		byte[] array = Class9.smethod_5(string_0);
		if (array == null)
		{
			return null;
		}
		return new Class12
		{
			class179_0 = new Class179
			{
				byte_0 = array,
				bool_0 = true,
				bool_1 = true
			}
		};
	}

	// Token: 0x060005D4 RID: 1492 RVA: 0x00030358 File Offset: 0x0002E558
	public static byte[] smethod_1(string string_0)
	{
		if (string_0 == null)
		{
			return null;
		}
		if (string_0.Length == 0)
		{
			return new byte[0];
		}
		byte[] bytes = Encoding.UTF8.GetBytes(string_0);
		byte[] result = Class175.smethod_0(bytes, Class55.smethod_0(), new Func<byte[]>(Class120.smethod_4));
		Array.Clear(bytes, 0, bytes.Length);
		return result;
	}

	// Token: 0x060005D5 RID: 1493 RVA: 0x000303A8 File Offset: 0x0002E5A8
	public static string smethod_2(byte[] byte_0, bool bool_0)
	{
		if (byte_0 == null)
		{
			return null;
		}
		if (byte_0.Length == 0)
		{
			return string.Empty;
		}
		byte[] array = Class175.smethod_1<byte>(byte_0, 0, Class55.smethod_0(), new Func<byte[]>(Class120.smethod_4), bool_0);
		string @string = Encoding.UTF8.GetString(array);
		Array.Clear(array, 0, array.Length);
		return @string;
	}

	// Token: 0x060005D6 RID: 1494 RVA: 0x000303F4 File Offset: 0x0002E5F4
	public static void smethod_3(string string_0)
	{
		if (string.IsInterned(string_0) != null)
		{
			return;
		}
		GCHandle gchandle = default(GCHandle);
		try
		{
			gchandle = GCHandle.Alloc(string_0, GCHandleType.Pinned);
			IntPtr ptr = gchandle.AddrOfPinnedObject();
			bool flag = IntPtr.Size == 4;
			int num = string_0.Length * 2;
			int i = 0;
			int num2 = num / IntPtr.Size;
			for (int j = 0; j < num2; j++)
			{
				if (flag)
				{
					Marshal.WriteInt32(ptr, i, 0);
				}
				else
				{
					Marshal.WriteInt64(ptr, i, 0L);
				}
				i += IntPtr.Size;
			}
			while (i < num)
			{
				Marshal.WriteInt16(ptr, i, 0);
				i += 2;
			}
			gchandle.Free();
		}
		catch (Exception)
		{
			if (gchandle.IsAllocated)
			{
				gchandle.Free();
			}
		}
	}

	// Token: 0x060005D7 RID: 1495 RVA: 0x00005DA5 File Offset: 0x00003FA5
	private static byte[] smethod_4()
	{
		return (byte[])Class62.smethod_0().method_232(Class62.smethod_1(), "rr;n^qYTOQ", null);
	}
}
