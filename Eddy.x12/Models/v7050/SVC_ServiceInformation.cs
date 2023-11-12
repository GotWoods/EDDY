using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050.Composites;
namespace Eddy.x12.Models.v7050;

[Segment("SVC")]
public class SVC_ServiceInformation : EdiX12Segment
{
	[Position(01)]
	public C003_CompositeMedicalProcedureIdentifier CompositeMedicalProcedureIdentifier { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(04)]
	public string ProductServiceID { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public C003_CompositeMedicalProcedureIdentifier CompositeMedicalProcedureIdentifier2 { get; set; }

	[Position(07)]
	public decimal? Quantity2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SVC_ServiceInformation>(this);
		validator.Required(x=>x.CompositeMedicalProcedureIdentifier);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		return validator.Results;
	}
}
