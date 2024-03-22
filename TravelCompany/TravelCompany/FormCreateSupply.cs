using Microsoft.Extensions.Logging;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TravelCompanyView
{
    public partial class FormCreateSupply : Form
    {
        private readonly ILogger _logger;
        private readonly ITravelLogic _logicP;
        private readonly IShopLogic _logicS;
        private List<ShopViewModel> _shopList = new List<ShopViewModel>();
        private List<TravelViewModel> _TravelList = new List<TravelViewModel>();

        public FormCreateSupply(ILogger<FormCreateSupply> logger, ITravelLogic logicP, IShopLogic logicS)
        {
            InitializeComponent();
            _logger = logger;
            _logicP = logicP;
            _logicS = logicS;
        }

        private void FormCreateSupply_Load(object sender, EventArgs e)
        {
            _shopList = _logicS.ReadList(null);
            _TravelList = _logicP.ReadList(null);
            if (_shopList != null)
            {
                comboBoxShop.DisplayMember = "ShopName";
                comboBoxShop.ValueMember = "Id";
                comboBoxShop.DataSource = _shopList;
                comboBoxShop.SelectedItem = null;
                _logger.LogInformation("Загрузка магазинов для поставок");
            }
            if (_TravelList != null)
            {
                comboBoxTravel.DisplayMember = "TravelName";
                comboBoxTravel.ValueMember = "Id";
                comboBoxTravel.DataSource = _TravelList;
                comboBoxTravel.SelectedItem = null;
                _logger.LogInformation("Загрузка пиццы для поставок");
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxShop.SelectedValue == null)
            {
                MessageBox.Show("Выберите магазин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxTravel.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Создание поставки");
            try
            {
                var operationResult = _logicS.MakeSupply(new SupplyBindingModel
                {
                    ShopId = Convert.ToInt32(comboBoxShop.SelectedValue),
                    TravelId = Convert.ToInt32(comboBoxTravel.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });
                if (!operationResult)
                {
                    throw new Exception("Ошибка при создании поставки. Дополнительная информация в логах.");
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания поставки");
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
