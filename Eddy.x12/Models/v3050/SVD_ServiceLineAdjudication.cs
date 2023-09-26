using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("SVD")]
public class SVD_ServiceLineAdjudication : EdiX12Segment
{
	[Position(01)]
	public string IdentificationCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public C003_CompositeMedicalProcedureIdentifier CompositeMedicalProcedureIdentifier { get; set; }

	[Position(04)]
	public string ProductServiceID { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public int? AssignedNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SVD_ServiceLineAdjudication>(this);
		validator.Required(x=>x.IdentificationCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.IdentificationCode, 2, 20);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.ProductServiceID, 1, 40);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.AssignedNumber, 1, 6);
		return validator.Results;
	}
}
