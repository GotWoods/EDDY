using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("TXN")]
public class TXN_TransactionCapabilities : EdiX12Segment
{
	[Position(01)]
	public string ActionCode { get; set; }

	[Position(02)]
	public string ResponsibleAgencyCode { get; set; }

	[Position(03)]
	public string TransactionSetIdentifierCode { get; set; }

	[Position(04)]
	public string VersionReleaseIndustryIdentifierCode { get; set; }

	[Position(05)]
	public string ActionCode2 { get; set; }

	[Position(06)]
	public string ApplicationReceiversCode { get; set; }

	[Position(07)]
	public string ApplicationSendersCode { get; set; }

	[Position(08)]
	public string Date { get; set; }

	[Position(09)]
	public string Time { get; set; }

	[Position(10)]
	public C053_StandardsInformation StandardsInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TXN_TransactionCapabilities>(this);
		validator.Required(x=>x.ActionCode);
		validator.OnlyOneOf(x=>x.VersionReleaseIndustryIdentifierCode, x=>x.StandardsInformation);
		validator.Required(x=>x.ActionCode2);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.ResponsibleAgencyCode, 1, 2);
		validator.Length(x => x.TransactionSetIdentifierCode, 3);
		validator.Length(x => x.VersionReleaseIndustryIdentifierCode, 1, 12);
		validator.Length(x => x.ActionCode2, 1, 2);
		validator.Length(x => x.ApplicationReceiversCode, 2, 15);
		validator.Length(x => x.ApplicationSendersCode, 2, 15);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		return validator.Results;
	}
}
