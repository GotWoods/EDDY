using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("M15")]
public class M15_MasterInBondArrivalDetails : EdiX12Segment
{
	[Position(01)]
	public string StatusCode { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string LocationIdentifier { get; set; }

	[Position(05)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(06)]
	public string Time { get; set; }

	[Position(07)]
	public string SealNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M15_MasterInBondArrivalDetails>(this);
		validator.Required(x=>x.StatusCode);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.LocationIdentifier);
		validator.Required(x=>x.Time);
		validator.Length(x => x.StatusCode, 1, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.LocationIdentifier, 1, 25);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Time, 4, 6);
		validator.Length(x => x.SealNumber, 2, 15);
		return validator.Results;
	}
}
