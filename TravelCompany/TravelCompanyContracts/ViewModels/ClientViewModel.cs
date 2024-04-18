using TravelCompanyDataModels.Models;
using System.ComponentModel;

namespace TravelCompanyContracts.ViewModels
{
    public class ClientViewModel : IClientModel
    {
        public int Id { get; set; }
        [DisplayName("ФИО клиента")]
        public string ClientFIO { get; set; } = string.Empty;
        [DisplayName("Логин (эл. почта)")]
        public string Email { get; set; } = string.Empty;
        [DisplayName("Пароль")]
        public string Password { get; set; } = string.Empty;
    }
}
