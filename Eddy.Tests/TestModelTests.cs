using Eddy.ClassGenerator.Lib;
using Eddy.Core.Validation;

namespace Eddy.Tests;

public class TestModelTests
{
    [Fact]
    public void GenerateRequired()
    {
        var model = new Model("01", "RejectedSetIdentifier", "string", 5, 10) { TestValue = "buQ1" };

        var allFields = new List<Model>()
        {
            model,
            new Model("02", "ReferenceDesignator", "string", 5, 10) {IsRequired = true, TestValue = "DEF"},
            new Model("03", "ErrorConditionCode", "string", 5, 10) { IsRequired = true, TestValue = "GHI"}
        };

        var tm = new ClassGenerator.Lib.TestModel(model, "A1_Rejection", allFields, TestType.Required);

        //tm.TestParameter.Add(tm.PrimaryItem);
        //tm.TestName = "Validation_RequiredRejectedSetIdentifier";
        //tm.Theories.Add("[InlineData(\"\", false)]");
        //tm.Theories.Add("[InlineData(\"buQ1\", true)]");
        //tm.RequiredTestItems.Add(new Model("02", "ReferenceDesignator", "string", 5, 10) { IsRequired = true, TestValue = "DEF" });
        //tm.RequiredTestItems.Add(new Model("03", "ErrorConditionCode", "string", 5, 10) { IsRequired = true, TestValue = "GHI" });

        var generate = tm.Generate();
        var expected = "\t[Theory]\r\n\t[InlineData(\"\", false)]\r\n\t[InlineData(\"buQ1\", true)]\r\n\tpublic void Validation_RequiredRejectedSetIdentifier(string rejectedSetIdentifier, bool isValidExpected)\r\n\t{\r\n\t\tvar subject = new A1_Rejection();\r\n\t\tsubject.ReferenceDesignator = \"DEF\";\r\n\t\tsubject.ErrorConditionCode = \"GHI\";\r\n\t\tsubject.RejectedSetIdentifier = rejectedSetIdentifier;\r\n\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);\r\n\t}\r\n";
        Assert.Equal(expected, generate);
    }

