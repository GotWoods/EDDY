using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SPKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPK*h*3*5*G*JK";

		var expected = new SPK_SpecimenKitInformation()
		{
			SpecimenKitTypeCode = "h",
			TransportationMethodTypeCode = "3",
			Temperature = 5,
			IdentificationCodeQualifier = "G",
			IdentificationCode = "JK",
		};

		var actual = Map.MapObject<SPK_SpecimenKitInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredSpecimenKitTypeCode(string specimenKitTypeCode, bool isValidExpected)
	{
		var subject = new SPK_SpecimenKitInformation();
		//Required fields
		//Test Parameters
		subject.SpecimenKitTypeCode = specimenKitTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "G";
			subject.IdentificationCode = "JK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "JK", true)]
	[InlineData("G", "", false)]
	[InlineData("", "JK", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new SPK_SpecimenKitInformation();
		//Required fields
		subject.SpecimenKitTypeCode = "h";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
