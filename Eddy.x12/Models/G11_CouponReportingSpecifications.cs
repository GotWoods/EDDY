using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G11")]
public class G11_CouponReportingSpecifications : EdiX12Segment
{
	[Position(01)]
	public string ReportingStructureIdentifier { get; set; }

	[Position(02)]
	public string Category { get; set; }

	[Position(03)]
	public string Category2 { get; set; }

	[Position(04)]
	public string Category3 { get; set; }

	[Position(05)]
	public string Category4 { get; set; }

	[Position(06)]
	public string Category5 { get; set; }

	[Position(07)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(08)]
	public string ReferenceIdentification { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(10)]
	public string FreeFormDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G11_CouponReportingSpecifications>(this);
		validator.Required(x=>x.ReportingStructureIdentifier);
		validator.Required(x=>x.Category);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.ReportingStructureIdentifier, 1, 3);
		validator.Length(x => x.Category, 1, 6);
		validator.Length(x => x.Category2, 1, 6);
		validator.Length(x => x.Category3, 1, 6);
		validator.Length(x => x.Category4, 1, 6);
		validator.Length(x => x.Category5, 1, 6);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		return validator.Results;
	}
}
