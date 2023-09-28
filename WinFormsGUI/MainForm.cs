using System.Diagnostics;
using ClassLibraryModelLayer;
using FlyBooking.Model;

namespace FlyBooking.WFORM
{
	public partial class MainForm : Form
	{
		const int PANEL_HISTORY_MAX_SIZE = 5;

		List<Panel> _panelHistory = new List<Panel>();

        Panel? _activePanel = null;

		List<Panel> _panels = new List<Panel>();

        internal readonly FlyBooking.APIClient.IFlightAPIClient _apiClientFlight;
        internal readonly FlyBooking.APIClient.IDestinationAPIClient _apiClientDestination;
        internal readonly FlyBooking.APIClient.IPlaneAPIClient _apiClientPlane;
		internal readonly FlyBooking.APIClient.IPlaneModelAPIClient _apiClientPlaneModel;

        public MainForm(	FlyBooking.APIClient.IFlightAPIClient apiClientFlight, 
							FlyBooking.APIClient.IDestinationAPIClient apiClientDestination,
							FlyBooking.APIClient.IPlaneAPIClient apiClientPlane,
							FlyBooking.APIClient.IPlaneModelAPIClient apiClientPlaneModel)
		{
			_apiClientFlight = apiClientFlight;
			_apiClientDestination = apiClientDestination;
			_apiClientPlane = apiClientPlane;
			_apiClientPlaneModel = apiClientPlaneModel;

			InitializeComponent();

			_panels.Add(LoginPnl);
			_panels.Add(MainPnl);
			_panels.Add(FlightInfoPnl);

			ArrivalDt.Format = DateTimePickerFormat.Custom;
			ArrivalDt.CustomFormat = "MM/dd/yyyy hh:mm";
            DepartureDt.Format = DateTimePickerFormat.Custom;
            DepartureDt.CustomFormat = "MM/dd/yyyy hh:mm";

            SwitchPanel(LoginPnl);

			BackBtn.Click += (_, _) => Back();
			LoginBtn.Click += (_,_) => Login();
			CreateNewbtn.Click += (_,_) => NewFlight();
			EditBtn.Click += (_, _) => UpdateFlight();

			SubmitBtn.Click += (_, _) => FlightInfoPanel.GetInstance().Submit();

			MainPnl.VisibleChanged += (_, _) => MainPanel.GetInstance().OnLoad(FlightLst);
			DeleteBtn.Click += (_, _) => MainPanel.GetInstance().DeleteFlight(((Models.FlightListItem)FlightLst.SelectedItem).Id);
			FlightLst.SelectedIndexChanged += (_, _) => MainPanel.GetInstance().ItemSelected(FlightLst);

			//System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;


            LoadFromDAL();
        }

		void LoadFromDAL()
		{
			foreach (Destination destination in _apiClientDestination.GetAllDestinations())
			{
				DestinationCb.Items.Add(new Models.DestinationListItem((int)destination.DestinationID, (string)destination.City));
			}

            foreach (Plane plane in _apiClientPlane.GetAllPlanes())
            {
				PlaneCb.Items.Add(new Models.PlaneListItem((int)plane.PlaneID, plane.PlaneModel.ModelName));
            }
        }

		void Back()
		{
			//new InformationForm().ShowInformationForm("Are you sure you want that?");
            if (_panelHistory.Count != 0)
			{
				EnablePanel(_panelHistory[_panelHistory.Count - 1]);
				if(_activePanel != null)
				{
                    DisablePanel(_activePanel);
                }
				_activePanel = _panelHistory[_panelHistory.Count - 1];
				_panelHistory.Remove(_panelHistory.Last());
			}
		}

        void Login()
        {
			SwitchPanel(MainPnl);
        }

		void NewFlight()
		{
            FlightInfoPanel.GetInstance().SetUpdate(-1);
            SwitchPanel(FlightInfoPnl);
		}

        void UpdateFlight()
		{
            FlightInfoPanel.GetInstance().SetUpdate((int)((Models.FlightListItem)FlightLst.SelectedItem).Id);
            SwitchPanel(FlightInfoPnl);
		}

        void SwitchPanel(Panel panel) 
		{
			EnablePanel(panel);
			if (_activePanel != null)
			{
                DisablePanel(_activePanel);
                AddToPanelHistory(_activePanel);
            }
			_activePanel = panel;
		}

        public void SwitchPanel(int index)
        {
			EnablePanel(_panels[index]);
            if (_activePanel != null)
            {
                DisablePanel(_activePanel);
                AddToPanelHistory(_activePanel);
            }
            _activePanel = _panels[index];
        }

        void AddToPanelHistory(Panel previousPanel)
		{
			if(_panelHistory.Count > PANEL_HISTORY_MAX_SIZE)
			{
				_panelHistory.Remove(_panelHistory.First());
			}

			_panelHistory.Add(previousPanel);
        }

		void EnablePanel(Panel panel) 
		{
			panel.Enabled = true;
			panel.Visible = true;
		}
        void DisablePanel(Panel panel)
        {
            panel.Enabled = false;
            panel.Visible = false;
        }
    }
}