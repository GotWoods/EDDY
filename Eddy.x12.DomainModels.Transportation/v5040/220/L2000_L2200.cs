using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Transportation.v5040._220;

public class L2000_L2200 {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public LCT_LogisticsContainerTrackingInformation? LogisticsContainerTrackingInformation { get; set; }
	[SectionPosition(3)] public List<MAN_MarksAndNumbersInformation> MarksAndNumbersInformation { get; set; } = new();
	[SectionPosition(4)] public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();
	[SectionPosition(5)] public AMT_MonetaryAmountInformation? MonetaryAmountInformation { get; set; }
	[SectionPosition(6)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(7)] public List<L2000__L2200_L2250> L2250 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000_L2200>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.MarksAndNumbersInformation, 0, 10);
		validator.CollectionSize(x => x.BillOfLadingHandlingRequirements, 0, 6);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 1, 2147483647);
		validator.CollectionSize(x => x.L2250, 1, 2147483647);
		foreach (var item in L2250) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
