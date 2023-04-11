using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("EFI")]
public class EFI_ElectronicFormatIdentification : EdiX12Segment
{
    [Position(1)]
    public string SecurityLevelCode { get; set; }
    [Position(2)]
    public string FreeFormMessageText { get; set; }
    [Position(3)]
    public string SecurityTechniqueCode { get; set; }
    [Position(4)]
    public string ProgramVersionIdentifier { get; set; }
    [Position(5)]
    public string ProgramIdentifier { get; set; }
    [Position(6)]
    public string InterchangeVersionIdentifier { get; set; }
    [Position(7)]
    public string InterchangeFormat { get; set; }

    [Position(8)]
    public string CompressionTechniqueVersionIdentifier { get; set; }

    [Position(9)]
    public string CompressionTechnique { get; set; }

    [Position(10)]
    public string DrawingSheetSizeCode { get; set; }

    [Position(11)]
    public string FileName { get; set; }

    [Position(12)]
    public string BlockType { get; set; }

    [Position(13)]
    public int? RecordLength { get; set; }

    [Position(14)]
    public int? BlockLength { get; set; }

    [Position(15)]
    public string FilterIdCodeVersionIdentifier { get; set; }

    [Position(16)]
    public string FilterIdCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<EFI_ElectronicFormatIdentification>(this);

        validator.Required(x => x.SecurityLevelCode);
        validator.ARequiresB(x => x.ProgramIdentifier, x => x.ProgramVersionIdentifier);
        validator.ARequiresB(x => x.InterchangeFormat, x => x.InterchangeVersionIdentifier);
        validator.ARequiresB(x => x.CompressionTechnique, x => x.CompressionTechniqueVersionIdentifier);
        validator.IfOneIsFilled_AllAreRequired(x => x.FilterIdCode, x => x.FilterIdCodeVersionIdentifier);

        validator.Length(x => x.SecurityLevelCode, 2);
        validator.Length(x => x.FreeFormMessageText, 1, 264);
        validator.Length(x => x.SecurityTechniqueCode, 2);
        validator.Length(x => x.ProgramVersionIdentifier, 1, 30);
        validator.Length(x => x.ProgramIdentifier, 1, 30);
        validator.Length(x => x.InterchangeVersionIdentifier, 1, 30);
        validator.Length(x => x.InterchangeFormat, 1, 30);
        validator.Length(x => x.CompressionTechniqueVersionIdentifier, 1, 30);
        validator.Length(x => x.CompressionTechnique, 1, 30);
        validator.Length(x => x.DrawingSheetSizeCode, 2);
        validator.Length(x => x.FileName, 1, 64);
        validator.Length(x => x.BlockType, 1, 4);
        validator.Length(x => x.RecordLength, 1, 15);
        validator.Length(x => x.BlockLength, 1, 5);
        validator.Length(x => x.FilterIdCodeVersionIdentifier, 1, 30);
        validator.Length(x => x.FilterIdCode, 3);
        return validator.Results;
    }


}