using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class THETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "THE*Zr*Y*T*1*7";

		var expected = new THE_ScreenTheaterIdentification()
		{
			IdentificationCode = "Zr",
			Name = "Y",
			ReferenceIdentification = "T",
			Quantity = 1,
			Quantity2 = 7,
		};

		var actual = Map.MapObject<THE_ScreenTheaterIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Zr", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new THE_ScreenTheaterIdentification();
		subject.Name = "Y";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new THE_ScreenTheaterIdentification();
		subject.IdentificationCode = "Zr";
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, false)]
	[InlineData("T",1, true)]
	[InlineData("", 1, true)]
	[InlineData("T", 0, true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, decimal quantity, bool isValidExpected)
	{
		var subject = new THE_ScreenTheaterIdentification();
		subject.IdentificationCode = "Zr";
		subject.Name = "Y";
		subject.ReferenceIdentification = referenceIdentification;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
