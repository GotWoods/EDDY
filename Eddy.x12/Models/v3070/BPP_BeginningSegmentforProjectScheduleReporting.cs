using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("BPP")]
public class BPP_BeginningSegmentForProjectScheduleReporting : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string NetworkOrScheduleDataType { get; set; }

	[Position(04)]
	public string ContractNumber { get; set; }

	[Position(05)]
	public string Description { get; set; }

	[Position(06)]
	public string ReferenceIdentification { get; set; }

	[Position(07)]
	public string Date2 { get; set; }

	[Position(08)]
	public string ReportTypeCode { get; set; }

	[Position(09)]
	public string ReferenceIdentification2 { get; set; }

	[Position(10)]
	public string Description2 { get; set; }

	[Position(11)]
	public string Date3 { get; set; }

	[Position(12)]
	public string ReferenceIdentification3 { get; set; }

	[Position(13)]
	public string SecurityLevelCode { get; set; }

	[Position(14)]
	public string VersionIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BPP_BeginningSegmentForProjectScheduleReporting>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.NetworkOrScheduleDataType);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.NetworkOrScheduleDataType, 2);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.ReportTypeCode, 2);
		validator.Length(x => x.ReferenceIdentification2, 1, 30);
		validator.Length(x => x.Description2, 1, 80);
		validator.Length(x => x.Date3, 6);
		validator.Length(x => x.ReferenceIdentification3, 1, 30);
		validator.Length(x => x.SecurityLevelCode, 2);
		validator.Length(x => x.VersionIdentifier, 1, 30);
		return validator.Results;
	}
}
