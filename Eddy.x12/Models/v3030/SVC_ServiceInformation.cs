using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("SVC")]
public class SVC_ServiceInformation : EdiX12Segment
{
	[Position(01)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(02)]
	public string ProductServiceID { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(05)]
	public string ProductServiceID2 { get; set; }

	[Position(06)]
	public string ProcedureModifier { get; set; }

	[Position(07)]
	public string ProcedureModifier2 { get; set; }

	[Position(08)]
	public string ProcedureModifier3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SVC_ServiceInformation>(this);
		validator.Required(x=>x.ProductServiceIDQualifier);
		validator.Required(x=>x.ProductServiceID);
		validator.Required(x=>x.MonetaryAmount);
		validator.Required(x=>x.MonetaryAmount2);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.ProductServiceID2, 1, 30);
		validator.Length(x => x.ProcedureModifier, 2);
		validator.Length(x => x.ProcedureModifier2, 2);
		validator.Length(x => x.ProcedureModifier3, 2);
		return validator.Results;
	}
}
