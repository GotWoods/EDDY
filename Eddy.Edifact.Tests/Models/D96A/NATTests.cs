using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class NATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "NAT+T+";

		var expected = new NAT_Nationality()
		{
			NationalityQualifier = "T",
			NationalityDetails = null,
		};

		var actual = Map.MapObject<NAT_Nationality>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredNationalityQualifier(string nationalityQualifier, bool isValidExpected)
	{
		var subject = new NAT_Nationality();
		//Required fields
		//Test Parameters
		subject.NationalityQualifier = nationalityQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
