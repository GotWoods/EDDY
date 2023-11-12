using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("E10")]
public class E10_TransactionSetGrouping : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceOperationCode { get; set; }

	[Position(02)]
	public string TransactionSetIdentifierCode { get; set; }

	[Position(03)]
	public string FunctionalIdentifierCode { get; set; }

	[Position(04)]
	public string Description { get; set; }

	[Position(05)]
	public int? NoteIdentificationNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E10_TransactionSetGrouping>(this);
		validator.Required(x=>x.MaintenanceOperationCode);
		validator.Required(x=>x.TransactionSetIdentifierCode);
		validator.Required(x=>x.FunctionalIdentifierCode);
		validator.Required(x=>x.Description);
		validator.Length(x => x.MaintenanceOperationCode, 1);
		validator.Length(x => x.TransactionSetIdentifierCode, 3);
		validator.Length(x => x.FunctionalIdentifierCode, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.NoteIdentificationNumber, 1, 6);
		return validator.Results;
	}
}
