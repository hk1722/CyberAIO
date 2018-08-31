using System;

// Token: 0x02000009 RID: 9
internal sealed class Class141 : Class139
{
	// Token: 0x0600002C RID: 44 RVA: 0x00002D8E File Offset: 0x00000F8E
	public short method_2()
	{
		return this.short_0;
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00002D96 File Offset: 0x00000F96
	public void method_3(short short_1)
	{
		this.short_0 = short_1;
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00002D9F File Offset: 0x00000F9F
	public override object vmethod_0()
	{
		return this.method_2();
	}

	// Token: 0x0600002F RID: 47 RVA: 0x000082B0 File Offset: 0x000064B0
	public override void vmethod_1(object object_0)
	{
		if (object_0 is int)
		{
			this.method_3((short)((int)object_0));
			return;
		}
		if (object_0 is long)
		{
			this.method_3((short)((long)object_0));
			return;
		}
		if (object_0 is ushort)
		{
			this.method_3((short)((ushort)object_0));
			return;
		}
		if (object_0 is uint)
		{
			this.method_3((short)((uint)object_0));
			return;
		}
		if (object_0 is ulong)
		{
			this.method_3((short)((ulong)object_0));
			return;
		}
		if (object_0 is float)
		{
			this.method_3((short)((float)object_0));
			return;
		}
		if (object_0 is double)
		{
			this.method_3((short)((double)object_0));
			return;
		}
		this.method_3(Convert.ToInt16(object_0));
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00002DAC File Offset: 0x00000FAC
	public override Class139 vmethod_4()
	{
		Class141 @class = new Class141();
		@class.method_3(this.short_0);
		@class.method_1(base.method_0());
		return @class;
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00002DCB File Offset: 0x00000FCB
	public override int vmethod_2()
	{
		return 15;
	}

	// Token: 0x06000032 RID: 50 RVA: 0x00008364 File Offset: 0x00006564
	public override Class139 vmethod_3(Class139 class139_0)
	{
		base.method_1(class139_0.method_0());
		switch (class139_0.vmethod_2())
		{
		case 0:
			this.method_3((short)((Class159)class139_0).method_2());
			return this;
		case 2:
			this.method_3((short)Convert.ToByte(((Class144)class139_0).method_2()));
			return this;
		case 4:
			this.method_3(Convert.ToInt16(((Class166)class139_0).method_2()));
			return this;
		case 7:
			this.method_3((short)((Class145)class139_0).method_2());
			return this;
		case 9:
			this.method_3((short)((Class161)class139_0).method_2());
			return this;
		case 10:
			this.method_3((short)((Class162)class139_0).method_2());
			return this;
		case 11:
			this.method_3((short)((Class156)class139_0).method_2());
			return this;
		case 14:
			this.method_3((short)((int)((Class146)class139_0).method_2()));
			return this;
		case 15:
			this.method_3(((Class141)class139_0).method_2());
			return this;
		case 17:
			this.method_3((short)((Class158)class139_0).method_2());
			return this;
		case 19:
			this.method_3((short)((Class165)class139_0).method_2());
			return this;
		case 21:
			this.method_3((short)((Class163)class139_0).method_2());
			return this;
		case 22:
			this.method_3((short)((Class164)class139_0).method_2());
			return this;
		case 24:
			this.method_3(Convert.ToInt16(((Class160)class139_0).method_2()));
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x04000025 RID: 37
	private short short_0;
}
