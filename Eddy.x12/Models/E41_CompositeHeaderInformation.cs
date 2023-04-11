using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("E41")]
public class E41_CompositeHeaderInformation : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceOperationCode { get; set; }

	[Position(02)]
	public string DataElementReferenceCode { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public int? NoteIdentificationNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E41_CompositeHeaderInformation>(this);
		validator.Required(x=>x.MaintenanceOperationCode);
		validator.Required(x=>x.DataElementReferenceCode);
		validator.Length(x => x.MaintenanceOperationCode, 1);
		validator.Length(x => x.DataElementReferenceCode, 1, 4);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.NoteIdentificationNumber, 1, 6);
		return validator.Results;
	}
}
