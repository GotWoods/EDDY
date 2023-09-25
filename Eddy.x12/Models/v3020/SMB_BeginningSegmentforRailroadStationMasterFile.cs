using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("SMB")]
public class SMB_BeginningSegmentForRailroadStationMasterFile : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string StationTypeCode { get; set; }

	[Position(04)]
	public string StandardPointLocationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SMB_BeginningSegmentForRailroadStationMasterFile>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.StationTypeCode);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.StationTypeCode, 1);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		return validator.Results;
	}
}
