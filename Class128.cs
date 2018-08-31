using System;

// Token: 0x020000F1 RID: 241
internal sealed class Class128 : Class123
{
	// Token: 0x06000623 RID: 1571 RVA: 0x00005FED File Offset: 0x000041ED
	public byte method_0()
	{
		return this.byte_0;
	}

	// Token: 0x06000624 RID: 1572 RVA: 0x00005FF5 File Offset: 0x000041F5
	public void method_1(byte byte_1)
	{
		this.byte_0 = byte_1;
	}

	// Token: 0x06000625 RID: 1573 RVA: 0x00005FFE File Offset: 0x000041FE
	public bool method_2()
	{
		return (this.method_0() & 2) > 0;
	}

	// Token: 0x06000626 RID: 1574 RVA: 0x0000600B File Offset: 0x0000420B
	public bool method_3()
	{
		return (this.method_0() & 1) > 0;
	}

	// Token: 0x06000627 RID: 1575 RVA: 0x00006018 File Offset: 0x00004218
	public Class45 method_4()
	{
		return this.class45_0;
	}

	// Token: 0x06000628 RID: 1576 RVA: 0x00006020 File Offset: 0x00004220
	public void method_5(Class45 class45_4)
	{
		this.class45_0 = class45_4;
	}

	// Token: 0x06000629 RID: 1577 RVA: 0x00006029 File Offset: 0x00004229
	public string method_6()
	{
		return this.string_0;
	}

	// Token: 0x0600062A RID: 1578 RVA: 0x00006031 File Offset: 0x00004231
	public void method_7(string string_1)
	{
		this.string_0 = string_1;
	}

	// Token: 0x0600062B RID: 1579 RVA: 0x0000603A File Offset: 0x0000423A
	public Class45[] method_8()
	{
		return this.class45_1;
	}

	// Token: 0x0600062C RID: 1580 RVA: 0x00006042 File Offset: 0x00004242
	public void method_9(Class45[] class45_4)
	{
		this.class45_1 = class45_4;
	}

	// Token: 0x0600062D RID: 1581 RVA: 0x0000604B File Offset: 0x0000424B
	public Class45[] method_10()
	{
		return this.class45_2;
	}

	// Token: 0x0600062E RID: 1582 RVA: 0x00006053 File Offset: 0x00004253
	public void method_11(Class45[] class45_4)
	{
		this.class45_2 = class45_4;
	}

	// Token: 0x0600062F RID: 1583 RVA: 0x0000605C File Offset: 0x0000425C
	public Class45 method_12()
	{
		return this.class45_3;
	}

	// Token: 0x06000630 RID: 1584 RVA: 0x00006064 File Offset: 0x00004264
	public void method_13(Class45 class45_4)
	{
		this.class45_3 = class45_4;
	}

	// Token: 0x06000631 RID: 1585 RVA: 0x0000606D File Offset: 0x0000426D
	public override byte vmethod_0()
	{
		return 4;
	}

	// Token: 0x0400032F RID: 815
	private byte byte_0;

	// Token: 0x04000330 RID: 816
	private Class45 class45_0;

	// Token: 0x04000331 RID: 817
	private string string_0;

	// Token: 0x04000332 RID: 818
	private Class45[] class45_1;

	// Token: 0x04000333 RID: 819
	private Class45[] class45_2;

	// Token: 0x04000334 RID: 820
	private Class45 class45_3;
}
