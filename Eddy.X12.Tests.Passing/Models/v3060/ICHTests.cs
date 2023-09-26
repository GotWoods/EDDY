using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class ICHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ICH*5*VM*s*r*v*q*hh*vd1M*rr*X*d";

		var expected = new ICH_IndividualCharacteristics()
		{
			Count = 5,
			DateTimePeriodFormatQualifier = "VM",
			DateTimePeriod = "s",
			GenderCode = "r",
			ReferenceIdentification = "v",
			ReferenceIdentification2 = "q",
			StateOrProvinceCode = "hh",
			OccupationCode = "vd1M",
			IndividualRelationshipCode = "rr",
			Description = "X",
			Description2 = "d",
		};

		var actual = Map.MapObject<ICH_IndividualCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("VM", "s", true)]
	[InlineData("VM", "", false)]
	[InlineData("", "s", false)]
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
