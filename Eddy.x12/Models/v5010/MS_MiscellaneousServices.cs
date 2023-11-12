using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5010;

[Segment("MS")]
public class MS_MiscellaneousServices : EdiX12Segment
{
	[Position(01)]
	public string AgencyQualifierCode { get; set; }

	[Position(02)]
	public string SpecialServicesCode { get; set; }

	[Position(03)]
	public string AmountCharged { get; set; }

	[Position(04)]
	public string RateValueQualifier { get; set; }

	[Position(05)]
	public string AmountCharged2 { get; set; }

	[Position(06)]
	public int? AssignedNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MS_MiscellaneousServices>(this);
		validator.Required(x=>x.AgencyQualifierCode);
		validator.Required(x=>x.SpecialServicesCode);
		validator.Required(x=>x.AmountCharged);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.SpecialServicesCode, 2, 10);
		validator.Length(x => x.AmountCharged, 1, 15);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.AmountCharged2, 1, 15);
		validator.Length(x => x.AssignedNumber, 1, 6);
		return validator.Results;
	}
}
