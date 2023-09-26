using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SPKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPK*c*z*6*P*r6";

		var expected = new SPK_SpecimenKitInformation()
		{
			SpecimenKitTypeCode = "c",
			TransportationMethodTypeCode = "z",
			Temperature = 6,
			IdentificationCodeQualifier = "P",
			IdentificationCode = "r6",
		};

		var actual = Map.MapObject<SPK_SpecimenKitInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredSpecimenKitTypeCode(string specimenKitTypeCode, bool isValidExpected)
	{
		var subject = new SPK_SpecimenKitInformation();
		//Required fields
		//Test Parameters
		subject.SpecimenKitTypeCode = specimenKitTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "P";
			subject.IdentificationCode = "r6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P", "r6", true)]
	[InlineData("P", "", false)]
	[InlineData("", "r6", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new SPK_SpecimenKitInformation();
		//Required fields
		subject.SpecimenKitTypeCode = "c";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
