using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class THETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "THE*fJ*m*9*8*1";

		var expected = new THE_ScreenTheaterIdentification()
		{
			IdentificationCode = "fJ",
			Name = "m",
			ReferenceIdentification = "9",
			Quantity = 8,
			Quantity2 = 1,
		};

		var actual = Map.MapObject<THE_ScreenTheaterIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fJ", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new THE_ScreenTheaterIdentification();
		//Required fields
		subject.Name = "m";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.ReferenceIdentification = "9";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new THE_ScreenTheaterIdentification();
		//Required fields
		subject.IdentificationCode = "fJ";
		//Test Parameters
		subject.Name = name;
		//At Least one
		subject.ReferenceIdentification = "9";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("9", 8, true)]
	[InlineData("9", 0, true)]
	[InlineData("", 8, true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, decimal quantity, bool isValidExpected)
	{
		var subject = new THE_ScreenTheaterIdentification();
		//Required fields
		subject.IdentificationCode = "fJ";
		subject.Name = "m";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
