using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class CERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CER*sY*t*n*K*6*vO*Tf2MtDwG*JoSJ8V0S";

		var expected = new CER_Certification()
		{
			AgencyQualifierCode = "sY",
			NameLastOrOrganizationName = "t",
			Description = "n",
			ReferenceIdentification = "K",
			IdentificationCodeQualifier = "6",
			IdentificationCode = "vO",
			Date = "Tf2MtDwG",
			Date2 = "JoSJ8V0S",
		};

		var actual = Map.MapObject<CER_Certification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("sY", "t", true)]
	[InlineData("sY", "", true)]
	[InlineData("", "t", true)]
	public void Validation_AtLeastOneAgencyQualifierCode(string agencyQualifierCode, string nameLastOrOrganizationName, bool isValidExpected)
	{
		var subject = new CER_Certification();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.NameLastOrOrganizationName = nameLastOrOrganizationName;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "6";
			subject.IdentificationCode = "vO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6", "vO", true)]
	[InlineData("6", "", false)]
	[InlineData("", "vO", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CER_Certification();
		//Required fields
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.AgencyQualifierCode = "sY";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
