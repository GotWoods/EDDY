using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("SMB")]
public class SMB_BeginningSegmentForRailroadStationMasterFile : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string StationTypeCode { get; set; }

	[Position(03)]
	public string StandardPointLocationCode { get; set; }

	[Position(04)]
	public string StationTypeCode2 { get; set; }

	[Position(05)]
	public string StationTypeCode3 { get; set; }

	[Position(06)]
	public string StationTypeCode4 { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(08)]
	public string Rule260JunctionCode { get; set; }

	[Position(09)]
	public string StationTypeCode5 { get; set; }

	[Position(10)]
	public string StatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SMB_BeginningSegmentForRailroadStationMasterFile>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.StationTypeCode);
		validator.Required(x=>x.StandardPointLocationCode);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.StationTypeCode, 1);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.StationTypeCode2, 1);
		validator.Length(x => x.StationTypeCode3, 1);
		validator.Length(x => x.StationTypeCode4, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Rule260JunctionCode, 1, 5);
		validator.Length(x => x.StationTypeCode5, 1);
		validator.Length(x => x.StatusCode, 2);
		return validator.Results;
	}
}
