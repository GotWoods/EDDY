using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PBI*o*H*p*u*4*H*8*r";

		var expected = new PBI_ProblemIdentification()
		{
			ReferenceIdentification = "o",
			ActionCode = "H",
			FreeFormMessageText = "p",
			TaxInformationIdentificationNumber = "u",
			Quantity = 4,
			FixedFormatInformation = "H",
			Quantity2 = 8,
			FixedFormatInformation2 = "r",
		};

		var actual = Map.MapObject<PBI_ProblemIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("o", "H", true)]
	[InlineData("o", "", true)]
	[InlineData("", "H", true)]
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
	[InlineData(4, "H", false)]
	[InlineData(4, "", true)]
	[InlineData(0, "H", true)]
	public void Validation_OnlyOneOfQuantity(decimal quantity, string fixedFormatInformation, bool isValidExpected)
	{
		var subject = new PBI_ProblemIdentification();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.FixedFormatInformation = fixedFormatInformation;
		//At Least one
		subject.ReferenceIdentification = "o";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "r", false)]
	[InlineData(8, "", true)]
	[InlineData(0, "r", true)]
	public void Validation_OnlyOneOfQuantity2(decimal quantity2, string fixedFormatInformation2, bool isValidExpected)
	{
		var subject = new PBI_ProblemIdentification();
		//Required fields
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		subject.FixedFormatInformation2 = fixedFormatInformation2;
		//At Least one
		subject.ReferenceIdentification = "o";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
