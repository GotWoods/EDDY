using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060.Composites;

namespace Eddy.x12.Models.v3060;

[Segment("REC")]
public class REC_RealEstateCondition : EdiX12Segment
{
	[Position(01)]
	public string OccupancyCode { get; set; }

	[Position(02)]
	public string RealEstatePropertyConditionCode { get; set; }

	[Position(03)]
	public string PropertyDamageCode { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public string PropertyInspectionQualifier { get; set; }

	[Position(07)]
	public string ActionCode { get; set; }

	[Position(08)]
	public string QuantityQualifier { get; set; }

	[Position(09)]
	public decimal? Quantity2 { get; set; }

	[Position(10)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(11)]
	public string OccupancyVerificationCode { get; set; }

	[Position(12)]
	public string NoteReferenceCode { get; set; }

	[Position(13)]
	public string FreeFormMessage { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<REC_RealEstateCondition>(this);
		validator.Required(x=>x.OccupancyCode);
		validator.ARequiresB(x=>x.PropertyInspectionQualifier, x=>x.RealEstatePropertyConditionCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.QuantityQualifier, x=>x.Quantity2);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.QuantityQualifier, x=>x.PropertyInspectionQualifier, x=>x.ActionCode, x=>x.Quantity2, x=>x.CompositeUnitOfMeasure, x=>x.NoteReferenceCode, x=>x.FreeFormMessage);
		validator.ARequiresB(x=>x.Quantity2, x=>x.PropertyInspectionQualifier);
		validator.ARequiresB(x=>x.NoteReferenceCode, x=>x.FreeFormMessage);
		validator.Length(x => x.OccupancyCode, 2);
		validator.Length(x => x.RealEstatePropertyConditionCode, 2);
		validator.Length(x => x.PropertyDamageCode, 1, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.PropertyInspectionQualifier, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.OccupancyVerificationCode, 2);
		validator.Length(x => x.NoteReferenceCode, 3);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		return validator.Results;
	}
}
