using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("EXI")]
public class EXI_ExcavationTicketInformation : EdiX12Segment
{
	[Position(01)]
	public C040_ReferenceIdentifier ReferenceIdentifier { get; set; }

	[Position(02)]
	public int? Priority { get; set; }

	[Position(03)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(04)]
	public string DateTimePeriod { get; set; }

	[Position(05)]
	public string TimePeriodUnitQualifier { get; set; }

	[Position(06)]
	public decimal? Quantity { get; set; }

	[Position(07)]
	public string Description { get; set; }

	[Position(08)]
	public string ActionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EXI_ExcavationTicketInformation>(this);
		validator.Required(x=>x.ReferenceIdentifier);
		validator.Required(x=>x.Priority);
		validator.Required(x=>x.DateTimePeriodFormatQualifier);
		validator.Required(x=>x.DateTimePeriod);
		validator.AtLeastOneIsRequired(x=>x.Quantity, x=>x.Description);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TimePeriodUnitQualifier, x=>x.Quantity);
		validator.Length(x => x.Priority, 1);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.TimePeriodUnitQualifier, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ActionCode, 1, 2);
		return validator.Results;
	}
}
