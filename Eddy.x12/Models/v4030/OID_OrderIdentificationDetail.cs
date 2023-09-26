using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("OID")]
public class OID_OrderIdentificationDetail : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string PurchaseOrderNumber { get; set; }

	[Position(03)]
	public string ReferenceIdentification2 { get; set; }

	[Position(04)]
	public string PackagingFormCode { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public string WeightUnitCode { get; set; }

	[Position(07)]
	public decimal? Weight { get; set; }

	[Position(08)]
	public string VolumeUnitQualifier { get; set; }

	[Position(09)]
	public decimal? Volume { get; set; }

	[Position(10)]
	public string ApplicationErrorConditionCode { get; set; }

	[Position(11)]
	public string ReferenceIdentification3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<OID_OrderIdentificationDetail>(this);
		validator.AtLeastOneIsRequired(x=>x.ReferenceIdentification, x=>x.PurchaseOrderNumber);
		validator.ARequiresB(x=>x.ReferenceIdentification2, x=>x.PurchaseOrderNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PackagingFormCode, x=>x.Quantity);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WeightUnitCode, x=>x.Weight);
		validator.IfOneIsFilled_AllAreRequired(x=>x.VolumeUnitQualifier, x=>x.Volume);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.ReferenceIdentification2, 1, 50);
		validator.Length(x => x.PackagingFormCode, 3);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.VolumeUnitQualifier, 1);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.ApplicationErrorConditionCode, 1, 3);
		validator.Length(x => x.ReferenceIdentification3, 1, 50);
		return validator.Results;
	}
}
