using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("PD")]
public class PD_ProposalData : EdiX12Segment
{
	[Position(01)]
	public string UnitOfTimePeriodOrInterval { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string Name { get; set; }

	[Position(06)]
	public string Description { get; set; }

	[Position(07)]
	public string BreakdownStructureDetailCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PD_ProposalData>(this);
		validator.Required(x=>x.UnitOfTimePeriodOrInterval);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.Name);
		validator.Required(x=>x.Description);
		validator.Length(x => x.UnitOfTimePeriodOrInterval, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Name, 1, 35);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.BreakdownStructureDetailCode, 2);
		return validator.Results;
	}
}
