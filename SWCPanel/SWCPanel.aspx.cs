using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SWCPanel
{
    public partial class SWCPanel : System.Web.UI.Page
    {
		private static HttpClient client;
		public static panelData panel;

		protected void Page_Load(object sender, EventArgs e)
        {
			client = new HttpClient();
			panelData panel = new panelData();
		}

        protected void btnUpdateTime_Click(object sender, EventArgs e)
        {

        }
		

		static async Task RunAsync()
		{
			
			client.BaseAddress = new Uri("https://www.swcombine.com/ws/v1.0/api/");
			client.DefaultRequestHeaders.Accept.Clear();

		}

		static async void pullCGT()
		{

			//URL: https://www.swcombine.com/ws/v1.0/api/time/cgt/
			//Method: GET
			//Description:	Gets the current Combine Galactic Time
			//Requires Authentication:	No
			//Permissions:	N / A
			//Returns: 200 OK: Returns current CGT value

			DateTime temp;

			var responseTask = client.GetAsync("time/cgt/");
			responseTask.Wait();

			var result = responseTask.Result;
			if (result.IsSuccessStatusCode)
			{

				var readTask = result.Content.ReadAsAsync(DateTime);
				readTask.Wait();

				
			}
		}

		static async void convertCGT()
		{
			DateTime current = DateTime.Now;
			var responseTask = client.PostAsync("time/cgt/", current);
			responseTask.Wait();

			var result = responseTask.Result;
			if (result.IsSuccessStatusCode)
			{

				var readTask = result.Content.ReadAsAsync(DateTime);
				readTask.Wait();

				panel.CGT = readTask.Result;
				return temp;
			}
		}

	}

	public class panelData
    {
		public DateTime CGT;

        panelData()
        {
			CGT = DateTime.Now;
        }
	}
}