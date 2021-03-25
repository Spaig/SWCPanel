using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SWCPanel { 


public partial class SWCPanel : System.Web.UI.Page
{
		public DateTime CGT { get; set; }
	}

class Program { 
	

		static HttpClient client = new HttpClient();

	static async Task RunAsync()
	{
		client.BaseAddress = new Uri("https://www.swcombine.com/ws/v1.0/api/");
		CGT = getCGT();
	}

	static async getCGT(){

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

			temp = readTask.Result;
			return temp;
		}}

	static async convertCGT()
    {
		DateTime current = DateTime.Now;
		var responseTask = client.PostAsync("time/cgt/",current);
		responseTask.Wait();

		var result = responseTask.Result;
		if (result.IsSuccessStatusCode)
		{

			var readTask = result.Content.ReadAsAsync(DateTime);
			readTask.Wait();

			temp = readTask.Result;
			return temp;
		}}

    }
}
}