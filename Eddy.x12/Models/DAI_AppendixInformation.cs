using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("DAI")]
public class DAI_AppendixInformation : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceOperationCode { get; set; }

	[Position(02)]
	public string CodeListReference { get; set; }

	[Position(03)]
	public int? NoteIdentificationNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DAI_AppendixInformation>(this);
		validator.Required(x=>x.MaintenanceOperationCode);
		validator.Required(x=>x.CodeListReference);
		validator.Length(x => x.MaintenanceOperationCode, 1);
		validator.Length(x => x.CodeListReference, 1, 6);
		validator.Length(x => x.NoteIdentificationNumber, 1, 6);
		return validator.Results;
	}
}
