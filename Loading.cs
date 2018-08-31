using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using EO.WebBrowser;
using EO.WebEngine;

// Token: 0x020000BE RID: 190
public sealed partial class Loading : Form
{
	// Token: 0x060004F0 RID: 1264 RVA: 0x00028508 File Offset: 0x00026708
	public Loading(bool bool_2 = false, string string_2 = null)
	{
		this.InitializeComponent();
		this.bool_1 = bool_2;
		this.string_1 = string_2;
		BrowserOptions options = new BrowserOptions
		{
			EnableWebSecurity = new bool?(false),
			LoadImages = new bool?(true)
		};
		this.webView_0 = new WebView();
		this.webView_0.SetOptions(options);
		this.webView_0.Create(base.Handle);
		base.Size = new Size(600, 400);
		Loading.string_0 = "<!DOCTYPE html>\r\n<html lang=\"en\" >\r\n\r\n<head>\r\n <meta charset=\"UTF-8\">\r\n <title>Prism Loading Screen</title>\r\n \r\n <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css\">\r\n\r\n \r\n <style>\r\n body {\r\n -webkit-font-smoothing: antialiased;\r\n text-rendering: optimizeLegibility;\r\n font-family: \"proxima-nova-soft\", sans-serif;\r\n -webkit-user-select: none;\r\n overflow: hidden;\r\n}\r\nbody .vertical-centered-box {\r\n position: absolute;\r\n width: 100%;\r\n height: 100%;\r\n text-align: center;\r\n}\r\nbody .vertical-centered-box:after {\r\n content: '';\r\n display: inline-block;\r\n height: 100%;\r\n vertical-align: middle;\r\n margin-right: -0.25em;\r\n}\r\nbody .vertical-centered-box .content {\r\n -webkit-box-sizing: border-box;\r\n -moz-box-sizing: border-box;\r\n box-sizing: border-box;\r\n display: inline-block;\r\n vertical-align: middle;\r\n text-align: left;\r\n font-size: 0;\r\n}\r\n\r\n* {\r\n -webkit-transition: all 0.3s;\r\n -moz-transition: all 0.3s;\r\n -o-transition: all 0.3s;\r\n transition: all 0.3s;\r\n}\r\nbody {\r\n background: #201E26;\r\n}\r\n.loader-circle {\r\n position: absolute;\r\n left: 50%;\r\n top: 50%;\r\n width: 120px;\r\n height: 120px;\r\n border-radius: 50%;\r\n box-shadow: inset 0 0 0 1px rgba(255, 255, 255, 0.1);\r\n margin-left: -60px;\r\n margin-top: -60px;\r\n}\r\n#message{ \r\n opacity:0;\r\n transition: opacity 2s;\r\n -webkit-transition: opacity 1s; /* Safari */\r\n}\r\n.loader-line-mask {\r\n position: absolute;\r\n left: 50%;\r\n top: 50%;\r\n width: 60px;\r\n height: 120px;\r\n margin-left: -60px;\r\n margin-top: -60px;\r\n overflow: hidden;\r\n -webkit-transform-origin: 60px 60px;\r\n -moz-transform-origin: 60px 60px;\r\n -ms-transform-origin: 60px 60px;\r\n -o-transform-origin: 60px 60px;\r\n transform-origin: 60px 60px;\r\n -webkit-mask-image: -webkit-linear-gradient(top, #000000, rgba(0, 0, 0, 0));\r\n -webkit-animation: rotate 1.2s infinite linear;\r\n -moz-animation: rotate 1.2s infinite linear;\r\n -o-animation: rotate 1.2s infinite linear;\r\n animation: rotate 1.2s infinite linear;\r\n}\r\n.loader-line-mask .loader-line {\r\n width: 120px;\r\n height: 120px;\r\n border-radius: 50%;\r\n box-shadow: inset 0 0 0 1px rgba(255, 255, 255, 0.5);\r\n}\r\n#particles-background,\r\n#particles-foreground {\r\n left: -51%;\r\n top: -51%;\r\n width: 202%;\r\n height: 202%;\r\n -webkit-transform: scale3d(0.5, 0.5, 1);\r\n -moz-transform: scale3d(0.5, 0.5, 1);\r\n -ms-transform: scale3d(0.5, 0.5, 1);\r\n -o-transform: scale3d(0.5, 0.5, 1);\r\n transform: scale3d(0.5, 0.5, 1);\r\n}\r\n#particles-background {\r\n background: #2c2d44;\r\n background-image: -moz-linear-gradient(45deg, #3f3251 2%, #002025 100%);\r\n background-image: -webkit-linear-gradient(45deg, #3f3251 2%, #002025 100%);\r\n background-image: linear-gradient(45deg, #3f3251 2%, #002025 100%);\r\n}\r\nlesshat-selector {\r\n -lh-property: 0; } \r\n@-webkit-keyframes rotate{ 0% { -webkit-transform: rotate(0deg);} 100% { -webkit-transform: rotate(360deg);}}\r\n@-moz-keyframes rotate{ 0% { -moz-transform: rotate(0deg);} 100% { -moz-transform: rotate(360deg);}}\r\n@-o-keyframes rotate{ 0% { -o-transform: rotate(0deg);} 100% { -o-transform: rotate(360deg);}}\r\n@keyframes rotate{ 0% {-webkit-transform: rotate(0deg);-moz-transform: rotate(0deg);-ms-transform: rotate(0deg);transform: rotate(0deg);} 100% {-webkit-transform: rotate(360deg);-moz-transform: rotate(360deg);-ms-transform: rotate(360deg);transform: rotate(360deg);}}\r\n[not-existing] {\r\n zoom: 1;\r\n}\r\nlesshat-selector {\r\n -lh-property: 0; } \r\n@-webkit-keyframes fade{ 0% { opacity: 1;} 50% { opacity: 0.25;}}\r\n@-moz-keyframes fade{ 0% { opacity: 1;} 50% { opacity: 0.25;}}\r\n@-o-keyframes fade{ 0% { opacity: 1;} 50% { opacity: 0.25;}}\r\n@keyframes fade{ 0% { opacity: 1;} 50% { opacity: 0.25;}}\r\n[not-existing] {\r\n zoom: 1;\r\n}\r\nlesshat-selector {\r\n -lh-property: 0; } \r\n@-webkit-keyframes fade-in{ 0% { opacity: 0;} 100% { opacity: 1;}}\r\n@-moz-keyframes fade-in{ 0% { opacity: 0;} 100% { opacity: 1;}}\r\n@-o-keyframes fade-in{ 0% { opacity: 0;} 100% { opacity: 1;}}\r\n@keyframes fade-in{ 0% { opacity: 0;} 100% { opacity: 1;}}\r\n[not-existing] {\r\n zoom: 1;\r\n}\r\n</style>\r\n\r\n \r\n</head>\r\n\r\n<body>\r\n <div id=\"message\" style=\"position: absolute;\r\n top: 50%;\r\n left: 50%;\r\n transform: translateX(-50%) translateY(600%);\r\n color: white;\r\n font-family: Poppins, sans-serif!important;\r\n font-weight: bold;\r\n font-size: 14px\">test</div>\r\n\r\n<div id=\"particles-foreground\" class=\"vertical-centered-box\"></div>\r\n\r\n<div class=\"vertical-centered-box\">\r\n <div class=\"content\">\r\n <div class=\"loader-circle\"></div>\r\n <div class=\"loader-line-mask\">\r\n <div class=\"loader-line\"></div>\r\n </div>\r\n <img src=\"images/globe.png\" width=\"100px\" height=\"70px\">\r\n </div>\r\n</div>\r\n \r\n \r\n\r\n <script src=\"js/index.js\"></script>\r\n\r\n\r\n\r\n\r\n</body>\r\n<script>\r\n /*!\r\n * Particleground\r\n *\r\n * @author Jonathan Nicol - @mrjnicol\r\n * @version 1.1.0\r\n * @description Creates a canvas based particle system background\r\n *\r\n * Inspired by http://requestlab.fr/ and http://disruptivebydesign.com/\r\n */\r\n!function(a,b){\"use strict\";function c(a){a=a||{};for(var b=1;b<arguments.length;b++){var c=arguments[b];if(c)for(var d in c)c.hasOwnProperty(d)&&(\"object\"==typeof c[d]?deepExtend(a[d],c[d]):a[d]=c[d])}return a}function d(d,g){function h(){if(y){r=b.createElement(\"canvas\"),r.className=\"pg-canvas\",r.style.display=\"block\",d.insertBefore(r,d.firstChild),s=r.getContext(\"2d\"),i();for(var c=Math.round(r.width*r.height/g.density),e=0;c>e;e++){var f=new n;f.setStackPos(e),z.push(f)}a.addEventListener(\"resize\",function(){k()},!1),b.addEventListener(\"mousemove\",function(a){A=a.pageX,B=a.pageY},!1),D&&!C&&a.addEventListener(\"deviceorientation\",function(){F=Math.min(Math.max(-event.beta,-30),30),E=Math.min(Math.max(-event.gamma,-30),30)},!0),j(),q(\"onInit\")}}function i(){r.width=d.offsetWidth,r.height=d.offsetHeight,s.fillStyle=g.dotColor,s.strokeStyle=g.lineColor,s.lineWidth=g.lineWidth}function j(){if(y){u=a.innerWidth,v=a.innerHeight,s.clearRect(0,0,r.width,r.height);for(var b=0;b<z.length;b++)z[b].updatePosition();for(var b=0;b<z.length;b++)z[b].draw();G||(t=requestAnimationFrame(j))}}function k(){i();for(var a=d.offsetWidth,b=d.offsetHeight,c=z.length-1;c>=0;c--)(z[c].position.x>a||z[c].position.y>b)&&z.splice(c,1);var e=Math.round(r.width*r.height/g.density);if(e>z.length)for(;e>z.length;){var f=new n;z.push(f)}else e<z.length&&z.splice(e);for(c=z.length-1;c>=0;c--)z[c].setStackPos(c)}function l(){G=!0}function m(){G=!1,j()}function n(){switch(this.stackPos,this.active=!0,this.layer=Math.ceil(3*Math.random()),this.parallaxOffsetX=0,this.parallaxOffsetY=0,this.position={x:Math.ceil(Math.random()*r.width),y:Math.ceil(Math.random()*r.height)},this.speed={},g.directionX){case\"left\":this.speed.x=+(-g.maxSpeedX+Math.random()*g.maxSpeedX-g.minSpeedX).toFixed(2);break;case\"right\":this.speed.x=+(Math.random()*g.maxSpeedX+g.minSpeedX).toFixed(2);break;default:this.speed.x=+(-g.maxSpeedX/2+Math.random()*g.maxSpeedX).toFixed(2),this.speed.x+=this.speed.x>0?g.minSpeedX:-g.minSpeedX}switch(g.directionY){case\"up\":this.speed.y=+(-g.maxSpeedY+Math.random()*g.maxSpeedY-g.minSpeedY).toFixed(2);break;case\"down\":this.speed.y=+(Math.random()*g.maxSpeedY+g.minSpeedY).toFixed(2);break;default:this.speed.y=+(-g.maxSpeedY/2+Math.random()*g.maxSpeedY).toFixed(2),this.speed.x+=this.speed.y>0?g.minSpeedY:-g.minSpeedY}}function o(a,b){return b?void(g[a]=b):g[a]}function p(){console.log(\"destroy\"),r.parentNode.removeChild(r),q(\"onDestroy\"),f&&f(d).removeData(\"plugin_\"+e)}function q(a){void 0!==g[a]&&g[a].call(d)}var r,s,t,u,v,w,x,y=!!b.createElement(\"canvas\").getContext,z=[],A=0,B=0,C=!navigator.userAgent.match(/(iPhone|iPod|iPad|Android|BlackBerry|BB10|mobi|tablet|opera mini|nexus 7)/i),D=!!a.DeviceOrientationEvent,E=0,F=0,G=!1;return g=c({},a[e].defaults,g),n.prototype.draw=function(){s.beginPath(),s.arc(this.position.x+this.parallaxOffsetX,this.position.y+this.parallaxOffsetY,g.particleRadius/2,0,2*Math.PI,!0),s.closePath(),s.fill(),s.beginPath();for(var a=z.length-1;a>this.stackPos;a--){var b=z[a],c=this.position.x-b.position.x,d=this.position.y-b.position.y,e=Math.sqrt(c*c+d*d).toFixed(2);e<g.proximity&&(s.moveTo(this.position.x+this.parallaxOffsetX,this.position.y+this.parallaxOffsetY),g.curvedLines?s.quadraticCurveTo(Math.max(b.position.x,b.position.x),Math.min(b.position.y,b.position.y),b.position.x+b.parallaxOffsetX,b.position.y+b.parallaxOffsetY):s.lineTo(b.position.x+b.parallaxOffsetX,b.position.y+b.parallaxOffsetY))}s.stroke(),s.closePath()},n.prototype.updatePosition=function(){if(g.parallax){if(D&&!C){var a=(u-0)/60;w=(E- -30)*a+0;var b=(v-0)/60;x=(F- -30)*b+0}else w=A,x=B;this.parallaxTargX=(w-u/2)/(g.parallaxMultiplier*this.layer),this.parallaxOffsetX+=(this.parallaxTargX-this.parallaxOffsetX)/10,this.parallaxTargY=(x-v/2)/(g.parallaxMultiplier*this.layer),this.parallaxOffsetY+=(this.parallaxTargY-this.parallaxOffsetY)/10}var c=d.offsetWidth,e=d.offsetHeight;switch(g.directionX){case\"left\":this.position.x+this.speed.x+this.parallaxOffsetX<0&&(this.position.x=c-this.parallaxOffsetX);break;case\"right\":this.position.x+this.speed.x+this.parallaxOffsetX>c&&(this.position.x=0-this.parallaxOffsetX);break;default:(this.position.x+this.speed.x+this.parallaxOffsetX>c||this.position.x+this.speed.x+this.parallaxOffsetX<0)&&(this.speed.x=-this.speed.x)}switch(g.directionY){case\"up\":this.position.y+this.speed.y+this.parallaxOffsetY<0&&(this.position.y=e-this.parallaxOffsetY);break;case\"down\":this.position.y+this.speed.y+this.parallaxOffsetY>e&&(this.position.y=0-this.parallaxOffsetY);break;default:(this.position.y+this.speed.y+this.parallaxOffsetY>e||this.position.y+this.speed.y+this.parallaxOffsetY<0)&&(this.speed.y=-this.speed.y)}this.position.x+=this.speed.x,this.position.y+=this.speed.y},n.prototype.setStackPos=function(a){this.stackPos=a},h(),{option:o,destroy:p,start:m,pause:l}}var e=\"particleground\",f=a.jQuery;a[e]=function(a,b){return new d(a,b)},a[e].defaults={minSpeedX:.1,maxSpeedX:.7,minSpeedY:.1,maxSpeedY:.7,directionX:\"center\",directionY:\"center\",density:1e4,dotColor:\"#666666\",lineColor:\"#666666\",particleRadius:7,lineWidth:1,curvedLines:!1,proximity:100,parallax:!0,parallaxMultiplier:5,onInit:function(){},onDestroy:function(){}},f&&(f.fn[e]=function(a){if(\"string\"==typeof arguments[0]){var b,c=arguments[0],g=Array.prototype.slice.call(arguments,1);return this.each(function(){f.data(this,\"plugin_\"+e)&&\"function\"==typeof f.data(this,\"plugin_\"+e)[c]&&(b=f.data(this,\"plugin_\"+e)[c].apply(this,g))}),void 0!==b?b:this}return\"object\"!=typeof a&&a?void 0:this.each(function(){f.data(this,\"plugin_\"+e)||f.data(this,\"plugin_\"+e,new d(this,a))})})}(window,document),/**\r\n * requestAnimationFrame polyfill by Erik Möller. fixes from Paul Irish and Tino Zijdel\r\n * @see: http://paulirish.com/2011/requestanimationframe-for-smart-animating/\r\n * @see: http://my.opera.com/emoller/blog/2011/12/20/requestanimationframe-for-smart-er-animating\r\n * @license: MIT license\r\n */\r\nfunction(){for(var a=0,b=[\"ms\",\"moz\",\"webkit\",\"o\"],c=0;c<b.length&&!window.requestAnimationFrame;++c)window.requestAnimationFrame=window[b[c]+\"RequestAnimationFrame\"],window.cancelAnimationFrame=window[b[c]+\"CancelAnimationFrame\"]||window[b[c]+\"CancelRequestAnimationFrame\"];window.requestAnimationFrame||(window.requestAnimationFrame=function(b){var c=(new Date).getTime(),d=Math.max(0,16-(c-a)),e=window.setTimeout(function(){b(c+d)},d);return a=c+d,e}),window.cancelAnimationFrame||(window.cancelAnimationFrame=function(a){clearTimeout(a)})}();\r\n\r\n\r\nparticleground(document.getElementById('particles-foreground'), {\r\n dotColor: 'rgba(255, 255, 255, 1)',\r\n lineColor: 'rgba(255, 255, 255, 0.05)',\r\n minSpeedX: 0.3,\r\n maxSpeedX: 0.6,\r\n minSpeedY: 0.3,\r\n maxSpeedY: 0.6,\r\n density: 50000, // One particle every n pixels\r\n curvedLines: false,\r\n proximity: 250, // How close two dots need to be before they join\r\n parallaxMultiplier: 10, // Lower the number is more extreme parallax\r\n particleRadius: 4, // Dot size\r\n});\r\n\r\nparticleground(document.getElementById('particles-background'), {\r\n dotColor: 'rgba(255, 255, 255, 0.5)',\r\n lineColor: 'rgba(255, 255, 255, 0.05)',\r\n minSpeedX: 0.075,\r\n maxSpeedX: 0.15,\r\n minSpeedY: 0.075,\r\n maxSpeedY: 0.15,\r\n density: 30000, // One particle every n pixels\r\n curvedLines: false,\r\n proximity: 20, // How close two dots need to be before they join\r\n parallaxMultiplier: 20, // Lower the number is more extreme parallax\r\n particleRadius: 2, // Dot size\r\n});\r\n</script>\r\n</html>\r\n";
		this.webView_0.LoadHtml(Loading.string_0, "file:///" + Directory.GetCurrentDirectory() + "/");
		this.webView_0.LoadCompleted += this.webView_0_LoadCompleted;
		if (bool_2)
		{
			this.method_0(new EventHandler(this.method_7));
		}
	}

