using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Models.Internals;

namespace EdiParser.x12.Models;

[Segment("L0")]
public class L0_LineItemQuantityAndWeight : EdiX12Segment
{
    [Position(01)] public string LadingLineItemNumber { get; set; }

    [Position(02)] public decimal? BilledOrRatedAsQuantity { get; set; }

    [Position(03)] public string BilledOrRatedAsQualifier { get; set; }

    [Position(04)] public decimal? Weight { get; set; }

    [Position(05)] public string WeightQualifier { get; set; }

    [Position(06)] public decimal? Volume { get; set; }

    [Position(07)] public string VolumeUnitQualifier { get; set; }

    [Position(08)] public int? LadingQuantity { get; set; }

    [Position(09)] public string PackagingFormCode { get; set; }

    [Position(10)] public string DunnageDescription { get; set; }

    [Position(11)] public string WeightUnitCode { get; set; }

    [Position(12)] public string TypeOfServiceCode { get; set; }

    [Position(13)] public decimal? Quantity { get; set; }

    [Position(14)] public string PackagingFormCode2 { get; set; }

    [Position(15)] public string YesNoConditionorResponseCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<L0_LineItemQuantityAndWeight>(this);

        validator.IfOneIsFilled_AllAreRequired(x=>x.BilledOrRatedAsQualifier, x=>x.BilledOrRatedAsQuantity);
        validator.IfOneIsFilled_AllAreRequired(x => x.WeightQualifier, x => x.Weight);
        validator.IfOneIsFilled_AllAreRequired(x => x.VolumeUnitQualifier, x => x.Volume);
        validator.IfOneIsFilled_AllAreRequired(x => x.PackagingFormCode, x => x.LadingQuantity);
        validator.IfOneIsFilled_AllAreRequired(x => x.Quantity, x => x.YesNoConditionorResponseCode);

        validator.ARequiresB(x => x.WeightUnitCode, x => x.Weight);

        validator.Length(x => x.LadingLineItemNumber, 1, 6);
        validator.Length(x => x.BilledOrRatedAsQuantity, 1, 11);
        validator.Length(x => x.BilledOrRatedAsQualifier, 2);
        validator.Length(x => x.Weight, 1, 10);
        validator.Length(x => x.WeightQualifier, 1, 2);
        validator.Length(x => x.Volume, 1, 8);
        validator.Length(x => x.VolumeUnitQualifier, 1);
        validator.Length(x => x.LadingQuantity, 1, 7);
        validator.Length(x => x.PackagingFormCode, 3);
        validator.Length(x => x.DunnageDescription, 2, 25);
        validator.Length(x => x.WeightUnitCode, 1);
        validator.Length(x => x.TypeOfServiceCode, 2);
        validator.Length(x => x.Quantity, 1, 15);
        validator.Length(x => x.PackagingFormCode2, 3);
        validator.Length(x => x.YesNoConditionorResponseCode, 1);
        return validator.Results;
    }


}