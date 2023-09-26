using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class PPATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPA*q*k*PNns9Sv*Y*XmpbW2W*s";

		var expected = new PPA_PropertyLocation()
		{
			LocationQualifier = "q",
			LocationIdentifier = "k",
			LongitudeCode = "PNns9Sv",
			DirectionIdentifierCode = "Y",
			LatitudeCode = "XmpbW2W",
			DirectionIdentifierCode2 = "s",
		};

		var actual = Map.MapObject<PPA_PropertyLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationIdentifier = "k";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "q";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
