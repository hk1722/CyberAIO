using System;

// Token: 0x02000003 RID: 3
internal sealed class Class140 : Class139
{
	// Token: 0x06000004 RID: 4 RVA: 0x00002BA0 File Offset: 0x00000DA0
	public Array method_2()
	{
		return this.array_0;
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002BA8 File Offset: 0x00000DA8
	public void method_3(Array array_1)
	{
		this.array_0 = array_1;
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002BB1 File Offset: 0x00000DB1
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002BB9 File Offset: 0x00000DB9
	public override void vmethod_1(object object_0)
	{
		this.method_3((Array)object_0);
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002BC7 File Offset: 0x00000DC7
	public override Class139 vmethod_4()
	{
		Class140 @class = new Class140();
		@class.method_3(this.array_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002BE6 File Offset: 0x00000DE6
	public override int vmethod_2()
	{
		return 1;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00006CBC File Offset: 0x00004EBC
	public override Class139 vmethod_3(Class139 class139_0)
	{
		base.method_1(class139_0.method_0());
		int num = class139_0.vmethod_2();
		if (num != 1)
		{
			if (num != 4)
			{
				throw new ArgumentOutOfRangeException();
			}
			this.method_3((Array)((Class166)class139_0).method_2());
		}
		else
		{
			this.method_3(((Class140)class139_0).method_2());
		}
		return this;
	}

	// Token: 0x04000001 RID: 1
	private Array array_0;
}
