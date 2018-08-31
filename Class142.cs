using System;
using System.Reflection;

// Token: 0x0200000C RID: 12
internal sealed class Class142 : Class139
{
	// Token: 0x06000039 RID: 57 RVA: 0x00002E2D File Offset: 0x0000102D
	public MethodBase method_2()
	{
		return this.methodBase_0;
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00002E35 File Offset: 0x00001035
	public void method_3(MethodBase methodBase_1)
	{
		this.methodBase_0 = methodBase_1;
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00008854 File Offset: 0x00006A54
	public IntPtr method_4()
	{
		return this.method_2().MethodHandle.GetFunctionPointer();
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00002E3E File Offset: 0x0000103E
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00002E46 File Offset: 0x00001046
	public override void vmethod_1(object object_0)
	{
		this.method_3((MethodBase)object_0);
	}

	// Token: 0x0600003E RID: 62 RVA: 0x00002E54 File Offset: 0x00001054
	public override int vmethod_2()
	{
		return 23;
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00008874 File Offset: 0x00006A74
	public override Class139 vmethod_3(Class139 class139_0)
	{
		base.method_1(class139_0.method_0());
		int num = class139_0.vmethod_2();
		if (num == 23)
		{
			this.method_3(((Class142)class139_0).method_2());
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x06000040 RID: 64 RVA: 0x00002E58 File Offset: 0x00001058
	public override Class139 vmethod_4()
	{
		Class142 @class = new Class142();
		@class.method_3(this.methodBase_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x04000033 RID: 51
	private MethodBase methodBase_0;
}
