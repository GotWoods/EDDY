using System;
using System.Globalization;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("GS")]
public class GenericFunctionalGroupHeader : EdiX12Segment
{
    [Position(01)]
    public string FunctionalIdentifierCode { get; set; }

    [Position(02)]
    public string ApplicationSendersCode { get; set; }
    
    [Position(03)]
    public string ApplicationReceiversCode { get; set; }
    
    [Position(04)]
    public string Date { get; set; }

    [Position(05)]
    public string Time { get; set; }

    [Position(06)]
    public string GroupControlNumber { get; set; }

    [Position(07)]
    public string ResponsibleAgencyCode { get; set; }

    [Position(08)]
    public string VersionReleaseIndustryIdentifierCode { get; set; }

    public override ValidationResult Validate()
    {
        return new ValidationResult();
    }

    public DateTime GetDateTime()
    {
        return x12DateTimeParser.Parse(Date, Time, SupportedDateFormats.EightDigit, SupportedTimeFormats.All);
    }
}