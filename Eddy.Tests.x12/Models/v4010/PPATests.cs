using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PPATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPA*g*S*8MwPF6w*G*69EnhL6*O";

		var expected = new PPA_PropertyLocation()
		{
			LocationQualifier = "g",
			LocationIdentifier = "S",
			LongitudeCode = "8MwPF6w",
			DirectionIdentifierCode = "G",
			LatitudeCode = "69EnhL6",
			DirectionIdentifierCode2 = "O",
		};

		var actual = Map.MapObject<PPA_PropertyLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationIdentifier = "S";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode))
		{
			subject.LongitudeCode = "8MwPF6w";
			subject.DirectionIdentifierCode = "G";
		}
		if(!string.IsNullOrEmpty(subject.LatitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2))
		{
			subject.LatitudeCode = "69EnhL6";
			subject.DirectionIdentifierCode2 = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "g";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode))
		{
			subject.LongitudeCode = "8MwPF6w";
			subject.DirectionIdentifierCode = "G";
		}
		if(!string.IsNullOrEmpty(subject.LatitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2))
		{
			subject.LatitudeCode = "69EnhL6";
			subject.DirectionIdentifierCode2 = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8MwPF6w", "G", true)]
	[InlineData("8MwPF6w", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredLongitudeCode(string longitudeCode, string directionIdentifierCode, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "g";
		subject.LocationIdentifier = "S";
		//Test Parameters
		subject.LongitudeCode = longitudeCode;
		subject.DirectionIdentifierCode = directionIdentifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LatitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2))
		{
			subject.LatitudeCode = "69EnhL6";
			subject.DirectionIdentifierCode2 = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("69EnhL6", "O", true)]
	[InlineData("69EnhL6", "", false)]
	[InlineData("", "O", false)]
	public void Validation_AllAreRequiredLatitudeCode(string latitudeCode, string directionIdentifierCode2, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "g";
		subject.LocationIdentifier = "S";
		//Test Parameters
		subject.LatitudeCode = latitudeCode;
		subject.DirectionIdentifierCode2 = directionIdentifierCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode))
		{
			subject.LongitudeCode = "8MwPF6w";
			subject.DirectionIdentifierCode = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
