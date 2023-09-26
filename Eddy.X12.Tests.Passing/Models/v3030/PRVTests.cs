using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PRVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRV*E*mC*a*sW*mr*WnX*AJw";

		var expected = new PRV_ProviderInformation()
		{
			ProviderCode = "E",
			ReferenceNumberQualifier = "mC",
			ReferenceNumber = "a",
			StateOrProvinceCode = "sW",
			AgencyQualifierCode = "mr",
			ProviderSpecialtyCode = "WnX",
			ProviderOrganizationCode = "AJw",
		};

		var actual = Map.MapObject<PRV_ProviderInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredProviderCode(string providerCode, bool isValidExpected)
	{
		var subject = new PRV_ProviderInformation();
		//Required fields
		subject.ReferenceNumberQualifier = "mC";
		subject.ReferenceNumber = "a";
		//Test Parameters
		subject.ProviderCode = providerCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mr", "WnX", true)]
	[InlineData("mr", "", false)]
	[InlineData("", "WnX", false)]
	public void Validation_AllAreRequiredProviderCode(string agencyQualifierCode, string providerSpecialtyCode, bool isValidExpected)
	{
		var subject = new PRV_ProviderInformation();
        subject.ProviderCode = "AB";
		//Required fields
		subject.ReferenceNumberQualifier = "mC";
		subject.ReferenceNumber = "a";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ProviderSpecialtyCode = providerSpecialtyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mC", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new PRV_ProviderInformation();
		//Required fields
		subject.ProviderCode = "E";
		subject.ReferenceNumber = "a";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new PRV_ProviderInformation();
		//Required fields
		subject.ProviderCode = "E";
		subject.ReferenceNumberQualifier = "mC";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
