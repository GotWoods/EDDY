using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SUPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SUP*KAf*fH*h*9K";

		var expected = new SUP_SupplementaryInformation()
		{
			SupplementaryInformationQualifier = "KAf",
			CertificationClauseCode = "fH",
			FreeFormMessage = "h",
			PrintOptionCode = "9K",
		};

		var actual = Map.MapObject<SUP_SupplementaryInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KAf", true)]
	public void Validation_RequiredSupplementaryInformationQualifier(string supplementaryInformationQualifier, bool isValidExpected)
	{
		var subject = new SUP_SupplementaryInformation();
		subject.SupplementaryInformationQualifier = supplementaryInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
