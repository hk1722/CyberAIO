using System;

// Token: 0x020000C0 RID: 192
internal static class Class102
{
	// Token: 0x06000504 RID: 1284 RVA: 0x00005577 File Offset: 0x00003777
	public static Type smethod_0(Type type_0)
	{
		if (!type_0.IsByRef && !type_0.IsArray && !type_0.IsPointer)
		{
			return type_0;
		}
		return Class102.smethod_0(type_0.GetElementType());
	}

	// Token: 0x06000505 RID: 1285 RVA: 0x0000559E File Offset: 0x0000379E
	public static Type smethod_1(Type type_0)
	{
		if (type_0.HasElementType && !type_0.IsArray)
		{
			type_0 = type_0.GetElementType();
		}
		return type_0;
	}

	// Token: 0x06000506 RID: 1286 RVA: 0x00028AE4 File Offset: 0x00026CE4
	public static Class57<Struct45> smethod_2(Type type_0)
	{
		Class57<Struct45> @class = new Class57<Struct45>();
		Type type = type_0;
		for (;;)
		{
			if (type.IsArray)
			{
				@class.method_7(new Struct45
				{
					int_0 = 0,
					int_1 = type.GetArrayRank()
				});
			}
			else if (type.IsByRef)
			{
				@class.method_7(new Struct45
				{
					int_0 = 2
				});
			}
			else
			{
				if (!type.IsPointer)
				{
					break;
				}
				@class.method_7(new Struct45
				{
					int_0 = 1
				});
			}
			type = type.GetElementType();
		}
		return @class;
	}

	// Token: 0x06000507 RID: 1287 RVA: 0x00028B78 File Offset: 0x00026D78
	public static Class57<Struct45> smethod_3(string string_0)
	{
		string text = string_0;
		Class57<Struct45> @class = new Class57<Struct45>();
		for (;;)
		{
			if (text.EndsWith("&", StringComparison.Ordinal))
			{
				@class.method_7(new Struct45
				{
					int_0 = 2
				});
				text = text.Substring(0, text.Length - 1);
			}
			else if (text.EndsWith("*", StringComparison.Ordinal))
			{
				@class.method_7(new Struct45
				{
					int_0 = 1
				});
				text = text.Substring(0, text.Length - 1);
			}
			else if (text.EndsWith("[]", StringComparison.Ordinal))
			{
				@class.method_7(new Struct45
				{
					int_0 = 0,
					int_1 = 1
				});
				text = text.Substring(0, text.Length - 2);
			}
			else
			{
				if (!text.EndsWith(",]", StringComparison.Ordinal))
				{
					return @class;
				}
				int num = 1;
				int num2 = -1;
				for (int i = text.Length - 2; i >= 0; i--)
				{
					char c = text[i];
					if (c != ',')
					{
						if (c != '[')
						{
							goto Block_5;
						}
						num2 = i;
						i = -1;
					}
					else
					{
						num++;
					}
				}
				if (num2 < 0)
				{
					goto IL_145;
				}
				text = text.Substring(0, num2);
				@class.method_7(new Struct45
				{
					int_0 = 0,
					int_1 = num
				});
			}
		}
		Block_5:
		throw new InvalidOperationException("VM-3012");
		IL_145:
		throw new InvalidOperationException("VM-3014");
	}

	// Token: 0x06000508 RID: 1288 RVA: 0x00028CE4 File Offset: 0x00026EE4
	public static Type smethod_4(Type type_0, Class57<Struct45> class57_0)
	{
		Type type = type_0;
		while (class57_0.Count > 0)
		{
			Struct45 @struct = class57_0.method_6();
			switch (@struct.int_0)
			{
			case 0:
				if (@struct.int_1 == 1)
				{
					type = type.MakeArrayType();
				}
				else
				{
					type = type.MakeArrayType(@struct.int_1);
				}
				break;
			case 1:
				type = type.MakePointerType();
				break;
			case 2:
				type = type.MakeByRefType();
				break;
			}
		}
		return type;
	}
}
