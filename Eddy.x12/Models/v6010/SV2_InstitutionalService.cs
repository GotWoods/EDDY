using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6010;

[Segment("SV2")]
public class SV2_InstitutionalService : EdiX12Segment
{
	[Position(01)]
	public string ProductServiceID { get; set; }

	[Position(02)]
	public C003_CompositeMedicalProcedureIdentifier CompositeMedicalProcedureIdentifier { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public decimal? UnitRate { get; set; }

	[Position(07)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(09)]
	public string NursingHomeResidentialStatusCode { get; set; }

	[Position(10)]
	public string LevelOfCareCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SV2_InstitutionalService>(this);
		validator.AtLeastOneIsRequired(x=>x.ProductServiceID, x=>x.CompositeMedicalProcedureIdentifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.Quantity);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitRate, 1, 10);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.NursingHomeResidentialStatusCode, 1);
		validator.Length(x => x.LevelOfCareCode, 1);
		return validator.Results;
	}
}
