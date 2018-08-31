using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

// Token: 0x020000F7 RID: 247
internal sealed class Class138
{
	// Token: 0x06000659 RID: 1625 RVA: 0x00035F7C File Offset: 0x0003417C
	public static async Task<Stream> smethod_0(string string_0)
	{
		TaskAwaiter<HttpResponseMessage> taskAwaiter = Class138.class70_0.method_6(string_0, false).GetAwaiter();
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			TaskAwaiter<HttpResponseMessage> taskAwaiter2;
			taskAwaiter = taskAwaiter2;
			taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
		}
		TaskAwaiter<Stream> taskAwaiter3 = taskAwaiter.GetResult().Content.ReadAsStreamAsync().GetAwaiter();
		if (!taskAwaiter3.IsCompleted)
		{
			await taskAwaiter3;
			TaskAwaiter<Stream> taskAwaiter4;
			taskAwaiter3 = taskAwaiter4;
			taskAwaiter4 = default(TaskAwaiter<Stream>);
		}
		return taskAwaiter3.GetResult();
	}

	// Token: 0x0600065A RID: 1626 RVA: 0x00035FC4 File Offset: 0x000341C4
	public static async Task<string> smethod_1(Stream stream_0)
	{
		StringContent stringContent = new StringContent("{\"part_content_type\":\"audio/mp3\"}");
		stringContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
		ByteArrayContent byteArrayContent = new ByteArrayContent(stream_0.smethod_5());
		byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/mp3");
		MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
		multipartFormDataContent.Add(stringContent, "metadata");
		multipartFormDataContent.Add(byteArrayContent, "upload");
		TaskAwaiter<HttpResponseMessage> taskAwaiter = Class138.class70_0.httpClient_0.PostAsync("https://stream.watsonplatform.net/speech-to-text/api/v1/recognize?model=en-US_BroadbandModel&watson-token=BRa%2FfWRDE6nKLG333F1gCNBsuOBO%2BU95UL7RJagmzJWjPHB8i8ctyFl2mhxroYHYciVCUDCdE6aKw3QTkTzOlZS4TY854iWJvGpNZHAMl%2FNfYV71X3EhM8CUOkcr%2Ba9KNstMVoZZ9yCehiJ2sRqGy4mXrPMUUYUBBEv7XV2HhxQwZExs7pBHfJwU01DaZg9TRlrQwTJPuaKNpnPoMRhfLgiaTjPWNHs97dDKo3VKsD%2B61kIDPtnFJBg4cxka5i5pArstGtT0V7zDtav2%2FedRZJJTKp%2FRBBqCwcEPbSnuZMUfjDE5cvbn5qpb14pl4SF3KKzAj5USiLhST041QK2I%2BOGd6xZtHw%2BeS6YD%2BifiMqZKNVHNjo%2Bm6qOeBNdpuUJaho6CL%2FNxbegj9fZsrSb4jc6ykdR2pRYqZVM90eBISq5GtA3yL3mDYx0ZQ9LVxmAfA5b8cO4WgV%2FsdnCIvHcJRAIe%2BV%2BM9xvkFfUW2stw2qO58F8%2FLXKjOx9UvXCgBAY7awHm2NIY2PZkHADUhuVYqnwjSN%2FIe4U46PTUFz7oydn3y5AChXTspfqEFXtFueShCIvitWOMN4DmbEOzJ8Ykwq80KFIopg%2BD4gzpsXp22H6qvnKHByrZlW1Bx0F1GV0DHwO1qAlpj5Q%2Fv4hHeR2mrpMfx5HbwmMzFU7%2BBgjj%2BJ7khNew0Oe0MnR2RWroM6DDjLzpaJDCQBXeEKirb6LlChsvU%2Fu9%2BTj4ZZaBDxwjyfkcu9kdPucrXzkUB20nISWBkPuSfcTeKg5dtJOf3%2BINZwn19G2seFB3CFsPyU2zOIytC9y1%2FRY8%2FdEvFB%2FhLyTAJfowrt8zZ2JVHfWATnUQ5YQLVty79ucUEfMEEUpBM9oTtfk8nS1tzOgZNckZfw7T2MnzlqoIdoBafRq%2BVkz7NGmT4YoNqGUklNLZwMvkhGG7RnDJgZkDviJd8dGqboRij2UiuHpjWPEHsX9GZqmZ3uirr0SGDXKCVVTDEVA3pT%2Bpo%2BtNtYJ%2BDWVjd9iV7mKXI06IPMcYX%2Fx9xzqMR3ww0g", multipartFormDataContent).GetAwaiter();
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			TaskAwaiter<HttpResponseMessage> taskAwaiter2;
			taskAwaiter = taskAwaiter2;
			taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
		}
		return taskAwaiter.GetResult().smethod_0()["results"][0]["alternatives"][0]["transcript"].ToString();
	}

	// Token: 0x04000349 RID: 841
	public static Class70 class70_0 = new Class70(null, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", 10, false, true, null, false);

	// Token: 0x020000F8 RID: 248
	[StructLayout(LayoutKind.Auto)]
	private struct Struct55 : IAsyncStateMachine
	{
		// Token: 0x0600065B RID: 1627 RVA: 0x0003600C File Offset: 0x0003420C
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Stream result;
			try
			{
				TaskAwaiter<Stream> awaiter;
				TaskAwaiter<HttpResponseMessage> awaiter2;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = this.taskAwaiter_1;
						this.taskAwaiter_1 = default(TaskAwaiter<Stream>);
						this.int_0 = -1;
						goto IL_CB;
					}
					awaiter2 = Class138.class70_0.method_6(this.string_0, false).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						this.int_0 = 0;
						this.taskAwaiter_0 = awaiter2;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class138.Struct55>(ref awaiter2, ref this);
						return;
					}
				}
				else
				{
					awaiter2 = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
					this.int_0 = -1;
				}
				awaiter = awaiter2.GetResult().Content.ReadAsStreamAsync().GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					this.int_0 = 1;
					this.taskAwaiter_1 = awaiter;
					this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<Stream>, Class138.Struct55>(ref awaiter, ref this);
					return;
				}
				IL_CB:
				result = awaiter.GetResult();
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

		// Token: 0x0600065C RID: 1628 RVA: 0x0000621D File Offset: 0x0000441D
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400034A RID: 842
		public int int_0;

		// Token: 0x0400034B RID: 843
		public AsyncTaskMethodBuilder<Stream> asyncTaskMethodBuilder_0;

		// Token: 0x0400034C RID: 844
		public string string_0;

		// Token: 0x0400034D RID: 845
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;

		// Token: 0x0400034E RID: 846
		private TaskAwaiter<Stream> taskAwaiter_1;
	}

	// Token: 0x020000F9 RID: 249
	[StructLayout(LayoutKind.Auto)]
	private struct Struct56 : IAsyncStateMachine
	{
		// Token: 0x0600065D RID: 1629 RVA: 0x0003612C File Offset: 0x0003432C
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			string result;
			try
			{
				TaskAwaiter<HttpResponseMessage> awaiter;
				if (num != 0)
				{
					StringContent stringContent = new StringContent("{\"part_content_type\":\"audio/mp3\"}");
					stringContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
					ByteArrayContent byteArrayContent = new ByteArrayContent(this.stream_0.smethod_5());
					byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/mp3");
					MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
					multipartFormDataContent.Add(stringContent, "metadata");
					multipartFormDataContent.Add(byteArrayContent, "upload");
					awaiter = Class138.class70_0.httpClient_0.PostAsync("https://stream.watsonplatform.net/speech-to-text/api/v1/recognize?model=en-US_BroadbandModel&watson-token=BRa%2FfWRDE6nKLG333F1gCNBsuOBO%2BU95UL7RJagmzJWjPHB8i8ctyFl2mhxroYHYciVCUDCdE6aKw3QTkTzOlZS4TY854iWJvGpNZHAMl%2FNfYV71X3EhM8CUOkcr%2Ba9KNstMVoZZ9yCehiJ2sRqGy4mXrPMUUYUBBEv7XV2HhxQwZExs7pBHfJwU01DaZg9TRlrQwTJPuaKNpnPoMRhfLgiaTjPWNHs97dDKo3VKsD%2B61kIDPtnFJBg4cxka5i5pArstGtT0V7zDtav2%2FedRZJJTKp%2FRBBqCwcEPbSnuZMUfjDE5cvbn5qpb14pl4SF3KKzAj5USiLhST041QK2I%2BOGd6xZtHw%2BeS6YD%2BifiMqZKNVHNjo%2Bm6qOeBNdpuUJaho6CL%2FNxbegj9fZsrSb4jc6ykdR2pRYqZVM90eBISq5GtA3yL3mDYx0ZQ9LVxmAfA5b8cO4WgV%2FsdnCIvHcJRAIe%2BV%2BM9xvkFfUW2stw2qO58F8%2FLXKjOx9UvXCgBAY7awHm2NIY2PZkHADUhuVYqnwjSN%2FIe4U46PTUFz7oydn3y5AChXTspfqEFXtFueShCIvitWOMN4DmbEOzJ8Ykwq80KFIopg%2BD4gzpsXp22H6qvnKHByrZlW1Bx0F1GV0DHwO1qAlpj5Q%2Fv4hHeR2mrpMfx5HbwmMzFU7%2BBgjj%2BJ7khNew0Oe0MnR2RWroM6DDjLzpaJDCQBXeEKirb6LlChsvU%2Fu9%2BTj4ZZaBDxwjyfkcu9kdPucrXzkUB20nISWBkPuSfcTeKg5dtJOf3%2BINZwn19G2seFB3CFsPyU2zOIytC9y1%2FRY8%2FdEvFB%2FhLyTAJfowrt8zZ2JVHfWATnUQ5YQLVty79ucUEfMEEUpBM9oTtfk8nS1tzOgZNckZfw7T2MnzlqoIdoBafRq%2BVkz7NGmT4YoNqGUklNLZwMvkhGG7RnDJgZkDviJd8dGqboRij2UiuHpjWPEHsX9GZqmZ3uirr0SGDXKCVVTDEVA3pT%2Bpo%2BtNtYJ%2BDWVjd9iV7mKXI06IPMcYX%2Fx9xzqMR3ww0g", multipartFormDataContent).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						this.int_0 = 0;
						this.taskAwaiter_0 = awaiter;
						this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, Class138.Struct56>(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = this.taskAwaiter_0;
					this.taskAwaiter_0 = default(TaskAwaiter<HttpResponseMessage>);
					this.int_0 = -1;
				}
				result = awaiter.GetResult().smethod_0()["results"][0]["alternatives"][0]["transcript"].ToString();
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

		// Token: 0x0600065E RID: 1630 RVA: 0x0000622B File Offset: 0x0000442B
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x0400034F RID: 847
		public int int_0;

		// Token: 0x04000350 RID: 848
		public AsyncTaskMethodBuilder<string> asyncTaskMethodBuilder_0;

		// Token: 0x04000351 RID: 849
		public Stream stream_0;

		// Token: 0x04000352 RID: 850
		private TaskAwaiter<HttpResponseMessage> taskAwaiter_0;
	}
}
