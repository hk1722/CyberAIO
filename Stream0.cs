using System;
using System.IO;

// Token: 0x020000DB RID: 219
internal sealed class Stream0 : Stream
{
	// Token: 0x060005BB RID: 1467 RVA: 0x00005CC2 File Offset: 0x00003EC2
	public Stream0(Stream stream_1, int int_1)
	{
		this.method_1(stream_1);
		this.int_0 = int_1;
	}

	// Token: 0x060005BC RID: 1468 RVA: 0x00005CD8 File Offset: 0x00003ED8
	public Stream method_0()
	{
		return this.stream_0;
	}

	// Token: 0x060005BD RID: 1469 RVA: 0x00005CE0 File Offset: 0x00003EE0
	private void method_1(Stream stream_1)
	{
		this.stream_0 = stream_1;
	}

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x060005BE RID: 1470 RVA: 0x00005CE9 File Offset: 0x00003EE9
	public override bool CanRead
	{
		get
		{
			return this.method_0().CanRead;
		}
	}

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x060005BF RID: 1471 RVA: 0x00005CF6 File Offset: 0x00003EF6
	public override bool CanSeek
	{
		get
		{
			return this.method_0().CanSeek;
		}
	}

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x060005C0 RID: 1472 RVA: 0x00005D03 File Offset: 0x00003F03
	public override bool CanWrite
	{
		get
		{
			return this.method_0().CanWrite;
		}
	}

	// Token: 0x060005C1 RID: 1473 RVA: 0x00005D10 File Offset: 0x00003F10
	public override void Flush()
	{
		this.method_0().Flush();
	}

	// Token: 0x17000009 RID: 9
	// (get) Token: 0x060005C2 RID: 1474 RVA: 0x00005D1D File Offset: 0x00003F1D
	public override long Length
	{
		get
		{
			return this.method_0().Length;
		}
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x060005C3 RID: 1475 RVA: 0x00005D2A File Offset: 0x00003F2A
	// (set) Token: 0x060005C4 RID: 1476 RVA: 0x00005D37 File Offset: 0x00003F37
	public override long Position
	{
		get
		{
			return this.method_0().Position;
		}
		set
		{
			this.method_0().Position = value;
		}
	}

	// Token: 0x060005C5 RID: 1477 RVA: 0x00030094 File Offset: 0x0002E294
	private byte method_2(byte byte_0, long long_0)
	{
		byte b = (byte)((ulong)this.int_0 | (ulong)long_0);
		return byte_0 ^ b;
	}

	// Token: 0x060005C6 RID: 1478 RVA: 0x000300B0 File Offset: 0x0002E2B0
	public override void Write(byte[] buffer, int offset, int count)
	{
		byte[] array = new byte[count];
		Buffer.BlockCopy(buffer, offset, array, 0, count);
		long position = this.Position;
		for (int i = 0; i < count; i++)
		{
			array[i] = this.method_2(array[i], position + (long)i);
		}
		this.method_0().Write(array, 0, count);
	}

	// Token: 0x060005C7 RID: 1479 RVA: 0x00030100 File Offset: 0x0002E300
	public override int Read(byte[] buffer, int offset, int count)
	{
		long position = this.Position;
		byte[] array = new byte[count];
		int num = this.method_0().Read(array, 0, count);
		for (int i = 0; i < num; i++)
		{
			buffer[i + offset] = this.method_2(array[i], position + (long)i);
		}
		return num;
	}

	// Token: 0x060005C8 RID: 1480 RVA: 0x00005D45 File Offset: 0x00003F45
	public override long Seek(long offset, SeekOrigin origin)
	{
		return this.method_0().Seek(offset, origin);
	}

	// Token: 0x060005C9 RID: 1481 RVA: 0x00005D54 File Offset: 0x00003F54
	public override void SetLength(long value)
	{
		this.method_0().SetLength(value);
	}

	// Token: 0x040002B9 RID: 697
	private readonly int int_0;

	// Token: 0x040002BA RID: 698
	private Stream stream_0;
}
