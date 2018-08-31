using System;

// Token: 0x020000B4 RID: 180
internal sealed class Class95 : Interface1
{
	// Token: 0x060004CB RID: 1227 RVA: 0x000052E4 File Offset: 0x000034E4
	public Class95(Interface1 interface1_1, byte[] byte_1) : this(interface1_1, byte_1, 0, byte_1.Length)
	{
	}

	// Token: 0x060004CC RID: 1228 RVA: 0x00027A14 File Offset: 0x00025C14
	public Class95(Interface1 interface1_1, byte[] byte_1, int int_0, int int_1)
	{
		if (interface1_1 == null)
		{
			throw new ArgumentNullException("parameters");
		}
		if (byte_1 == null)
		{
			throw new ArgumentNullException("iv");
		}
		this.interface1_0 = interface1_1;
		this.byte_0 = new byte[int_1];
		Array.Copy(byte_1, int_0, this.byte_0, 0, int_1);
	}

	// Token: 0x060004CD RID: 1229 RVA: 0x000052F2 File Offset: 0x000034F2
	public byte[] method_0()
	{
		return (byte[])this.byte_0.Clone();
	}

	// Token: 0x060004CE RID: 1230 RVA: 0x00005304 File Offset: 0x00003504
	public Interface1 method_1()
	{
		return this.interface1_0;
	}

	// Token: 0x0400024F RID: 591
	private readonly Interface1 interface1_0;

	// Token: 0x04000250 RID: 592
	private readonly byte[] byte_0;
}
