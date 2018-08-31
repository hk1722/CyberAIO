using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;
using CyberAIO.Websites.Shopify;
using EO.WebBrowser;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;

// Token: 0x020000D0 RID: 208
internal sealed class Class111
{
	// Token: 0x06000571 RID: 1393 RVA: 0x0002EF94 File Offset: 0x0002D194
	public static void smethod_0(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		try
		{
			foreach (KeyValuePair<string, JToken> keyValuePair in JObject.Parse(jsextInvokeArgs_0.Arguments.First<object>().ToString()))
			{
				Class111.Class112 @class = new Class111.Class112();
				@class.jtoken_0 = keyValuePair.Value;
				if (MainWindow.dictionary_0.ContainsKey((int)@class.jtoken_0["id"]))
				{
					if (Class111.Class114.callSite_0 == null)
					{
						Class111.Class114.callSite_0 = CallSite<Func<CallSite, object, Thread>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Thread), typeof(Class111)));
					}
					if (Class111.Class114.callSite_0.Target(Class111.Class114.callSite_0, MainWindow.dictionary_0[(int)@class.jtoken_0["id"]]["thread"]).IsAlive)
					{
						continue;
					}
				}
				string text = @class.jtoken_0["store"].ToString();
				uint num = Class93.smethod_0(text);
				Thread thread;
				if (num <= 1213666813u)
				{
					if (num <= 834122706u)
					{
						if (num <= 156382626u)
						{
							if (num <= 72053246u)
							{
								if (num != 7379352u)
								{
									if (num != 72053246u)
									{
										goto IL_780;
									}
									if (!(text == "Lacoste CA"))
									{
										goto IL_780;
									}
									thread = new Thread(new ThreadStart(@class.method_14));
								}
								else
								{
									if (!(text == "EastBay "))
									{
										goto IL_780;
									}
									thread = new Thread(new ThreadStart(@class.method_20));
								}
							}
							else if (num != 94696313u)
							{
								if (num != 156382626u)
								{
									goto IL_780;
								}
								if (!(text == "Lacoste FR"))
								{
									goto IL_780;
								}
								thread = new Thread(new ThreadStart(@class.method_4));
							}
							else
							{
								if (!(text == "Size?"))
								{
									goto IL_780;
								}
								thread = new Thread(new ThreadStart(@class.method_30));
							}
						}
						else if (num <= 537959913u)
						{
							if (num != 356287031u)
							{
								if (num != 537959913u)
								{
									goto IL_780;
								}
								if (!(text == "Footlocker US "))
								{
									goto IL_780;
								}
								thread = new Thread(new ThreadStart(@class.method_17));
							}
							else
							{
								if (!(text == "Lacoste IT"))
								{
									goto IL_780;
								}
								thread = new Thread(new ThreadStart(@class.method_7));
							}
						}
						else if (num != 607951316u)
						{
							if (num != 834122706u)
							{
								goto IL_780;
							}
							if (!(text == "MrPorter"))
							{
								goto IL_780;
							}
							thread = new Thread(new ThreadStart(@class.method_1));
						}
						else
						{
							if (!(text == "Lacoste IE"))
							{
								goto IL_780;
							}
							thread = new Thread(new ThreadStart(@class.method_6));
						}
					}
					else if (num <= 1073939897u)
					{
						if (num <= 993983648u)
						{
							if (num != 978780147u)
							{
								if (num != 993983648u)
								{
									goto IL_780;
								}
								if (!(text == "Lacoste NL"))
								{
									goto IL_780;
								}
								thread = new Thread(new ThreadStart(@class.method_5));
							}
							else
							{
								if (!(text == "Lacoste DK"))
								{
									goto IL_780;
								}
								thread = new Thread(new ThreadStart(@class.method_8));
							}
						}
						else if (num != 1033461544u)
						{
							if (num != 1073939897u)
							{
								goto IL_780;
							}
							if (!(text == "Footlocker CA "))
							{
								goto IL_780;
							}
							thread = new Thread(new ThreadStart(@class.method_18));
						}
						else
						{
							if (!(text == "EastBay"))
							{
								goto IL_780;
							}
							thread = new Thread(new ThreadStart(@class.method_24));
						}
					}
					else if (num <= 1127660147u)
					{
						if (num != 1115811218u)
						{
							if (num != 1127660147u)
							{
								goto IL_780;
							}
							if (!(text == "Lacoste KR"))
							{
								goto IL_780;
							}
							thread = new Thread(new ThreadStart(@class.method_12));
						}
						else
						{
							if (!(text == "Lacoste UK"))
							{
								goto IL_780;
							}
							thread = new Thread(new ThreadStart(@class.method_3));
						}
					}
					else if (num != 1162892671u)
					{
						if (num != 1213666813u)
						{
							goto IL_780;
						}
						if (!(text == "Lacoste DE"))
						{
							goto IL_780;
						}
						thread = new Thread(new ThreadStart(@class.method_11));
					}
					else
					{
						if (!(text == "Lacoste AT"))
						{
							goto IL_780;
						}
						thread = new Thread(new ThreadStart(@class.method_9));
					}
				}
				else if (num <= 3276705478u)
				{
					if (num <= 2445159016u)
					{
						if (num <= 1494588195u)
						{
							if (num != 1258127411u)
							{
								if (num != 1494588195u)
								{
									goto IL_780;
								}
								if (!(text == "Footlocker CA"))
								{
									goto IL_780;
								}
								thread = new Thread(new ThreadStart(@class.method_23));
							}
							else
							{
								if (!(text == "Footlocker US"))
								{
									goto IL_780;
								}
								thread = new Thread(new ThreadStart(@class.method_22));
							}
						}
						else if (num != 1518474074u)
						{
							if (num != 2445159016u)
							{
								goto IL_780;
							}
							if (!(text == "The Hip Store"))
							{
								goto IL_780;
							}
							thread = new Thread(new ThreadStart(@class.method_28));
						}
						else
						{
							if (!(text == "Lacoste US"))
							{
								goto IL_780;
							}
							thread = new Thread(new ThreadStart(@class.method_15));
						}
					}
					else if (num <= 2692391852u)
					{
						if (num != 2508713984u)
						{
							if (num != 2692391852u)
							{
								goto IL_780;
							}
							if (!(text == "Supreme"))
							{
								goto IL_780;
							}
							thread = new Thread(new ThreadStart(@class.method_31));
						}
						else
						{
							if (!(text == "Champs Sports "))
							{
								goto IL_780;
							}
							thread = new Thread(new ThreadStart(@class.method_21));
						}
					}
					else if (num != 3138249339u)
					{
						if (num != 3276705478u)
						{
							goto IL_780;
						}
						if (!(text == "Off-White"))
						{
							goto IL_780;
						}
						thread = new Thread(new ThreadStart(@class.method_0));
					}
					else
					{
						if (!(text == "Footaction"))
						{
							goto IL_780;
						}
						thread = new Thread(new ThreadStart(@class.method_26));
					}
				}
				else if (num <= 3925924200u)
				{
					if (num <= 3544959638u)
					{
						if (num != 3520812353u)
						{
							if (num != 3544959638u)
							{
								goto IL_780;
							}
							if (!(text == "JD Sports"))
							{
								goto IL_780;
							}
							thread = new Thread(new ThreadStart(@class.method_29));
						}
						else
						{
							if (!(text == "Footaction "))
							{
								goto IL_780;
							}
							thread = new Thread(new ThreadStart(@class.method_19));
						}
					}
					else if (num != 3842920480u)
					{
						if (num != 3925924200u)
						{
							goto IL_780;
						}
						if (!(text == "Antonioli"))
						{
							goto IL_780;
						}
						thread = new Thread(new ThreadStart(@class.method_2));
					}
					else
					{
						if (!(text == "Champs Sports"))
						{
							goto IL_780;
						}
						thread = new Thread(new ThreadStart(@class.method_25));
					}
				}
				else if (num <= 4053610095u)
				{
					if (num != 4009715463u)
					{
						if (num != 4053610095u)
						{
							goto IL_780;
						}
						if (!(text == "Footlocker EU "))
						{
							goto IL_780;
						}
						thread = new Thread(new ThreadStart(@class.method_16));
					}
					else
					{
						if (!(text == "Footpatrol"))
						{
							goto IL_780;
						}
						thread = new Thread(new ThreadStart(@class.method_27));
					}
				}
				else if (num != 4249577209u)
				{
					if (num != 4285839398u)
					{
						goto IL_780;
					}
					if (!(text == "Lacoste PL"))
					{
						goto IL_780;
					}
					thread = new Thread(new ThreadStart(@class.method_13));
				}
				else
				{
					if (!(text == "Lacoste CH"))
					{
						goto IL_780;
					}
					thread = new Thread(new ThreadStart(@class.method_10));
				}
				IL_7A6:
				thread.IsBackground = true;
				Dictionary<int, Dictionary<string, object>> dictionary_ = MainWindow.dictionary_0;
				int key = (int)@class.jtoken_0["id"];
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary["thread"] = thread;
				dictionary["stop"] = false;
				dictionary_[key] = dictionary;
				thread.Start();
				MainWindow.webView_0.QueueScriptCall(string.Format("updateButton({0},true)", @class.jtoken_0["id"]));
				continue;
				IL_780:
				thread = new Thread(new ThreadStart(@class.method_32));
				goto IL_7A6;
			}
		}
		catch
		{
		}
	}

	// Token: 0x06000572 RID: 1394 RVA: 0x0002F810 File Offset: 0x0002DA10
	[PermissionSet(SecurityAction.Demand, XML = "<PermissionSet class=\"System.Security.PermissionSet\"\r\nversion=\"1\">\r\n<IPermission class=\"System.Security.Permissions.SecurityPermission, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\"\r\nversion=\"1\"\r\nFlags=\"ControlThread\"/>\r\n</PermissionSet>\r\n")]
	public static void smethod_1(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		Class111.Class113 @class = new Class111.Class113();
		@class.jsextInvokeArgs_0 = jsextInvokeArgs_0;
		try
		{
			new Task(new Action(@class.method_0)).Start();
		}
		catch
		{
		}
	}

	// Token: 0x020000D1 RID: 209
	private sealed class Class112
	{
		// Token: 0x06000574 RID: 1396 RVA: 0x000058E8 File Offset: 0x00003AE8
		internal void method_0()
		{
			new Class106(this.jtoken_0).method_0();
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x000058FA File Offset: 0x00003AFA
		internal void method_1()
		{
			new Class59(this.jtoken_0).method_0();
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x0000590C File Offset: 0x00003B0C
		internal void method_2()
		{
			new Class27(this.jtoken_0).method_0();
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0000591E File Offset: 0x00003B1E
		internal void method_3()
		{
			new Class176(this.jtoken_0, "/on/demandware.store/Sites-GB-Site/en/").method_0();
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x00005935 File Offset: 0x00003B35
		internal void method_4()
		{
			new Class176(this.jtoken_0, "/on/demandware.store/Sites-FR-Site/fr/").method_0();
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x0000594C File Offset: 0x00003B4C
		internal void method_5()
		{
			new Class176(this.jtoken_0, "/on/demandware.store/Sites-NL-Site/fr/").method_0();
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x00005963 File Offset: 0x00003B63
		internal void method_6()
		{
			new Class176(this.jtoken_0, "/on/demandware.store/Sites-IE-Site/fr/").method_0();
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x0000597A File Offset: 0x00003B7A
		internal void method_7()
		{
			new Class176(this.jtoken_0, "/on/demandware.store/Sites-IT-Site/fr/").method_0();
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x00005991 File Offset: 0x00003B91
		internal void method_8()
		{
			new Class176(this.jtoken_0, "/on/demandware.store/Sites-DK-Site/fr/").method_0();
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x000059A8 File Offset: 0x00003BA8
		internal void method_9()
		{
			new Class176(this.jtoken_0, "/on/demandware.store/Sites-AT-Site/fr/").method_0();
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x000059BF File Offset: 0x00003BBF
		internal void method_10()
		{
			new Class176(this.jtoken_0, "/on/demandware.store/Sites-CH-Site/fr/").method_0();
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x000059D6 File Offset: 0x00003BD6
		internal void method_11()
		{
			new Class176(this.jtoken_0, "/on/demandware.store/Sites-DE-Site/fr/").method_0();
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x000059ED File Offset: 0x00003BED
		internal void method_12()
		{
			new Class176(this.jtoken_0, "/on/demandware.store/Sites-KR-Site/fr/").method_0();
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x00005A04 File Offset: 0x00003C04
		internal void method_13()
		{
			new Class176(this.jtoken_0, "/on/demandware.store/Sites-PL-Site/fr/").method_0();
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x00005A1B File Offset: 0x00003C1B
		internal void method_14()
		{
			new Class176(this.jtoken_0, "/on/demandware.store/Sites-CA-Site/fr/").method_0();
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x00005A32 File Offset: 0x00003C32
		internal void method_15()
		{
			new Class176(this.jtoken_0, "/on/demandware.store/Sites-FlagShip-Site/en_US/").method_0();
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x00005A49 File Offset: 0x00003C49
		internal void method_16()
		{
			new Class56(this.jtoken_0).method_0();
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x00005A5B File Offset: 0x00003C5B
		internal void method_17()
		{
			new Class121(this.jtoken_0, "footlocker.com").method_0();
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x00005A72 File Offset: 0x00003C72
		internal void method_18()
		{
			new Class121(this.jtoken_0, "footlocker.ca").method_0();
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x00005A89 File Offset: 0x00003C89
		internal void method_19()
		{
			new Class121(this.jtoken_0, "footaction.com").method_0();
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x00005AA0 File Offset: 0x00003CA0
		internal void method_20()
		{
			new Class121(this.jtoken_0, "eastbay.com").method_0();
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x00005AB7 File Offset: 0x00003CB7
		internal void method_21()
		{
			new Class121(this.jtoken_0, "champssports.com").method_0();
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x00005ACE File Offset: 0x00003CCE
		internal void method_22()
		{
			new Class103(this.jtoken_0, "footlocker.com").method_0();
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x00005AE5 File Offset: 0x00003CE5
		internal void method_23()
		{
			new Class103(this.jtoken_0, "footlocker.ca").method_0();
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x00005AFC File Offset: 0x00003CFC
		internal void method_24()
		{
			new Class103(this.jtoken_0, "eastbay.com").method_0();
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x00005B13 File Offset: 0x00003D13
		internal void method_25()
		{
			new Class103(this.jtoken_0, "champssports.com").method_0();
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x00005A89 File Offset: 0x00003C89
		internal void method_26()
		{
			new Class121(this.jtoken_0, "footaction.com").method_0();
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x00005B2A File Offset: 0x00003D2A
		internal void method_27()
		{
			new Class13(this.jtoken_0, "footpatrol", "AD60F89E1BB248F388B9FC671851A2B8").method_0();
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x00005B46 File Offset: 0x00003D46
		internal void method_28()
		{
			new Class13(this.jtoken_0, "thehipstore", "117860D26D504A5FB26B2FB64CE35FB8").method_0();
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x00005B62 File Offset: 0x00003D62
		internal void method_29()
		{
			new Class13(this.jtoken_0, "jdsports", "60743806B14F4AF389F582E83A141733").method_0();
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x00005B7E File Offset: 0x00003D7E
		internal void method_30()
		{
			new Class13(this.jtoken_0, "size", "3565AE9C56464BB0AD8020F735D1479E").method_0();
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x00005B9A File Offset: 0x00003D9A
		internal void method_31()
		{
			new Class130(this.jtoken_0).method_0();
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x00005BAC File Offset: 0x00003DAC
		internal void method_32()
		{
			new Shopify(this.jtoken_0).Start();
		}

		// Token: 0x040002A4 RID: 676
		public JToken jtoken_0;
	}

	// Token: 0x020000D2 RID: 210
	private sealed class Class113
	{
		// Token: 0x06000596 RID: 1430 RVA: 0x0002F858 File Offset: 0x0002DA58
		internal void method_0()
		{
			JObject jobject = JObject.Parse(this.jsextInvokeArgs_0.Arguments.First<object>().ToString());
			foreach (KeyValuePair<string, JToken> keyValuePair in jobject)
			{
				JToken value = keyValuePair.Value;
				if (MainWindow.dictionary_0.ContainsKey((int)value["id"]))
				{
					object arg = MainWindow.dictionary_0[(int)value["id"]]["thread"];
					if (Class111.Class115.callSite_0 == null)
					{
						Class111.Class115.callSite_0 = CallSite<Func<CallSite, object, Thread>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Thread), typeof(Class111)));
					}
					if (Class111.Class115.callSite_0.Target(Class111.Class115.callSite_0, arg).IsAlive)
					{
						MainWindow.dictionary_0[(int)value["id"]]["stop"] = true;
						MainWindow.webView_0.QueueScriptCall(string.Format("updateTable('Stopping...','DARKORANGE',{0},7)", value["id"]));
					}
				}
			}
			foreach (KeyValuePair<string, JToken> keyValuePair2 in jobject)
			{
				JToken value2 = keyValuePair2.Value;
				if (MainWindow.dictionary_0.ContainsKey((int)value2["id"]))
				{
					object arg2 = MainWindow.dictionary_0[(int)value2["id"]]["thread"];
					if (Class111.Class115.callSite_1 == null)
					{
						Class111.Class115.callSite_1 = CallSite<Func<CallSite, object, Thread>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Thread), typeof(Class111)));
					}
					if (Class111.Class115.callSite_1.Target(Class111.Class115.callSite_1, arg2).IsAlive)
					{
						Class30.smethod_1((int)value2["id"], null);
						if (Class111.Class115.callSite_2 == null)
						{
							Class111.Class115.callSite_2 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Abort", null, typeof(Class111), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Class111.Class115.callSite_2.Target(Class111.Class115.callSite_2, arg2);
					}
				}
			}
			foreach (KeyValuePair<string, JToken> keyValuePair3 in jobject)
			{
				JToken value3 = keyValuePair3.Value;
				if (MainWindow.dictionary_0.ContainsKey((int)value3["id"]))
				{
					object arg3 = MainWindow.dictionary_0[(int)value3["id"]]["thread"];
					if (Class111.Class115.callSite_3 == null)
					{
						Class111.Class115.callSite_3 = CallSite<Func<CallSite, object, Thread>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Thread), typeof(Class111)));
					}
					if (Class111.Class115.callSite_3.Target(Class111.Class115.callSite_3, arg3).IsAlive)
					{
						if (Class111.Class115.callSite_4 == null)
						{
							Class111.Class115.callSite_4 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Join", null, typeof(Class111), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Class111.Class115.callSite_4.Target(Class111.Class115.callSite_4, arg3);
						MainWindow.webView_0.QueueScriptCall(string.Format("updateTable('Stopped','red',{0},7)", value3["id"].ToString()));
						MainWindow.webView_0.QueueScriptCall(string.Format("updateButton({0},false)", value3["id"].ToString()));
					}
					MainWindow.dictionary_0.Remove((int)value3["id"]);
				}
			}
		}

		// Token: 0x040002A5 RID: 677
		public JSExtInvokeArgs jsextInvokeArgs_0;
	}

	// Token: 0x020000D3 RID: 211
	private static class Class114
	{
		// Token: 0x040002A6 RID: 678
		public static CallSite<Func<CallSite, object, Thread>> callSite_0;
	}

	// Token: 0x020000D4 RID: 212
	private static class Class115
	{
		// Token: 0x040002A7 RID: 679
		public static CallSite<Func<CallSite, object, Thread>> callSite_0;

		// Token: 0x040002A8 RID: 680
		public static CallSite<Func<CallSite, object, Thread>> callSite_1;

		// Token: 0x040002A9 RID: 681
		public static CallSite<Action<CallSite, object>> callSite_2;

		// Token: 0x040002AA RID: 682
		public static CallSite<Func<CallSite, object, Thread>> callSite_3;

		// Token: 0x040002AB RID: 683
		public static CallSite<Action<CallSite, object>> callSite_4;
	}
}
