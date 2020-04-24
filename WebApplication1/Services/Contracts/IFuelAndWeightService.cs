namespace BMS.Services.Contracts
{
    using BMS.Models;
    using System.Threading.Tasks;
    public interface IFuelAndWeightService
    {
        Task<bool> AddFuelForm(FuelFormInputModel fuelFormInputModel);

        Task<bool> AddWeightForm(WeightFormInputModel weightInputModel);
    }
}
