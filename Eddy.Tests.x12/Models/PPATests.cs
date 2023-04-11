using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PPATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPA*x*U*dNxHumv*I*jRxe53N*A*6*6";

		var expected = new PPA_PropertyLocation()
		{
			LocationQualifier = "x",
			LocationIdentifier = "U",
			LongitudeCode = "dNxHumv",
			DirectionIdentifierCode = "I",
			LatitudeCode = "jRxe53N",
			DirectionIdentifierCode2 = "A",
			LongitudeDecimalFormat = 6,
			LatitudeDecimalFormat = 6,
		};

		var actual = Map.MapObject<PPA_PropertyLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		subject.LocationIdentifier = "U";
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		subject.LocationQualifier = "x";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("dNxHumv", "jRxe53N", true)]
	[InlineData("", "jRxe53N", false)]
	[InlineData("dNxHumv", "", false)]
	public void Validation_AllAreRequiredLongitudeCode(string longitudeCode, string latitudeCode, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		subject.LocationQualifier = "x";
		subject.LocationIdentifier = "U";
		subject.LongitudeCode = longitudeCode;
		subject.LatitudeCode = latitudeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("dNxHumv","I", true)]
	[InlineData("", "I", true)]
	[InlineData("dNxHumv", "", true)]
	public void Validation_AtLeastOneLongitudeCode(string longitudeCode, string directionIdentifierCode, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		subject.LocationQualifier = "x";
		subject.LocationIdentifier = "U";
		subject.LongitudeCode = longitudeCode;
		subject.DirectionIdentifierCode = directionIdentifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("dNxHumv", 6, false)]
	[InlineData("", 6, true)]
	[InlineData("dNxHumv", 0, true)]
	public void Validation_OnlyOneOfLongitudeCode(string longitudeCode, decimal longitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		subject.LocationQualifier = "x";
		subject.LocationIdentifier = "U";
		subject.LongitudeCode = longitudeCode;
		if (longitudeDecimalFormat > 0)
		subject.LongitudeDecimalFormat = longitudeDecimalFormat;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("","", 0, true)]
	[InlineData("I", "dNxHumv", 0, true)]
	[InlineData("", "dNxHumv", 0, true)]
	[InlineData("I", "", 0, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DirectionIdentifierCode(string directionIdentifierCode, string longitudeCode, decimal longitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		subject.LocationQualifier = "x";
		subject.LocationIdentifier = "U";
		subject.DirectionIdentifierCode = directionIdentifierCode;
		subject.LongitudeCode = longitudeCode;
		if (longitudeDecimalFormat > 0)
		subject.LongitudeDecimalFormat = longitudeDecimalFormat;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("jRxe53N","A", true)]
	[InlineData("", "A", true)]
	[InlineData("jRxe53N", "", true)]
	public void Validation_AtLeastOneLatitudeCode(string latitudeCode, string directionIdentifierCode2, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		subject.LocationQualifier = "x";
		subject.LocationIdentifier = "U";
		subject.LatitudeCode = latitudeCode;
		subject.DirectionIdentifierCode2 = directionIdentifierCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("jRxe53N", 6, false)]
	[InlineData("", 6, true)]
	[InlineData("jRxe53N", 0, true)]
	public void Validation_OnlyOneOfLatitudeCode(string latitudeCode, decimal latitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		subject.LocationQualifier = "x";
		subject.LocationIdentifier = "U";
		subject.LatitudeCode = latitudeCode;
		if (latitudeDecimalFormat > 0)
		subject.LatitudeDecimalFormat = latitudeDecimalFormat;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("A", "jRxe53N", 0, true)]
	[InlineData("", "jRxe53N", 0, true)]
	[InlineData("A", "", 0, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DirectionIdentifierCode2(string directionIdentifierCode2, string latitudeCode, decimal latitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		subject.LocationQualifier = "x";
		subject.LocationIdentifier = "U";
		subject.DirectionIdentifierCode2 = directionIdentifierCode2;
		subject.LatitudeCode = latitudeCode;
		if (latitudeDecimalFormat > 0)
		subject.LatitudeDecimalFormat = latitudeDecimalFormat;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0,0, true)]
	[InlineData(6, 6, true)]
	[InlineData(0, 6, false)]
	[InlineData(6, 0, false)]
	public void Validation_AllAreRequiredLongitudeDecimalFormat(decimal longitudeDecimalFormat, decimal latitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		subject.LocationQualifier = "x";
		subject.LocationIdentifier = "U";
		if (longitudeDecimalFormat > 0)
		subject.LongitudeDecimalFormat = longitudeDecimalFormat;
		if (latitudeDecimalFormat > 0)
		subject.LatitudeDecimalFormat = latitudeDecimalFormat;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
