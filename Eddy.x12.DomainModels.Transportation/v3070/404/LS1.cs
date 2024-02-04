using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Transportation.v3070._404;

public class LS1 {
	[SectionPosition(1)] public S1_StopOffName StopOffName { get; set; } = new();
	[SectionPosition(2)] public S2_StopOffAddress? StopOffAddress { get; set; }
	[SectionPosition(3)] public S9_StopOffStation? StopOffStation { get; set; }
	[SectionPosition(4)] public N1_Name? Name { get; set; }
	[SectionPosition(5)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(6)] public N3_AddressInformation? AddressInformation { get; set; }
	[SectionPosition(7)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(8)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(9)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(10)] public List<LS1_LS1> LS1_LS1 { get;set;} = new();
	[SectionPosition(11)] public LE_LoopTrailer? LoopTrailer { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LS1>(this);
		validator.Required(x => x.StopOffName);
		validator.CollectionSize(x => x.LS1_LS1, 0, 12);
		foreach (var item in LS1_LS1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
