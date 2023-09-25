using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("SV2")]
public class SV2_InstitutionalService : EdiX12Segment
{
	[Position(01)]
	public string ProductServiceID { get; set; }

	[Position(02)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(03)]
	public string ProductServiceID2 { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	[Position(05)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(06)]
	public decimal? Quantity { get; set; }

	[Position(07)]
	public string ProcedureModifier { get; set; }

	[Position(08)]
	public string ProcedureModifier2 { get; set; }

	[Position(09)]
	public string ProcedureModifier3 { get; set; }

	[Position(10)]
	public decimal? UnitRate { get; set; }

	[Position(11)]
	public string Description { get; set; }

	[Position(12)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(13)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(14)]
	public string NursingHomeResidentialStatusCode { get; set; }

	[Position(15)]
	public string LevelOfCareCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SV2_InstitutionalService>(this);
		validator.AtLeastOneIsRequired(x=>x.ProductServiceID, x=>x.ProductServiceID2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.Quantity);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID2, 1, 30);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ProcedureModifier, 2);
		validator.Length(x => x.ProcedureModifier2, 2);
		validator.Length(x => x.ProcedureModifier3, 2);
		validator.Length(x => x.UnitRate, 1, 10);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.NursingHomeResidentialStatusCode, 1);
		validator.Length(x => x.LevelOfCareCode, 1);
		return validator.Results;
	}
}
