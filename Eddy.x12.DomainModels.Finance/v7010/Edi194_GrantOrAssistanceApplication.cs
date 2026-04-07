using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;
using Eddy.x12.DomainModels.Finance.v7010._194;

namespace Eddy.x12.DomainModels.Finance.v7010;

public class Edi194_GrantOrAssistanceApplication {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<LDT_LeadTime> LeadTime { get; set; } = new();
	[SectionPosition(5)] public List<PWK_Paperwork> Paperwork { get; set; } = new();
	[SectionPosition(6)] public List<LN9> LN9 {get;set;} = new();
	[SectionPosition(7)] public List<LNM1> LNM1 {get;set;} = new();

	//Details
	[SectionPosition(8)] public List<LHL> LHL {get;set;} = new();
	[SectionPosition(9)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();



	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi194_GrantOrAssistanceApplication>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.LeadTime, 1, 2147483647);
		validator.CollectionSize(x => x.Paperwork, 1, 2147483647);
		

		validator.CollectionSize(x => x.LN9, 1, 2147483647);
		validator.CollectionSize(x => x.LNM1, 1, 2147483647);
		foreach (var item in LN9) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LHL, 1, 2147483647);
		foreach (var item in LHL) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
