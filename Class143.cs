using System;

// Token: 0x02000016 RID: 22
internal sealed class Class143 : Class139
{
	// Token: 0x06000083 RID: 131 RVA: 0x000030B0 File Offset: 0x000012B0
	public string method_2()
	{
		return this.string_0;
	}

	// Token: 0x06000084 RID: 132 RVA: 0x000030B8 File Offset: 0x000012B8
	public void method_3(string string_1)
	{
		this.string_0 = string_1;
	}

	// Token: 0x06000085 RID: 133 RVA: 0x000030C1 File Offset: 0x000012C1
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x06000086 RID: 134 RVA: 0x000030C9 File Offset: 0x000012C9
	public override void vmethod_1(object object_0)
	{
		this.method_3((string)object_0);
	}

	// Token: 0x06000087 RID: 135 RVA: 0x000030D7 File Offset: 0x000012D7
	public override int vmethod_2()
	{
		return 5;
	}

	// Token: 0x06000088 RID: 136 RVA: 0x0000AAD4 File Offset: 0x00008CD4
	public override Class139 vmethod_3(Class139 class139_0)
	{
		base.method_1(class139_0.method_0());
		int num = class139_0.vmethod_2();
		if (num != 4)
		{
			if (num != 5)
			{
				throw new ArgumentOutOfRangeException();
			}
			this.method_3(((Class143)class139_0).method_2());
		}
		else
		{
			this.method_3((string)((Class166)class139_0).method_2());
		}
		return this;
	}

	// Token: 0x06000089 RID: 137 RVA: 0x000030DA File Offset: 0x000012DA
	public override Class139 vmethod_4()
	{
		Class143 @class = new Class143();
		@class.method_3(this.string_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x04000062 RID: 98
	private string string_0;
}
