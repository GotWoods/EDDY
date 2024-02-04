using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;
using Eddy.x12.DomainModels.Transportation.v7060._228;

namespace Eddy.x12.DomainModels.Transportation.v7060;

public class Edi228_EquipmentInspectionReport {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public Q5_StatusDetails StatusDetails { get; set; } = new();
	[SectionPosition(4)] public List<LW2> LW2 {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi228_EquipmentInspectionReport>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.Required(x => x.StatusDetails);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LW2, 1, 1000);
		foreach (var item in LW2) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
