using System;
using System.Reflection;
using System.Security.Cryptography;

// Token: 0x020000F4 RID: 244
internal sealed class Class136 : IDisposable
{
	// Token: 0x06000644 RID: 1604 RVA: 0x00006128 File Offset: 0x00004328
	public Class136()
	{
		this.method_1((Enum0)1);
	}

	// Token: 0x06000645 RID: 1605 RVA: 0x00035D38 File Offset: 0x00033F38
	public void Dispose()
	{
		IDisposable disposable = this.symmetricAlgorithm_0;
		if (disposable != null)
		{
			disposable.Dispose();
		}
	}

	// Token: 0x06000646 RID: 1606 RVA: 0x00006137 File Offset: 0x00004337
	public Enum0 method_0()
	{
		return this.enum0_0;
	}

	// Token: 0x06000647 RID: 1607 RVA: 0x0000613F File Offset: 0x0000433F
	public void method_1(Enum0 enum0_1)
	{
		if (this.enum0_0 == enum0_1)
		{
			return;
		}
		this.enum0_0 = enum0_1;
		this.bool_1 = true;
	}

	// Token: 0x06000648 RID: 1608 RVA: 0x00006159 File Offset: 0x00004359
	public Enum1 method_2()
	{
		return this.enum1_0;
	}

	// Token: 0x06000649 RID: 1609 RVA: 0x00006161 File Offset: 0x00004361
	public void method_3(Enum1 enum1_1)
	{
		if (this.enum1_0 == enum1_1)
		{
			return;
		}
		this.enum1_0 = enum1_1;
		this.bool_1 = true;
	}

	// Token: 0x0600064A RID: 1610 RVA: 0x0000617B File Offset: 0x0000437B
	public byte[] method_4()
	{
		return this.byte_0;
	}

	// Token: 0x0600064B RID: 1611 RVA: 0x00006183 File Offset: 0x00004383
	public void method_5(byte[] byte_2)
	{
		this.byte_0 = byte_2;
		this.bool_1 = true;
	}

	// Token: 0x0600064C RID: 1612 RVA: 0x00006193 File Offset: 0x00004393
	public byte[] method_6()
	{
		return this.byte_1;
	}

	// Token: 0x0600064D RID: 1613 RVA: 0x0000619B File Offset: 0x0000439B
	public void method_7(byte[] byte_2)
	{
		this.byte_1 = byte_2;
		this.bool_1 = true;
	}

	// Token: 0x0600064E RID: 1614 RVA: 0x00035D58 File Offset: 0x00033F58
	private static SymmetricAlgorithm smethod_0()
	{
		if (Class136.type_0 != null)
		{
			if (Class136.type_0 == typeof(Class136.Class137))
			{
				return null;
			}
			return Activator.CreateInstance(Class136.type_0) as SymmetricAlgorithm;
		}
		else
		{
			Class136.type_0 = typeof(Class136.Class137);
			Assembly assembly = null;
			try
			{
				assembly = Assembly.Load("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
			}
			catch
			{
			}
			if (assembly == null)
			{
				return null;
			}
			try
			{
				Type type = assembly.GetType("System.Security.Cryptography.AesCryptoServiceProvider");
				if (type != null)
				{
					SymmetricAlgorithm result = Activator.CreateInstance(type) as SymmetricAlgorithm;
					Class136.type_0 = type;
					return result;
				}
			}
			catch
			{
			}
			try
			{
				Type type2 = assembly.GetType("System.Security.Cryptography.AesManaged");
				if (type2 != null)
				{
					SymmetricAlgorithm result2 = Activator.CreateInstance(type2) as SymmetricAlgorithm;
					Class136.type_0 = type2;
					return result2;
				}
			}
			catch
			{
			}
			return null;
		}
	}

	// Token: 0x0600064F RID: 1615 RVA: 0x000061AB File Offset: 0x000043AB
	private static CipherMode smethod_1(Enum0 enum0_1)
	{
		if (enum0_1 == (Enum0)1)
		{
			return CipherMode.CBC;
		}
		throw new InvalidOperationException("Cipher mode is not supported");
	}

	// Token: 0x06000650 RID: 1616 RVA: 0x000061BF File Offset: 0x000043BF
	private static PaddingMode smethod_2(Enum1 enum1_1)
	{
		if (enum1_1 == (Enum1)1)
		{
			return PaddingMode.None;
		}
		if (enum1_1 != (Enum1)2)
		{
			throw new InvalidOperationException("Padding mode is not supported");
		}
		return PaddingMode.PKCS7;
	}

	// Token: 0x06000651 RID: 1617 RVA: 0x000061D7 File Offset: 0x000043D7
	public Class47 method_8()
	{
		return this.method_10(true);
	}

	// Token: 0x06000652 RID: 1618 RVA: 0x000061E0 File Offset: 0x000043E0
	public Class47 method_9()
	{
		return this.method_10(false);
	}

	// Token: 0x06000653 RID: 1619 RVA: 0x00035E5C File Offset: 0x0003405C
	private Class47 method_10(bool bool_2)
	{
		if (!this.bool_0)
		{
			bool flag = this.bool_1 || this.symmetricAlgorithm_0 == null;
			if (this.symmetricAlgorithm_0 == null)
			{
				this.symmetricAlgorithm_0 = Class136.smethod_0();
				if (this.symmetricAlgorithm_0 == null)
				{
					this.bool_0 = true;
				}
			}
			if (this.symmetricAlgorithm_0 != null)
			{
				if (flag)
				{
					this.symmetricAlgorithm_0.Key = this.method_4();
					this.symmetricAlgorithm_0.IV = this.method_6();
					this.symmetricAlgorithm_0.Mode = Class136.smethod_1(this.method_0());
					this.symmetricAlgorithm_0.Padding = Class136.smethod_2(this.method_2());
				}
				return new Class48(bool_2 ? this.symmetricAlgorithm_0.CreateEncryptor() : this.symmetricAlgorithm_0.CreateDecryptor());
			}
		}
		Class92 interface6_ = new Class92(new Class135());
		Class65 @class;
		if (this.method_2() != (Enum1)1)
		{
			@class = new Class66(interface6_, Class136.smethod_3(this.method_2()));
		}
		else
		{
			@class = new Class65(interface6_);
		}
		Class95 interface1_ = new Class95(new Class19(this.method_4()), this.method_6());
		@class.imethod_1(bool_2, interface1_);
		return new Class49(@class);
	}

	// Token: 0x06000654 RID: 1620 RVA: 0x000061E9 File Offset: 0x000043E9
	private static Interface8 smethod_3(Enum1 enum1_1)
	{
		if (enum1_1 == (Enum1)1)
		{
			return null;
		}
		if (enum1_1 != (Enum1)2)
		{
			throw new InvalidOperationException("Padding mode is not supported");
		}
		return new Class181();
	}

	// Token: 0x04000341 RID: 833
	private Enum0 enum0_0;

	// Token: 0x04000342 RID: 834
	private Enum1 enum1_0;

	// Token: 0x04000343 RID: 835
	private byte[] byte_0;

	// Token: 0x04000344 RID: 836
	private byte[] byte_1;

	// Token: 0x04000345 RID: 837
	private static Type type_0;

	// Token: 0x04000346 RID: 838
	private bool bool_0;

	// Token: 0x04000347 RID: 839
	private bool bool_1;

	// Token: 0x04000348 RID: 840
	private SymmetricAlgorithm symmetricAlgorithm_0;

	// Token: 0x020000F5 RID: 245
	private sealed class Class137
	{
	}
}
