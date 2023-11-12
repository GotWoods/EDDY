using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class THETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "THE*Vj*5*2*6*5";

		var expected = new THE_ScreenTheaterIdentification()
		{
			IdentificationCode = "Vj",
			Name = "5",
			ReferenceIdentification = "2",
			Quantity = 6,
			Quantity2 = 5,
		};

		var actual = Map.MapObject<THE_ScreenTheaterIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Vj", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new THE_ScreenTheaterIdentification();
		//Required fields
		subject.Name = "5";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.ReferenceIdentification = "2";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new THE_ScreenTheaterIdentification();
		//Required fields
		subject.IdentificationCode = "Vj";
		//Test Parameters
		subject.Name = name;
		//At Least one
		subject.ReferenceIdentification = "2";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("2", 6, true)]
	[InlineData("2", 0, true)]
	[InlineData("", 6, true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, decimal quantity, bool isValidExpected)
	{
		var subject = new THE_ScreenTheaterIdentification();
		//Required fields
		subject.IdentificationCode = "Vj";
		subject.Name = "5";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
