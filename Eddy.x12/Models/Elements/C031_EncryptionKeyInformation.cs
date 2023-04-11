﻿using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C031")]
public class C031_EncryptionKeyInformation : EdiX12Component
{
    [Position(00)]
    public string EncryptionKeyName { get; set; }

    [Position(01)]
    public string ProtocolIDCode { get; set; }

    [Position(02)]
    public string KeyingMaterial { get; set; }

    [Position(03)]
    public string OneTimeEncryptionKey { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C031_EncryptionKeyInformation>(this);
        validator.Required(x => x.EncryptionKeyName);
        validator.Length(x => x.EncryptionKeyName, 1, 64);
        validator.Length(x => x.ProtocolIDCode, 3);
        validator.Length(x => x.KeyingMaterial, 1, 512);
        validator.Length(x => x.OneTimeEncryptionKey, 1, 512);
        return validator.Results;
    }
}