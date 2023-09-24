using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class GYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GY*j*z*p*jr*q*G*mi*l*v9*U*I*Yo";

		var expected = new GY_Geography()
		{
			GeographyQualifierCode = "j",
			CommodityGeographicLogicalConnectorCode = "z",
			LocationQualifier = "p",
			StateOrProvinceCode = "jr",
			LocationIdentifier = "q",
			LocationIdentifier2 = "G",
			StandardCarrierAlphaCode = "mi",
			ChangeTypeCode = "l",
			StandardCarrierAlphaCode2 = "v9",
			DocketControlNumber = "U",
			DocketIdentification = "I",
			GroupTitle = "Yo",
		};

		var actual = Map.MapObject<GY_Geography>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredGeographyQualifierCode(string geographyQualifierCode, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = geographyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "p", true)]
	[InlineData("q", "", false)]
	[InlineData("", "p", true)]
	public void Validation_ARequiresBLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = "j";
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "q", true)]
	[InlineData("G", "", false)]
	[InlineData("", "q", true)]
	public void Validation_ARequiresBLocationIdentifier2(string locationIdentifier2, string locationIdentifier, bool isValidExpected)
	{
		var subject = new GY_Geography();
		subject.GeographyQualifierCode = "j";
		subject.LocationIdentifier2 = locationIdentifier2;
		subject.LocationIdentifier = locationIdentifier;
		if (locationIdentifier != "")
			subject.LocationQualifier = "p";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
