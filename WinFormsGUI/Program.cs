namespace FlyBooking.WFORM
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			ApplicationConfiguration.Initialize();
			MainForm mainForm = new MainForm(	new FlyBooking.APIClient.FlightAPIClient("https://localhost:7241/api/Flights"),
                                                new FlyBooking.APIClient.DestinationAPIClient("https://localhost:7241/api/Destinations"),
                                                new FlyBooking.APIClient.PlaneAPIClient("https://localhost:7241/api/Planes"),
												new FlyBooking.APIClient.PlaneModelAPIClient("https://localhost:7241/api/PlaneModels"));
			FlightInfoPanel.GetInstance(mainForm);
			MainPanel.GetInstance(mainForm);
			LoginPanel.GetInstance(mainForm);
            		Application.Run(mainForm);
		}		
	}
}
