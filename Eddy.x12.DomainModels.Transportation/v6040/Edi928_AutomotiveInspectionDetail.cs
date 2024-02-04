using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;
using Eddy.x12.DomainModels.Transportation.v6040._928;

namespace Eddy.x12.DomainModels.Transportation.v6040;

public class Edi928_AutomotiveInspectionDetail {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BIX_BeginningSegmentForAutomotiveInspection BeginningSegmentForAutomotiveInspection { get; set; } = new();
	[SectionPosition(3)] public TI_TransportInformation? TransportInformation { get; set; }
	[SectionPosition(4)] public List<LVC> LVC {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi928_AutomotiveInspectionDetail>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForAutomotiveInspection);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LVC, 1, 36);
		foreach (var item in LVC) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
