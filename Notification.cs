using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

// Token: 0x02000089 RID: 137
public sealed partial class Notification : Form
{
	// Token: 0x060002E6 RID: 742 RVA: 0x00018074 File Offset: 0x00016274
	public Notification()
	{
		this.InitializeComponent();
		Notification.notification_0 = this;
		base.TopMost = true;
		Rectangle workingArea = Screen.GetWorkingArea(this);
		base.Location = new Point(workingArea.Right - base.Size.Width - 10, workingArea.Bottom - base.Size.Height - 10);
		base.Hide();
	}

	// Token: 0x060002E8 RID: 744 RVA: 0x000180E4 File Offset: 0x000162E4
	public static void smethod_0(string string_1, string string_2, Notification.GEnum0 genum0_0, bool bool_0)
	{
		Notification.Class75 @class = new Notification.Class75();
		@class.genum0_0 = genum0_0;
		@class.string_0 = string_1;
		@class.string_1 = string_2;
		string string_3 = GClass2.smethod_2(10);
		Notification.string_0 = string_3;
		Notification.notification_0.Show();
		Notification.smethod_3(new Action(@class.method_0));
		if (bool_0)
		{
			Notification.smethod_1(string_3);
		}
	}

	// Token: 0x060002E9 RID: 745 RVA: 0x00018140 File Offset: 0x00016340
	public static void smethod_1(string string_1)
	{
		Notification.Class76 @class = new Notification.Class76();
		@class.string_0 = string_1;
		@class.timer_0 = new Timer
		{
			Interval = 3000
		};
		@class.timer_0.Tick += @class.method_0;
		@class.timer_0.Start();
	}

	// Token: 0x060002EA RID: 746 RVA: 0x00018194 File Offset: 0x00016394
	public static Timer smethod_2()
	{
		Notification.Class78 @class = new Notification.Class78();
		@class.double_0 = 0.0;
		Notification.notification_0.Opacity = 0.0;
		Notification.timer_0.Stop();
		Notification.timer_0 = new Timer
		{
			Interval = 10
		};
		Notification.timer_0.Tick += @class.method_0;
		Notification.timer_0.Start();
		return Notification.timer_0;
	}

	// Token: 0x060002EB RID: 747 RVA: 0x0001820C File Offset: 0x0001640C
	public static Timer smethod_3(Action action_0)
	{
		Notification.Class77 @class = new Notification.Class77();
		@class.action_0 = action_0;
		Notification.timer_1.Stop();
		Notification.timer_1 = new Timer
		{
			Interval = 10
		};
		Notification.timer_1.Tick += @class.method_0;
		Notification.timer_1.Start();
		return Notification.timer_1;
	}

	// Token: 0x060002EC RID: 748 RVA: 0x00004723 File Offset: 0x00002923
	private void close_btn_Click(object sender, EventArgs e)
	{
		Notification.smethod_3(new Action(this.method_0));
	}

	// Token: 0x060002EF RID: 751 RVA: 0x00002CB5 File Offset: 0x00000EB5
	private void method_0()
	{
		base.Hide();
	}

	// Token: 0x04000192 RID: 402
	private static Notification notification_0;

	// Token: 0x04000193 RID: 403
	public static string string_0;

	// Token: 0x04000194 RID: 404
	public static Timer timer_0 = new Timer();

	// Token: 0x04000195 RID: 405
	public static Timer timer_1 = new Timer();

	// Token: 0x0200008A RID: 138
	[Serializable]
	private sealed class Class74
	{
		// Token: 0x060002F2 RID: 754 RVA: 0x00004762 File Offset: 0x00002962
		internal void method_0()
		{
			Notification.notification_0.Hide();
		}

		// Token: 0x0400019D RID: 413
		public static readonly Notification.Class74 class74_0 = new Notification.Class74();

		// Token: 0x0400019E RID: 414
		public static Action action_0;
	}

	// Token: 0x0200008B RID: 139
	private sealed class Class75
	{
		// Token: 0x060002F4 RID: 756 RVA: 0x000186E8 File Offset: 0x000168E8
		internal void method_0()
		{
			Notification.GEnum0 genum = this.genum0_0;
			if (genum != (Notification.GEnum0)0)
			{
				if (genum != (Notification.GEnum0)1)
				{
					return;
				}
				Notification.notification_0.logo.ImageLocation = "images\\stop.png";
			}
			else
			{
				Notification.notification_0.logo.ImageLocation = "images\\Success.png";
			}
			Notification.notification_0.title.Text = this.string_0;
			Notification.notification_0.description.Text = this.string_1;
			Notification.smethod_2();
		}

		// Token: 0x0400019F RID: 415
		public Notification.GEnum0 genum0_0;

		// Token: 0x040001A0 RID: 416
		public string string_0;

		// Token: 0x040001A1 RID: 417
		public string string_1;
	}

	// Token: 0x0200008C RID: 140
	private sealed class Class76
	{
		// Token: 0x060002F6 RID: 758 RVA: 0x00018760 File Offset: 0x00016960
		internal void method_0(object sender, EventArgs e)
		{
			if (Notification.string_0 == this.string_0 && !Notification.notification_0.ClientRectangle.Contains(Notification.notification_0.PointToClient(Control.MousePosition)))
			{
				Notification.smethod_3(new Action(Notification.Class74.class74_0.method_0));
				return;
			}
			if (Notification.string_0 != this.string_0)
			{
				this.timer_0.Dispose();
			}
		}

		// Token: 0x040001A2 RID: 418
		public string string_0;

		// Token: 0x040001A3 RID: 419
		public Timer timer_0;
	}

	// Token: 0x0200008D RID: 141
	private sealed class Class77
	{
		// Token: 0x060002F8 RID: 760 RVA: 0x000187E8 File Offset: 0x000169E8
		internal void method_0(object sender, EventArgs e)
		{
			if (Notification.notification_0.Opacity <= 0.0)
			{
				Action action = this.action_0;
				if (action != null)
				{
					action();
				}
				Notification.timer_1.Dispose();
				return;
			}
			Notification.notification_0.Opacity -= 0.05;
		}

		// Token: 0x040001A4 RID: 420
		public Action action_0;
	}

	// Token: 0x0200008E RID: 142
	private sealed class Class78
	{
		// Token: 0x060002FA RID: 762 RVA: 0x00018840 File Offset: 0x00016A40
		internal void method_0(object sender, EventArgs e)
		{
			if (this.double_0 < 1.0)
			{
				Notification.notification_0.Opacity += 0.05;
				this.double_0 += 0.05;
				return;
			}
			Notification.timer_0.Dispose();
		}

		// Token: 0x040001A5 RID: 421
		public double double_0;
	}

	// Token: 0x0200008F RID: 143
	public enum GEnum0
	{

	}
}
