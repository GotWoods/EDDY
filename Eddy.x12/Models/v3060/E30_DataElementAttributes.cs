using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("E30")]
public class E30_DataElementAttributes : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceOperationCode { get; set; }

	[Position(02)]
	public int? DataElementReferenceNumber { get; set; }

	[Position(03)]
	public string DataElementType { get; set; }

	[Position(04)]
	public int? MinimumLength { get; set; }

	[Position(05)]
	public int? MaximumLength { get; set; }

	[Position(06)]
	public string Description { get; set; }

	[Position(07)]
	public int? NoteIdentificationNumber { get; set; }

	[Position(08)]
	public int? DataElementReferenceNumber2 { get; set; }

	[Position(09)]
	public string CodeListReference { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E30_DataElementAttributes>(this);
		validator.Required(x=>x.MaintenanceOperationCode);
		validator.Required(x=>x.DataElementReferenceNumber);
		validator.Required(x=>x.DataElementType);
		validator.Required(x=>x.MinimumLength);
		validator.Required(x=>x.MaximumLength);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DataElementReferenceNumber2, x=>x.CodeListReference);
		validator.Length(x => x.MaintenanceOperationCode, 1);
		validator.Length(x => x.DataElementReferenceNumber, 1, 4);
		validator.Length(x => x.DataElementType, 1, 2);
		validator.Length(x => x.MinimumLength, 1, 2);
		validator.Length(x => x.MaximumLength, 1, 7);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.NoteIdentificationNumber, 1, 6);
		validator.Length(x => x.DataElementReferenceNumber2, 1, 4);
		validator.Length(x => x.CodeListReference, 1, 6);
		return validator.Results;
	}
}
