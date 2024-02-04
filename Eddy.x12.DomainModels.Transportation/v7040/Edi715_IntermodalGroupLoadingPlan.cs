using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;
using Eddy.x12.DomainModels.Transportation.v7040._715;

namespace Eddy.x12.DomainModels.Transportation.v7040;

public class Edi715_IntermodalGroupLoadingPlan {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public GR2_TrainData TrainData { get; set; } = new();
	[SectionPosition(4)] public V1_VesselIdentification? VesselIdentification { get; set; }
	[SectionPosition(5)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(6)] public List<LGR4> LGR4 {get;set;} = new();
	[SectionPosition(7)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi715_IntermodalGroupLoadingPlan>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.Required(x => x.TrainData);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LGR4, 1, 100);
		foreach (var item in LGR4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
