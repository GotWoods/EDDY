using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("PD")]
public class PD_PricingData : EdiX12Segment
{
	[Position(01)]
	public string UnitOfTimePeriodOrInterval { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string Name { get; set; }

	[Position(06)]
	public string Description { get; set; }

	[Position(07)]
	public string BreakdownStructureDetailCode { get; set; }

	[Position(08)]
	public string ReferenceIdentification { get; set; }

	[Position(09)]
	public string Description2 { get; set; }

	[Position(10)]
	public string ProposalDataDetailIdentifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PD_PricingData>(this);
		validator.Required(x=>x.UnitOfTimePeriodOrInterval);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.CompositeUnitOfMeasure);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.Name);
		validator.Length(x => x.UnitOfTimePeriodOrInterval, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.BreakdownStructureDetailCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.Description2, 1, 80);
		validator.Length(x => x.ProposalDataDetailIdentifierCode, 1, 3);
		return validator.Results;
	}
}
