using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("MPI")]
public class MPI_MilitaryPersonnelInformation : EdiX12Segment
{
	[Position(01)]
	public string InformationStatusCode { get; set; }

	[Position(02)]
	public string EmploymentStatusCode { get; set; }

	[Position(03)]
	public string GovernmentServiceAffiliationCode { get; set; }

	[Position(04)]
	public string Description { get; set; }

	[Position(05)]
	public string MilitaryServiceRankCode { get; set; }

	[Position(06)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(07)]
	public string DateTimePeriod { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MPI_MilitaryPersonnelInformation>(this);
		validator.Required(x=>x.InformationStatusCode);
		validator.Required(x=>x.EmploymentStatusCode);
		validator.Required(x=>x.GovernmentServiceAffiliationCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Length(x => x.InformationStatusCode, 1);
		validator.Length(x => x.EmploymentStatusCode, 2);
		validator.Length(x => x.GovernmentServiceAffiliationCode, 1);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.MilitaryServiceRankCode, 2);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		return validator.Results;
	}
}
