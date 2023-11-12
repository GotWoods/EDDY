using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SHPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SHP*Ly*4*cmh*VE5Dhp*3Eq1*yOi16Y*U1DL";

		var expected = new SHP_ShippedReceivedInformation()
		{
			QuantityQualifier = "Ly",
			Quantity = 4,
			DateTimeQualifier = "cmh",
			Date = "VE5Dhp",
			Time = "3Eq1",
			Date2 = "yOi16Y",
			Time2 = "U1DL",
		};

		var actual = Map.MapObject<SHP_ShippedReceivedInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Ly", 4, true)]
	[InlineData("Ly", 0, false)]
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
	[InlineData("VE5Dhp", "cmh", true)]
	[InlineData("VE5Dhp", "", false)]
	[InlineData("", "cmh", true)]
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
