using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("API")]
public class API_ActivityOrProcessInformation : EdiX12Segment
{
	[Position(01)]
	public string CodeCategory { get; set; }

	[Position(02)]
	public string ActionCode { get; set; }

	[Position(03)]
	public string MaintenanceTypeCode { get; set; }

	[Position(04)]
	public string StatusReasonCode { get; set; }

	[Position(05)]
	public string AffectedAreaOrSectionCode { get; set; }

	[Position(06)]
	public string InsuranceTypeCode { get; set; }

	[Position(07)]
	public string LoanTypeCode { get; set; }

	[Position(08)]
	public string InformationStatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<API_ActivityOrProcessInformation>(this);
		validator.Required(x=>x.CodeCategory);
		validator.Length(x => x.CodeCategory, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.MaintenanceTypeCode, 3);
		validator.Length(x => x.StatusReasonCode, 3);
		validator.Length(x => x.AffectedAreaOrSectionCode, 1);
		validator.Length(x => x.InsuranceTypeCode, 1, 3);
		validator.Length(x => x.LoanTypeCode, 1, 2);
		validator.Length(x => x.InformationStatusCode, 1);
		return validator.Results;
	}
}
