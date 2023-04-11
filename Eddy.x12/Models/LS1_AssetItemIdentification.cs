using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("LS1")]
public class LS1_AssetItemIdentification : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string AssignedIdentification { get; set; }

	[Position(03)]
	public string ChangeOrResponseTypeCode { get; set; }

	[Position(04)]
	public string ProductServiceID { get; set; }

	[Position(05)]
	public string ProductServiceID2 { get; set; }

	[Position(06)]
	public string ProductServiceID3 { get; set; }

	[Position(07)]
	public string ProductServiceID4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LS1_AssetItemIdentification>(this);
		validator.Required(x=>x.Quantity);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.ChangeOrResponseTypeCode, 2);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.ProductServiceID2, 1, 80);
		validator.Length(x => x.ProductServiceID3, 1, 80);
		validator.Length(x => x.ProductServiceID4, 1, 80);
		return validator.Results;
	}
}
