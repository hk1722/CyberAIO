using System;
using System.Runtime.InteropServices;
using System.Security;

// Token: 0x02000033 RID: 51
internal sealed class Class26 : Interface0, IDisposable
{
	// Token: 0x0600013E RID: 318 RVA: 0x0000387D File Offset: 0x00001A7D
	public int imethod_0()
	{
		return this.secureString_0.Length;
	}

	// Token: 0x0600013F RID: 319 RVA: 0x0000388A File Offset: 0x00001A8A
	public Interface0 imethod_4()
	{
		return new Class26();
	}

	// Token: 0x06000140 RID: 320 RVA: 0x0000E230 File Offset: 0x0000C430
	public void imethod_1(int int_0, out byte byte_0)
	{
		if (int_0 >= 0 && int_0 < this.imethod_0())
		{
			IntPtr intPtr = IntPtr.Zero;
			char char_ = '\0';
			try
			{
				intPtr = Marshal.SecureStringToGlobalAllocUnicode(this.secureString_0);
				char_ = (char)Marshal.ReadInt16(intPtr, int_0 * 2);
				byte_0 = Class26.smethod_1(char_, int_0);
				return;
			}
			finally
			{
				Class169.smethod_3(ref char_);
				if (intPtr != IntPtr.Zero)
				{
					Marshal.ZeroFreeGlobalAllocUnicode(intPtr);
				}
			}
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x06000141 RID: 321 RVA: 0x0000E2A8 File Offset: 0x0000C4A8
	public void imethod_2(int int_0, ref byte byte_0)
	{
		for (int i = this.secureString_0.Length; i <= int_0; i++)
		{
			if (i == int_0)
			{
				this.secureString_0.AppendChar(Class26.smethod_0(byte_0, i));
				return;
			}
			this.secureString_0.AppendChar(Class26.smethod_0(0, i));
		}
		this.secureString_0.SetAt(int_0, Class26.smethod_0(byte_0, int_0));
	}

	// Token: 0x06000142 RID: 322 RVA: 0x00003891 File Offset: 0x00001A91
	private static char smethod_0(byte byte_0, int int_0)
	{
		return (char)(byte_0 + 1);
	}

	// Token: 0x06000143 RID: 323 RVA: 0x00003897 File Offset: 0x00001A97
	private static byte smethod_1(char char_0, int int_0)
	{
		return (byte)(char_0 - '\u0001');
	}

	// Token: 0x06000144 RID: 324 RVA: 0x0000389D File Offset: 0x00001A9D
	public void imethod_3()
	{
		this.secureString_0.Clear();
	}

	// Token: 0x06000145 RID: 325 RVA: 0x000038AA File Offset: 0x00001AAA
	public void Dispose()
	{
		this.secureString_0.Dispose();
		this.secureString_0 = null;
	}

	// Token: 0x040000A4 RID: 164
	private SecureString secureString_0 = new SecureString();
}
