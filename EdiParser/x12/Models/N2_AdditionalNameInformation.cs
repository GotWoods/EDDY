using System;
using System.Collections.Generic;
using System.Text;
using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;


[Segment("N2")]
public class N2_AdditionalNameInformation : EdiX12Segment
{
    [Position(01)]
    public string Name { get; set; }

    [Position(02)]
    public string Name2 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<N2_AdditionalNameInformation>(this);
        validator.Required(x => x.Name);
        validator.Length(x => x.Name, 1, 60);
        validator.Length(x => x.Name, 1, 60);
        return validator.Results;
    }


}