using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class THETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "THE*Ip*Y*s*7*6";

		var expected = new THE_ScreenTheaterIdentification()
		{
			IdentificationCode = "Ip",
			Name = "Y",
			ReferenceNumber = "s",
			Quantity = 7,
			Quantity2 = 6,
		};

		var actual = Map.MapObject<THE_ScreenTheaterIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ip", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new THE_ScreenTheaterIdentification();
		//Required fields
		subject.Name = "Y";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.ReferenceNumber = "s";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new THE_ScreenTheaterIdentification();
		//Required fields
		subject.IdentificationCode = "Ip";
		//Test Parameters
		subject.Name = name;
		//At Least one
		subject.ReferenceNumber = "s";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("s", 7, true)]
	[InlineData("s", 0, true)]
	[InlineData("", 7, true)]
	public void Validation_AtLeastOneReferenceNumber(string referenceNumber, decimal quantity, bool isValidExpected)
	{
		var subject = new THE_ScreenTheaterIdentification();
		//Required fields
		subject.IdentificationCode = "Ip";
		subject.Name = "Y";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
