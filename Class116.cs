using System;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

// Token: 0x020000D6 RID: 214
internal static class Class116
{
	// Token: 0x0600059F RID: 1439 RVA: 0x0002FF04 File Offset: 0x0002E104
	public static JObject smethod_0(this HttpResponseMessage httpResponseMessage_0)
	{
		JObject result;
		try
		{
			result = JObject.Parse(httpResponseMessage_0.Content.ReadAsStringAsync().Result);
		}
		catch
		{
			result = null;
		}
		return result;
	}

	// Token: 0x060005A0 RID: 1440 RVA: 0x0002FF40 File Offset: 0x0002E140
	public static async Task<JObject> smethod_1(this HttpResponseMessage httpResponseMessage_0)
	{
		JObject result;
		try
		{
			TaskAwaiter<string> taskAwaiter = httpResponseMessage_0.Content.ReadAsStringAsync().GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<string> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<string>);
			}
			result = JObject.Parse(taskAwaiter.GetResult());
		}
		catch
		{
			result = null;
		}
		return result;
	}

	// Token: 0x060005A1 RID: 1441 RVA: 0x0002FF88 File Offset: 0x0002E188
	public static JArray smethod_2(this HttpResponseMessage httpResponseMessage_0)
	{
		JArray result;
		try
		{
			result = JArray.Parse(httpResponseMessage_0.Content.ReadAsStringAsync().Result);
		}
		catch
		{
			result = null;
		}
		return result;
	}

	// Token: 0x060005A2 RID: 1442 RVA: 0x00005BFF File Offset: 0x00003DFF
	public static string smethod_3(this HttpResponseMessage httpResponseMessage_0)
	{
		return httpResponseMessage_0.Content.ReadAsStringAsync().Result;
	}

	// Token: 0x060005A3 RID: 1443 RVA: 0x00005C11 File Offset: 0x00003E11
	public static Task<string> smethod_4(this HttpResponseMessage httpResponseMessage_0)
	{
		return httpResponseMessage_0.Content.ReadAsStringAsync();
	}

	// Token: 0x060005A4 RID: 1444 RVA: 0x00005C1E File Offset: 0x00003E1E
	public static bool smethod_5(this HttpResponseMessage httpResponseMessage_0)
	{
		return httpResponseMessage_0.smethod_3().Contains("jschl-answer");
	}

	// Token: 0x020000D7 RID: 215
	[StructLayout(LayoutKind.Auto)]
	private struct Struct44 : IAsyncStateMachine
	{
		// Token: 0x060005A5 RID: 1445 RVA: 0x0002FFC4 File Offset: 0x0002E1C4
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			JObject result;
			try
			{
				try
				{
					TaskAwaiter<string> awaiter;
					if (num != 0)
					{
						awaiter = this.httpResponseMessage_0.Content.ReadAsStringAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							this.int_0 = 0;
							this.taskAwaiter_0 = awaiter;
							this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Class116.Struct44>(ref awaiter, ref this);
							return;
						}
					}
					else
					{
						awaiter = this.taskAwaiter_0;
						this.taskAwaiter_0 = default(TaskAwaiter<string>);
						this.int_0 = -1;
					}
					result = JObject.Parse(awaiter.GetResult());
				}
				catch
				{
					result = null;
				}
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			this.int_0 = -2;
			this.asyncTaskMethodBuilder_0.SetResult(result);
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x00005C30 File Offset: 0x00003E30
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x040002AD RID: 685
		public int int_0;

		// Token: 0x040002AE RID: 686
		public AsyncTaskMethodBuilder<JObject> asyncTaskMethodBuilder_0;

		// Token: 0x040002AF RID: 687
		public HttpResponseMessage httpResponseMessage_0;

		// Token: 0x040002B0 RID: 688
		private TaskAwaiter<string> taskAwaiter_0;
	}
}
