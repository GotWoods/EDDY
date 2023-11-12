using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5010.Composites;

[Segment("C003")]
public class C003_CompositeMedicalProcedureIdentifier : EdiX12Component
{
	[Position(00)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(01)]
	public string ProductServiceID { get; set; }

	[Position(02)]
	public string ProcedureModifier { get; set; }

	[Position(03)]
	public string ProcedureModifier2 { get; set; }

	[Position(04)]
	public string ProcedureModifier3 { get; set; }

	[Position(05)]
	public string ProcedureModifier4 { get; set; }

	[Position(06)]
	public string Description { get; set; }

	[Position(07)]
	public string ProductServiceID2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C003_CompositeMedicalProcedureIdentifier>(this);
		validator.Required(x=>x.ProductServiceIDQualifier);
		validator.Required(x=>x.ProductServiceID);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 48);
		validator.Length(x => x.ProcedureModifier, 2);
		validator.Length(x => x.ProcedureModifier2, 2);
		validator.Length(x => x.ProcedureModifier3, 2);
		validator.Length(x => x.ProcedureModifier4, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ProductServiceID2, 1, 48);
		return validator.Results;
	}
}
