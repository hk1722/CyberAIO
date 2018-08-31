using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CyberAIO.Properties
{
	// Token: 0x0200012A RID: 298
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.7.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000749 RID: 1865 RVA: 0x00006967 File Offset: 0x00004B67
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600074A RID: 1866 RVA: 0x0000696E File Offset: 0x00004B6E
		// (set) Token: 0x0600074B RID: 1867 RVA: 0x00006980 File Offset: 0x00004B80
		[UserScopedSetting]
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		public string LicenseKey
		{
			get
			{
				return (string)this["LicenseKey"];
			}
			set
			{
				this["LicenseKey"] = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600074C RID: 1868 RVA: 0x0000698E File Offset: 0x00004B8E
		// (set) Token: 0x0600074D RID: 1869 RVA: 0x000069A0 File Offset: 0x00004BA0
		[UserScopedSetting]
		[DefaultSettingValue("2500")]
		[DebuggerNonUserCode]
		public int retry_delay
		{
			get
			{
				return (int)this["retry_delay"];
			}
			set
			{
				this["retry_delay"] = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600074E RID: 1870 RVA: 0x000069B3 File Offset: 0x00004BB3
		// (set) Token: 0x0600074F RID: 1871 RVA: 0x000069C5 File Offset: 0x00004BC5
		[DefaultSettingValue("2500")]
		[DebuggerNonUserCode]
		[UserScopedSetting]
		public int monitor_delay
		{
			get
			{
				return (int)this["monitor_delay"];
			}
			set
			{
				this["monitor_delay"] = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000750 RID: 1872 RVA: 0x000069D8 File Offset: 0x00004BD8
		// (set) Token: 0x06000751 RID: 1873 RVA: 0x000069EA File Offset: 0x00004BEA
		[UserScopedSetting]
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		public string UniqueID
		{
			get
			{
				return (string)this["UniqueID"];
			}
			set
			{
				this["UniqueID"] = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000752 RID: 1874 RVA: 0x000069F8 File Offset: 0x00004BF8
		// (set) Token: 0x06000753 RID: 1875 RVA: 0x00006A0A File Offset: 0x00004C0A
		[UserScopedSetting]
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		public string profiles
		{
			get
			{
				return (string)this["profiles"];
			}
			set
			{
				this["profiles"] = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000754 RID: 1876 RVA: 0x00006A18 File Offset: 0x00004C18
		// (set) Token: 0x06000755 RID: 1877 RVA: 0x00006A2A File Offset: 0x00004C2A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string proxies
		{
			get
			{
				return (string)this["proxies"];
			}
			set
			{
				this["proxies"] = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000756 RID: 1878 RVA: 0x00006A38 File Offset: 0x00004C38
		// (set) Token: 0x06000757 RID: 1879 RVA: 0x00006A4A File Offset: 0x00004C4A
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		[UserScopedSetting]
		public string tasks
		{
			get
			{
				return (string)this["tasks"];
			}
			set
			{
				this["tasks"] = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000758 RID: 1880 RVA: 0x00006A58 File Offset: 0x00004C58
		// (set) Token: 0x06000759 RID: 1881 RVA: 0x00006A6A File Offset: 0x00004C6A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string user
		{
			get
			{
				return (string)this["user"];
			}
			set
			{
				this["user"] = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600075A RID: 1882 RVA: 0x00006A78 File Offset: 0x00004C78
		// (set) Token: 0x0600075B RID: 1883 RVA: 0x00006A8A File Offset: 0x00004C8A
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		[UserScopedSetting]
		public bool UpgradeRequired
		{
			get
			{
				return (bool)this["UpgradeRequired"];
			}
			set
			{
				this["UpgradeRequired"] = value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600075C RID: 1884 RVA: 0x00006A9D File Offset: 0x00004C9D
		// (set) Token: 0x0600075D RID: 1885 RVA: 0x00006AAF File Offset: 0x00004CAF
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string webhook
		{
			get
			{
				return (string)this["webhook"];
			}
			set
			{
				this["webhook"] = value;
			}
		}

		// Token: 0x040004FA RID: 1274
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
