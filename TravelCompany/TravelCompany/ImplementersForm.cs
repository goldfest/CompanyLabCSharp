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
	public partial class ImplementersForm : Form
	{
		private readonly ILogger _logger;
		private readonly IImplementerLogic _logic;
		public ImplementersForm(ILogger<ImplementersForm> logger, IImplementerLogic logic)
		{
			InitializeComponent();
			_logger = logger;
			_logic = logic;
		}

		private void ImplementersForm_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			try
			{
				var list = _logic.ReadList(null);
				if (list != null)
				{
					dataGridView1.DataSource = list;
					dataGridView1.Columns["Id"].Visible = false;
					dataGridView1.Columns["ImplementerFIO"].AutoSizeMode =
				   DataGridViewAutoSizeColumnMode.Fill;
					dataGridView1.Columns["Password"].AutoSizeMode =
				   DataGridViewAutoSizeColumnMode.Fill;
					dataGridView1.Columns["Qualification"].AutoSizeMode =
				   DataGridViewAutoSizeColumnMode.Fill;
					dataGridView1.Columns["WorkExperience"].AutoSizeMode =
				   DataGridViewAutoSizeColumnMode.Fill;
				}
				_logger.LogInformation("Загрузка компонентов");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки исполнителей");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
			}
		}
		private void CreateButton_Click(object sender, EventArgs e)
		{
			var service = Program.ServiceProvider?.GetService(typeof(ImplementerForm));
			if (service is ImplementerForm form)
			{
				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadData();
				}
			}
		}

		private void ChangeButton_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count == 1)
			{
				var service =
			   Program.ServiceProvider?.GetService(typeof(ImplementerForm));
				if (service is ImplementerForm form)
				{
					form.Id =
				   Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
					if (form.ShowDialog() == DialogResult.OK)
					{
						LoadData();
					}
				}
			}
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count == 1)
			{
				if (MessageBox.Show("Удалить запись?", "Вопрос",
			   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					int id =
				   Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
					_logger.LogInformation("Удаление компонента");
					try
					{
						if (!_logic.Delete(new ImplementerBindingModel
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
						_logger.LogError(ex, "Ошибка удаления исполнителя");
						MessageBox.Show(ex.Message, "Ошибка",
					   MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void RefreshButton_Click(object sender, EventArgs e)
		{
			LoadData();
		}
	}
}
