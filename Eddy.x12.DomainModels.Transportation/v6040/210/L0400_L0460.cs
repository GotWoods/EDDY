using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Transportation.v6040._210;

public class L0400_L0460 {
	[SectionPosition(1)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(3)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(6)] public List<L0400__L0460_L0463> L0463 {get;set;} = new();
	[SectionPosition(7)] public List<L0400__L0460_L0465> L0465 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0400_L0460>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.L0463, 0, 999999);
		validator.CollectionSize(x => x.L0465, 0, 999999);
		foreach (var item in L0463) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0465) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
