using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class NATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "NAT+w+";

		var expected = new NAT_Nationality()
		{
			NationalityCodeQualifier = "w",
			NationalityDetails = null,
		};

		var actual = Map.MapObject<NAT_Nationality>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredNationalityCodeQualifier(string nationalityCodeQualifier, bool isValidExpected)
	{
		var subject = new NAT_Nationality();
		//Required fields
		//Test Parameters
		subject.NationalityCodeQualifier = nationalityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
