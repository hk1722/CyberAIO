using System;
using System.Runtime.CompilerServices;

// Token: 0x020000C1 RID: 193
internal struct Struct42
{
	// Token: 0x06000509 RID: 1289 RVA: 0x000055BB File Offset: 0x000037BB
	public Struct42(string string_0)
	{
		this.class58_0 = new Class58
		{
			class12_0 = Class120.smethod_0(string_0)
		};
	}

	// Token: 0x0600050B RID: 1291 RVA: 0x00028D54 File Offset: 0x00026F54
	private bool method_0(out string string_0)
	{
		string_0 = null;
		Class58 @class = this.class58_0;
		Class12 class2 = (@class != null) ? @class.class12_0 : null;
		if (class2 == null)
		{
			return true;
		}
		WeakReference weakReference_ = class2.weakReference_0;
		string_0 = (((weakReference_ != null) ? weakReference_.Target : null) as string);
		return string_0 != null;
	}

	// Token: 0x0600050C RID: 1292 RVA: 0x00028D9C File Offset: 0x00026F9C
	public string method_1()
	{
		string text;
		if (this.method_0(out text))
		{
			return text;
		}
		object obj = Struct42.object_0;
		lock (obj)
		{
			if (this.method_0(out text))
			{
				return text;
			}
			Class179 class179_ = this.class58_0.class12_0.class179_0;
			object obj2 = class179_.object_0;
			byte[] byte_;
			bool bool_;
			lock (obj2)
			{
				byte_ = class179_.byte_0;
				bool_ = class179_.bool_0;
				if (class179_.bool_1)
				{
					if (byte_ == null)
					{
						throw new Exception("Unable to decrypt string data: encrypted value is null");
					}
				}
				else
				{
					WeakReference weakReference_ = this.class58_0.class12_0.weakReference_1;
					string text2 = ((weakReference_ != null) ? weakReference_.Target : null) as string;
					if (text2 == null)
					{
						throw new Exception("Unable to obtain original string data");
					}
					text = string.Copy(text2);
					Class120.smethod_3(text2);
				}
				class179_.bool_1 = true;
			}
			if (text == null)
			{
				text = Class120.smethod_2(byte_, bool_);
			}
			this.method_2(text);
		}
		return text;
	}

	// Token: 0x0600050D RID: 1293 RVA: 0x00028EB4 File Offset: 0x000270B4
	private void method_2(string string_0)
	{
		Class83 @class;
		if (!Struct42.conditionalWeakTable_0.TryGetValue(string_0, out @class))
		{
			Class12 class2 = new Class12
			{
				class179_0 = new Class179(),
				weakReference_0 = new WeakReference(string_0),
				weakReference_1 = new WeakReference(string_0, true)
			};
			@class = new Class83(string_0, class2, class2.class179_0);
			Struct42.conditionalWeakTable_0.Add(string_0, @class);
		}
		this.class58_0.class12_0 = @class.class12_0;
	}

	// Token: 0x0600050E RID: 1294 RVA: 0x00028F28 File Offset: 0x00027128
	public void method_3(string string_0)
	{
		object obj = Struct42.object_0;
		lock (obj)
		{
			if (string_0 == null)
			{
				this.class58_0 = null;
			}
			else
			{
				this.class58_0 = new Class58();
				this.method_2(string_0);
			}
		}
	}

	// Token: 0x0600050F RID: 1295 RVA: 0x000055EA File Offset: 0x000037EA
	public void method_4()
	{
		this.method_3(null);
	}

	// Token: 0x04000266 RID: 614
	private static readonly ConditionalWeakTable<string, Class83> conditionalWeakTable_0 = new ConditionalWeakTable<string, Class83>();

	// Token: 0x04000267 RID: 615
	private static readonly object object_0 = new object();

	// Token: 0x04000268 RID: 616
	private Class58 class58_0;
}
