using System;
using System.Runtime.InteropServices;

// Token: 0x020000AF RID: 175
internal sealed class Class93
{
	// Token: 0x060004BF RID: 1215 RVA: 0x000277A0 File Offset: 0x000259A0
	internal static uint smethod_0(string string_0)
	{
		uint num;
		if (string_0 != null)
		{
			num = 2166136261u;
			for (int i = 0; i < string_0.Length; i++)
			{
				num = ((uint)string_0[i] ^ num) * 16777619u;
			}
		}
		return num;
	}

	// Token: 0x0400024A RID: 586 RVA: 0x00002B88 File Offset: 0x00000D88
	internal static readonly Class93.Struct40 struct40_0;

	// Token: 0x020000B0 RID: 176
	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 16)]
	private struct Struct40
	{
	}
}
