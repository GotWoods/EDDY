using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TCD*O*kQRwRTng*7Qxo*N*J*Pb*S*E*fU*7*3*4*3*6*9*M";

		var expected = new TCD_ItemizedCallDetail()
		{
			AssignedIdentification = "O",
			Date = "kQRwRTng",
			Time = "7Qxo",
			LocationQualifier = "N",
			LocationIdentifier = "J",
			StateOrProvinceCode = "Pb",
			LocationQualifier2 = "S",
			LocationIdentifier2 = "E",
			StateOrProvinceCode2 = "fU",
			MeasurementValue = 7,
			MeasurementValue2 = 3,
			MonetaryAmount = 4,
			MonetaryAmount2 = 3,
			MonetaryAmount3 = 6,
			MonetaryAmount4 = 9,
			RelationshipCode = "M",
		};

		var actual = Map.MapObject<TCD_ItemizedCallDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("N", "J", true)]
	[InlineData("", "J", false)]
	[InlineData("N", "", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new TCD_ItemizedCallDetail();
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("S", "E", true)]
	[InlineData("", "E", false)]
	[InlineData("S", "", false)]
	public void Validation_AllAreRequiredLocationQualifier2(string locationQualifier2, string locationIdentifier2, bool isValidExpected)
	{
		var subject = new TCD_ItemizedCallDetail();
		subject.LocationQualifier2 = locationQualifier2;
		subject.LocationIdentifier2 = locationIdentifier2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
