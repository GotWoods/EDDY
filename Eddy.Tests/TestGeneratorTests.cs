using Eddy.ClassGenerator.Lib;
using Eddy.Core.Validation;

namespace Eddy.Tests;

public class TestGeneratorTests
{
    [Fact]
    public void GenerateRequired()
    {
        var tm = new ClassGenerator.Lib.TestModel();
        tm.SubjectName = "A1_Rejection";
        tm.ExpectedErrorCode = nameof(ErrorCodes.Required);
        tm.PrimaryItem = new Model("01", "RejectedSetIdentifier", "string", 5, 10) { TestValue = "ABC" };
        tm.TestParameter.Add(tm.PrimaryItem);
        tm.TestName = "Validation_RequiredRejectedSetIdentifier";
        tm.Theories.Add("[InlineData(\"\", false)]");
        tm.Theories.Add("[InlineData(\"buQ1\", true)]");
        tm.RequiredTestItems.Add(new Model("02", "ReferenceDesignator", "string", 5, 10) { IsRequired = true, TestValue = "DEF" });
        tm.RequiredTestItems.Add(new Model("03", "ErrorConditionCode", "string", 5, 10) { IsRequired = true, TestValue = "GHI" });

        var generate = tm.Generate();
        var expected = "\t[Theory]\r\n[InlineData(\"\", false)]\r\n[InlineData(\"buQ1\", true)]\r\n\tpublic void Validation_RequiredRejectedSetIdentifier(string rejectedSetIdentifier, bool isValidExpected)\r\n\t{\r\n\t\tvar subject = new A1_Rejection();\r\n\t\tsubject.ReferenceDesignator = \"DEF\";\r\n\t\tsubject.ErrorConditionCode = \"GHI\";\r\n\t\tsubject.RejectedSetIdentifier = rejectedSetIdentifier;\r\n\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);\r\n\t}\r\n";
        Assert.Equal(expected, generate);
    }

