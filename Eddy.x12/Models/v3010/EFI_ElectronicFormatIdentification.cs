using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("EFI")]
public class EFI_ElectronicFormatIdentification : EdiX12Segment
{
	[Position(01)]
	public string SecurityLevelCode { get; set; }

	[Position(02)]
	public string FreeFormMessageText { get; set; }

	[Position(03)]
	public string SecurityTechniqueCode { get; set; }

	[Position(04)]
	public string VersionIdentifier { get; set; }

	[Position(05)]
	public string ProgramIdentifier { get; set; }

	[Position(06)]
	public string VersionIdentifier2 { get; set; }

	[Position(07)]
	public string InterchangeFormat { get; set; }

	[Position(08)]
	public string VersionIdentifier3 { get; set; }

	[Position(09)]
	public string CompressionTechnique { get; set; }

	[Position(10)]
	public string DrawingSheetSizeCode { get; set; }

	[Position(11)]
	public string FileName { get; set; }

	[Position(12)]
	public string BlockType { get; set; }

	[Position(13)]
	public string RecordLength { get; set; }

	[Position(14)]
	public string BlockLength { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EFI_ElectronicFormatIdentification>(this);
		validator.Required(x=>x.SecurityLevelCode);
		validator.Length(x => x.SecurityLevelCode, 2);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		validator.Length(x => x.SecurityTechniqueCode, 2);
		validator.Length(x => x.VersionIdentifier, 1, 30);
		validator.Length(x => x.ProgramIdentifier, 1, 30);
		validator.Length(x => x.VersionIdentifier2, 1, 30);
		validator.Length(x => x.InterchangeFormat, 1, 30);
		validator.Length(x => x.VersionIdentifier3, 1, 30);
		validator.Length(x => x.CompressionTechnique, 1, 30);
		validator.Length(x => x.DrawingSheetSizeCode, 2);
		validator.Length(x => x.FileName, 1, 64);
		validator.Length(x => x.BlockType, 1, 4);
		validator.Length(x => x.RecordLength, 1, 15);
		validator.Length(x => x.BlockLength, 1, 5);
		return validator.Results;
	}
}
