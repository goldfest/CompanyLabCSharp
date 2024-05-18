using TravelCompanyDataModels.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.DI;
using TravelCompanyDatabaseImplement.Models;

namespace TravelCompany.Forms
{
    public partial class FormTravel : Form
    {
        private readonly ILogger _logger;
        private readonly ITravelLogic _logic;
        private int? _id;
        private Dictionary<int, (IComponentModel, int)> _travelComponents;
        public int Id { set { _id = value; } }
        public FormTravel(ILogger<FormTravel> logger, ITravelLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
            _travelComponents = new Dictionary<int, (IComponentModel, int)>();
        }
        private void FormTravel_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                _logger.LogInformation("Загрузка изделия");
                try
                {
                    var view = _logic.ReadElement(new TravelSearchModel
                    {
                        Id = _id.Value
                    });
                    if (view != null)
                    {
                        textBoxName.Text = view.TravelName;
                        textBoxPrice.Text = view.Price.ToString();
                        _travelComponents = view.TravelComponents ?? new Dictionary<int, (IComponentModel, int)>();
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка загрузки изделия");
                }
            }
        }
        private void LoadData()
        {
            _logger.LogInformation("Загрузка компонент изделия");
            try
            {
                if (_travelComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in _travelComponents)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1.ComponentName, pc.Value.Item2 });
                    }
                    textBoxPrice.Text = CalcPrice().ToString();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки компонент изделия");
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormTravelComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                return;
            }
            _logger.LogInformation("Добавление нового ингридиента:{ ComponentName}-{ Count}", form.ComponentModel.ComponentName, form.Count);
            if (_travelComponents.ContainsKey(form.Id))
            {
                _travelComponents[form.Id] = (form.ComponentModel,
                form.Count);
            }
            else
            {
                _travelComponents.Add(form.Id, (form.ComponentModel,
                form.Count));
            }
            LoadData();
        }
        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = DependencyManager.Instance.Resolve<FormTravelComponent>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = _travelComponents[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.ComponentModel == null)
                    {
                        return;
                    }
                    _logger.LogInformation("Изменение ингридиента:{ ComponentName}-{ Count}", form.ComponentModel.ComponentName, form.Count);
                    _travelComponents[form.Id] = (form.ComponentModel, form.Count);
                    LoadData();
                }
            }
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _logger.LogInformation("Удаление компонента: { ComponentName} - { Count}", dataGridView.SelectedRows[0].Cells[1].Value);
                        _travelComponents?.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_travelComponents == null || _travelComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Сохранение изделия");
            try
            {
                var model = new TravelBindingModel
                {
                    Id = _id ?? 0,
                    TravelName = textBoxName.Text,
                    Price = Convert.ToDouble(textBoxPrice.Text),
                    TravelComponents = _travelComponents
                };
                var operationResult = _id.HasValue ? _logic.Update(model) : _logic.Create(model);
                if (!operationResult)
                {
                    throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information); DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка сохранения изделия");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private double CalcPrice()
        {
            double price = 0;
            foreach (var elem in _travelComponents)
            {
                price += ((elem.Value.Item1?.Cost ?? 0) * elem.Value.Item2);
            }
            return Math.Round(price * 1.1, 2);
        }
    }
}
