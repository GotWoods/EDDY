using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Transportation.v4020._240;

public class L2000_L2700 {
	[SectionPosition(1)] public L11_BusinessInstructionsAndReferenceNumber BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(2)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
	[SectionPosition(3)] public List<AT7_ShipmentStatusDetails> ShipmentStatusDetails { get; set; } = new();
	[SectionPosition(4)] public List<CD3_CartonPackageDetail> CartonPackageDetail { get; set; } = new();
	[SectionPosition(5)] public List<Q7_LadingExceptionCode> LadingExceptionCode { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000_L2700>(this);
		validator.Required(x => x.BusinessInstructionsAndReferenceNumber);
		validator.CollectionSize(x => x.MarksAndNumbers, 1, 2147483647);
		validator.CollectionSize(x => x.ShipmentStatusDetails, 1, 2147483647);
		validator.CollectionSize(x => x.CartonPackageDetail, 1, 2147483647);
		validator.CollectionSize(x => x.LadingExceptionCode, 1, 2147483647);
		return validator.Results;
	}
}
