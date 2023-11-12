using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("CS")]
public class CS_ContractSummary : EdiX12Segment
{
	[Position(01)]
	public string ContractNumber { get; set; }

	[Position(02)]
	public string ChangeOrderSequenceNumber { get; set; }

	[Position(03)]
	public string ReleaseNumber { get; set; }

	[Position(04)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(05)]
	public string ReferenceIdentification { get; set; }

	[Position(06)]
	public string PurchaseOrderNumber { get; set; }

	[Position(07)]
	public string SpecialServicesCode { get; set; }

	[Position(08)]
	public string FOBPointCode { get; set; }

	[Position(09)]
	public decimal? Percent { get; set; }

	[Position(10)]
	public decimal? Percent2 { get; set; }

	[Position(11)]
	public decimal? MonetaryAmount { get; set; }

	[Position(12)]
	public string TermsTypeCode { get; set; }

	[Position(13)]
	public string SpecialServicesCode2 { get; set; }

	[Position(14)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(15)]
	public decimal? UnitPrice { get; set; }

	[Position(16)]
	public string TermsTypeCode2 { get; set; }

	[Position(17)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(18)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CS_ContractSummary>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.ChangeOrderSequenceNumber, 1, 8);
		validator.Length(x => x.ReleaseNumber, 1, 30);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.SpecialServicesCode, 2, 10);
		validator.Length(x => x.FOBPointCode, 2);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.Percent2, 1, 10);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.TermsTypeCode, 2);
		validator.Length(x => x.SpecialServicesCode2, 2, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.UnitPrice, 1, 17);
		validator.Length(x => x.TermsTypeCode2, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		return validator.Results;
	}
}
