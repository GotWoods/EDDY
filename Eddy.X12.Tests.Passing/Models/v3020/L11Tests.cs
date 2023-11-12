using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class L11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L11*0*gG*z";

		var expected = new L11_BusinessInstructions()
		{
			ReferenceNumber = "0",
			ReferenceNumberQualifier = "gG",
			Description = "z",
		};

		var actual = Map.MapObject<L11_BusinessInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "gG", true)]
	[InlineData("0", "", false)]
	[InlineData("", "gG", false)]
	public void Validation_AllAreRequiredReferenceNumber(string referenceNumber, string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new L11_BusinessInstructions();
		//Required fields
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		subject.ReferenceNumberQualifier = referenceNumberQualifier;

        if (subject.ReferenceNumber == "")
            subject.Description = "AB";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("0", "z", true)]
	[InlineData("0", "", true)]
	[InlineData("", "z", true)]
	public void Validation_AtLeastOneReferenceNumber(string referenceNumber, string description, bool isValidExpected)
	{
		var subject = new L11_BusinessInstructions();
		//Required fields
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		subject.Description = description;

        if (subject.ReferenceNumber != "")
            subject.ReferenceNumberQualifier = "AB";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
