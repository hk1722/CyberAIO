using System;

// Token: 0x020000CB RID: 203
internal class Class65 : Class64
{
	// Token: 0x06000553 RID: 1363 RVA: 0x00005771 File Offset: 0x00003971
	protected Class65()
	{
	}

	// Token: 0x06000554 RID: 1364 RVA: 0x00005779 File Offset: 0x00003979
	public Class65(Interface6 interface6_1)
	{
		if (interface6_1 == null)
		{
			throw new ArgumentNullException("cipher");
		}
		this.interface6_0 = interface6_1;
		this.byte_1 = new byte[interface6_1.imethod_2()];
		this.int_0 = 0;
	}

	// Token: 0x06000555 RID: 1365 RVA: 0x000057AE File Offset: 0x000039AE
	public override string imethod_0()
	{
		return this.interface6_0.imethod_0();
	}

	// Token: 0x06000556 RID: 1366 RVA: 0x000057BB File Offset: 0x000039BB
	public override void imethod_1(bool bool_1, Interface1 interface1_0)
	{
		this.bool_0 = bool_1;
		this.imethod_15();
		this.interface6_0.imethod_1(bool_1, interface1_0);
	}

	// Token: 0x06000557 RID: 1367 RVA: 0x000057D7 File Offset: 0x000039D7
	public override int imethod_2()
	{
		return this.interface6_0.imethod_2();
	}

	// Token: 0x06000558 RID: 1368 RVA: 0x0002EAF4 File Offset: 0x0002CCF4
	public override int imethod_4(int int_1)
	{
		int num = int_1 + this.int_0;
		int num2 = num % this.byte_1.Length;
		return num - num2;
	}

	// Token: 0x06000559 RID: 1369 RVA: 0x000057E4 File Offset: 0x000039E4
	public override int imethod_3(int int_1)
	{
		return int_1 + this.int_0;
	}

	// Token: 0x0600055A RID: 1370 RVA: 0x0002EB18 File Offset: 0x0002CD18
	public override byte[] imethod_6(byte[] byte_2, int int_1, int int_2)
	{
		if (byte_2 == null)
		{
			throw new ArgumentNullException("\u0002");
		}
		if (int_2 < 1)
		{
			return null;
		}
		int num = this.imethod_4(int_2);
		byte[] array = (num > 0) ? new byte[num] : null;
		int num2 = this.imethod_8(byte_2, int_1, int_2, array, 0);
		if (num > 0 && num2 < num)
		{
			byte[] array2 = new byte[num2];
			Array.Copy(array, 0, array2, 0, num2);
			array = array2;
		}
		return array;
	}

	// Token: 0x0600055B RID: 1371 RVA: 0x0002EB78 File Offset: 0x0002CD78
	public override int imethod_8(byte[] byte_2, int int_1, int int_2, byte[] byte_3, int int_3)
	{
		if (int_2 < 1)
		{
			if (int_2 < 0)
			{
				throw new ArgumentException("Can't have a negative input length!");
			}
			return 0;
		}
		else
		{
			int num = this.imethod_2();
			int num2 = this.imethod_4(int_2);
			if (num2 > 0 && int_3 + num2 > byte_3.Length)
			{
				throw new Exception1("output buffer too short");
			}
			int num3 = 0;
			int num4 = this.byte_1.Length - this.int_0;
			if (int_2 > num4)
			{
				Array.Copy(byte_2, int_1, this.byte_1, this.int_0, num4);
				num3 += this.interface6_0.imethod_4(this.byte_1, 0, byte_3, int_3);
				this.int_0 = 0;
				int_2 -= num4;
				int_1 += num4;
				while (int_2 > this.byte_1.Length)
				{
					num3 += this.interface6_0.imethod_4(byte_2, int_1, byte_3, int_3 + num3);
					int_2 -= num;
					int_1 += num;
				}
			}
			Array.Copy(byte_2, int_1, this.byte_1, this.int_0, int_2);
			this.int_0 += int_2;
			if (this.int_0 == this.byte_1.Length)
			{
				num3 += this.interface6_0.imethod_4(this.byte_1, 0, byte_3, int_3 + num3);
				this.int_0 = 0;
			}
			return num3;
		}
	}

	// Token: 0x0600055C RID: 1372 RVA: 0x0002ECA0 File Offset: 0x0002CEA0
	public override byte[] imethod_9()
	{
		byte[] array = Class64.byte_0;
		int num = this.imethod_3(0);
		if (num > 0)
		{
			array = new byte[num];
			int num2 = this.imethod_12(array, 0);
			if (num2 < array.Length)
			{
				byte[] array2 = new byte[num2];
				Array.Copy(array, 0, array2, 0, num2);
				array = array2;
			}
		}
		else
		{
			this.imethod_15();
		}
		return array;
	}

	// Token: 0x0600055D RID: 1373 RVA: 0x0002ECF4 File Offset: 0x0002CEF4
	public override byte[] imethod_11(byte[] byte_2, int int_1, int int_2)
	{
		if (byte_2 == null)
		{
			throw new ArgumentNullException("\u0002");
		}
		int num = this.imethod_3(int_2);
		byte[] array = Class64.byte_0;
		if (num > 0)
		{
			array = new byte[num];
			int num2 = (int_2 > 0) ? this.imethod_8(byte_2, int_1, int_2, array, 0) : 0;
			num2 += this.imethod_12(array, num2);
			if (num2 < array.Length)
			{
				byte[] array2 = new byte[num2];
				Array.Copy(array, 0, array2, 0, num2);
				array = array2;
			}
		}
		else
		{
			this.imethod_15();
		}
		return array;
	}

	// Token: 0x0600055E RID: 1374 RVA: 0x0002ED68 File Offset: 0x0002CF68
	public override int imethod_12(byte[] byte_2, int int_1)
	{
		int result;
		try
		{
			if (this.int_0 != 0)
			{
				if (!this.interface6_0.imethod_3())
				{
					throw new Exception1("data not block size aligned");
				}
				if (int_1 + this.int_0 > byte_2.Length)
				{
					throw new Exception1("output buffer too short for DoFinal()");
				}
				this.interface6_0.imethod_4(this.byte_1, 0, this.byte_1, 0);
				Array.Copy(this.byte_1, 0, byte_2, int_1, this.int_0);
			}
			result = this.int_0;
		}
		finally
		{
			this.imethod_15();
		}
		return result;
	}

	// Token: 0x0600055F RID: 1375 RVA: 0x000057EE File Offset: 0x000039EE
	public override void imethod_15()
	{
		Array.Clear(this.byte_1, 0, this.byte_1.Length);
		this.int_0 = 0;
		this.interface6_0.imethod_5();
	}

	// Token: 0x0400029D RID: 669
	internal byte[] byte_1;

	// Token: 0x0400029E RID: 670
	internal int int_0;

	// Token: 0x0400029F RID: 671
	internal bool bool_0;

	// Token: 0x040002A0 RID: 672
	internal Interface6 interface6_0;
}
