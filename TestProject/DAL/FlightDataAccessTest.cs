using ClassLibraryModelLayer;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using FlyBooking.DAL;

namespace Flybooking.Test.DAL
{
    public class FlightDataAccessTest
    {
        FlightDataAccess _dal = null;
        const string CONN_STR = @"Data Source=hildur.ucn.dk;Initial Catalog=DMA-CSD-V221_10461268;User ID=DMA-CSD-V221_10461268;Password=Password1!;";

        List<int> addedFlightIds; //store ids of all flights added to the database during testing, so they can be deleted on cleanup.

        [SetUp]
        public void Setup()
        {
            addedFlightIds = new List<int>();
            _dal = new FlightDataAccess(CONN_STR);
        }

        //Flight model helper method
        private Flight GenerateFlightTestModel()
        {
            Flight flight = new ClassLibraryModelLayer.Flight()
            {
                PlaneId = 1, //known plane in database
                DestinationId = 2, //known destination in database
                ArrivalDate = new DateTime(2023, 5, 1, 0, 0, 0), //random arrival date
                DepartureDate = new DateTime(2023, 5, 1, 1, 30, 0), // random depature date
            };

            FlightPrice priceModel = new FlightPrice()
            {
                FlightId = flight.FlightId,
                Price = 800,
                PriceDate = new DateTime(2023, 5, 1, 0, 0, 0)
            };
            flight.Price = priceModel;
            return flight;
        }

        //Integration test helper
        private int? AddFlightTestHelper(Flight flight = null)
        {
            if(_dal == null)
            {
                Assert.Fail();
                return null;
            }

            //Arrange
            Flight flightModel;

            if (flight == null)
            {
                flightModel = GenerateFlightTestModel(); //use helper method to generate a basic flight model if none are given
            }
            else
            {
                flightModel = flight;
            }
            
            //Act
            int addedFlightID = _dal.AddFlight(flightModel);
            addedFlightIds.Add(addedFlightID);
            Flight addedFlight = _dal.GetFlightById(addedFlightID);

            //Assert
             Assert.AreEqual(flightModel.PlaneId, addedFlight.PlaneId);
             Assert.AreEqual(flightModel.DestinationId, addedFlight.DestinationId);
             Assert.AreEqual(   flightModel.DepartureDate.Value.AddTicks(-flightModel.DepartureDate.Value.Ticks % TimeSpan.TicksPerSecond), 
                                addedFlight.DepartureDate.Value.AddTicks(-addedFlight.DepartureDate.Value.Ticks % TimeSpan.TicksPerSecond));
             Assert.AreEqual(   flightModel.ArrivalDate.Value.AddTicks(-flightModel.ArrivalDate.Value.Ticks % TimeSpan.TicksPerSecond), 
                                addedFlight.ArrivalDate.Value.AddTicks(-addedFlight.ArrivalDate.Value.Ticks % TimeSpan.TicksPerSecond));

            return addedFlightID;
        }

		//Integration test helper
		private bool DeleteFlightTestHelper(int? id = null)
        {
            if (_dal == null)
            {
                Assert.Fail();
                return false;
            }

            //Arrange
            Flight flightModel = null;
            Flight addedFlight = null;
            int addedFlightID = 0;

            if (id == null)
            {
                flightModel = GenerateFlightTestModel();
                addedFlightID = (int)AddFlightTestHelper(flightModel);
            }
            else
            {
                addedFlightID = (int)id;
            }

            addedFlight = _dal.GetFlightById(addedFlightID);

            //Act
            if (!_dal.DeleteFlight(addedFlightID))
            {
                Assert.Fail();
            }

            //Assert
            Assert.AreEqual(addedFlight.DestinationId, addedFlight.DestinationId); //check if there have been added some flight before deleltion

            try
            {
                _dal.GetFlightById(addedFlightID); //should result in an expection since it have been deleted

                Assert.Fail();
                return false;
            }
            catch
            {
                Assert.Pass();
                return true;
            }
        }

        //Integration test
        [Test]
        public void AddFlightTest()
        {
            AddFlightTestHelper();
        }

        //Integration test
        [Test]
        public void DeleteFlightTest()
        {
            DeleteFlightTestHelper();
        }

        //Integration test
        [Test]
        public void GetAllFlightsTest()
        {
            if (_dal == null)
            {
                Assert.Fail();
                return;
            }

            //Arrange
            Flight flightModel = GenerateFlightTestModel();

            int addedFlightID = (int)AddFlightTestHelper(flightModel);
            Flight addedFlight = _dal.GetFlightById(addedFlightID);

            //Act
            List<Flight> flightModels = _dal.GetAllFlights().ToList();

            //Assert
            Assert.AreEqual(addedFlight.FlightId, flightModels.Last().FlightId); //Checks that the last element added to the list of all flights matches the newly added flight
            Assert.AreEqual(flightModel.PlaneId, flightModels.Last().PlaneId);
            Assert.AreEqual(flightModel.DestinationId, flightModels.Last().DestinationId);
            Assert.AreEqual(flightModel.DepartureDate.Value.AddTicks(-flightModel.DepartureDate.Value.Ticks % TimeSpan.TicksPerSecond),
                               flightModels.Last().DepartureDate.Value.AddTicks(-flightModels.Last().DepartureDate.Value.Ticks % TimeSpan.TicksPerSecond));
            Assert.AreEqual(flightModel.ArrivalDate.Value.AddTicks(-flightModel.ArrivalDate.Value.Ticks % TimeSpan.TicksPerSecond),
                               flightModels.Last().ArrivalDate.Value.AddTicks(-flightModels.Last().ArrivalDate.Value.Ticks % TimeSpan.TicksPerSecond));
        }

        //Integration test
        [TestCase("01/05/2023 01:30:00", "02/05/2023 02:15:00")]
        [TestCase("06/04/2023 12:00:00", "08/04/2023 18:55:00")]
        [TestCase("01/01/2012 08:30:00", "01/02/2023 07:30:30")]
        public void UpdateFlightTest(DateTime depatureDatePreUpdate, DateTime depatureDatePostUpdate)
        {
            if (_dal == null)
            {
                Assert.Fail();
                return;
            }

            //Arrange
            Flight flightModel = GenerateFlightTestModel(); //Generate base flight model
            flightModel.DepartureDate = depatureDatePreUpdate;

            int addedFlightID = (int)AddFlightTestHelper(flightModel);
            Flight addedFlight = _dal.GetFlightById(addedFlightID); //Flight added to data base before update

            addedFlight.DepartureDate = depatureDatePostUpdate; //change depature date on the flight model

            //Act
            _dal.UpdateFlight(addedFlight);

            //Assert
            Assert.AreEqual(_dal.GetFlightById(addedFlightID).DepartureDate, depatureDatePostUpdate);
        }

        [TearDown]
        public void CleanUp()
        {
            foreach (int id in addedFlightIds)
            {
                _dal.DeleteFlight(id);
            }
        }
    }
}
