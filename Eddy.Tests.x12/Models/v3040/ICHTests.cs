using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class ICHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ICH*9*oJ*u*c*f*p*hl*VeCW*vK*C*U";

		var expected = new ICH_IndividualCharacteristics()
		{
			Count = 9,
			DateTimePeriodFormatQualifier = "oJ",
			DateTimePeriod = "u",
			GenderCode = "c",
			ReferenceNumber = "f",
			ReferenceNumber2 = "p",
			StateOrProvinceCode = "hl",
			OccupationCode = "VeCW",
			IndividualRelationshipCode = "vK",
			Description = "C",
			Description2 = "U",
		};

		var actual = Map.MapObject<ICH_IndividualCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("oJ", "u", true)]
	[InlineData("oJ", "", false)]
	[InlineData("", "u", false)]
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
