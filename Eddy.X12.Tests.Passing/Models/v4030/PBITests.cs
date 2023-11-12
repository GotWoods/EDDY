using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class PBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PBI*x*s*w*j*9*4*8*l";

		var expected = new PBI_ProblemIdentification()
		{
			ReferenceIdentification = "x",
			ActionCode = "s",
			FreeFormMessageText = "w",
			TaxInformationIdentificationNumber = "j",
			Quantity = 9,
			FixedFormatInformation = "4",
			Quantity2 = 8,
			FixedFormatInformation2 = "l",
		};

		var actual = Map.MapObject<PBI_ProblemIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("x", "s", true)]
	[InlineData("x", "", true)]
	[InlineData("", "s", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string actionCode, bool isValidExpected)
	{
		var subject = new PBI_ProblemIdentification();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "4", false)]
	[InlineData(9, "", true)]
	[InlineData(0, "4", true)]
	public void Validation_OnlyOneOfQuantity(decimal quantity, string fixedFormatInformation, bool isValidExpected)
	{
		var subject = new PBI_ProblemIdentification();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.FixedFormatInformation = fixedFormatInformation;
		//At Least one
		subject.ReferenceIdentification = "x";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "l", false)]
	[InlineData(8, "", true)]
	[InlineData(0, "l", true)]
	public void Validation_OnlyOneOfQuantity2(decimal quantity2, string fixedFormatInformation2, bool isValidExpected)
	{
		var subject = new PBI_ProblemIdentification();
		//Required fields
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		subject.FixedFormatInformation2 = fixedFormatInformation2;
		//At Least one
		subject.ReferenceIdentification = "x";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