    [Fact]
    public void GenerateARequiresB()
    {
        
        var firstField = new Model("01", "DateTimeQualifier", "string", 5, 10)
        {
            TestValue = "DI8",
            ARequiresBValidation = new List<ValidationData> { new() { FirstFieldPosition = "01", OtherFields = new List<string> { "02" } } }
        };
        var secondField = new Model("02", "Date", "string", 5, 10)
        {
            TestValue = "8jlR59aM"
        };
        var thirdField = new Model("03", "LineItemStatusCode", "string", 5, 10)
        {
            IsRequired = true,
            TestValue = "DEF"
        };

        var allItems = new List<Model>
        {
            firstField,
            secondField,
            thirdField
        };



        var subject = new ClassGenerator.Lib.TestModel(firstField, "ACK_LineItemAcknowledgment", allItems,TestType.ARequiresBValidation);
        var result = subject.Generate(); //GenerateTestBody(TestType.ARequiresBValidation, allItems[0], allItems, "ACK_LineItemAcknowledgment", nameof(ErrorCodes.ARequiresB));
        var expected = "\t[Theory]\r\n\t[InlineData(\"\", \"\", true)]\r\n\t[InlineData(\"DI8\", \"8jlR59aM\", true)]\r\n\t[InlineData(\"DI8\", \"\", false)]\r\n\t[InlineData(\"\", \"8jlR59aM\", true)]\r\n\tpublic void Validation_ARequiresBDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)\r\n\t{\r\n\t\tvar subject = new ACK_LineItemAcknowledgment();\r\n\t\tsubject.LineItemStatusCode = \"DEF\";\r\n\t\tsubject.DateTimeQualifier = dateTimeQualifier;\r\n\t\tsubject.Date = date;\r\n\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);\r\n\t}\r\n";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GenerateAtLeastOne()
    {
        
        var firstField = new Model("01", "Date", "string", 5, 10)
        {
            TestValue = "7wRAyvyC",
            AtLeastOneValidations = new List<ValidationData> { new() { FirstFieldPosition = "01", OtherFields = new List<string> { "02" } } }
        };
        var secondField = new Model("02", "TestPeriodOrIntervalValue", "int?", 5, 10)
        {
            TestValue = "8"
        };
        var thirdField = new Model("03", "OffspringCountCode", "string", 5, 10)
        {
            IsRequired = true,
            TestValue = "FGH"
        };
        var fourthField = new Model("04", "Count", "int?", 5, 10)
        {
            IsRequired = true,
            TestValue = "9"
        };

        var allItems = new List<Model>
        {
            firstField,
            secondField,
            thirdField,
            fourthField
        };

        var subject = new ClassGenerator.Lib.TestModel(firstField, "AOC_AnimalOffspringCounts", allItems, TestType.AtLeastOneValidations);
        var result = subject.Generate(); //(TestType.AtLeastOneValidations, allItems[0], allItems, "AOC_AnimalOffspringCounts", nameof(ErrorCodes.AtLeastOneIsRequired));
        var expected = "\t[Theory]\r\n\t[InlineData(\"\", 0, false)]\r\n\t[InlineData(\"7wRAyvyC\", 8, true)]\r\n\t[InlineData(\"7wRAyvyC\", 0, true)]\r\n\t[InlineData(\"\", 8, true)]\r\n\tpublic void Validation_AtLeastOneDate(string date, int testPeriodOrIntervalValue, bool isValidExpected)\r\n\t{\r\n\t\tvar subject = new AOC_AnimalOffspringCounts();\r\n\t\tsubject.OffspringCountCode = \"FGH\";\r\n\t\tsubject.Count = 9;\r\n\t\tsubject.Date = date;\r\n\t\tif (testPeriodOrIntervalValue > 0)\r\n\t\t\tsubject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;\r\n\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);\r\n\t}\r\n";
        Assert.Equal(expected, result);
    }


    [Fact]
    public void GenerateAllAreRequired()
    {
        
        var firstField = new Model("01", "Quantity", "decimal?", 5, 10)
        {
            TestValue = "9", IfOneIsFilledAllAreRequiredValidations = new List<ValidationData> { new() { FirstFieldPosition = "01", OtherFields = new List<string> { "02" } } }
        };
        var secondField = new Model("02", "UnitOrBasisForMeasurementCode", "string", 5, 10)
        {
            TestValue = "vF"
        };
        var thirdField = new Model("03", "LineItemStatusCode", "string", 5, 10)
        {
            IsRequired = true,
            TestValue = "RH"
        };


        var allItems = new List<Model>
        {
            firstField,
            secondField,
            thirdField
        };

        var subject = new ClassGenerator.Lib.TestModel(firstField, "ACK_LineItemAcknowledgment", allItems, TestType.IfOneIsFilledAllAreRequiredValidations);
        var result = subject.Generate();  //GenerateTestBody(TestType.IfOneIsFilledAllAreRequiredValidations, allItems[0], allItems, "ACK_LineItemAcknowledgment", nameof(ErrorCodes.IfOneIsFilledAllAreRequired));
        var expected = "\t[Theory]\r\n\t[InlineData(0, \"\", true)]\r\n\t[InlineData(9, \"vF\", true)]\r\n\t[InlineData(9, \"\", false)]\r\n\t[InlineData(0, \"vF\", false)]\r\n\tpublic void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)\r\n\t{\r\n\t\tvar subject = new ACK_LineItemAcknowledgment();\r\n\t\tsubject.LineItemStatusCode = \"RH\";\r\n\t\tif (quantity > 0)\r\n\t\t\tsubject.Quantity = quantity;\r\n\t\tsubject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;\r\n\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);\r\n\t}\r\n";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GenerateIfOneIsFilledThenAtLeastOne()
    {
        var firstField = new Model("01", "Amount", "string", 5, 10)
        {
            TestValue = "S",
            IfOneIsFilledThenAtLeastOne = new List<ValidationData> { new() { FirstFieldPosition = "01", OtherFields = new List<string> { "02", "03" } } }
        };
        var secondField = new Model("02", "Amount2", "string", 5, 10) {TestValue="W"};
        var thirdField = new Model("03", "Amount3", "string", 5, 10) {TestValue = "l" };


        var allItems = new List<Model>
        {
            firstField,
            secondField,
            thirdField,
            new("04", "AdjustmentApplicationCode", "string", 0, 0) { IsRequired = true, TestValue = "E" },
            new("05", "MonetaryAmount", "int?", 0, 0) { IsRequired = true, TestValue = "8" },
            new("06", "Date", "string", 0, 0) { IsRequired = true, TestValue = "8jSVIk" },
            new("07", "Date2", "string", 0, 0) { IsRequired = true, TestValue = "moWpSm" }
        };


        var subject = new ClassGenerator.Lib.TestModel(firstField, "ADJ_AdjustmentsToBalancesOrServices", allItems, TestType.IfOneIsFilledThenAtLeastOne);
        var result = subject.Generate(); // GenerateTestBody(TestType.IfOneIsFilledThenAtLeastOne, allItems[0], allItems, "ADJ_AdjustmentsToBalancesOrServices", nameof(ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired));
        var expected = "\t[Theory]\r\n\t[InlineData(\"\", \"\", \"\", true)]\r\n\t[InlineData(\"S\", \"W\", \"l\", true)]\r\n\t[InlineData(\"S\", \"\", \"\", false)]\r\n\t[InlineData(\"\", \"W\", \"l\", true)]\r\n\tpublic void Validation_IfOneSpecifiedThenOneMoreRequired_Amount(string amount, string amount2, string amount3, bool isValidExpected)\r\n\t{\r\n\t\tvar subject = new ADJ_AdjustmentsToBalancesOrServices();\r\n\t\tsubject.AdjustmentApplicationCode = \"E\";\r\n\t\tsubject.MonetaryAmount = 8;\r\n\t\tsubject.Date = \"8jSVIk\";\r\n\t\tsubject.Date2 = \"moWpSm\";\r\n\t\tsubject.Amount = amount;\r\n\t\tsubject.Amount2 = amount2;\r\n\t\tsubject.Amount3 = amount3;\r\n\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);\r\n\t}\r\n";
        Assert.Equal(expected, result);
    }


    [Fact]
    public void GenerateOnlyOneOf()
    {
        
        var firstField = new Model("01", "LocationQualifier", "string", 5, 10)
        {
            TestValue = "A",
            OnlyOneOfValidations = new List<ValidationData> { new() { FirstFieldPosition = "01", OtherFields = new List<string> { "02" } } }
        };
        var secondField = new Model("02", "StandardCarrierAlphaCode2", "string", 5, 10) {TestValue = "bj"};


        var allItems = new List<Model>
        {
            firstField,
            secondField,
            new("03", "GeographyQualifierCode", "string", 0, 0) { IsRequired = true, TestValue = "P" }
        };


        var subject = new ClassGenerator.Lib.TestModel(firstField, "GY_Geography", allItems, TestType.OnlyOneOfValidations);
        var result = subject.Generate();  //GenerateTestBody(TestType.OnlyOneOfValidations, allItems[0], allItems, "GY_Geography", nameof(ErrorCodes.OnlyOneOf));
        var expected = "\t[Theory]\r\n\t[InlineData(\"\", \"\", true)]\r\n\t[InlineData(\"A\", \"bj\", false)]\r\n\t[InlineData(\"A\", \"\", true)]\r\n\t[InlineData(\"\", \"bj\", true)]\r\n\tpublic void Validation_OnlyOneOfLocationQualifier(string locationQualifier, string standardCarrierAlphaCode2, bool isValidExpected)\r\n\t{\r\n\t\tvar subject = new GY_Geography();\r\n\t\tsubject.GeographyQualifierCode = \"P\";\r\n\t\tsubject.LocationQualifier = locationQualifier;\r\n\t\tsubject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;\r\n\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);\r\n\t}\r\n";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GenerateWithDependentABRule()
    {
        //Here is where we have the case where we generate a test for one scenario that breaks another scenario
        //E.g. We have an IfOneIsFilledAllAreRequiredValidations but the second field being filled in would trigger an ARequiresB scenario

        
        var firstField = new Model("01", "Quantity", "decimal?", 5, 10)
        {
            TestValue = "9",
            IfOneIsFilledAllAreRequiredValidations = new List<ValidationData> { new() { FirstFieldPosition = "01", OtherFields = new List<string> { "02" } } }
        };
        var secondField = new Model("02", "UnitOrBasisForMeasurementCode", "string", 5, 10)
        {
            TestValue = "vF",
            ARequiresBValidation = new List<ValidationData> { new() { FirstFieldPosition = "02", OtherFields = new List<string> { "03" } } } //when this gets filled in the test, then LineItemStatusCode would be required

        };
        var thirdField = new Model("03", "LineItemStatusCode", "string", 5, 10)
        {
            IsRequired = false,
            TestValue = "RH"
        };


        var allItems = new List<Model>
        {
            firstField,
            secondField,
            thirdField
        };

        var subject = new ClassGenerator.Lib.TestModel(firstField, "DUM_Dummy", allItems, TestType.IfOneIsFilledAllAreRequiredValidations);
        var result = subject.Generate(); //GenerateTestBody(TestType.IfOneIsFilledAllAreRequiredValidations, allItems[0], allItems, "DUM_Dummy", nameof(ErrorCodes.IfOneIsFilledAllAreRequired));
        var expected = "\t[Theory]\r\n\t[InlineData(0, \"\", true)]\r\n\t[InlineData(9, \"vF\", true)]\r\n\t[InlineData(9, \"\", false)]\r\n\t[InlineData(0, \"vF\", false)]\r\n\tpublic void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)\r\n\t{\r\n\t\tvar subject = new DUM_Dummy();\r\n\t\tif (quantity > 0)\r\n\t\t\tsubject.Quantity = quantity;\r\n\t\tsubject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;\r\n\t\tif (unitOrBasisForMeasurementCode != \"\")\r\n\t\t\tsubject.LineItemStatusCode == \"RH\"\r\n\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);\r\n\t}\r\n";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GenerateWithDependentAtLeastOneOfRule()
    {
        var firstField = new Model("01", "Quantity", "decimal?", 5, 10)
        {
            IsRequired = true,
            TestValue = "9",
            //IfOneIsFilledAllAreRequiredValidations = new List<ValidationData> { new() { FirstFieldPosition = "01", OtherFields = new List<string> { "02" } } }
        };
        var secondField = new Model("02", "UnitOrBasisForMeasurementCode", "string", 5, 10)
        {
            TestValue = "vF",
            AtLeastOneValidations = new List<ValidationData> { new() { FirstFieldPosition = "02", OtherFields = new List<string> { "03" } } } //when this gets filled in the test, then  either this or the LineItemStatusCode would be required
        };
        var thirdField = new Model("03", "LineItemStatusCode", "string", 5, 10)
        {
            IsRequired = false,
            TestValue = "RH"
        };

        var allItems = new List<Model>
        {
            firstField,
            secondField,
            thirdField
        };

        var subject = new ClassGenerator.Lib.TestModel(firstField, "DUM_Dummy", allItems, TestType.Required);
        var result = subject.Generate(); //GenerateTestBody(TestType.IfOneIsFilledAllAreRequiredValidations, allItems[0], allItems, "DUM_Dummy", nameof(ErrorCodes.IfOneIsFilledAllAreRequired));
        var expected = "";
        Assert.Equal(expected, result);
    }
}