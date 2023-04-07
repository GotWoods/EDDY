﻿using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("H3")]
public class H3_SpecialHandlingInstructions : EdiX12Segment
{
    [Position(01)] public string SpecialHandlingCode { get; set; }

    [Position(02)] public string SpecialHandlingDescription { get; set; }

    [Position(03)] public string ProtectiveServiceCode { get; set; }

    [Position(04)] public string VentInstructionCode { get; set; }

    [Position(05)] public string TariffApplicationCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<H3_SpecialHandlingInstructions>(this);
        validator.OnlyOneOf(x => x.SpecialHandlingCode, x => x.SpecialHandlingDescription);
        validator.Length(x => x.SpecialHandlingCode, 2, 3);
        validator.Length(x => x.SpecialHandlingDescription, 2, 30);
        validator.Length(x => x.ProtectiveServiceCode, 1, 4);
        validator.Length(x => x.VentInstructionCode, 1, 7);
        validator.Length(x => x.TariffApplicationCode, 1);
        return validator.Results;
    }
}