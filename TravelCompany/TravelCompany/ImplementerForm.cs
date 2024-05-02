using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.SearchModels;
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
	public partial class ImplementerForm : Form
	{
		private readonly ILogger _logger;
		private readonly IImplementerLogic _logic;
		private int? _id;
		public int Id { set { _id = value; } }
		public ImplementerForm(ILogger<ImplementerForm> logger, IImplementerLogic logic)
		{
			InitializeComponent();
			_logger = logger;
			_logic = logic;
		}

		private void ImplementerForm_Load(object sender, EventArgs e)
		{
			if (_id.HasValue)
			{
				try
				{
					_logger.LogInformation("Получение исполнителя");
					var view = _logic.ReadElement(new ImplementerSearchModel
					{
						Id =
				   _id.Value
					});
					if (view != null)
					{
						FIOTextBox.Text = view.ImplementerFIO;
						PasswordTextBox.Text = view.Password;
						QualificationTextBox.Text = view.Qualification.ToString();
						WorkExperienceTextBox.Text = view.WorkExperience.ToString();
					}
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Ошибка получения исполнителя");
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				}
			}
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(FIOTextBox.Text))
			{
				MessageBox.Show("Заполните ФИО", "Ошибка",
			   MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (string.IsNullOrEmpty(PasswordTextBox.Text))
			{
				MessageBox.Show("Заполните пароль", "Ошибка",
			   MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			_logger.LogInformation("Сохранение компонента");
			try
			{
				var model = new ImplementerBindingModel
				{
					Id = _id ?? 0,
					ImplementerFIO = FIOTextBox.Text,
					Password = PasswordTextBox.Text,
					Qualification = Convert.ToInt32(QualificationTextBox.Text),
					WorkExperience = Convert.ToInt32(WorkExperienceTextBox.Text),
				};
				var operationResult = _id.HasValue ? _logic.Update(model) :
			   _logic.Create(model);
				if (!operationResult)
				{
					throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
				}
				MessageBox.Show("Сохранение прошло успешно", "Сообщение",
			   MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка сохранения исполнителя");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
			}
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
