using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class PBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PBI*x*U*L*o*1*R*8*d";

		var expected = new PBI_ProblemIdentification()
		{
			ReferenceNumber = "x",
			ActionCode = "U",
			FreeFormMessageText = "L",
			TaxInformationIdentificationNumber = "o",
			Quantity = 1,
			FixedFormatInformation = "R",
			Quantity2 = 8,
			FixedFormatInformation2 = "d",
		};

		var actual = Map.MapObject<PBI_ProblemIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("x", "U", true)]
	[InlineData("x", "", true)]
	[InlineData("", "U", true)]
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
	[InlineData(1, "R", false)]
	[InlineData(1, "", true)]
	[InlineData(0, "R", true)]
	public void Validation_OnlyOneOfQuantity(decimal quantity, string fixedFormatInformation, bool isValidExpected)
	{
		var subject = new PBI_ProblemIdentification();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.FixedFormatInformation = fixedFormatInformation;
		//At Least one
		subject.ReferenceNumber = "x";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "d", false)]
	[InlineData(8, "", true)]
	[InlineData(0, "d", true)]
	public void Validation_OnlyOneOfQuantity2(decimal quantity2, string fixedFormatInformation2, bool isValidExpected)
	{
		var subject = new PBI_ProblemIdentification();
		//Required fields
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		subject.FixedFormatInformation2 = fixedFormatInformation2;
		//At Least one
		subject.ReferenceNumber = "x";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
