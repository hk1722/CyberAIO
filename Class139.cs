using System;

// Token: 0x020000FA RID: 250
internal abstract class Class139
{
	// Token: 0x06000660 RID: 1632
	public abstract object vmethod_0();

	// Token: 0x06000661 RID: 1633
	public abstract void vmethod_1(object object_0);

	// Token: 0x06000662 RID: 1634
	public abstract int vmethod_2();

	// Token: 0x06000663 RID: 1635
	public abstract Class139 vmethod_3(Class139 class139_0);

	// Token: 0x06000664 RID: 1636
	public abstract Class139 vmethod_4();

	// Token: 0x06000665 RID: 1637 RVA: 0x00006239 File Offset: 0x00004439
	public Type method_0()
	{
		return this.type_0;
	}

	// Token: 0x06000666 RID: 1638 RVA: 0x00006241 File Offset: 0x00004441
	public void method_1(Type type_1)
	{
		this.type_0 = type_1;
	}

	// Token: 0x04000353 RID: 851
	private Type type_0;
}
