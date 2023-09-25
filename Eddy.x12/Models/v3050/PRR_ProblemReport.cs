using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("PRR")]
public class PRR_ProblemReport : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public string AgencyQualifierCode { get; set; }

	[Position(03)]
	public string SourceSubqualifier { get; set; }

	[Position(04)]
	public string ComplaintCode { get; set; }

	[Position(05)]
	public string Description { get; set; }

	[Position(06)]
	public string AgencyQualifierCode2 { get; set; }

	[Position(07)]
	public string SourceSubqualifier2 { get; set; }

	[Position(08)]
	public string ServiceClassificationCode { get; set; }

	[Position(09)]
	public string AgencyQualifierCode3 { get; set; }

	[Position(10)]
	public string SourceSubqualifier3 { get; set; }

	[Position(11)]
	public string SeverityConditionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRR_ProblemReport>(this);
		validator.ARequiresB(x=>x.AgencyQualifierCode, x=>x.ComplaintCode);
		validator.ARequiresB(x=>x.SourceSubqualifier, x=>x.AgencyQualifierCode);
		validator.AtLeastOneIsRequired(x=>x.ComplaintCode, x=>x.Description);
		validator.ARequiresB(x=>x.AgencyQualifierCode2, x=>x.ServiceClassificationCode);
		validator.ARequiresB(x=>x.SourceSubqualifier2, x=>x.AgencyQualifierCode2);
		validator.ARequiresB(x=>x.AgencyQualifierCode3, x=>x.SeverityConditionCode);
		validator.ARequiresB(x=>x.SourceSubqualifier3, x=>x.AgencyQualifierCode3);
		validator.Length(x => x.AssignedIdentification, 1, 11);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.SourceSubqualifier, 1, 15);
		validator.Length(x => x.ComplaintCode, 3, 6);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.AgencyQualifierCode2, 2);
		validator.Length(x => x.SourceSubqualifier2, 1, 15);
		validator.Length(x => x.ServiceClassificationCode, 1, 4);
		validator.Length(x => x.AgencyQualifierCode3, 2);
		validator.Length(x => x.SourceSubqualifier3, 1, 15);
		validator.Length(x => x.SeverityConditionCode, 1, 2);
		return validator.Results;
	}
}
