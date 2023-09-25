using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSD*Ty*W*3*V*3*l1*q*j3";

		var expected = new BSD_BreakdownStructureDescription()
		{
			ReferenceNumberQualifier = "Ty",
			ReferenceNumber = "W",
			Description = "3",
			Level = "V",
			ReferenceNumber2 = "3",
			BreakdownStructureDetailCode = "l1",
			Level2 = "q",
			SecurityLevelCode = "j3",
		};

		var actual = Map.MapObject<BSD_BreakdownStructureDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ty", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new BSD_BreakdownStructureDescription();
		//Required fields
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		//At Least one
		subject.ReferenceNumber = "W";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("W", "3", true)]
	[InlineData("W", "", true)]
	[InlineData("", "3", true)]
	public void Validation_AtLeastOneReferenceNumber(string referenceNumber, string description, bool isValidExpected)
	{
		var subject = new BSD_BreakdownStructureDescription();
		//Required fields
		subject.ReferenceNumberQualifier = "Ty";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
