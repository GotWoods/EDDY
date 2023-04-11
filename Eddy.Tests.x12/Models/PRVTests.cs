using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PRVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRV*T*gM*L*p3**0fZ";

		var expected = new PRV_ProviderInformation()
		{
			ProviderCode = "T",
			ReferenceIdentificationQualifier = "gM",
			ReferenceIdentification = "L",
			StateOrProvinceCode = "p3",
			ProviderSpecialtyInformation = "",
			ProviderOrganizationCode = "0fZ",
		};

		var actual = Map.MapObject<PRV_ProviderInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredProviderCode(string providerCode, bool isValidExpected)
	{
		var subject = new PRV_ProviderInformation();
		subject.ProviderCode = providerCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("gM", "L", true)]
	[InlineData("", "L", false)]
	[InlineData("gM", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new PRV_ProviderInformation();
		subject.ProviderCode = "T";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
