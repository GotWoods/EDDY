﻿using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C070Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "ux*1P*Jc*PX*0h";

        var expected = new C070_CompositeChannelOfDistribution()
        {
            ChannelOfDistribution = "ux",
            ChannelOfDistribution2 = "1P",
            ChannelOfDistribution3 = "Jc",
            ChannelOfDistribution4 = "PX",
            ChannelOfDistribution5 = "0h",
        };

        var actual = Map.MapObject<C070_CompositeChannelOfDistribution>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("ux", true)]
    public void Validation_RequiredChannelOfDistribution(string channelOfDistribution, bool isValidExpected)
    {
        var subject = new C070_CompositeChannelOfDistribution();
        subject.ChannelOfDistribution = channelOfDistribution;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}