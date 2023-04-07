using System;
using System.Collections.Generic;
using System.Text;
using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BOL")]
public class BOL_BeginningSegmentForTheMotorCarrierBillOfLading : EdiX12Segment
{
    [Position(01)]
    public string StandardCarrierAlphaCode { get; set; }

    [Position(02)]
    public string ShipmentMethodOfPaymentCode { get; set; }

    [Position(03)]
    public string ShipmentIdentificationNumber { get; set; }

    [Position(04)]
    public string Date { get; set; }

    [Position(05)]
    public string Time { get; set; }

    [Position(06)]
    public string ReferenceIdentification { get; set; }

    [Position(07)]
    public string StatusReportRequestCode { get; set; }

    [Position(08)]
    public string SectionSevenCode { get; set; }

    [Position(09)]
    public string CustomsDocumentationHandlingCode { get; set; }

    [Position(10)]
    public string ShipmentMethodOfPaymentCode2 { get; set; }

    [Position(11)]
    public string CurrencyCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<BOL_BeginningSegmentForTheMotorCarrierBillOfLading>(this);
        validator.Required(x => x.StandardCarrierAlphaCode);
        validator.Required(x => x.ShipmentMethodOfPaymentCode);
        validator.Required(x => x.ShipmentIdentificationNumber);
        validator.Required(x => x.Date);
        validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
        validator.Length(x => x.ShipmentMethodOfPaymentCode, 2);
        validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
        validator.Length(x => x.Date, 8);
        validator.Length(x => x.Time, 4, 8);
        validator.Length(x => x.ReferenceIdentification, 1, 80);
        validator.Length(x => x.StatusReportRequestCode, 1);
        validator.Length(x => x.SectionSevenCode, 1);
        validator.Length(x => x.CustomsDocumentationHandlingCode, 2);
        validator.Length(x => x.ShipmentMethodOfPaymentCode2, 2);
        validator.Length(x => x.CurrencyCode, 3);
        return validator.Results;
    }
}
