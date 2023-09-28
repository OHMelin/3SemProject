using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.WFORM
{
    internal class MainPanel
    {
        static MainPanel instance = null;
        static MainForm mainForm = null;

        public static MainPanel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainPanel();
            }
            if (mainForm == null)
            {
                throw new Exception("Main form reference not set");
            }
            return instance;
        }

        public static MainPanel GetInstance(MainForm form)
        {
            mainForm = form;
            return GetInstance();
        }

        public void DeleteFlight(int? id)
        {
            if (((ListBox)mainForm.Controls["MainPnl"].Controls["FlightLst"]).SelectedIndex != -1 && id != null)
            {
                mainForm._apiClientFlight.DeleteFlight((int)id);
                new InformationForm().ShowInformationForm("Deleted");
            } 
        }

        public void ItemSelected(ListBox flightList)
        {
            if (flightList.SelectedIndex != -1)
            {
                mainForm.Controls["MainPnl"].Controls["ButtonPnl"].Controls["EditBtn"].Enabled = true;
                mainForm.Controls["MainPnl"].Controls["ButtonPnl"].Controls["DeleteBtn"].Enabled = true;
            }
            else
            {
                mainForm.Controls["MainPnl"].Controls["ButtonPnl"].Controls["EditBtn"].Enabled = false;
                mainForm.Controls["MainPnl"].Controls["ButtonPnl"].Controls["DeleteBtn"].Enabled = false;
            }
        }

        public void OnLoad(ListBox flightList)
        {

            if (mainForm.Controls["MainPnl"].Visible)
            {
                Task.Run(() => GetFlightsAndFillListWorker(flightList));
            }
        }

        private void GetFlightsAndFillListWorker(ListBox flightList)
        {
            List<Models.FlightListItem> flightListItems = GetFlightListItems().ToList();
            UpdateFlightList(flightList, flightListItems);
        }

        private void UpdateFlightList(ListBox flightList, IEnumerable<Models.FlightListItem> items)
        {
            if(flightList.InvokeRequired)
            {
                flightList.Invoke(new Action(() => UpdateFlightList(flightList, items)));
            }
            else
            {
                flightList.Items.Clear();
                foreach (var item in items) 
                {
                    flightList.Items.Add(item);
                }
            }
        }

        public IEnumerable<Models.FlightListItem> GetFlightListItems()
        {
            List<Models.FlightListItem> result = new List<Models.FlightListItem>();

            List<ClassLibraryModelLayer.Flight> flights = mainForm._apiClientFlight.GetAllFlights().ToList();
            foreach (var flight in flights)
            {
                if(flight != null)
                {
                    result.Add(new Models.FlightListItem(flight.FlightId, flight.Plane.PlaneModel.ModelName, flight.ArrivalDate, flight.DepartureDate, flight.Destination.City));
                }
            }
            return result;
        }
    }
}
