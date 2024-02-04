using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;
using Eddy.x12.DomainModels.Transportation.v6020._434;

namespace Eddy.x12.DomainModels.Transportation.v6020;

public class Edi434_RailroadMarkRegisterUpdateActivity {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BRR_BeginningSegmentForRailroadMarkRegisterUpdateActivity BeginningSegmentForRailroadMarkRegisterUpdateActivity { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi434_RailroadMarkRegisterUpdateActivity>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForRailroadMarkRegisterUpdateActivity);
		validator.CollectionSize(x => x.DateTimeReference, 1, 10);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LN1, 1, 25);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
