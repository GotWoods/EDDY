using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class USTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UST+p+d";

		var expected = new UST_SecurityTrailer()
		{
			SecurityReferenceNumber = "p",
			NumberOfSecuritySegments = "d",
		};

		var actual = Map.MapObject<UST_SecurityTrailer>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredSecurityReferenceNumber(string securityReferenceNumber, bool isValidExpected)
	{
		var subject = new UST_SecurityTrailer();
		//Required fields
		subject.NumberOfSecuritySegments = "d";
		//Test Parameters
		subject.SecurityReferenceNumber = securityReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredNumberOfSecuritySegments(string numberOfSecuritySegments, bool isValidExpected)
	{
		var subject = new UST_SecurityTrailer();
		//Required fields
		subject.SecurityReferenceNumber = "p";
		//Test Parameters
		subject.NumberOfSecuritySegments = numberOfSecuritySegments;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
