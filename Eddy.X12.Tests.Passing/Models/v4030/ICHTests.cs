using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class ICHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ICH*9*0T*9*m*L*B*ep*E57j*S4*8*D*zF";

		var expected = new ICH_IndividualCharacteristics()
		{
			Count = 9,
			DateTimePeriodFormatQualifier = "0T",
			DateTimePeriod = "9",
			GenderCode = "m",
			ReferenceIdentification = "L",
			ReferenceIdentification2 = "B",
			StateOrProvinceCode = "ep",
			OccupationCode = "E57j",
			IndividualRelationshipCode = "S4",
			Description = "8",
			Description2 = "D",
			PoliticalPartyAffiliationCode = "zF",
		};

		var actual = Map.MapObject<ICH_IndividualCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0T", "9", true)]
	[InlineData("0T", "", false)]
	[InlineData("", "9", false)]
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
