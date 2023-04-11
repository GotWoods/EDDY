using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class AT8Tests
{
    [Fact]
    public void ShouldParse()
    {
        var expected = new AT8_ShipmentWeightPackagingAndQuantityData();
        expected.WeightQualifier = "G";
        expected.WeightUnitCode = 'L'.ToString();
        expected.Weight = 6240;
        expected.LadingQuantity = 402;

        var actual = Map.MapObject<AT8_ShipmentWeightPackagingAndQuantityData>("AT8*G*L*6240*402", MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Fact]
    public void Validate()
    {
        var expected = new AT8_ShipmentWeightPackagingAndQuantityData();
        expected.WeightQualifier = "G";
        expected.WeightUnitCode = 'L'.ToString();
        expected.Weight = 6240;
        expected.LadingQuantity = 402;

        var actual = expected.Validate();
        Assert.True(actual.IsValid, actual.ToString());
    }


    [Fact]
    public void Validate_WeightQualifier_WeightUnitCode_Weight_AllRequireEachOther()
    {
        var subject = new AT8_ShipmentWeightPackagingAndQuantityData();
        subject.WeightQualifier = "G";
        subject.WeightUnitCode = 'L'.ToString();
        subject.Weight = 6240;

        var results = subject.Validate();
        Assert.True(results.IsValid, results.ToString());

        //remove weight
        subject.WeightQualifier = "";
        subject.WeightUnitCode = "L";
        subject.Weight = 6240;
        results = subject.Validate();
        Assert.False(results.IsValid);
        Assert.Single(results.Errors);
        Assert.Equal(ErrorCodes.IfOneIsFilledAllAreRequired, results.Errors[0].ErrorCode);

        //remove weight unit code
        subject.WeightQualifier = "G";
        subject.WeightUnitCode = "";
        subject.Weight = 6240;
        results = subject.Validate();
        Assert.False(results.IsValid);
        Assert.Single(results.Errors);
        Assert.Equal(ErrorCodes.IfOneIsFilledAllAreRequired, results.Errors[0].ErrorCode);

        //remove weight
        subject.WeightQualifier = "G";
        subject.WeightUnitCode = "L";
        subject.Weight = null;
        results = subject.Validate();
        Assert.False(results.IsValid);
        Assert.Single(results.Errors);
        Assert.Equal(ErrorCodes.IfOneIsFilledAllAreRequired, results.Errors[0].ErrorCode);

    }

    [Fact]
    public void Validate_VolumeUnitQualifier_Requires_Volume()
    {
        var subject = new AT8_ShipmentWeightPackagingAndQuantityData();
        subject.VolumeUnitQualifier = "L";
        subject.Volume = 6240;

        var results = subject.Validate();
        Assert.True(results.IsValid, results.ToString());

        //remove volume
        subject.VolumeUnitQualifier = "L";
        subject.Volume = null;
        results = subject.Validate();
        Assert.False(results.IsValid);
        Assert.Single(results.Errors);
        Assert.Equal(ErrorCodes.IfOneIsFilledAllAreRequired, results.Errors[0].ErrorCode);

        //remove qualifier
        subject.VolumeUnitQualifier = "";
        subject.Volume = 6240;
        results = subject.Validate();
        Assert.False(results.IsValid);
        Assert.Single(results.Errors);
        Assert.Equal(ErrorCodes.IfOneIsFilledAllAreRequired, results.Errors[0].ErrorCode);
    }
}