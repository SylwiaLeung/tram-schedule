using NUnit.Framework;
using Tram_Schedule.DAL.DAO;
using Tram_Schedule.Models;
using Tram_Schedule_Controls;
using NSubstitute;
using System;

namespace Tram_ScheduleTests
{
    public class Tests
    {
        public RouteControls RouteControls;
        public TramStopControls StopControls;
        public TramControls TramControls;
        public IDao<Tram> TramDao;
        public IDao<Route> RouteDao;
        public IDao<TramStop> StopDao;

        [SetUp]
        public void Setup()
        {
            TramDao = Substitute.For<IDao<Tram>>();
            RouteDao = Substitute.For<IDao<Route>>();
            StopDao = Substitute.For<IDao<TramStop>>();
            TramControls = new(TramDao);
            StopControls = new(StopDao);
            TramControls = new(TramDao);
        }

        [Test]
        public void AddNewTram_WrongFirstRunArgument_ThrowsFormatException()
        {
            //arrange
            string name = "name";
            string firstrun = "abc";
            //act, assert
            Assert.Throws<FormatException>(() => TramControls.AddNewTram(name, firstrun));
        }

        [Test]
        public void AddNewTram_CorrectArgs_DoesntThrowExceptions()
        {
            //arrange
            string name = "name";
            string firstrun = "14-11-1992";
            //act, assert
            Assert.DoesNotThrow(() => TramControls.AddNewTram(name, firstrun));
        }

        [Test]
        public void AddNewStop_RouteNameIsNull_ThrowsArgumentException()
        {
            //arrange
            string name = "name";
            string description = "f";
            string routName = null;
            //act, assert
            Assert.Throws<ArgumentException>(() => StopControls.AddNewStop(name, description, routName));
        }

        [Test]
        public void AddNewStop_RouteNameIsEmptyString_ThrowsArgumentException()
        {
            //arrange
            string name = "name";
            string description = "f";
            string routName = string.Empty;
            //act, assert
            Assert.Throws<ArgumentException>(() => StopControls.AddNewStop(name, description, routName));
        }
    }
}