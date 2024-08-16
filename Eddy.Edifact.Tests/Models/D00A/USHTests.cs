using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class USHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "USH+p+c+P+M+Z+f+O++c+";

		var expected = new USH_SecurityHeader()
		{
			SecurityServiceCoded = "p",
			SecurityReferenceNumber = "c",
			ScopeOfSecurityApplicationCoded = "P",
			ResponseTypeCoded = "M",
			FilterFunctionCoded = "Z",
			OriginalCharacterSetEncodingCoded = "f",
			RoleOfSecurityProviderCoded = "O",
			SecurityIdentificationDetails = null,
			SecuritySequenceNumber = "c",
			SecurityDateAndTime = null,
		};

		var actual = Map.MapObject<USH_SecurityHeader>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredSecurityServiceCoded(string securityServiceCoded, bool isValidExpected)
	{
		var subject = new USH_SecurityHeader();
		//Required fields
		subject.SecurityReferenceNumber = "c";
		//Test Parameters
		subject.SecurityServiceCoded = securityServiceCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredSecurityReferenceNumber(string securityReferenceNumber, bool isValidExpected)
	{
		var subject = new USH_SecurityHeader();
		//Required fields
		subject.SecurityServiceCoded = "p";
		//Test Parameters
		subject.SecurityReferenceNumber = securityReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
