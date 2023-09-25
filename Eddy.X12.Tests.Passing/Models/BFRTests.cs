﻿using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BFRTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "BFR*zB*V*j*Vc*o*YNiOM2hT*VfSmT8T6*Wfu9FFDY*yKGkQHHu*w*v*I6*W";

        var expected = new BFR_BeginningSegmentForPlanningSchedule()
        {
            TransactionSetPurposeCode = "zB",
            ReferenceIdentification = "V",
            ReleaseNumber = "j",
            ScheduleTypeQualifier = "Vc",
            ScheduleQuantityQualifier = "o",
            Date = "YNiOM2hT",
            Date2 = "VfSmT8T6",
            Date3 = "Wfu9FFDY",
            Date4 = "yKGkQHHu",
            ContractNumber = "w",
            PurchaseOrderNumber = "v",
            PlanningScheduleTypeCode = "I6",
            ActionCode = "W",
        };

        var actual = Map.MapObject<BFR_BeginningSegmentForPlanningSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("zB", true)]
    public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
    {
        var subject = new BFR_BeginningSegmentForPlanningSchedule();
        subject.ScheduleTypeQualifier = "Vc";
        subject.ScheduleQuantityQualifier = "o";
        subject.Date = "YNiOM2hT";
        subject.Date3 = "Wfu9FFDY";
        subject.TransactionSetPurposeCode = transactionSetPurposeCode;
        subject.ReleaseNumber = "124";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", "", false)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", true)]
    public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string releaseNumber, bool isValidExpected)
    {
        var subject = new BFR_BeginningSegmentForPlanningSchedule();
        subject.TransactionSetPurposeCode = "zB";
        subject.ScheduleTypeQualifier = "Vc";
        subject.ScheduleQuantityQualifier = "o";
        subject.Date = "YNiOM2hT";
        subject.Date3 = "Wfu9FFDY";
        subject.ReferenceIdentification = referenceIdentification;
        subject.ReleaseNumber = releaseNumber;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("Vc", true)]
    public void Validation_RequiredScheduleTypeQualifier(string scheduleTypeQualifier, bool isValidExpected)
    {
        var subject = new BFR_BeginningSegmentForPlanningSchedule();
        subject.TransactionSetPurposeCode = "zB";
        subject.ScheduleQuantityQualifier = "o";
        subject.Date = "YNiOM2hT";
        subject.Date3 = "Wfu9FFDY";
        subject.ScheduleTypeQualifier = scheduleTypeQualifier;
        subject.ReleaseNumber = "124";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("o", true)]
    public void Validation_RequiredScheduleQuantityQualifier(string scheduleQuantityQualifier, bool isValidExpected)
    {
        var subject = new BFR_BeginningSegmentForPlanningSchedule();
        subject.TransactionSetPurposeCode = "zB";
        subject.ScheduleTypeQualifier = "Vc";
        subject.Date = "YNiOM2hT";
        subject.Date3 = "Wfu9FFDY";
        subject.ScheduleQuantityQualifier = scheduleQuantityQualifier;
        subject.ReleaseNumber = "124";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("YNiOM2hT", true)]
    public void Validation_RequiredDate(string date, bool isValidExpected)
    {
        var subject = new BFR_BeginningSegmentForPlanningSchedule();
        subject.TransactionSetPurposeCode = "zB";
        subject.ScheduleTypeQualifier = "Vc";
        subject.ScheduleQuantityQualifier = "o";
        subject.Date3 = "Wfu9FFDY";
        subject.Date = date;
        subject.ReleaseNumber = "124";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("Wfu9FFDY", true)]
    public void Validation_RequiredDate3(string date3, bool isValidExpected)
    {
        var subject = new BFR_BeginningSegmentForPlanningSchedule();
        subject.TransactionSetPurposeCode = "zB";
        subject.ScheduleTypeQualifier = "Vc";
        subject.ScheduleQuantityQualifier = "o";
        subject.Date = "YNiOM2hT";
        subject.Date3 = date3;
        subject.ReleaseNumber = "124";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}