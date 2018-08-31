using System;
using System.IO;
using System.Windows.Forms;
using EO.WebBrowser;
using Newtonsoft.Json.Linq;

// Token: 0x02000050 RID: 80
internal sealed class Class46
{
	// Token: 0x060001BB RID: 443 RVA: 0x00010ED8 File Offset: 0x0000F0D8
	public static void smethod_0(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "Profile Files|*.json";
		openFileDialog.Title = "Select your profiles file";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			JObject jobject = JObject.Parse(new StreamReader(openFileDialog.FileName).ReadToEnd().ToString());
			string code = string.Format("importProfiles('{0}')", jobject.ToString().Replace("\n", string.Empty).Replace("\r", string.Empty));
			MainWindow.webView_0.EvalScript(code);
		}
	}

	// Token: 0x060001BC RID: 444 RVA: 0x00010F60 File Offset: 0x0000F160
	public static void smethod_1(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = "Profile Files|*.json";
		saveFileDialog.Title = "Export Profiles";
		saveFileDialog.FileName = "Profiles";
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			StreamWriter streamWriter = new StreamWriter(saveFileDialog.OpenFile());
			streamWriter.WriteLine(MainWindow.webView_0.EvalScript("JSON.stringify(profiles)").ToString());
			streamWriter.Dispose();
		}
	}
}
