using System;

// Token: 0x0200009F RID: 159
internal sealed class Class83
{
	// Token: 0x06000337 RID: 823 RVA: 0x00004913 File Offset: 0x00002B13
	public Class83(string string_1, Class12 class12_1, Class179 class179_1)
	{
		this.string_0 = string_1;
		this.class12_0 = class12_1;
		this.class179_0 = class179_1;
	}

	// Token: 0x06000338 RID: 824 RVA: 0x0001BA18 File Offset: 0x00019C18
	protected override void Finalize()
	{
		try
		{
			object object_ = this.class179_0.object_0;
			lock (object_)
			{
				if (!this.class179_0.bool_1)
				{
					this.class179_0.byte_0 = Class120.smethod_1(this.string_0);
					this.class179_0.bool_1 = true;
					Class120.smethod_3(this.string_0);
				}
			}
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x04000208 RID: 520
	public readonly string string_0;

	// Token: 0x04000209 RID: 521
	public readonly Class12 class12_0;

	// Token: 0x0400020A RID: 522
	public readonly Class179 class179_0;
}
