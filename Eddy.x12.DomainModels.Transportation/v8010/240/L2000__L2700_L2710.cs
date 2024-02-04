using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Transportation.v8010._240;

public class L2000__L2700_L2710 {
	[SectionPosition(1)] public MAN_MarksAndNumbersInformation MarksAndNumbersInformation { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<AT7_ShipmentStatusDetails> ShipmentStatusDetails { get; set; } = new();
	[SectionPosition(4)] public List<CD3_CartonPackageDetail> CartonPackageDetail { get; set; } = new();
	[SectionPosition(5)] public NM1_IndividualOrOrganizationalName? IndividualOrOrganizationalName { get; set; }
	[SectionPosition(6)] public List<Q7_LadingExceptionStatus> LadingExceptionStatus { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2700_L2710>(this);
		validator.Required(x => x.MarksAndNumbersInformation);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 1, 2147483647);
		validator.CollectionSize(x => x.ShipmentStatusDetails, 1, 2147483647);
		validator.CollectionSize(x => x.CartonPackageDetail, 1, 2147483647);
		validator.CollectionSize(x => x.LadingExceptionStatus, 1, 2147483647);
		return validator.Results;
	}
}
