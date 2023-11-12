using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("NCA")]
public class NCA_NonconformanceAction : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public string NonconformanceResultantResponseCode { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string UnitOfMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NCA_NonconformanceAction>(this);
		validator.AtLeastOneIsRequired(x=>x.NonconformanceResultantResponseCode, x=>x.Description);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Quantity, x=>x.UnitOfMeasurementCode);
		validator.Length(x => x.AssignedIdentification, 1, 11);
		validator.Length(x => x.NonconformanceResultantResponseCode, 1, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		return validator.Results;
	}
}
