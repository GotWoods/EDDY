using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class TCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TCD*p*nASzrr*qb0K*O*P*Hy*N*M*oH*1*5*1*2*8*4*q";

		var expected = new TCD_ItemizedCallDetail()
		{
			AssignedIdentification = "p",
			Date = "nASzrr",
			Time = "qb0K",
			LocationQualifier = "O",
			LocationIdentifier = "P",
			StateOrProvinceCode = "Hy",
			LocationQualifier2 = "N",
			LocationIdentifier2 = "M",
			StateOrProvinceCode2 = "oH",
			MeasurementValue = 1,
			MeasurementValue2 = 5,
			MonetaryAmount = 1,
			MonetaryAmount2 = 2,
			MonetaryAmount3 = 8,
			MonetaryAmount4 = 4,
			PriceRelationshipCode = "q",
		};

		var actual = Map.MapObject<TCD_ItemizedCallDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O", "P", true)]
	[InlineData("O", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new TCD_ItemizedCallDetail();
		//Required fields
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationQualifier2) || !string.IsNullOrEmpty(subject.LocationIdentifier2))
		{
			subject.LocationQualifier2 = "N";
			subject.LocationIdentifier2 = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("N", "M", true)]
	[InlineData("N", "", false)]
	[InlineData("", "M", false)]
	public void Validation_AllAreRequiredLocationQualifier2(string locationQualifier2, string locationIdentifier2, bool isValidExpected)
	{
		var subject = new TCD_ItemizedCallDetail();
		//Required fields
		//Test Parameters
		subject.LocationQualifier2 = locationQualifier2;
		subject.LocationIdentifier2 = locationIdentifier2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "O";
			subject.LocationIdentifier = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
