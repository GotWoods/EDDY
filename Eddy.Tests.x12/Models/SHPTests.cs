using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SHPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SHP*11*3*Zl1*41bRaXru*wHmG*I02R0wz7*WrDl";

		var expected = new SHP_ShippedReceivedInformation()
		{
			QuantityQualifier = "11",
			Quantity = 3,
			DateTimeQualifier = "Zl1",
			Date = "41bRaXru",
			Time = "wHmG",
			Date2 = "I02R0wz7",
			Time2 = "WrDl",
		};

		var actual = Map.MapObject<SHP_ShippedReceivedInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 3, true)]
	[InlineData("11", 0, false)]
	public void Validation_ARequiresBQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new SHP_ShippedReceivedInformation();
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Zl1", "41bRaXru", true)]
	[InlineData("","41bRaXru", true)]
	[InlineData("Zl1", "", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier(string dateTimeQualifier, string date, string time, bool isValidExpected)
	{
		var subject = new SHP_ShippedReceivedInformation();
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		subject.Time = time;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Zl1", true)]
	[InlineData("41bRaXru", "", false)]
	public void Validation_ARequiresBDate(string date, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new SHP_ShippedReceivedInformation();
		subject.Date = date;
		subject.DateTimeQualifier = dateTimeQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Zl1", true)]
	[InlineData("wHmG", "", false)]
	public void Validation_ARequiresBTime(string time, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new SHP_ShippedReceivedInformation();
		subject.Time = time;
		subject.DateTimeQualifier = dateTimeQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
