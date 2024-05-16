using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Runtime.Serialization;

namespace TravelCompanyFileImplement.Models
{
    [DataContract]
    public class Implementer : IImplementerModel
	{
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public string ImplementerFIO { get; private set; } = string.Empty;
        [DataMember]
        public string Password { get; set; } = string.Empty;
        [DataMember]
        public int Qualification { get; set; } = 0;
        [DataMember]
        public int WorkExperience { get; set; } = 0;
        public static Implementer? Create(ImplementerBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new Implementer()
			{
				Id = model.Id,
				ImplementerFIO = model.ImplementerFIO,
				Password = model.Password,
				WorkExperience = model.WorkExperience,
				Qualification = model.Qualification
			};
		}
		public void Update(ImplementerBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			ImplementerFIO = model.ImplementerFIO;
			Password = model.Password;
			WorkExperience = model.WorkExperience;
			Qualification = model.Qualification;
		}
		public ImplementerViewModel GetViewModel => new()
		{
			Id = Id,
			ImplementerFIO = ImplementerFIO,
			Password = Password,
			WorkExperience = WorkExperience,
			Qualification = Qualification
		};
		public static Implementer? Create(XElement element)
		{
			if (element == null)
			{
				return null;
			}
			return new Implementer()
			{
				Id = Convert.ToInt32(element.Attribute("Id")!.Value),
				ImplementerFIO = element.Element("ImplementerFIO")!.Value,
				Password = element.Element("Password")!.Value,
				Qualification = Convert.ToInt32(element.Element("Qualification")!.Value),
				WorkExperience = Convert.ToInt32(element.Element("WorkExperience")!.Value)
			};
		}

		public XElement GetXElement => new("Implementer",
				new XAttribute("Id", Id),
				new XElement("ImplementerFIO", ImplementerFIO),
				new XElement("Password", Password),
				new XElement("Qualification", Qualification.ToString()),
				new XElement("WorkExperience", WorkExperience.ToString())
			);
	}
}
