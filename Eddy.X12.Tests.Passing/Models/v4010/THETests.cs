using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class THETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "THE*NJ*Y*b*6*8";

		var expected = new THE_ScreenTheaterIdentification()
		{
			IdentificationCode = "NJ",
			Name = "Y",
			ReferenceIdentification = "b",
			Quantity = 6,
			Quantity2 = 8,
		};

		var actual = Map.MapObject<THE_ScreenTheaterIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NJ", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new THE_ScreenTheaterIdentification();
		//Required fields
		subject.Name = "Y";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.ReferenceIdentification = "b";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new THE_ScreenTheaterIdentification();
		//Required fields
		subject.IdentificationCode = "NJ";
		//Test Parameters
		subject.Name = name;
		//At Least one
		subject.ReferenceIdentification = "b";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("b", 6, true)]
	[InlineData("b", 0, true)]
	[InlineData("", 6, true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, decimal quantity, bool isValidExpected)
	{
		var subject = new THE_ScreenTheaterIdentification();
		//Required fields
		subject.IdentificationCode = "NJ";
		subject.Name = "Y";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
