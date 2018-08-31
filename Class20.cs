using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

// Token: 0x02000027 RID: 39
internal static class Class20
{
	// Token: 0x060000F9 RID: 249 RVA: 0x0000D14C File Offset: 0x0000B34C
	public static Bitmap smethod_0(int int_0, int int_1, int int_2, int int_3, Bitmap bitmap_0)
	{
		Rectangle srcRect = new Rectangle(int_0, int_1, int_2, int_3);
		Bitmap bitmap = new Bitmap(srcRect.Width, srcRect.Height);
		using (Graphics graphics = Graphics.FromImage(bitmap))
		{
			graphics.DrawImage(bitmap_0, new Rectangle(0, 0, bitmap.Width, bitmap.Height), srcRect, GraphicsUnit.Pixel);
		}
		return bitmap;
	}

	// Token: 0x060000FA RID: 250 RVA: 0x0000D1BC File Offset: 0x0000B3BC
	public static void smethod_1(Bitmap bitmap_0, int int_0, int int_1, string string_0)
	{
		GClass3.smethod_0("Starting captcha OCR service", "OCR");
		int width = bitmap_0.Width;
		int height = bitmap_0.Height;
		int num = 1;
		JObject jobject = new JObject();
		for (int i = 0; i < height; i += height / int_0)
		{
			for (int j = 0; j < width; j += width / int_1)
			{
				Class20.smethod_3(Class20.smethod_0(j, i, width / int_1, height / int_0, bitmap_0), num, jobject, string_0);
				num++;
			}
		}
		while (jobject.Count != num - 1)
		{
			Thread.Sleep(200);
		}
		GClass3.smethod_0("OCR completed, attempting to solve captcha", "OCR");
		Console.WriteLine(jobject.ToString());
	}

	// Token: 0x060000FB RID: 251 RVA: 0x0000D260 File Offset: 0x0000B460
	public static void smethod_2(string string_0)
	{
		try
		{
			HtmlDocument htmlDocument = new HtmlDocument();
			htmlDocument.LoadHtml(string_0);
			string innerText = htmlDocument.DocumentNode.SelectSingleNode("//strong").InnerText;
			GClass3.smethod_0("Found question: " + innerText, "OCR");
			string text = htmlDocument.DocumentNode.SelectSingleNode("//img").Attributes["src"].Value.Replace("amp;", string.Empty);
			GClass3.smethod_0("Found image URL: " + text, "OCR");
			int count = htmlDocument.DocumentNode.SelectNodes("//td[@class='rc-imageselect-tile']").Count;
			GClass3.smethod_0(string.Format("{0} images detected", count), "OCR");
			int num = htmlDocument.DocumentNode.SelectNodes("//img").Select(new Func<HtmlNode, string>(Class20.Class21.class21_0.method_0)).Distinct<string>().Count<string>();
			GClass3.smethod_0(string.Format("{0} rows detected", num), "OCR");
			int num2 = htmlDocument.DocumentNode.SelectNodes("//img").Select(new Func<HtmlNode, string>(Class20.Class21.class21_0.method_1)).Distinct<string>().Count<string>();
			GClass3.smethod_0(string.Format("{0} columns detected", num2), "OCR");
			WebClient webClient = new WebClient();
			byte[] buffer;
			try
			{
				buffer = webClient.DownloadData(text);
			}
			finally
			{
				((IDisposable)webClient).Dispose();
			}
			MemoryStream memoryStream = new MemoryStream(buffer);
			try
			{
				Class20.smethod_1(new Bitmap(memoryStream), num, num2, innerText);
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}
		catch
		{
			GClass3.smethod_0("Error extracting OCR info", "OCR");
		}
	}

	// Token: 0x060000FC RID: 252 RVA: 0x00003557 File Offset: 0x00001757
	public static void smethod_3(Bitmap bitmap_0, int int_0, JObject jobject_0, string string_0)
	{
		new Task(new Action(new Class20.Class22
		{
			bitmap_0 = bitmap_0,
			jobject_0 = jobject_0,
			int_0 = int_0,
			string_0 = string_0
		}.method_0)).Start();
	}

	// Token: 0x060000FD RID: 253 RVA: 0x0000D474 File Offset: 0x0000B674
	public static JObject smethod_4(Bitmap bitmap_0)
	{
		JObject result2;
		try
		{
			HttpClient httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", string.Empty);
			string requestUri = "https://westcentralus.api.cognitive.microsoft.com/vision/v2.0/analyze?visualFeatures=Categories,Description,Color";
			ByteArrayContent byteArrayContent = new ByteArrayContent((byte[])new ImageConverter().ConvertTo(bitmap_0, typeof(byte[])));
			HttpResponseMessage result;
			try
			{
				byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
				result = httpClient.PostAsync(requestUri, byteArrayContent).Result;
			}
			finally
			{
				((IDisposable)byteArrayContent).Dispose();
			}
			result2 = result.smethod_0();
		}
		catch (Exception)
		{
			result2 = new JObject();
		}
		return result2;
	}

	// Token: 0x02000028 RID: 40
	[Serializable]
	private sealed class Class21
	{
		// Token: 0x06000100 RID: 256 RVA: 0x0000359B File Offset: 0x0000179B
		internal string method_0(HtmlNode htmlNode_0)
		{
			return htmlNode_0.Attributes["style"].Value.Split(new char[]
			{
				';'
			})[0];
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000035C4 File Offset: 0x000017C4
		internal string method_1(HtmlNode htmlNode_0)
		{
			return htmlNode_0.Attributes["style"].Value.Split(new char[]
			{
				';'
			})[1];
		}

		// Token: 0x0400008F RID: 143
		public static readonly Class20.Class21 class21_0 = new Class20.Class21();

		// Token: 0x04000090 RID: 144
		public static Func<HtmlNode, string> func_0;

		// Token: 0x04000091 RID: 145
		public static Func<HtmlNode, string> func_1;
	}

	// Token: 0x02000029 RID: 41
	private sealed class Class22
	{
		// Token: 0x06000103 RID: 259 RVA: 0x0000D520 File Offset: 0x0000B720
		internal void method_0()
		{
			JObject jobject = Class20.smethod_4(this.bitmap_0);
			try
			{
				this.jobject_0[this.int_0.ToString()] = new JObject();
				JToken jtoken = this.jobject_0[this.int_0.ToString()];
				object key = "match";
				bool value;
				if (jobject["description"]["tags"].Count<JToken>() <= 0)
				{
					value = false;
				}
				else
				{
					IEnumerable<JToken> source = jobject["description"]["tags"];
					Func<JToken, bool> predicate;
					if ((predicate = this.func_0) == null)
					{
						predicate = (this.func_0 = new Func<JToken, bool>(this.method_1));
					}
					value = (source.Where(predicate).Count<JToken>() > 0);
				}
				jtoken[key] = value;
				this.jobject_0[this.int_0.ToString()]["tags"] = jobject["description"]["tags"];
				GClass3.smethod_0("Received answer for image " + this.int_0, "OCR");
			}
			catch
			{
				Console.WriteLine(jobject);
			}
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000035ED File Offset: 0x000017ED
		internal bool method_1(JToken jtoken_0)
		{
			return this.string_0.Contains(jtoken_0.ToString());
		}

		// Token: 0x04000092 RID: 146
		public Bitmap bitmap_0;

		// Token: 0x04000093 RID: 147
		public JObject jobject_0;

		// Token: 0x04000094 RID: 148
		public int int_0;

		// Token: 0x04000095 RID: 149
		public string string_0;

		// Token: 0x04000096 RID: 150
		public Func<JToken, bool> func_0;
	}
}
