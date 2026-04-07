using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Finance.v4060._197;

public class LPID {
	[SectionPosition(1)] public PID_ProductItemDescription ProductItemDescription { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(4)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(5)] public List<LPID_LNM1> LNM1 {get;set;} = new();
	[SectionPosition(6)] public List<LPID_LNX1> LNX1 {get;set;} = new();
	[SectionPosition(7)] public List<LPID_LFGS> LFGS {get;set;} = new();
	[SectionPosition(8)] public List<LPID_LLX> LLX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LPID>(this);
		validator.Required(x => x.ProductItemDescription);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 12);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		validator.CollectionSize(x => x.LNM1, 0, 5);
		validator.CollectionSize(x => x.LNX1, 1, 2147483647);
		validator.CollectionSize(x => x.LFGS, 1, 10);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNX1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LFGS) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
