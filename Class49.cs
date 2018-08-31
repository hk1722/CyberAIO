using System;

// Token: 0x020000FE RID: 254
internal sealed class Class49 : Class47
{
	// Token: 0x0600067C RID: 1660 RVA: 0x000062CC File Offset: 0x000044CC
	public Class49(Interface3 interface3_1)
	{
		this.interface3_0 = interface3_1;
	}

	// Token: 0x0600067D RID: 1661 RVA: 0x000062DB File Offset: 0x000044DB
	public override void Dispose()
	{
		this.interface3_0.imethod_15();
	}

	// Token: 0x0600067E RID: 1662 RVA: 0x00002BE6 File Offset: 0x00000DE6
	public override bool vmethod_0()
	{
		return true;
	}

	// Token: 0x0600067F RID: 1663 RVA: 0x000062E8 File Offset: 0x000044E8
	public override int vmethod_1()
	{
		return this.interface3_0.imethod_2();
	}

	// Token: 0x06000680 RID: 1664 RVA: 0x000062F5 File Offset: 0x000044F5
	public override int vmethod_2(byte[] byte_0, int int_0, int int_1, byte[] byte_1, int int_2)
	{
		return this.interface3_0.imethod_8(byte_0, int_0, int_1, byte_1, int_2);
	}

	// Token: 0x06000681 RID: 1665 RVA: 0x00006309 File Offset: 0x00004509
	public override byte[] vmethod_3(byte[] byte_0, int int_0, int int_1)
	{
		return this.interface3_0.imethod_11(byte_0, int_0, int_1);
	}

	// Token: 0x04000356 RID: 854
	private readonly Interface3 interface3_0;
}
