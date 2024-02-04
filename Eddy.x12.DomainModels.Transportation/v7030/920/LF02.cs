using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.DomainModels.Transportation.v7030._920;

public class LF02 {
	[SectionPosition(1)] public F02_IdentificationOfShipment IdentificationOfShipment { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<MAN_MarksAndNumbersInformation> MarksAndNumbersInformation { get; set; } = new();
	[SectionPosition(4)] public F05_AllowanceChargeClaim? AllowanceChargeClaim { get; set; }
	[SectionPosition(5)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(6)] public List<Q7_LadingExceptionStatus> LadingExceptionStatus { get; set; } = new();
	[SectionPosition(7)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(8)] public List<LF02_LF09> LF09 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LF02>(this);
		validator.Required(x => x.IdentificationOfShipment);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 99);
		validator.CollectionSize(x => x.MarksAndNumbersInformation, 0, 9999);
		validator.CollectionSize(x => x.DateTime, 0, 30);
		validator.CollectionSize(x => x.LadingExceptionStatus, 0, 10);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.LF09, 0, 100);
		foreach (var item in LF09) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
