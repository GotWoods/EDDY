using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSD*c5*v*d*q*5*uC";

		var expected = new BSD_BreakdownStructureDescription()
		{
			ReferenceNumberQualifier = "c5",
			ReferenceNumber = "v",
			Description = "d",
			Level = "q",
			ReferenceNumber2 = "5",
			BreakdownStructureDetailCode = "uC",
		};

		var actual = Map.MapObject<BSD_BreakdownStructureDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c5", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new BSD_BreakdownStructureDescription();
		//Required fields
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		//At Least one
		subject.ReferenceNumber = "v";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("v", "d", true)]
	[InlineData("v", "", true)]
	[InlineData("", "d", true)]
	public void Validation_AtLeastOneReferenceNumber(string referenceNumber, string description, bool isValidExpected)
	{
		var subject = new BSD_BreakdownStructureDescription();
		//Required fields
		subject.ReferenceNumberQualifier = "c5";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