    [Fact]
    public void GenerateARequiresB()
    {
        var subject = new TestGenerator();
        var firstField = new Model("01", "DateTimeQualifier", "string", 5, 10)
        {
            TestValue = "ABC",
            ARequiresBValidation = new List<ValidationData> { new() { FirstFieldPosition = "01", OtherFields = new List<string> { "02" } } }
        };
        var secondField = new Model("02", "Date", "string", 5, 10)
        {
            TestValue = "CDE"
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

        var theories = new List<string>
        {
            "[InlineData(\"\", \"\", true)]",
            "[InlineData(\"\", \"8jlR59aM\", true)]",
            "[InlineData(\"DI8\", \"\", false)]"
        };

        var result = subject.GenerateTestBody(TestType.ARequiresBValidation, allItems[0], allItems, "ACK_LineItemAcknowledgment", theories, nameof(ErrorCodes.ARequiresB));
        var expected = "\t[Theory]\r\n[InlineData(\"\", \"\", true)]\r\n[InlineData(\"\", \"8jlR59aM\", true)]\r\n[InlineData(\"DI8\", \"\", false)]\r\n\tpublic void Validation_ARequiresBDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)\r\n\t{\r\n\t\tvar subject = new ACK_LineItemAcknowledgment();\r\n\t\tsubject.LineItemStatusCode = \"DEF\";\r\n\t\tsubject.DateTimeQualifier = dateTimeQualifier;\r\n\t\tsubject.Date = date;\r\n\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);\r\n\t}\r\n";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GenerateAtLeastOne()
    {
        var subject = new TestGenerator();
        var firstField = new Model("01", "Date", "string", 5, 10)
        {
            TestValue = "ABC",
            AtLeastOneValidations = new List<ValidationData> { new() { FirstFieldPosition = "01", OtherFields = new List<string> { "02" } } }
        };
        var secondField = new Model("02", "TestPeriodOrIntervalValue", "int", 5, 10)
        {
            TestValue = "CDE"
        };
        var thirdField = new Model("03", "OffspringCountCode", "string", 5, 10)
        {
            IsRequired = true,
            TestValue = "FGH"
        };
        var fourthField = new Model("04", "Count", "int?", 5, 10)
        {
            IsRequired = true,
            TestValue = "9",
        };

        var allItems = new List<Model>
        {
            firstField,
            secondField,
            thirdField, 
            fourthField,
        };

        var theories = new List<string>
        {
            "[InlineData(\"\", 0, false)]",
            "[InlineData(\"7wRAyvyC\", 8, true)]",
            "[InlineData(\"\", 8, true)]",
            "[InlineData(\"7wRAyvyC\", 0, true)]"
        };

        var result = subject.GenerateTestBody(TestType.AtLeastOneValidations, allItems[0], allItems, "AOC_AnimalOffspringCounts", theories, nameof(ErrorCodes.AtLeastOneIsRequired));
        var expected = "\t[Theory]\r\n[InlineData(\"\", 0, false)]\r\n[InlineData(\"7wRAyvyC\", 8, true)]\r\n[InlineData(\"\", 8, true)]\r\n[InlineData(\"7wRAyvyC\", 0, true)]\r\n\tpublic void Validation_AtLeastOneDate(string date, int testPeriodOrIntervalValue, bool isValidExpected)\r\n\t{\r\n\t\tvar subject = new AOC_AnimalOffspringCounts();\r\n\t\tsubject.OffspringCountCode = \"FGH\";\r\n\t\tsubject.Count = 9;\r\n\t\tsubject.Date = date;\r\n\t\tsubject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;\r\n\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);\r\n\t}\r\n";
        Assert.Equal(expected, result);
    }


    [Fact]
    public void GenerateAllAreRequired()
    {
   
        var subject = new TestGenerator();
        var firstField = new Model("01", "Quantity", "decimal?", 5, 10)
        {
            TestValue = "ABC",  IfOneIsFilledAllAreRequiredValidations = new List<ValidationData> { new() { FirstFieldPosition = "01", OtherFields = new List<string> { "02" } } }
        };
        var secondField = new Model("02", "UnitOrBasisForMeasurementCode", "string", 5, 10)
        {
            TestValue = "CDE"
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
            thirdField,
        };

        //[InlineData(0, "", true)]
        //[InlineData(9, "vF", true)]
        //[InlineData(0, "vF", false)]
        //[InlineData(9, "", false)]

        var theories = new List<string>
        {
            "[InlineData(0, \"\", true)]",
            "[InlineData(9, \"vF\", true)]",
            "[InlineData(0, \"vF\", false)]",
            "[InlineData(9, \"\", false)]"
        };

        var result = subject.GenerateTestBody(TestType.IfOneIsFilledAllAreRequiredValidations, allItems[0], allItems, "ACK_LineItemAcknowledgment", theories, nameof(ErrorCodes.IfOneIsFilledAllAreRequired));
        var expected = "\t[Theory]\r\n[InlineData(0, \"\", true)]\r\n[InlineData(9, \"vF\", true)]\r\n[InlineData(0, \"vF\", false)]\r\n[InlineData(9, \"\", false)]\r\n\tpublic void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)\r\n\t{\r\n\t\tvar subject = new ACK_LineItemAcknowledgment();\r\n\t\tsubject.LineItemStatusCode = \"RH\";\r\n\t\tif (quantity > 0)\r\n\t\tsubject.Quantity = quantity;\r\n\t\tsubject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;\r\n\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);\r\n\t}\r\n";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GenerateIfOneIsFilledThenAtLeastOne()
    {
        var subject = new TestGenerator();
        var firstField = new Model("01", "Amount", "string", 5, 10)
        {
            IfOneIsFilledThenAtLeastOne = new List<ValidationData> { new() { FirstFieldPosition = "01", OtherFields = new List<string> { "02", "03" } } }
        };
        var secondField = new Model("02", "Amount2", "string", 5, 10);
        var thirdField = new Model("03", "Amount3", "string", 5, 10);



        var allItems = new List<Model>
        {
            firstField,
            secondField,
            thirdField,
            new Model("04", "AdjustmentApplicationCode", "string", 0,0 ) { IsRequired = true, TestValue = "E"},
            new Model("05", "MonetaryAmount", "int?", 0,0 ) { IsRequired = true, TestValue = "8"},
            new Model("06", "Date", "string", 0,0 ) { IsRequired = true, TestValue = "8jSVIk"},
            new Model("07", "Date2", "string", 0,0 ) { IsRequired = true, TestValue = "moWpSm"},
        };

        var theories = new List<string>
        {
            "[InlineData(\"\", \"\", \"\", true)]",
            "[InlineData(\"S\", \"W\", \"l\", true)]",
            "[InlineData(\"S\", \"\", \"\", false)]",
            "[InlineData(\"\", \"W\", \"l\", true)]"
        };

        var result = subject.GenerateTestBody(TestType.IfOneIsFilledThenAtLeastOne, allItems[0], allItems, "ADJ_AdjustmentsToBalancesOrServices", theories, nameof(ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired));
        var expected = "\t[Theory]\r\n[InlineData(\"\", \"\", \"\", true)]\r\n[InlineData(\"S\", \"W\", \"l\", true)]\r\n[InlineData(\"S\", \"\", \"\", false)]\r\n[InlineData(\"\", \"W\", \"l\", true)]\r\n\tpublic void Validation_IfOneSpecifiedThenOneMoreRequired_Amount(string amount, string amount2, string amount3, bool isValidExpected)\r\n\t{\r\n\t\tvar subject = new ADJ_AdjustmentsToBalancesOrServices();\r\n\t\tsubject.AdjustmentApplicationCode = \"E\";\r\n\t\tsubject.MonetaryAmount = 8;\r\n\t\tsubject.Date = \"8jSVIk\";\r\n\t\tsubject.Date2 = \"moWpSm\";\r\n\t\tsubject.Amount = amount;\r\n\t\tsubject.Amount2 = amount2;\r\n\t\tsubject.Amount3 = amount3;\r\n\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);\r\n\t}\r\n";
        Assert.Equal(expected, result);
    }

   
    [Fact]
    public void GenerateOnlyOneOf()
    {
        /*
    [Theory]
	[InlineData("", "", true)]
	[InlineData("A", "bj", false)]
	[InlineData("", "bj", true)]
	[InlineData("A", "", true)]
	public void Validation_OnlyOneOfLocationQualifier(string locationQualifier, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = "P";
		subject.LocationQualifier = locationQualifier;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}
         */
        var subject = new TestGenerator();
        var firstField = new Model("01", "LocationQualifier", "string", 5, 10)
        {
            OnlyOneOfValidations = new List<ValidationData> { new() { FirstFieldPosition = "01", OtherFields = new List<string> { "02" } } }
        };
        var secondField = new Model("02", "StandardCarrierAlphaCode2", "string", 5, 10);
        


        var allItems = new List<Model>
        {
            firstField,
            secondField,
            new Model("03", "GeographyQualifierCode", "string", 0,0 ) { IsRequired = true, TestValue = "P"},
        };

        var theories = new List<string>
        {
            "[InlineData(\"\", \"\", true)]",
            "[InlineData(\"A\", \"bj\", false)]",
            "[InlineData(\"\", \"bj\", true)]",
            "[InlineData(\"A\", \"\", true)]"
        };

        var result = subject.GenerateTestBody(TestType.OnlyOneOfValidations, allItems[0], allItems, "GY_Geography", theories, nameof(ErrorCodes.OnlyOneOf));
        var expected = "\t[Theory]\r\n[InlineData(\"\", \"\", true)]\r\n[InlineData(\"A\", \"bj\", false)]\r\n[InlineData(\"\", \"bj\", true)]\r\n[InlineData(\"A\", \"\", true)]\r\n\tpublic void Validation_OnlyOneOfLocationQualifier(string locationQualifier, string standardCarrierAlphaCode2, bool isValidExpected)\r\n\t{\r\n\t\tvar subject = new GY_Geography();\r\n\t\tsubject.GeographyQualifierCode = \"P\";\r\n\t\tsubject.LocationQualifier = locationQualifier;\r\n\t\tsubject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;\r\n\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);\r\n\t}\r\n";
        Assert.Equal(expected, result);
    }


}