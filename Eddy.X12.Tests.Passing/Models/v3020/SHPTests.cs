using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SHPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SHP*KC*4*ihZ*5Z2Mlm*Rvgf*rDraqF*YjoS";

		var expected = new SHP_ShippedReceivedInformation()
		{
			QuantityQualifier = "KC",
			Quantity = 4,
			DateTimeQualifier = "ihZ",
			Date = "5Z2Mlm",
			Time = "Rvgf",
			Date2 = "rDraqF",
			Time2 = "YjoS",
		};

		var actual = Map.MapObject<SHP_ShippedReceivedInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("KC", 4, true)]
	[InlineData("KC", 0, false)]
	[InlineData("", 4, true)]
	public void Validation_ARequiresBQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new SHP_ShippedReceivedInformation();
		//Required fields
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5Z2Mlm", "ihZ", true)]
	[InlineData("5Z2Mlm", "", false)]
	[InlineData("", "ihZ", true)]
	public void Validation_ARequiresBDate(string date, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new SHP_ShippedReceivedInformation();
		//Required fields
		//Test Parameters
		subject.Date = date;
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
