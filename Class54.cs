using System;
using System.IO;

// Token: 0x02000090 RID: 144
internal sealed class Class54 : Class52
{
	// Token: 0x060002FB RID: 763 RVA: 0x0000476E File Offset: 0x0000296E
	public Class54(Stream stream_1, int int_1)
	{
		this.stream_0 = stream_1;
		this.int_0 = int_1;
	}

	// Token: 0x060002FC RID: 764 RVA: 0x00004784 File Offset: 0x00002984
	public Stream method_0()
	{
		return this.stream_0;
	}

	// Token: 0x060002FD RID: 765 RVA: 0x0000478C File Offset: 0x0000298C
	public override bool vmethod_0()
	{
		return this.method_0().CanRead;
	}

	// Token: 0x060002FE RID: 766 RVA: 0x00004799 File Offset: 0x00002999
	public override bool vmethod_2()
	{
		return this.method_0().CanSeek;
	}

	// Token: 0x060002FF RID: 767 RVA: 0x000047A6 File Offset: 0x000029A6
	public override bool vmethod_1()
	{
		return this.method_0().CanWrite;
	}

	// Token: 0x06000300 RID: 768 RVA: 0x000047B3 File Offset: 0x000029B3
	public override void vmethod_8()
	{
		this.method_0().Flush();
	}

	// Token: 0x06000301 RID: 769 RVA: 0x000047C0 File Offset: 0x000029C0
	public override long vmethod_3()
	{
		return this.method_0().Length;
	}

	// Token: 0x06000302 RID: 770 RVA: 0x000047CD File Offset: 0x000029CD
	public override long vmethod_4()
	{
		return this.method_0().Position;
	}

	// Token: 0x06000303 RID: 771 RVA: 0x000047DA File Offset: 0x000029DA
	public override void vmethod_5(long long_0)
	{
		this.method_0().Position = long_0;
	}

	// Token: 0x06000304 RID: 772 RVA: 0x0001889C File Offset: 0x00016A9C
	private byte method_1(byte byte_0, long long_0)
	{
		byte b = (byte)(this.int_0 ^ -559030707 ^ (int)((uint)long_0));
		return byte_0 ^ b;
	}

	// Token: 0x06000305 RID: 773 RVA: 0x000188C0 File Offset: 0x00016AC0
	public override void vmethod_13(byte[] byte_0, int int_1, int int_2)
	{
		long num = this.vmethod_4();
		byte[] array = new byte[int_2];
		for (int i = 0; i < int_2; i++)
		{
			array[i] = this.method_1(byte_0[i + int_1], num + (long)i);
		}
		this.method_0().Write(array, 0, int_2);
	}

	// Token: 0x06000306 RID: 774 RVA: 0x00018908 File Offset: 0x00016B08
	public override int vmethod_11(byte[] byte_0, int int_1, int int_2)
	{
		long num = this.vmethod_4();
		byte[] array = new byte[int_2];
		int num2 = this.method_0().Read(array, 0, int_2);
		for (int i = 0; i < num2; i++)
		{
			byte_0[i + int_1] = this.method_1(array[i], num + (long)i);
		}
		return num2;
	}

	// Token: 0x06000307 RID: 775 RVA: 0x00018954 File Offset: 0x00016B54
	public override long vmethod_9(long long_0, int int_1)
	{
		SeekOrigin origin;
		switch (int_1)
		{
		case 0:
			origin = SeekOrigin.Begin;
			break;
		case 1:
			origin = SeekOrigin.Current;
			break;
		case 2:
			origin = SeekOrigin.End;
			break;
		default:
			throw new ArgumentException();
		}
		return this.method_0().Seek(long_0, origin);
	}

	// Token: 0x06000308 RID: 776 RVA: 0x000047E8 File Offset: 0x000029E8
	public override void vmethod_10(long long_0)
	{
		this.method_0().SetLength(long_0);
	}

	// Token: 0x040001A7 RID: 423
	private readonly int int_0;

	// Token: 0x040001A8 RID: 424
	private readonly Stream stream_0;
}
