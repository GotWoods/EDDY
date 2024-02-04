using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;
using Eddy.x12.DomainModels.Transportation.v5040._359;

namespace Eddy.x12.DomainModels.Transportation.v5040;

public class Edi359_CustomsCustomerProfileManagement {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public CPM_CustomsProfileManagementInformation CustomsProfileManagementInformation { get; set; } = new();
	[SectionPosition(3)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(4)] public List<LNM1> LNM1 {get;set;} = new();
	[SectionPosition(5)] public List<LVEH> LVEH {get;set;} = new();
	[SectionPosition(6)] public List<LVID> LVID {get;set;} = new();
	[SectionPosition(7)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi359_CustomsCustomerProfileManagement>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.CustomsProfileManagementInformation);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LNM1, 0, 999);
		validator.CollectionSize(x => x.LVEH, 0, 999);
		validator.CollectionSize(x => x.LVID, 0, 999);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LVEH) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LVID) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
