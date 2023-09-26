using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.Tests.Models.v8040;

public class PPATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPA*a*I*HMmhWXo*W*o7qsvNe*J*1*2";

		var expected = new PPA_PropertyLocation()
		{
			LocationQualifier = "a",
			LocationIdentifier = "I",
			LongitudeCode = "HMmhWXo",
			DirectionIdentifierCode = "W",
			LatitudeCode = "o7qsvNe",
			DirectionIdentifierCode2 = "J",
			LongitudeDecimalFormat = 1,
			LatitudeDecimalFormat = 2,
		};

		var actual = Map.MapObject<PPA_PropertyLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationIdentifier = "I";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		//At Least one
		subject.LongitudeCode = "HMmhWXo";
		subject.LongitudeCode = "HMmhWXo";
		subject.LatitudeCode = "o7qsvNe";
		subject.LatitudeCode = "o7qsvNe";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "HMmhWXo";
			subject.LatitudeCode = "o7qsvNe";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 1;
			subject.LatitudeDecimalFormat = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "W";
			subject.LongitudeCode = "HMmhWXo";
			subject.LongitudeDecimalFormat = 1;
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "J";
			subject.LatitudeCode = "o7qsvNe";
			subject.LatitudeDecimalFormat = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "a";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//At Least one
		subject.LongitudeCode = "HMmhWXo";
		subject.LongitudeCode = "HMmhWXo";
		subject.LatitudeCode = "o7qsvNe";
		subject.LatitudeCode = "o7qsvNe";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "HMmhWXo";
			subject.LatitudeCode = "o7qsvNe";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 1;
			subject.LatitudeDecimalFormat = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "W";
			subject.LongitudeCode = "HMmhWXo";
			subject.LongitudeDecimalFormat = 1;
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "J";
			subject.LatitudeCode = "o7qsvNe";
			subject.LatitudeDecimalFormat = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("HMmhWXo", "o7qsvNe", true)]
	[InlineData("HMmhWXo", "", false)]
	[InlineData("", "o7qsvNe", false)]
	public void Validation_AllAreRequiredLongitudeCode(string longitudeCode, string latitudeCode, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "a";
		subject.LocationIdentifier = "I";
		//Test Parameters
		subject.LongitudeCode = longitudeCode;
		subject.LatitudeCode = latitudeCode;
		//At Least one
		subject.DirectionIdentifierCode2 = "J";
		subject.LatitudeDecimalFormat = 2;
		//If one filled, all required
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 1;
			subject.LatitudeDecimalFormat = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "W";
			subject.LongitudeDecimalFormat = 1;
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "J";
			subject.LatitudeDecimalFormat = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("HMmhWXo", 1, false)]
	[InlineData("HMmhWXo", 0, true)]
	[InlineData("", 1, true)]
	public void Validation_OnlyOneOfLongitudeCode(string longitudeCode, decimal longitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "a";
		subject.LocationIdentifier = "I";
		//Test Parameters
		subject.LongitudeCode = longitudeCode;
		if (longitudeDecimalFormat > 0) 
			subject.LongitudeDecimalFormat = longitudeDecimalFormat;
		//At Least one
		subject.LatitudeCode = "o7qsvNe";
		subject.LatitudeCode = "o7qsvNe";
		//If one filled, all required
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 1;
			subject.LatitudeDecimalFormat = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode))
		{
			subject.DirectionIdentifierCode = "W";
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "J";
			subject.LatitudeCode = "o7qsvNe";
			subject.LatitudeDecimalFormat = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("W", "HMmhWXo", 1, true)]
	[InlineData("W", "", 0, false)]
	[InlineData("", "HMmhWXo", 1, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DirectionIdentifierCode(string directionIdentifierCode, string longitudeCode, decimal longitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "a";
		subject.LocationIdentifier = "I";
		//Test Parameters
		subject.DirectionIdentifierCode = directionIdentifierCode;
		subject.LongitudeCode = longitudeCode;
		if (longitudeDecimalFormat > 0) 
			subject.LongitudeDecimalFormat = longitudeDecimalFormat;
		//At Least one
		subject.LatitudeCode = "o7qsvNe";
		subject.LatitudeCode = "o7qsvNe";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "HMmhWXo";
			subject.LatitudeCode = "o7qsvNe";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 1;
			subject.LatitudeDecimalFormat = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "J";
			subject.LatitudeCode = "o7qsvNe";
			subject.LatitudeDecimalFormat = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("o7qsvNe", 2, false)]
	[InlineData("o7qsvNe", 0, true)]
	[InlineData("", 2, true)]
	public void Validation_OnlyOneOfLatitudeCode(string latitudeCode, decimal latitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "a";
		subject.LocationIdentifier = "I";
		//Test Parameters
		subject.LatitudeCode = latitudeCode;
		if (latitudeDecimalFormat > 0) 
			subject.LatitudeDecimalFormat = latitudeDecimalFormat;
		//At Least one
		subject.LongitudeCode = "HMmhWXo";
		subject.LongitudeCode = "HMmhWXo";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "HMmhWXo";
			subject.LatitudeCode = "o7qsvNe";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 1;
			subject.LatitudeDecimalFormat = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "W";
			subject.LongitudeCode = "HMmhWXo";
			subject.LongitudeDecimalFormat = 1;
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2))
		{
			subject.DirectionIdentifierCode2 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("J", "o7qsvNe", 2, true)]
	[InlineData("J", "", 0, false)]
	[InlineData("", "o7qsvNe", 2, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DirectionIdentifierCode2(string directionIdentifierCode2, string latitudeCode, decimal latitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "a";
		subject.LocationIdentifier = "I";
		//Test Parameters
		subject.DirectionIdentifierCode2 = directionIdentifierCode2;
		subject.LatitudeCode = latitudeCode;
		if (latitudeDecimalFormat > 0) 
			subject.LatitudeDecimalFormat = latitudeDecimalFormat;
		//At Least one
		subject.LongitudeCode = "HMmhWXo";
		subject.LongitudeCode = "HMmhWXo";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "HMmhWXo";
			subject.LatitudeCode = "o7qsvNe";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 1;
			subject.LatitudeDecimalFormat = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "W";
			subject.LongitudeCode = "HMmhWXo";
			subject.LongitudeDecimalFormat = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(1, 2, true)]
	[InlineData(1, 0, false)]
	[InlineData(0, 2, false)]
	public void Validation_AllAreRequiredLongitudeDecimalFormat(decimal longitudeDecimalFormat, decimal latitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "a";
		subject.LocationIdentifier = "I";
		//Test Parameters
		if (longitudeDecimalFormat > 0) 
			subject.LongitudeDecimalFormat = longitudeDecimalFormat;
		if (latitudeDecimalFormat > 0) 
			subject.LatitudeDecimalFormat = latitudeDecimalFormat;
		//At Least one
		subject.LongitudeCode = "HMmhWXo";
		subject.LongitudeCode = "HMmhWXo";
		subject.LatitudeCode = "o7qsvNe";
		subject.LatitudeCode = "o7qsvNe";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "HMmhWXo";
			subject.LatitudeCode = "o7qsvNe";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode))
		{
			subject.DirectionIdentifierCode = "W";
			subject.LongitudeCode = "HMmhWXo";
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.DirectionIdentifierCode2 = "J";
			subject.LatitudeCode = "o7qsvNe";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
