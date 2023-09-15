using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G21")]
public class G21_ProductInformation : EdiX12Segment
{
	[Position(01)]
	public string AuthorizeDeAuthorizeCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string UPCConsumerPackageCode { get; set; }

	[Position(04)]
	public string UPCCaseCode { get; set; }

	[Position(05)]
	public int? Pack { get; set; }

	[Position(06)]
	public decimal? UnitPrice { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G21_ProductInformation>(this);
		validator.Required(x=>x.AuthorizeDeAuthorizeCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.UPCConsumerPackageCode);
		validator.Length(x => x.AuthorizeDeAuthorizeCode, 1);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.UPCConsumerPackageCode, 12);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.Pack, 1, 6);
		validator.Length(x => x.UnitPrice, 1, 14);
		return validator.Results;
	}
}
