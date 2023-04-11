using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PPRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPR*N*p*a*at*FR";

		var expected = new PPR_ContractPartyRestriction()
		{
			YesNoConditionOrResponseCode = "N",
			Name = "p",
			IdentificationCodeQualifier = "a",
			IdentificationCode = "at",
			EntityIdentifierCode = "FR",
		};

		var actual = Map.MapObject<PPR_ContractPartyRestriction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new PPR_ContractPartyRestriction();
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("a", "at", true)]
	[InlineData("", "at", false)]
	[InlineData("a", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new PPR_ContractPartyRestriction();
		subject.YesNoConditionOrResponseCode = "N";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
