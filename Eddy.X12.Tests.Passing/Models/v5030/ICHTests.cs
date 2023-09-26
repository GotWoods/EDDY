using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class ICHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ICH*4*54*O*X*P*v*sg*LNQg*Ln*I*v*wQ";

		var expected = new ICH_IndividualCharacteristics()
		{
			Count = 4,
			DateTimePeriodFormatQualifier = "54",
			DateTimePeriod = "O",
			GenderCode = "X",
			ReferenceIdentification = "P",
			ReferenceIdentification2 = "v",
			StateOrProvinceCode = "sg",
			OccupationCode = "LNQg",
			IndividualRelationshipCode = "Ln",
			Description = "I",
			Description2 = "v",
			PoliticalPartyAffiliationCode = "wQ",
		};

		var actual = Map.MapObject<ICH_IndividualCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("54", "O", true)]
	[InlineData("54", "", false)]
	[InlineData("", "O", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new ICH_IndividualCharacteristics();
		//Required fields
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
