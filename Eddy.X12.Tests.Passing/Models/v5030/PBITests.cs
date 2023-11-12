using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class PBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PBI*w*z*k*R*6*2*5*y";

		var expected = new PBI_ProblemIdentification()
		{
			ReferenceIdentification = "w",
			ActionCode = "z",
			FreeFormMessageText = "k",
			TaxInformationIdentificationNumber = "R",
			Quantity = 6,
			FixedFormatInformation = "2",
			Quantity2 = 5,
			FixedFormatInformation2 = "y",
		};

		var actual = Map.MapObject<PBI_ProblemIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("w", "z", true)]
	[InlineData("w", "", true)]
	[InlineData("", "z", true)]
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
	[InlineData(6, "2", false)]
	[InlineData(6, "", true)]
	[InlineData(0, "2", true)]
	public void Validation_OnlyOneOfQuantity(decimal quantity, string fixedFormatInformation, bool isValidExpected)
	{
		var subject = new PBI_ProblemIdentification();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.FixedFormatInformation = fixedFormatInformation;
		//At Least one
		subject.ReferenceIdentification = "w";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "y", false)]
	[InlineData(5, "", true)]
	[InlineData(0, "y", true)]
	public void Validation_OnlyOneOfQuantity2(decimal quantity2, string fixedFormatInformation2, bool isValidExpected)
	{
		var subject = new PBI_ProblemIdentification();
		//Required fields
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		subject.FixedFormatInformation2 = fixedFormatInformation2;
		//At Least one
		subject.ReferenceIdentification = "w";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
