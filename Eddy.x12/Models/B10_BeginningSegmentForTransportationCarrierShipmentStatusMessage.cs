using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("B10")]
public class B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage : EdiX12Segment
{
    [Position(1)]
    public string ReferenceIdentification { get; set; }
    [Position(2)]
    public string ShipmentIdentificationNumber { get; set; }
    [Position(3)]
    public string StandardCarrierAlphaCode { get; set; }
    [Position(4)]
    public int? InquiryRequestNumber { get; set; }
    [Position(5)]
    public string ReferenceIdentificationQualifier { get; set; }
    [Position(6)]
    public string ReferenceIdentification2 { get; set; }
    [Position(7)]
    public char YesNoConditionOrResponseCode { get; set; }
    [Position(8)]
    public string Date { get; set; }
    [Position(9)]
    public string Time { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage>(this);
        validator.RequiredAorB(x => x.ReferenceIdentification, x => x.ReferenceIdentification2);
        validator.OnlyOneOf(x => x.ReferenceIdentification, x => x.ReferenceIdentificationQualifier);
        
        validator.ARequiresB(x => x.ReferenceIdentification2, x => x.ReferenceIdentificationQualifier);
        //validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentification2, x=>x.ReferenceIdentification);

        validator.VerifyDateFormat(x => x.Date);
        validator.VerifyTimeFormat(x => x.Time);
        validator.ARequiresB(x => x.Time, x => x.Date); //if a time is provided, a date must be also

        validator.Length(x => x.ReferenceIdentification, 1, 80);
        validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
        validator.Length(x => x.StandardCarrierAlphaCode, 2, 4); //may only be for 214s
        validator.Length(x => x.InquiryRequestNumber, 1, 3);
        validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
        validator.Length(x => x.ReferenceIdentification2, 1, 80);
        validator.Length(x => x.YesNoConditionOrResponseCode, 1);
        validator.Length(x => x.Date, 8);
        validator.Length(x => x.Time, 4, 8);


        validator.Required(x=>x.StandardCarrierAlphaCode);

        // //If 1 or 2 or 3 are present, all are required
        // validator.ARequiresB(x => x.WeightQualifier, x => x.WeightUnitCode);
        // validator.ARequiresB(x => x.WeightQualifier, x => x.Weight);
        //
        // validator.ARequiresB(x => x.WeightUnitCode, x => x.WeightQualifier);
        // validator.ARequiresB(x => x.WeightUnitCode, x => x.Weight);
        //
        // validator.ARequiresB(x => x.Weight, x => x.WeightQualifier);
        // validator.ARequiresB(x => x.Weight, x => x.WeightUnitCode);

        return validator.Results;
    }


}