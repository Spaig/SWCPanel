using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Globalization;

namespace SWCPanel
{
    public partial class SWCPanel : System.Web.UI.Page
    {
		private static HttpClient client;
		public static panelData panel;

		protected void Page_Load(object sender, EventArgs e)
        {
			client = new HttpClient();
			client.BaseAddress = new Uri("https://www.swcombine.com/ws/v1.0/api/");
			client.DefaultRequestHeaders.Accept.Clear();
			panelData panel = new panelData();
			lblSET.Text = DateTime.Now.ToString();
		}

        protected void btnUpdateTime_Click(object sender, EventArgs e)
        {
			pullCGT();
			//TODO patch this for actual async method
		}


		static async Task RunAsync()
		{
			
			
			

		}

		static async void pullCGT()
		{

			//URL: https://www.swcombine.com/ws/v1.0/api/time/cgt/
			//Method: GET
			//Description:	Gets the current Combine Galactic Time
			//Requires Authentication:	No
			//Permissions:	N / A
			//Returns: 200 OK: Returns current CGT value

			var responseTask = client.GetAsync("time/cgt/");
			responseTask.Wait();

			var result = responseTask.Result;
			if (result.IsSuccessStatusCode)
			{

				var readTask = result.Content.ReadAsStringAsync();
				readTask.Wait();
				

				String holderString = readTask.Result;
				var cultureInfo = new CultureInfo("en-US");
				panel.CGT = DateTime.Parse(holderString, cultureInfo);

			}

			
		}

		static async void convertCGT()
		{
			String current = DateTime.Now.ToString();
			var sendContent = new StringContent(current);
			var responseTask = client.PostAsync("time/cgt/", sendContent);
			responseTask.Wait();

			var result = responseTask.Result;
			if (result.IsSuccessStatusCode)
			{

				var readTask = result.Content.ReadAsStringAsync();
				readTask.Wait();

				String holderString = readTask.Result;
				var cultureInfo = new CultureInfo("en-US");
				panel.CGT = DateTime.Parse(holderString, cultureInfo);
			}
		}

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class panelData
    {
		public DateTime CGT;//combine galactic time
		public DateTime SET;//standard earth time

        public panelData()
        {
			CGT = DateTime.UtcNow;
			SET = DateTime.Now;
        }
	}
}