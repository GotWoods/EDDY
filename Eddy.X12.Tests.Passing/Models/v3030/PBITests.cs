using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PBI*f*w*W*A*2*o*4*R";

		var expected = new PBI_ProblemIdentification()
		{
			ReferenceNumber = "f",
			ActionCode = "w",
			FreeFormMessageText = "W",
			TaxInformationIdentificationNumber = "A",
			Quantity = 2,
			FixedFormatInformation = "o",
			Quantity2 = 4,
			FixedFormatInformation2 = "R",
		};

		var actual = Map.MapObject<PBI_ProblemIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("f", "w", true)]
	[InlineData("f", "", true)]
	[InlineData("", "w", true)]
	public void Validation_AtLeastOneReferenceNumber(string referenceNumber, string actionCode, bool isValidExpected)
	{
		var subject = new PBI_ProblemIdentification();
		//Required fields
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "o", false)]
	[InlineData(2, "", true)]
	[InlineData(0, "o", true)]
	public void Validation_OnlyOneOfQuantity(decimal quantity, string fixedFormatInformation, bool isValidExpected)
	{
		var subject = new PBI_ProblemIdentification();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.FixedFormatInformation = fixedFormatInformation;
		//At Least one
		subject.ReferenceNumber = "f";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "R", false)]
	[InlineData(4, "", true)]
	[InlineData(0, "R", true)]
	public void Validation_OnlyOneOfQuantity2(decimal quantity2, string fixedFormatInformation2, bool isValidExpected)
	{
		var subject = new PBI_ProblemIdentification();
		//Required fields
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		subject.FixedFormatInformation2 = fixedFormatInformation2;
		//At Least one
		subject.ReferenceNumber = "f";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
