﻿using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C002Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "*N*M*L*C*H";

        var expected = new C002_ActionsIndicated()
        {
            PaperworkReportActionCode = "N",
            PaperworkReportActionCode2 = "M",
            PaperworkReportActionCode3 = "L",
            PaperworkReportActionCode4 = "C",
            PaperworkReportActionCode5 = "H",
        };

        var actual = Map.MapObject<C002_ActionsIndicated>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        try
        {
            Assert.Equivalent(expected, actual);
        }
        catch
        {
            Assert.Fail(actual.ValidationResult.ToString());
        }
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("N", true)]
    public void Validatation_RequiredPaperworkReportActionCode(string paperworkReportActionCode, bool isValidExpected)
    {
        var subject = new C002_ActionsIndicated();
        subject.PaperworkReportActionCode = paperworkReportActionCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}