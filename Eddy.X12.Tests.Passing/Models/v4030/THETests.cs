using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class THETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "THE*OM*H*4*9*9";

		var expected = new THE_ScreenTheaterIdentification()
		{
			IdentificationCode = "OM",
			Name = "H",
			ReferenceIdentification = "4",
			Quantity = 9,
			Quantity2 = 9,
		};

		var actual = Map.MapObject<THE_ScreenTheaterIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OM", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new THE_ScreenTheaterIdentification();
		//Required fields
		subject.Name = "H";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.ReferenceIdentification = "4";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new THE_ScreenTheaterIdentification();
		//Required fields
		subject.IdentificationCode = "OM";
		//Test Parameters
		subject.Name = name;
		//At Least one
		subject.ReferenceIdentification = "4";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("4", 9, true)]
	[InlineData("4", 0, true)]
	[InlineData("", 9, true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, decimal quantity, bool isValidExpected)
	{
		var subject = new THE_ScreenTheaterIdentification();
		//Required fields
		subject.IdentificationCode = "OM";
		subject.Name = "H";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
