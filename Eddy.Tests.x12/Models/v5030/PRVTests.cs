using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class PRVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRV*9*Hj*z*Fo**hSC";

		var expected = new PRV_ProviderInformation()
		{
			ProviderCode = "9",
			ReferenceIdentificationQualifier = "Hj",
			ReferenceIdentification = "z",
			StateOrProvinceCode = "Fo",
			ProviderSpecialtyInformation = null,
			ProviderOrganizationCode = "hSC",
		};

		var actual = Map.MapObject<PRV_ProviderInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredProviderCode(string providerCode, bool isValidExpected)
	{
		var subject = new PRV_ProviderInformation();
		//Required fields
		//Test Parameters
		subject.ProviderCode = providerCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Hj";
			subject.ReferenceIdentification = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Hj", "z", true)]
	[InlineData("Hj", "", false)]
	[InlineData("", "z", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new PRV_ProviderInformation();
		//Required fields
		subject.ProviderCode = "9";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
