using Microsoft.Extensions.Logging;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelCompany.Forms
{
    public partial class FormSellTravels : Form
    {
        private readonly ILogger _logger;
        private readonly ITravelLogic _logicP;
        private readonly IShopLogic _logicS;
        private List<TravelViewModel> _TravelList = new List<TravelViewModel>();

        public FormSellTravels(ILogger<FormSellTravels> logger, ITravelLogic logicP, IShopLogic logicS)
        {
            InitializeComponent();
            _logger = logger;
            _logicP = logicP;
            _logicS = logicS;
        }

        private void FormSellingTravel_Load(object sender, EventArgs e)
        {
            _TravelList = _logicP.ReadList(null);
            if (_TravelList != null)
            {
                comboBoxTravel.DisplayMember = "TravelName";
                comboBoxTravel.ValueMember = "Id";
                comboBoxTravel.DataSource = _TravelList;
                comboBoxTravel.SelectedItem = null;
                _logger.LogInformation("Загрузка путёвок для продажи");
            }
        }

        private void ButtonSell_Click(object sender, EventArgs e)
        {
            if (comboBoxTravel.SelectedValue == null)
            {
                MessageBox.Show("Выберите пиццу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Создание покупки");
            try
            {
                bool resout = _logicS.Sale(new SupplySearchModel
                {
                    TravelId = Convert.ToInt32(comboBoxTravel.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });
                if (resout)
                {
                    _logger.LogInformation("Проверка пройдена, продажа  проведена");
                    MessageBox.Show("Продажа проведена", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    _logger.LogInformation("Проверка не пройдена");
                    MessageBox.Show("Продажа не может быть создана.", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания покупки");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}