using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.Finance.v7060._179;

public class LHL__LN9__LLM_LLQ {
	[SectionPosition(1)] public LQ_IndustryCodeIdentification IndustryCodeIdentification { get; set; } = new();
	[SectionPosition(2)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(3)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(4)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	[SectionPosition(5)] public List<N1_PartyIdentification> PartyIdentification { get; set; } = new();
	[SectionPosition(6)] public List<III_Information> Information { get; set; } = new();
	[SectionPosition(7)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(8)] public SPI_SpecificationIdentifier? SpecificationIdentifier { get; set; }
	[SectionPosition(9)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(10)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LN9__LLM_LLQ>(this);
		validator.Required(x => x.IndustryCodeIdentification);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 2147483647);
		validator.CollectionSize(x => x.PercentAmounts, 1, 2147483647);
		validator.CollectionSize(x => x.PartyIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.Information, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		validator.CollectionSize(x => x.Measurements, 1, 2147483647);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 1, 2147483647);
		return validator.Results;
	}
}
