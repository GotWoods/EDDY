using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PBI*n*R*9*5*6*k*6*4";

		var expected = new PBI_ProblemIdentification()
		{
			ReferenceIdentification = "n",
			ActionCode = "R",
			FreeFormMessageText = "9",
			TaxInformationIdentificationNumber = "5",
			Quantity = 6,
			FixedFormatInformation = "k",
			Quantity2 = 6,
			FixedFormatInformation2 = "4",
		};

		var actual = Map.MapObject<PBI_ProblemIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("n","R", true)]
	[InlineData("", "R", true)]
	[InlineData("n", "", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string actionCode, bool isValidExpected)
	{
		var subject = new PBI_ProblemIdentification();
		subject.ReferenceIdentification = referenceIdentification;
		subject.ActionCode = actionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "k", false)]
	[InlineData(0, "k", true)]
	[InlineData(6, "", true)]
	public void Validation_OnlyOneOfQuantity(decimal quantity, string fixedFormatInformation, bool isValidExpected)
	{
		var subject = new PBI_ProblemIdentification();
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.FixedFormatInformation = fixedFormatInformation;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "4", false)]
	[InlineData(0, "4", true)]
	[InlineData(6, "", true)]
	public void Validation_OnlyOneOfQuantity2(decimal quantity2, string fixedFormatInformation2, bool isValidExpected)
	{
		var subject = new PBI_ProblemIdentification();
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;
		subject.FixedFormatInformation2 = fixedFormatInformation2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
