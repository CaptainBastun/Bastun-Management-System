namespace BMS.Services.Contracts
{
    using BMS.Models;
    using System.Threading.Tasks;
    public interface IFuelAndWeightService
    {
        Task AddFuelForm(FuelFormInputModel fuelFormInputModel);

        Task AddWeightForm(WeightFormInputModel weightInputModel);
    }
}
