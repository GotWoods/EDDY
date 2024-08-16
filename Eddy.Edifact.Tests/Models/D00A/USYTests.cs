using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class USYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "USY+4++S";

		var expected = new USY_SecurityOnReferences()
		{
			SecurityReferenceNumber = "4",
			ValidationResult = null,
			SecurityErrorCoded = "S",
		};

		var actual = Map.MapObject<USY_SecurityOnReferences>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredSecurityReferenceNumber(string securityReferenceNumber, bool isValidExpected)
	{
		var subject = new USY_SecurityOnReferences();
		//Required fields
		//Test Parameters
		subject.SecurityReferenceNumber = securityReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
