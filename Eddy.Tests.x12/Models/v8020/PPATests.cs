using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class PPATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPA*r*4*nLBq0Bg*u*tI3oHA8*l*8*8";

		var expected = new PPA_PropertyLocation()
		{
			LocationQualifier = "r",
			LocationIdentifier = "4",
			LongitudeCode = "nLBq0Bg",
			DirectionIdentifierCode = "u",
			LatitudeCode = "tI3oHA8",
			DirectionIdentifierCode2 = "l",
			LongitudeDecimalFormat = 8,
			LatitudeDecimalFormat = 8,
		};

		var actual = Map.MapObject<PPA_PropertyLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationIdentifier = "4";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		//At Least one
		subject.LongitudeCode = "nLBq0Bg";
		subject.LatitudeCode = "tI3oHA8";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "nLBq0Bg";
			subject.LatitudeCode = "tI3oHA8";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 8;
			subject.LatitudeDecimalFormat = 8;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "u";
			subject.LongitudeCode = "nLBq0Bg";
			subject.LongitudeDecimalFormat = 8;
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "l";
			subject.LatitudeCode = "tI3oHA8";
			subject.LatitudeDecimalFormat = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "r";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//At Least one
		subject.LongitudeCode = "nLBq0Bg";
		subject.LatitudeCode = "tI3oHA8";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "nLBq0Bg";
			subject.LatitudeCode = "tI3oHA8";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 8;
			subject.LatitudeDecimalFormat = 8;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "u";
			subject.LongitudeCode = "nLBq0Bg";
			subject.LongitudeDecimalFormat = 8;
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "l";
			subject.LatitudeCode = "tI3oHA8";
			subject.LatitudeDecimalFormat = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("nLBq0Bg", "tI3oHA8", true)]
	[InlineData("nLBq0Bg", "", false)]
	[InlineData("", "tI3oHA8", false)]
	public void Validation_AllAreRequiredLongitudeCode(string longitudeCode, string latitudeCode, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "r";
		subject.LocationIdentifier = "4";
		//Test Parameters
		subject.LongitudeCode = longitudeCode;
		subject.LatitudeCode = latitudeCode;
		//At Least one
		subject.DirectionIdentifierCode2 = "l";
		//If one filled, all required
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 8;
			subject.LatitudeDecimalFormat = 8;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "u";
			subject.LongitudeDecimalFormat = 8;
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "l";
			subject.LatitudeDecimalFormat = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("nLBq0Bg", "u", true)]
	[InlineData("nLBq0Bg", "", true)]
	[InlineData("", "u", true)]
	public void Validation_AtLeastOneLongitudeCode(string longitudeCode, string directionIdentifierCode, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "r";
		subject.LocationIdentifier = "4";
		//Test Parameters
		subject.LongitudeCode = longitudeCode;
		subject.DirectionIdentifierCode = directionIdentifierCode;
		//At Least one
		subject.LatitudeCode = "tI3oHA8";
		//If one filled, all required
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 8;
			subject.LatitudeDecimalFormat = 8;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 8;
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "l";
			subject.LatitudeCode = "tI3oHA8";
			subject.LatitudeDecimalFormat = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("nLBq0Bg", 8, false)]
	[InlineData("nLBq0Bg", 0, true)]
	[InlineData("", 8, true)]
	public void Validation_OnlyOneOfLongitudeCode(string longitudeCode, decimal longitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "r";
		subject.LocationIdentifier = "4";
		//Test Parameters
		subject.LongitudeCode = longitudeCode;
		if (longitudeDecimalFormat > 0) 
			subject.LongitudeDecimalFormat = longitudeDecimalFormat;
		//At Least one
		subject.LatitudeCode = "tI3oHA8";
		//If one filled, all required
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 8;
			subject.LatitudeDecimalFormat = 8;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode))
		{
			subject.DirectionIdentifierCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "l";
			subject.LatitudeCode = "tI3oHA8";
			subject.LatitudeDecimalFormat = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("u", "nLBq0Bg", 8, true)]
	[InlineData("u", "", 0, false)]
	[InlineData("", "nLBq0Bg", 8, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DirectionIdentifierCode(string directionIdentifierCode, string longitudeCode, decimal longitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "r";
		subject.LocationIdentifier = "4";
		//Test Parameters
		subject.DirectionIdentifierCode = directionIdentifierCode;
		subject.LongitudeCode = longitudeCode;
		if (longitudeDecimalFormat > 0) 
			subject.LongitudeDecimalFormat = longitudeDecimalFormat;
		//At Least one
		subject.LatitudeCode = "tI3oHA8";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "nLBq0Bg";
			subject.LatitudeCode = "tI3oHA8";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 8;
			subject.LatitudeDecimalFormat = 8;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "l";
			subject.LatitudeCode = "tI3oHA8";
			subject.LatitudeDecimalFormat = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("tI3oHA8", "l", true)]
	[InlineData("tI3oHA8", "", true)]
	[InlineData("", "l", true)]
	public void Validation_AtLeastOneLatitudeCode(string latitudeCode, string directionIdentifierCode2, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "r";
		subject.LocationIdentifier = "4";
		//Test Parameters
		subject.LatitudeCode = latitudeCode;
		subject.DirectionIdentifierCode2 = directionIdentifierCode2;
		//At Least one
		subject.LongitudeCode = "nLBq0Bg";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "nLBq0Bg";
			subject.LatitudeCode = "tI3oHA8";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 8;
			subject.LatitudeDecimalFormat = 8;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "u";
			subject.LongitudeCode = "nLBq0Bg";
			subject.LongitudeDecimalFormat = 8;
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || subject.LatitudeDecimalFormat > 0)
		{
			subject.LatitudeDecimalFormat = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("tI3oHA8", 8, false)]
	[InlineData("tI3oHA8", 0, true)]
	[InlineData("", 8, true)]
	public void Validation_OnlyOneOfLatitudeCode(string latitudeCode, decimal latitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "r";
		subject.LocationIdentifier = "4";
		//Test Parameters
		subject.LatitudeCode = latitudeCode;
		if (latitudeDecimalFormat > 0) 
			subject.LatitudeDecimalFormat = latitudeDecimalFormat;
		//At Least one
		subject.LongitudeCode = "nLBq0Bg";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "nLBq0Bg";
			subject.LatitudeCode = "tI3oHA8";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 8;
			subject.LatitudeDecimalFormat = 8;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "u";
			subject.LongitudeCode = "nLBq0Bg";
			subject.LongitudeDecimalFormat = 8;
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2))
		{
			subject.DirectionIdentifierCode2 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("l", "tI3oHA8", 8, true)]
	[InlineData("l", "", 0, false)]
	[InlineData("", "tI3oHA8", 8, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DirectionIdentifierCode2(string directionIdentifierCode2, string latitudeCode, decimal latitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "r";
		subject.LocationIdentifier = "4";
		//Test Parameters
		subject.DirectionIdentifierCode2 = directionIdentifierCode2;
		subject.LatitudeCode = latitudeCode;
		if (latitudeDecimalFormat > 0) 
			subject.LatitudeDecimalFormat = latitudeDecimalFormat;
		//At Least one
		subject.LongitudeCode = "nLBq0Bg";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "nLBq0Bg";
			subject.LatitudeCode = "tI3oHA8";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 8;
			subject.LatitudeDecimalFormat = 8;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "u";
			subject.LongitudeCode = "nLBq0Bg";
			subject.LongitudeDecimalFormat = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(8, 8, true)]
	[InlineData(8, 0, false)]
	[InlineData(0, 8, false)]
	public void Validation_AllAreRequiredLongitudeDecimalFormat(decimal longitudeDecimalFormat, decimal latitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "r";
		subject.LocationIdentifier = "4";
		//Test Parameters
		if (longitudeDecimalFormat > 0) 
			subject.LongitudeDecimalFormat = longitudeDecimalFormat;
		if (latitudeDecimalFormat > 0) 
			subject.LatitudeDecimalFormat = latitudeDecimalFormat;
		//At Least one
		subject.LongitudeCode = "nLBq0Bg";
		subject.LatitudeCode = "tI3oHA8";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "nLBq0Bg";
			subject.LatitudeCode = "tI3oHA8";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode))
		{
			subject.DirectionIdentifierCode = "u";
			subject.LongitudeCode = "nLBq0Bg";
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.DirectionIdentifierCode2 = "l";
			subject.LatitudeCode = "tI3oHA8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
