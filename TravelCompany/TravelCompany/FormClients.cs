using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
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

namespace TravelCompany.Forms
{
    public partial class FormClients : Form
    {
        private readonly ILogger _logger;
        private readonly IClientLogic _logic;
        public FormClients(ILogger<FormClients> logger, IClientLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }

        private void LoadData()
        {
            try
            {
                DataGridView.FillAndConfigGrid(_logic.ReadList(null));
                _logger.LogInformation("Загрузка клиентов");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки клиентов");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id =
                   Convert.ToInt32(DataGridView.SelectedRows[0].Cells["Id"].Value);
                    _logger.LogInformation("Удаление клиента");
                    try
                    {
                        if (!_logic.Delete(new ClientBindingModel
                        {
                            Id = id
                        }))
                        {
                            throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
                        }
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка удаления компонента");
                        MessageBox.Show(ex.Message, "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
