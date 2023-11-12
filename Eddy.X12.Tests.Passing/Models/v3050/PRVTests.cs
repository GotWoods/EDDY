using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PRVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRV*B*ZO*b*ga*cE*E*tfa";

		var expected = new PRV_ProviderInformation()
		{
			ProviderCode = "B",
			ReferenceNumberQualifier = "ZO",
			ReferenceNumber = "b",
			StateOrProvinceCode = "ga",
			AgencyQualifierCode = "cE",
			ProviderSpecialtyCode = "E",
			ProviderOrganizationCode = "tfa",
		};

		var actual = Map.MapObject<PRV_ProviderInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredProviderCode(string providerCode, bool isValidExpected)
	{
		var subject = new PRV_ProviderInformation();
		//Required fields
		subject.ReferenceNumberQualifier = "ZO";
		subject.ReferenceNumber = "b";
		//Test Parameters
		subject.ProviderCode = providerCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("cE", "E", true)]
	[InlineData("cE", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredProviderCode(string agencyQualifierCode, string providerSpecialtyCode, bool isValidExpected)
	{
		var subject = new PRV_ProviderInformation();
		//Required fields
		subject.ReferenceNumberQualifier = "ZO";
		subject.ReferenceNumber = "b";
        subject.ProviderCode = "AB";
        //Test Parameters
        subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ProviderSpecialtyCode = providerSpecialtyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZO", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new PRV_ProviderInformation();
		//Required fields
		subject.ProviderCode = "B";
		subject.ReferenceNumber = "b";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new PRV_ProviderInformation();
		//Required fields
		subject.ProviderCode = "B";
		subject.ReferenceNumberQualifier = "ZO";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
