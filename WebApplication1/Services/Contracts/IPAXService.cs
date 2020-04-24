namespace BMS.Services.Contracts
{
    using BMS.Data.Models;
    using BMS.Models;
    using BMS.Models.ViewModels.Passengers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IPAXService
    {
        Task CreatePassenger(PAXInputModel inputModel);


        PassengerViewModel GetAllPassengers(string flightNumber);

        Task<PassengerOffloadEditViewModel> GetPassengerByFullName(string passengerName);

        Task<Passenger> GetPassengerById(int id);

        Task OffloadPassenger(int id);

        Task EditPassengerData(PassengerOffloadEditInputModel editInputModel,int id);


    }
}
