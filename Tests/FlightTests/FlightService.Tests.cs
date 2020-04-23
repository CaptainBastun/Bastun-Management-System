using BMS.Data.Models;
using BMS.Models;
using BMS.Models.FlightInputModels;
using BMS.Services.Contracts;
using Moq;
using System.Threading.Tasks;
using System;
using WebApplication1.Data;
using Xunit;
using Microsoft.EntityFrameworkCore;
using BMS.Services;
using Tests.Common;
using AutoMapper;
using AutoMapper.Mappers;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Tests
{
    public class FlightServiceTests
    {
        private static readonly MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<InboundFlightInputModel, InboundFlight>();
            cfg.CreateMap<OutboundFlightInputModel, OutboundFlight>();
        });

        private readonly IMapper _mapper = new Mapper(config);

        private readonly string _testSeatMapConfig = "OA60/OB60/OC60/OD60";
        private readonly DateTime testValidTime = DateTime.UtcNow;
        private readonly string _testFlightNumber = "BY2134";
       

        [Fact]
        public async void CreateInboundFlightWithEmptyFlightNumberShouldThrowException()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);
           
            var model = new InboundFlightInputModel
            {
                FlightNumber = string.Empty,
                STA = DateTime.UtcNow,
                Origin = "MAN"
            };

           await Assert.ThrowsAsync<ArgumentException>(() => service.CreateInbounddFlight(model)); 
        }

        [Fact]
        public async void CreateInboundFlightWithNullFlightNumberShouldThrowException()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);
            var model = new InboundFlightInputModel
            {
                FlightNumber = null,
                STA = DateTime.UtcNow,
                Origin = "MAN",
            };

           await Assert.ThrowsAsync<ArgumentException>(() => service.CreateInbounddFlight(model));
        }

        [Fact]
        public async void CreateInboundFlightWithEmptyOriginShouldThrowException()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);
            var model = new InboundFlightInputModel
            {
                FlightNumber = "BY2134",
                Origin = string.Empty,
                STA = DateTime.UtcNow
            };

            await Assert.ThrowsAsync<ArgumentException>(() => service.CreateInbounddFlight(model));
        }

        [Fact]
        public async void CreateInboundFlightWithNullOriginShouldThrowException()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);
            var model = new InboundFlightInputModel
            {
                FlightNumber = "BY2134",
                Origin = null,
                STA = DateTime.UtcNow
            };

            await Assert.ThrowsAsync<ArgumentException>(() => service.CreateInbounddFlight(model));
        }


        [Fact]
        public async void CreateInboundFlightWithMinimumSTAShouldThrowException()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);
            var model = new InboundFlightInputModel
            {
                FlightNumber = "BY2134",
                Origin = "MAN",
                STA = DateTime.MinValue
            };

          await  Assert.ThrowsAsync<ArgumentException>(() => service.CreateInbounddFlight(model));
        }

        [Fact]
        public async void CreateInboundFlightWithValidParamsShouldCreate()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);

            var model = new InboundFlightInputModel
            {
                FlightNumber = "BY2134",
                Origin = "MAN",
                STA = DateTime.UtcNow
            };
            await service.CreateInbounddFlight(model);
            var result = db.InboundFlights.Count();

            Assert.Equal(1, result);
        }

        [Fact]
        public async void CreateOutboundFlightWithValidParamsShouldCreate()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var model = new OutboundFlightInputModel
            {
                FlightNumber = "BY2134",
                RampAgentName = "Dimitar Penev",
                BookedPax = 221,
                Destination = "MAN",
                HandlingStation = "BOJ",
                SeatMap = "OA60/OB60/OC60/OD60",
                STD = DateTime.UtcNow
            };
            var service = new FlightsService(db,_mapper);
            await service.CreateOutboundFlight(model);

            var actual = db.OutboundFlights.Count();

            Assert.Equal(1, actual);
        }

        [Fact]
        public async void CreateOutboundFlightWithInvalidFlightNumberShouldNotCreate()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var model = new OutboundFlightInputModel
            {
                FlightNumber = "AKGAA1112333",
                RampAgentName = "Test1",
                BookedPax = 23,
                Destination = "AHA",
                HandlingStation = "HAH",
                SeatMap = _testSeatMapConfig,
                STD = testValidTime
            };
            var service = new FlightsService(db,_mapper);
            await service.CreateOutboundFlight(model);

            var actual = db.OutboundFlights.Count();
            
            Assert.Equal(0,actual);
        }

        [Fact]
        public async void CreateOutboundFlightWithEmptyFlightNumberShouldThrowException()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);
            var outbound = new OutboundFlightInputModel
            {
                FlightNumber = string.Empty
            };
            
            await Assert.ThrowsAsync<ArgumentException>(() => service.CreateOutboundFlight(outbound));
        }  

        [Fact]
        public async void CreateOutboundFlightWithNullFlightNumberThrowException()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);
            var model = new OutboundFlightInputModel
            {
                FlightNumber = null
            };

            await Assert.ThrowsAsync<ArgumentException>(() => service.CreateOutboundFlight(model));
        }


        [Fact]
        public async void CreateOutboundFlightWithNullSeatMapThrowsException()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);
            var model = new OutboundFlightInputModel
            {
                SeatMap = null
            };

            await Assert.ThrowsAsync<ArgumentException>(() => service.CreateOutboundFlight(model));
        }

        [Fact]
        public async void CreateOutboundFlightWithEmptySeatMapThrowsException()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);
            var model = new OutboundFlightInputModel
            {
                SeatMap = string.Empty
            };

            await Assert.ThrowsAsync<ArgumentException>(() => service.CreateOutboundFlight(model));
        }

        [Fact]
        public async void CreateOutboundFlightWithNegativeBookedPaxThrowsException()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);
            var model = new OutboundFlightInputModel
            {
                BookedPax = -20
            };

           await Assert.ThrowsAsync<ArgumentException>(() => service.CreateOutboundFlight(model));
        }

        [Fact]
        public async void CreateOutboundFlightWitZeroBookedPaxThrowsException()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);
            var model = new OutboundFlightInputModel
            {
                BookedPax = 0
            };

            await Assert.ThrowsAsync<ArgumentException>(() => service.CreateOutboundFlight(model));
        }

        [Fact]
        public async void CreateOutboundFlightWithNullRampAgentName()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);
            var model = new OutboundFlightInputModel
            {
                RampAgentName = null
            };

            await Assert.ThrowsAsync<ArgumentException>(() => service.CreateOutboundFlight(model));
        }

        [Fact]
        public async void CreateOutboundFlightWithEmptyRampAgentName()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);
            var model = new OutboundFlightInputModel
            {
                RampAgentName = string.Empty
            };

            await Assert.ThrowsAsync<ArgumentException>(() => service.CreateOutboundFlight(model));
        }

        [Fact]
        public async void CreateOutboundFlightWithSTDEqualToDateTimeMinValueThrowsException()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);
            var model = new OutboundFlightInputModel
            {
                STD = DateTime.MinValue
            };

            await Assert.ThrowsAsync<ArgumentException>(() => service.CreateOutboundFlight(model));
        }

        [Fact]
        public async void GetInboundFlightByCorrectFlightNumberShouldNotReturnNull()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db,_mapper);
            var model = new InboundFlightInputModel
            {
                FlightNumber = "BY2134",
                Origin = "MAN",
                STA = DateTime.UtcNow
            };

            await service.CreateInbounddFlight(model);
            string correct = "BY2134";
            var result = service.GetInboundFlightByFlightNumber(correct);

            Assert.NotNull(result);
        }

        [Fact]
        public async void CheckIfFlightIsInboundIncorrectFlightNumberReturnsFalse()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);
            var model = new InboundFlightInputModel
            {
                FlightNumber = "BY2134",
            };
            await service.CreateInbounddFlight(model);
            string incorrect = "BY2135";
            var result = service.CheckIfFlightIsInbound(incorrect);
            Assert.True(result == false);
        }

        [Fact]
        public async void CheckIfFlightIsInboundNullThrowsException()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);

            Assert.Throws<ArgumentException>(() => service.CheckIfFlightIsInbound(null));
        }

        [Fact]
        public async void CheckIfFlightIsInboundEmptyThrowsException()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);
          
            Assert.Throws<ArgumentException>(() => service.CheckIfFlightIsInbound(string.Empty));

        }

        [Fact]
        public async void CheckIfFlightIsOutboundReturnsTrue()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);
            var model = new OutboundFlightInputModel
            {
                FlightNumber = _testFlightNumber
            };
            await service.CreateOutboundFlight(model);
            bool result = service.CheckIfFlightIsOutbound(_testFlightNumber);
            Assert.True(result == true);
  
        }

        [Fact]
        public async void CheckIfFlightIsOutboundEmptyThrowsException()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);
            

            Assert.Throws<ArgumentException>(() => service.CheckIfFlightIsOutbound(string.Empty));

        }

        [Fact]
        public async void CheckIfFlightIsOutboundNullThrowsException()
        {
            var db = ApplicationDbContextFactory.InitializeContext();
            var service = new FlightsService(db, _mapper);
          

            Assert.Throws<ArgumentException>(() => service.CheckIfFlightIsOutbound(null));
        }
    }
}
