using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ICHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ICH*5*53*i*b*4*I*84*0vZ8*au*j*8*ev";

		var expected = new ICH_IndividualCharacteristics()
		{
			Count = 5,
			DateTimePeriodFormatQualifier = "53",
			DateTimePeriod = "i",
			GenderCode = "b",
			ReferenceIdentification = "4",
			ReferenceIdentification2 = "I",
			StateOrProvinceCode = "84",
			OccupationCode = "0vZ8",
			IndividualRelationshipCode = "au",
			Description = "j",
			Description2 = "8",
			PoliticalPartyAffiliationCode = "ev",
		};

		var actual = Map.MapObject<ICH_IndividualCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("53", "i", true)]
	[InlineData("", "i", false)]
	[InlineData("53", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new ICH_IndividualCharacteristics();
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
