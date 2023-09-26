using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class ICHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ICH*5*MF*l*M*L*O*Yy*W08k*3z*r*7*xe";

		var expected = new ICH_IndividualCharacteristics()
		{
			Count = 5,
			DateTimePeriodFormatQualifier = "MF",
			DateTimePeriod = "l",
			GenderCode = "M",
			ReferenceIdentification = "L",
			ReferenceIdentification2 = "O",
			StateOrProvinceCode = "Yy",
			OccupationCode = "W08k",
			IndividualRelationshipCode = "3z",
			Description = "r",
			Description2 = "7",
			PoliticalPartyAffiliationCode = "xe",
		};

		var actual = Map.MapObject<ICH_IndividualCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("MF", "l", true)]
	[InlineData("MF", "", false)]
	[InlineData("", "l", false)]
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
