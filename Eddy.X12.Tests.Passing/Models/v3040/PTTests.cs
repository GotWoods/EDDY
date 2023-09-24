using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class PTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PT*Rd*Us*E9*d*45*O*qk*X*S*NQ";

		var expected = new PT_Patron()
		{
			ConditionSegmentLogicalConnector = "Rd",
			EntityIdentifierCode = "Us",
			Name30CharacterFormat = "E9",
			IdentificationCodeQualifier = "d",
			IdentificationCode = "45",
			ChangeTypeCode = "O",
			StandardCarrierAlphaCode = "qk",
			DocketControlNumber = "X",
			DocketIdentification = "S",
			GroupTitle = "NQ",
		};

		var actual = Map.MapObject<PT_Patron>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Rd", true)]
	public void Validation_RequiredConditionSegmentLogicalConnector(string conditionSegmentLogicalConnector, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = conditionSegmentLogicalConnector;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "d";
			subject.IdentificationCode = "45";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "45", true)]
	[InlineData("d", "", false)]
	[InlineData("", "45", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new PT_Patron();
		subject.ConditionSegmentLogicalConnector = "Rd";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
