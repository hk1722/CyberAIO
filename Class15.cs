using System;
using System.IO;

// Token: 0x0200001E RID: 30
internal static class Class15
{
	// Token: 0x060000D7 RID: 215 RVA: 0x000033FB File Offset: 0x000015FB
	public static void smethod_0(int int_0, byte[] byte_0, int int_1)
	{
		byte_0[int_1] = (byte)int_0;
		byte_0[int_1 + 1] = (byte)(int_0 >> 8);
		byte_0[int_1 + 2] = (byte)(int_0 >> 16);
		byte_0[int_1 + 3] = (byte)(int_0 >> 24);
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x0000CBBC File Offset: 0x0000ADBC
	public static void smethod_1(long long_0, byte[] byte_0, int int_0)
	{
		byte_0[int_0] = (byte)long_0;
		byte_0[int_0 + 1] = (byte)(long_0 >> 8);
		byte_0[int_0 + 2] = (byte)(long_0 >> 16);
		byte_0[int_0 + 3] = (byte)(long_0 >> 24);
		byte_0[int_0 + 4] = (byte)(long_0 >> 32);
		byte_0[int_0 + 5] = (byte)(long_0 >> 40);
		byte_0[int_0 + 6] = (byte)(long_0 >> 48);
		byte_0[int_0 + 7] = (byte)(long_0 >> 56);
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x0000CC14 File Offset: 0x0000AE14
	public static byte[] smethod_2(int int_0)
	{
		if (BitConverter.IsLittleEndian)
		{
			return BitConverter.GetBytes(int_0);
		}
		byte[] array = new byte[4];
		Class15.smethod_0(int_0, array, 0);
		return array;
	}

	// Token: 0x060000DA RID: 218 RVA: 0x0000CC40 File Offset: 0x0000AE40
	public static byte[] smethod_3(long long_0)
	{
		if (BitConverter.IsLittleEndian)
		{
			return BitConverter.GetBytes(long_0);
		}
		byte[] array = new byte[8];
		Class15.smethod_1(long_0, array, 0);
		return array;
	}

	// Token: 0x060000DB RID: 219 RVA: 0x0000341F File Offset: 0x0000161F
	public static int smethod_4(byte[] byte_0, int int_0)
	{
		if (BitConverter.IsLittleEndian)
		{
			return BitConverter.ToInt32(byte_0, int_0);
		}
		return (int)byte_0[int_0] | (int)byte_0[int_0 + 1] << 8 | (int)byte_0[int_0 + 2] << 16 | (int)byte_0[int_0 + 3] << 24;
	}

	// Token: 0x060000DC RID: 220 RVA: 0x0000CC6C File Offset: 0x0000AE6C
	public static long smethod_5(byte[] byte_0, int int_0)
	{
		if (BitConverter.IsLittleEndian)
		{
			return BitConverter.ToInt64(byte_0, int_0);
		}
		return (long)((ulong)byte_0[int_0] | (ulong)byte_0[int_0 + 1] << 8 | (ulong)byte_0[int_0 + 2] << 16 | (ulong)byte_0[int_0 + 3] << 24 | (ulong)byte_0[int_0 + 4] << 32 | (ulong)byte_0[int_0 + 5] << 40 | (ulong)byte_0[int_0 + 6] << 48 | (ulong)byte_0[int_0 + 7] << 56);
	}

	// Token: 0x060000DD RID: 221 RVA: 0x0000CCD4 File Offset: 0x0000AED4
	public static float smethod_6(byte[] byte_0, int int_0)
	{
		if (BitConverter.IsLittleEndian && Struct2.bool_0)
		{
			return BitConverter.ToSingle(byte_0, int_0);
		}
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(byte_0, int_0, 4, false));
		float result = binaryReader.ReadSingle();
		binaryReader.Close();
		return result;
	}

	// Token: 0x060000DE RID: 222 RVA: 0x0000CD14 File Offset: 0x0000AF14
	public static double smethod_7(byte[] byte_0, int int_0)
	{
		if (BitConverter.IsLittleEndian && Struct57.bool_0)
		{
			return BitConverter.ToDouble(byte_0, int_0);
		}
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(byte_0, int_0, 8, false));
		double result = binaryReader.ReadDouble();
		binaryReader.Close();
		return result;
	}
}
