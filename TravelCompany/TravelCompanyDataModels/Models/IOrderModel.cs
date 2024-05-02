using TravelCompanyDataModels.Enums;

namespace TravelCompanyDataModels.Models
{
    public interface IOrderModel : IId
    {
        int TravelId { get; }
        int ClientId { get; }
        int Count { get; }
        double Sum { get; }
        OrderStatus Status { get; }
        DateTime DateCreate { get; }
        DateTime? DateImplement { get; }
    }
}