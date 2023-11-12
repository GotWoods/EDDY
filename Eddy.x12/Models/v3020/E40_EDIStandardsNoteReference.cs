using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("E40")]
public class E40_EDIStandardsNoteReference : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceOperationCode { get; set; }

	[Position(02)]
	public int? NoteIdentificationNumber { get; set; }

	[Position(03)]
	public string ElectronicFormNoteReferenceCode { get; set; }

	[Position(04)]
	public string AssignedIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E40_EDIStandardsNoteReference>(this);
		validator.Required(x=>x.MaintenanceOperationCode);
		validator.Required(x=>x.NoteIdentificationNumber);
		validator.Required(x=>x.ElectronicFormNoteReferenceCode);
		validator.Length(x => x.MaintenanceOperationCode, 1);
		validator.Length(x => x.NoteIdentificationNumber, 1, 6);
		validator.Length(x => x.ElectronicFormNoteReferenceCode, 3);
		validator.Length(x => x.AssignedIdentification, 1, 11);
		return validator.Results;
	}
}