	// Token: 0x060004F2 RID: 1266 RVA: 0x000285FC File Offset: 0x000267FC
	public void method_0(EventHandler eventHandler_1)
	{
		EventHandler eventHandler = this.eventHandler_0;
		EventHandler eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_1);
			eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, value, eventHandler2);
		}
		while (eventHandler != eventHandler2);
	}

	// Token: 0x060004F3 RID: 1267 RVA: 0x00028634 File Offset: 0x00026834
	public void method_1(EventHandler eventHandler_1)
	{
		EventHandler eventHandler = this.eventHandler_0;
		EventHandler eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, eventHandler_1);
			eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, value, eventHandler2);
		}
		while (eventHandler != eventHandler2);
	}

	// Token: 0x060004F4 RID: 1268 RVA: 0x00005452 File Offset: 0x00003652
	protected override void SetVisibleCore(bool value)
	{
		base.SetVisibleCore(this.bool_0 ? value : this.bool_0);
	}

	// Token: 0x060004F5 RID: 1269 RVA: 0x0002866C File Offset: 0x0002686C
	private void webView_0_LoadCompleted(object sender, LoadCompletedEventArgs e)
	{
		Thread.Sleep(500);
		this.method_2();
		this.webView_0.RegisterJSExtensionFunction("close", new JSExtInvokeHandler(this.method_8));
		this.webView_0.RegisterJSExtensionFunction("retry", new JSExtInvokeHandler(this.method_9));
	}

	// Token: 0x060004F6 RID: 1270 RVA: 0x000286C4 File Offset: 0x000268C4
	public void method_2()
	{
		base.CenterToScreen();
		this.bool_0 = true;
		base.Opacity = 0.0;
		base.Show();
		this.timer_0.Interval = 10;
		this.timer_0.Tick += this.timer_0_Tick;
		this.timer_0.Start();
	}

	// Token: 0x060004F7 RID: 1271 RVA: 0x0000546B File Offset: 0x0000366B
	public void method_3(object sender, EventArgs e)
	{
		this.timer_1.Interval = 10;
		this.timer_1.Tick += this.timer_1_Tick;
		this.timer_1.Start();
	}

	// Token: 0x060004F8 RID: 1272 RVA: 0x00028724 File Offset: 0x00026924
	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (base.Opacity >= 1.0)
		{
			this.timer_0.Stop();
			this.eventHandler_0(this, e);
			return;
		}
		base.Opacity += 0.05;
	}

	// Token: 0x060004F9 RID: 1273 RVA: 0x0000549C File Offset: 0x0000369C
	private void timer_1_Tick(object sender, EventArgs e)
	{
		if (base.Opacity <= 0.0)
		{
			this.timer_1.Dispose();
			base.Hide();
			return;
		}
		base.Opacity -= 0.05;
	}

	// Token: 0x060004FA RID: 1274 RVA: 0x000054D7 File Offset: 0x000036D7
	public void method_4()
	{
		this.webView_0.EvalScript("document.body.innerHTML = \"" + Loading.string_0 + "\"");
	}

	// Token: 0x060004FB RID: 1275 RVA: 0x000054F9 File Offset: 0x000036F9
	public void method_5(string string_2, string string_3)
	{
		this.webView_0.EvalScript(string.Format("document.getElementById('message').innerHTML= '{0}'; document.getElementById('message').style.opacity='1'; document.getElementById('message').style.color = '{1}'", string_2.ToUpper(), string_3));
	}

	// Token: 0x060004FC RID: 1276 RVA: 0x00005518 File Offset: 0x00003718
	public void method_6()
	{
		this.webView_0.EvalScript("document.getElementById('message').style.opacity='0'");
	}

	// Token: 0x060004FD RID: 1277
	public async void method_7(object sender, EventArgs e)
	{
		for (;;)
		{
			try
			{
				string a;
				if (this.string_1 == null)
				{
					if (GClass0.string_2 != null && GClass0.string_2.Length > 5)
					{
						this.method_5("Authenticating license", "white");
						TaskAwaiter<string> taskAwaiter = Licenser.smethod_11(GClass0.string_2, true, false).GetAwaiter();
						bool isCompleted = taskAwaiter.IsCompleted;
						a = taskAwaiter.GetResult();
					}
					else
					{
						this.method_5("Starting", "white");
						a = "none";
					}
				}
				else
				{
					a = this.string_1;
				}
				if (a == "valid")
				{
					this.method_6();
					Thread.Sleep(500);
					this.method_5(string.Format("Welcome back {0}", Licenser.string_0.Split(new char[]
					{
						'#'
					})[0]), "white");
					MainWindow.smethod_0(new EventHandler(this.method_3));
					new MainWindow().Show();
				}
				else
				{
					if (a == "error")
					{
						this.method_5(string.Format("Retrying in {0} seconds", Array.Empty<object>()), "white");
						Thread.Sleep(1000);
						continue;
					}
					MainWindow.smethod_0(new EventHandler(this.method_3));
					new MainWindow().Show();
				}
			}
			catch
			{
				for (int i = 10; i > 0; i--)
				{
					this.method_5(string.Format("Retrying in {0} seconds", i), "white");
					Thread.Sleep(1000);
				}
				continue;
			}
			break;
		}
	}

	// Token: 0x060004FE RID: 1278 RVA: 0x0000552B File Offset: 0x0000372B
	private void method_8(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		base.Close();
	}

	// Token: 0x060004FF RID: 1279 RVA: 0x00005533 File Offset: 0x00003733
	private void method_9(object object_0, JSExtInvokeArgs jsextInvokeArgs_0)
	{
		Process.Start(Application.ExecutablePath);
		Process.GetCurrentProcess().Kill();
	}

	// Token: 0x04000257 RID: 599
	public WebView webView_0;

	// Token: 0x04000258 RID: 600
	public static string string_0 = string.Empty;

	// Token: 0x04000259 RID: 601
	private bool bool_0;

	// Token: 0x0400025A RID: 602
	public bool bool_1;

	// Token: 0x0400025B RID: 603
	private System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();

	// Token: 0x0400025C RID: 604
	private System.Windows.Forms.Timer timer_1 = new System.Windows.Forms.Timer();

	// Token: 0x0400025D RID: 605
	private EventHandler eventHandler_0;

	// Token: 0x0400025E RID: 606
	public string string_1;

	// Token: 0x020000BF RID: 191
	[StructLayout(LayoutKind.Auto)]
	private struct Struct41 : IAsyncStateMachine
	{
		// Token: 0x06000502 RID: 1282 RVA: 0x000288AC File Offset: 0x00026AAC
		void IAsyncStateMachine.MoveNext()
		{
			int num = this.int_0;
			Loading loading = this.loading_0;
			try
			{
				for (;;)
				{
					try
					{
						string a;
						TaskAwaiter<string> awaiter;
						if (num != 0)
						{
							if (loading.string_1 != null)
							{
								a = loading.string_1;
								goto IL_CB;
							}
							if (GClass0.string_2 == null || GClass0.string_2.Length <= 5)
							{
								loading.method_5("Starting", "white");
								a = "none";
								goto IL_CB;
							}
							loading.method_5("Authenticating license", "white");
							awaiter = Licenser.smethod_11(GClass0.string_2, true, false).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								int num2 = 0;
								num = 0;
								this.int_0 = num2;
								this.taskAwaiter_0 = awaiter;
								this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Loading.Struct41>(ref awaiter, ref this);
								return;
							}
						}
						else
						{
							awaiter = this.taskAwaiter_0;
							this.taskAwaiter_0 = default(TaskAwaiter<string>);
							int num3 = -1;
							num = -1;
							this.int_0 = num3;
						}
						a = awaiter.GetResult();
						IL_CB:
						if (a == "valid")
						{
							loading.method_6();
							Thread.Sleep(500);
							loading.method_5(string.Format("Welcome back {0}", Licenser.string_0.Split(new char[]
							{
								'#'
							})[0]), "white");
							MainWindow.smethod_0(new EventHandler(loading.method_3));
							new MainWindow().Show();
						}
						else
						{
							if (a == "error")
							{
								for (int i = 10; i > 0; i--)
								{
									loading.method_5(string.Format("Retrying in {0} seconds", i), "white");
									Thread.Sleep(1000);
								}
								continue;
							}
							Licenser.smethod_0(new EventHandler(loading.method_3));
							new Licenser();
						}
					}
					catch
					{
						for (int j = 10; j > 0; j--)
						{
							loading.method_5(string.Format("Retrying in {0} seconds", j), "white");
							Thread.Sleep(1000);
						}
						continue;
					}
					break;
				}
			}
			catch (Exception exception)
			{
				this.int_0 = -2;
				this.asyncVoidMethodBuilder_0.SetException(exception);
				return;
			}
			this.int_0 = -2;
			this.asyncVoidMethodBuilder_0.SetResult();
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x00005569 File Offset: 0x00003769
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		// Token: 0x04000262 RID: 610
		public int int_0;

		// Token: 0x04000263 RID: 611
		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		// Token: 0x04000264 RID: 612
		public Loading loading_0;

		// Token: 0x04000265 RID: 613
		private TaskAwaiter<string> taskAwaiter_0;
	}
}
