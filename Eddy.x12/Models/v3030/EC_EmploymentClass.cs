using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("EC")]
public class EC_EmploymentClass : EdiX12Segment
{
	[Position(01)]
	public string EmploymentClassCode { get; set; }

	[Position(02)]
	public string EmploymentClassCode2 { get; set; }

	[Position(03)]
	public string EmploymentClassCode3 { get; set; }

	[Position(04)]
	public decimal? Percent { get; set; }

	[Position(05)]
	public string InformationStatusCode { get; set; }

	[Position(06)]
	public string OccupationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EC_EmploymentClass>(this);
		validator.Length(x => x.EmploymentClassCode, 2, 3);
		validator.Length(x => x.EmploymentClassCode2, 2, 3);
		validator.Length(x => x.EmploymentClassCode3, 2, 3);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.InformationStatusCode, 1);
		validator.Length(x => x.OccupationCode, 4, 6);
		return validator.Results;
	}
}
