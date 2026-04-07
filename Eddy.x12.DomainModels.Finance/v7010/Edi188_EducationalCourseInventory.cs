using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;
using Eddy.x12.DomainModels.Finance.v7010._188;

namespace Eddy.x12.DomainModels.Finance.v7010;

public class Edi188_EducationalCourseInventory {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public ERP_EducationalRecordPurpose EducationalRecordPurpose { get; set; } = new();
	[SectionPosition(3)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(4)] public List<LCSE> LCSE {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi188_EducationalCourseInventory>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.EducationalRecordPurpose);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LN1, 1, 2);
		validator.CollectionSize(x => x.LCSE, 1, 2147483647);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LCSE) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
