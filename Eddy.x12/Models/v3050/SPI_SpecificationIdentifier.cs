using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("SPI")]
public class SPI_SpecificationIdentifier : EdiX12Segment
{
	[Position(01)]
	public string SecurityLevelCode { get; set; }

	[Position(02)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(03)]
	public string ReferenceNumber { get; set; }

	[Position(04)]
	public string EntityTitle { get; set; }

	[Position(05)]
	public string EntityPurpose { get; set; }

	[Position(06)]
	public string EntityStatusCode { get; set; }

	[Position(07)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(08)]
	public string ReportTypeCode { get; set; }

	[Position(09)]
	public string SecurityLevelCode2 { get; set; }

	[Position(10)]
	public string AgencyQualifierCode { get; set; }

	[Position(11)]
	public string SourceSubqualifier { get; set; }

	[Position(12)]
	public int? AssignedNumber { get; set; }

	[Position(13)]
	public string CertificationTypeCode { get; set; }

	[Position(14)]
	public string ProposalDataDetailIdentifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SPI_SpecificationIdentifier>(this);
		validator.Required(x=>x.SecurityLevelCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.Length(x => x.SecurityLevelCode, 2);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.EntityTitle, 1, 132);
		validator.Length(x => x.EntityPurpose, 1, 80);
		validator.Length(x => x.EntityStatusCode, 1);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ReportTypeCode, 2);
		validator.Length(x => x.SecurityLevelCode2, 2);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.SourceSubqualifier, 1, 15);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.CertificationTypeCode, 1);
		validator.Length(x => x.ProposalDataDetailIdentifierCode, 1, 3);
		return validator.Results;
	}
}
