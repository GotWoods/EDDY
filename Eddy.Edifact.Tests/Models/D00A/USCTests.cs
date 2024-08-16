using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class USCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "USC+6++S+V+8+C+R+++T+P";

		var expected = new USC_Certificate()
		{
			CertificateReference = "6",
			SecurityIdentificationDetails = null,
			CertificateSyntaxAndVersionCoded = "S",
			FilterFunctionCoded = "V",
			OriginalCharacterSetEncodingCoded = "8",
			CertificateOriginalCharacterSetRepertoireCoded = "C",
			UserAuthorisationLevel = "R",
			ServiceCharacterForSignature = null,
			SecurityDateAndTime = null,
			SecurityStatusCoded = "T",
			RevocationReasonCoded = "P",
		};

		var actual = Map.MapObject<USC_Certificate>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
