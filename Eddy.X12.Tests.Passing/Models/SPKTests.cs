using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SPKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPK*y*k*5*8*lv";

		var expected = new SPK_SpecimenKitInformation()
		{
			SpecimenKitTypeCode = "y",
			TransportationMethodTypeCode = "k",
			Temperature = 5,
			IdentificationCodeQualifier = "8",
			IdentificationCode = "lv",
		};

		var actual = Map.MapObject<SPK_SpecimenKitInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredSpecimenKitTypeCode(string specimenKitTypeCode, bool isValidExpected)
	{
		var subject = new SPK_SpecimenKitInformation();
		subject.SpecimenKitTypeCode = specimenKitTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("8", "lv", true)]
	[InlineData("", "lv", false)]
	[InlineData("8", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new SPK_SpecimenKitInformation();
		subject.SpecimenKitTypeCode = "y";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
