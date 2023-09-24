using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SHPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SHP*Q4*8*5Hh*U7RK1DSQ*7Eh9*GJiUVvfS*2H1w";

		var expected = new SHP_ShippedReceivedInformation()
		{
			QuantityQualifier = "Q4",
			Quantity = 8,
			DateTimeQualifier = "5Hh",
			Date = "U7RK1DSQ",
			Time = "7Eh9",
			Date2 = "GJiUVvfS",
			Time2 = "2H1w",
		};

		var actual = Map.MapObject<SHP_ShippedReceivedInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Q4", 8, true)]
	[InlineData("Q4", 0, false)]
	[InlineData("", 8, true)]
	public void Validation_ARequiresBQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new SHP_ShippedReceivedInformation();
		//Required fields
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "5Hh";
			subject.Date = "U7RK1DSQ";
			subject.Time = "7Eh9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("5Hh", "U7RK1DSQ", "7Eh9", true)]
	[InlineData("5Hh", "", "", false)]
	[InlineData("", "U7RK1DSQ", "7Eh9", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier(string dateTimeQualifier, string date, string time, bool isValidExpected)
	{
		var subject = new SHP_ShippedReceivedInformation();
		//Required fields
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		subject.Time = time;
		//A Requires B
		if (date != "")
			subject.DateTimeQualifier = "5Hh";
		if (time != "")
			subject.DateTimeQualifier = "5Hh";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U7RK1DSQ", "5Hh", true)]
	[InlineData("U7RK1DSQ", "", false)]
	[InlineData("", "5Hh", true)]
	public void Validation_ARequiresBDate(string date, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new SHP_ShippedReceivedInformation();
		//Required fields
		//Test Parameters
		subject.Date = date;
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.Time = "7Eh9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7Eh9", "5Hh", true)]
	[InlineData("7Eh9", "", false)]
	[InlineData("", "5Hh", true)]
	public void Validation_ARequiresBTime(string time, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new SHP_ShippedReceivedInformation();
		//Required fields
		//Test Parameters
		subject.Time = time;
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.Date = "U7RK1DSQ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
