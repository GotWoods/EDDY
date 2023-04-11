using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class GYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GY*P*s*A*AA*h*N*xG*i*bj*A*c*ED*fk*a2*E";

		var expected = new GY_Geography()
		{
			GeographyQualifierCode = "P",
			CommodityGeographicLogicalConnectorCode = "s",
			LocationQualifier = "A",
			StateOrProvinceCode = "AA",
			LocationIdentifier = "h",
			LocationIdentifier2 = "N",
			StandardCarrierAlphaCode = "xG",
			ChangeTypeCode = "i",
			StandardCarrierAlphaCode2 = "bj",
			DocketControlNumber = "A",
			DocketIdentification = "c",
			GroupTitle = "ED",
			StateOrProvinceCode2 = "fk",
			CityName = "a2",
			YesNoConditionOrResponseCode = "E",
		};

		var actual = Map.MapObject<GY_Geography>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredGeographyQualifierCode(string geographyQualifierCode, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = geographyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "bj", false)]
	[InlineData("", "bj", true)]
	[InlineData("A", "", true)]
	public void Validation_OnlyOneOfLocationQualifier(string locationQualifier, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = "P";
		subject.LocationQualifier = locationQualifier;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "A", true)]
	[InlineData("h", "", false)]
	public void Validation_ARequiresBLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = "P";
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "h", true)]
	[InlineData("N", "", false)]
	public void Validation_ARequiresBLocationIdentifier2(string locationIdentifier2, string locationIdentifier, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = "P";
		subject.LocationIdentifier2 = locationIdentifier2;
		subject.LocationIdentifier = locationIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	//TODO: this test
	// [Theory]
	// [InlineData("", "", true)]
	// [InlineData("bj", "fk", false)]
	// [InlineData("", "fk", true)]
	// [InlineData("bj", "", true)]
	// public void Validation_OnlyOneOfStandardCarrierAlphaCode2(string standardCarrierAlphaCode, string stateOrProvinceCode2, string standardCarrierAlphaCode2, string yesNoConditionOrResponseCode, bool isValidExpected)
	// {
	// 	var subject = new GY_Geography();
	// 	subject.GeographyQualifierCode = "P";
	// 	subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
	// 	subject.StateOrProvinceCode2 = stateOrProvinceCode2;
	// 	subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
	// 	subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
	//
	// 	TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	// }

	[Theory]
	[InlineData("","", true)]
	[InlineData("fk", "a2", true)]
	[InlineData("", "a2", false)]
	[InlineData("fk", "", false)]
	public void Validation_AllAreRequiredStateOrProvinceCode2(string stateOrProvinceCode2, string cityName, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = "P";
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		subject.CityName = cityName;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
