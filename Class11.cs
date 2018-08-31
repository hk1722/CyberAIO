using System;

// Token: 0x02000019 RID: 25
internal sealed class Class11
{
	// Token: 0x0600009B RID: 155 RVA: 0x000031E6 File Offset: 0x000013E6
	public Class11(int int_2, int int_3)
	{
		this.method_1(int_2);
		this.int_1 = int_3;
	}

	// Token: 0x0600009C RID: 156 RVA: 0x000031FC File Offset: 0x000013FC
	public int method_0()
	{
		return this.int_0;
	}

	// Token: 0x0600009D RID: 157 RVA: 0x00003204 File Offset: 0x00001404
	public void method_1(int int_2)
	{
		this.int_0 = int_2;
	}

	// Token: 0x0600009E RID: 158 RVA: 0x0000320D File Offset: 0x0000140D
	public int method_2()
	{
		return this.int_1;
	}

	// Token: 0x0600009F RID: 159 RVA: 0x0000ACF4 File Offset: 0x00008EF4
	public override bool Equals(object obj)
	{
		Class11 class11_ = obj as Class11;
		return !(class11_ == null) && this.method_3(class11_);
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x00003215 File Offset: 0x00001415
	public bool method_3(Class11 class11_0)
	{
		return class11_0.method_0() == this.method_0();
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x00003225 File Offset: 0x00001425
	public static bool operator ==(Class11 class11_0, Class11 class11_1)
	{
		return class11_0.method_3(class11_1);
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x0000322E File Offset: 0x0000142E
	public static bool operator !=(Class11 class11_0, Class11 class11_1)
	{
		return !(class11_0 == class11_1);
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x0000AD1C File Offset: 0x00008F1C
	public override int GetHashCode()
	{
		return this.method_0().GetHashCode();
	}

	// Token: 0x060000A4 RID: 164 RVA: 0x0000AD38 File Offset: 0x00008F38
	public override string ToString()
	{
		return this.method_0().ToString();
	}

	// Token: 0x04000069 RID: 105
	private int int_0;

	// Token: 0x0400006A RID: 106
	private readonly int int_1;
}
