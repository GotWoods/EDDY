using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S500Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "e:p:O:R:S:P:w:W";

		var expected = new S500_SecurityIdentificationDetails()
		{
			SecurityPartyQualifier = "e",
			KeyName = "p",
			SecurityPartyIdentification = "O",
			SecurityPartyCodeListQualifier = "R",
			SecurityPartyCodeListResponsibleAgencyCoded = "S",
			SecurityPartyName = "P",
			SecurityPartyName2 = "w",
			SecurityPartyName3 = "W",
		};

		var actual = Map.MapComposite<S500_SecurityIdentificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredSecurityPartyQualifier(string securityPartyQualifier, bool isValidExpected)
	{
		var subject = new S500_SecurityIdentificationDetails();
		//Required fields
		//Test Parameters
		subject.SecurityPartyQualifier = securityPartyQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
