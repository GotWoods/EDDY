using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;
using Eddy.x12.DomainModels.Transportation.v6020._412;

namespace Eddy.x12.DomainModels.Transportation.v6020;

public class Edi412_TrailerOrContainerRepairBilling {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public R11_BeginningSegmentForTrailerOrContainerRepairBilling BeginningSegmentForTrailerOrContainerRepairBilling { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public CUR_Currency Currency { get; set; } = new();
	[SectionPosition(5)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(6)] public List<LR12> LR12 {get;set;} = new();
	[SectionPosition(7)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi412_TrailerOrContainerRepairBilling>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForTrailerOrContainerRepairBilling);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 5);
		validator.Required(x => x.Currency);
		

		validator.CollectionSize(x => x.LN1, 0, 10);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LR12, 1, 9999);
		foreach (var item in LR12) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
