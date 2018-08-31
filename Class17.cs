using System;
using System.Reflection;
using System.Security;

// Token: 0x02000020 RID: 32
internal static class Class17
{
	// Token: 0x060000E0 RID: 224 RVA: 0x0000CD54 File Offset: 0x0000AF54
	private static bool smethod_0()
	{
		bool result;
		try
		{
			if (Environment.Version.Major < 4)
			{
				result = false;
			}
			else
			{
				Assembly assembly = typeof(Class87).Assembly;
				Assembly assembly2 = typeof(SecurityCriticalAttribute).Assembly;
				bool flag = false;
				foreach (object obj in assembly.GetCustomAttributes(false))
				{
					if (obj is AllowPartiallyTrustedCallersAttribute)
					{
						flag = true;
					}
					else
					{
						Type type = obj.GetType();
						if (type.Assembly == assembly2 && "System.Security.SecurityRulesAttribute".Equals(type.FullName, StringComparison.Ordinal) && (byte)type.GetProperty("RuleSet").GetValue(obj, null) != 2)
						{
							return false;
						}
					}
				}
				result = flag;
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x00003459 File Offset: 0x00001659
	public static bool smethod_1()
	{
		return Class17.bool_0;
	}

	// Token: 0x0400008A RID: 138
	private static readonly bool bool_0 = Class17.smethod_0();
}
