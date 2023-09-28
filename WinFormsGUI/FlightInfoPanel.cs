using ClassLibraryModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.WFORM
{
    internal class FlightInfoPanel
    {
        static FlightInfoPanel instance = null;
        static MainForm mainForm = null;

        private bool updateFlight = false;
        private int updateFlightID = -1;
        Flight updateFlightModel = null;

        DateTimePicker depatureDTP = null;
        DateTimePicker arrivalDTP = null;
        ComboBox planeCB = null;
        ComboBox destinationCB = null;
        TextBox priceTXT = null;
        Label flightIdLBL = null;
        Button submitBTN = null;

        public static FlightInfoPanel GetInstance()
        {
            if(instance == null)
            {
                instance = new FlightInfoPanel();
            }
            if(mainForm == null)
            {
                throw new Exception("Main form reference not set");
            }

            return instance;
        }

        public static FlightInfoPanel GetInstance(MainForm form)
        {
            mainForm = form;
            return GetInstance();
        }

        private FlightInfoPanel()
        {
            depatureDTP = mainForm.Controls["FlightInfoPnl"].Controls["DepartureDt"] as DateTimePicker;
            arrivalDTP = mainForm.Controls["FlightInfoPnl"].Controls["ArrivalDt"] as DateTimePicker;
            planeCB = mainForm.Controls["FlightInfoPnl"].Controls["PlaneCb"] as ComboBox;
            destinationCB = mainForm.Controls["FlightInfoPnl"].Controls["DestinationCb"] as ComboBox;
            priceTXT = mainForm.Controls["FlightInfoPnl"].Controls["FlightPriceTxt"] as TextBox;
            flightIdLBL = mainForm.Controls["FlightInfoPnl"].Controls["FlightIdLbl"] as Label;
            submitBTN = mainForm.Controls["FlightInfoPnl"].Controls["SubmitBtn"] as Button;
        }

        public void Submit()
        {
            if(updateFlight)
            {
                UpdateFlight();
            }
            else
            {
                CreateFlight(   arrivalDTP.Value, depatureDTP.Value, 
                                ((Models.PlaneListItem)planeCB.SelectedItem).PlaneID, 
                                ((Models.DestinationListItem)destinationCB.SelectedItem).DestinationID, 
                                int.Parse(priceTXT.Text));
            }
        }

        public void SetUpdate(int updateID)
        {
            if(updateFlight = updateID >= 0)
            {
                updateFlightID = updateID;
                submitBTN.Text = "Update";
                LoadFlightInfo();
            }
            else
            {
                submitBTN.Text = "Create";
                ClearPanel();
            }

        }

        private void UpdateFlight()
        {
            updateFlightModel.DepartureDate = depatureDTP.Value;
            updateFlightModel.ArrivalDate = arrivalDTP.Value;
            updateFlightModel.DestinationId = ((Models.DestinationListItem)destinationCB.SelectedItem).DestinationID;
            updateFlightModel.PlaneId = ((Models.PlaneListItem)planeCB.SelectedItem).PlaneID;
            if((int)updateFlightModel.Price.Price != int.Parse(priceTXT.Text))
            {
                updateFlightModel.Price.FlightPriceID = null;
                updateFlightModel.Price.Price = int.Parse(priceTXT.Text);
                updateFlightModel.Price.PriceDate = DateTime.Now;
            }

            mainForm._apiClientFlight.UpdateFlight(updateFlightModel);
        }

        private void CreateFlight(DateTime arrivalDate, DateTime departureDate, int planeId, int destinationId, int price)
        {
            Task createFlightTast = Task.Run(() => CreateFlightWorker(arrivalDate, departureDate, planeId, destinationId, price));
            createFlightTast.Wait();

            mainForm.SwitchPanel(1); // return to mainPanel
            new InformationForm().ShowInformationForm("Flight created!");
        }

        private void CreateFlightWorker(DateTime arrivalDate, DateTime departureDate, int planeId, int destinationId, int price)
        {
            Flight flight = new Flight();
            flight.FlightId = 0; //Should not be needed
            flight.ArrivalDate = arrivalDate;
            flight.DepartureDate = departureDate;
            flight.PlaneId = planeId;
            flight.DestinationId = destinationId;

            FlightPrice priceModel = new FlightPrice()
            {
                FlightId = flight.FlightId,
                Price = price,
                PriceDate = DateTime.Now
            };

            flight.Price = priceModel;

            mainForm._apiClientFlight.AddFlight(flight);
        }

        private void ClearPanel()
        {

            depatureDTP.Value = DateTime.Now;
            arrivalDTP.Value = DateTime.Now;
            planeCB.SelectedIndex = -1;
            destinationCB.SelectedIndex = -1;
            priceTXT.Text = "";
            flightIdLBL.Text = "Flight ID: ";
        }

        private void LoadFlightInfo()
        {
            updateFlightModel = mainForm._apiClientFlight.GetFlightById(updateFlightID);

            flightIdLBL.Text = $"Flight ID: {updateFlightModel.FlightId}";
            depatureDTP.Value = (DateTime)updateFlightModel.DepartureDate;
            arrivalDTP.Value = (DateTime)updateFlightModel.ArrivalDate;
            planeCB.SelectedIndex = planeCB.FindStringExact(new Models.PlaneListItem((int)updateFlightModel.PlaneId, updateFlightModel.Plane.PlaneModel.ModelName).ToString());
            destinationCB.SelectedIndex = destinationCB.FindStringExact(new Models.DestinationListItem((int)updateFlightModel.DestinationId, updateFlightModel.Destination.City).ToString());
            priceTXT.Text = updateFlightModel.Price.Price.ToString();
        }
    }
}
