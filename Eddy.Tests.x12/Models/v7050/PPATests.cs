using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class PPATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPA*5*R*oDGV8Db*x*YH1IlYs*F*6*4";

		var expected = new PPA_PropertyLocation()
		{
			LocationQualifier = "5",
			LocationIdentifier = "R",
			LongitudeCode = "oDGV8Db",
			DirectionIdentifierCode = "x",
			LatitudeCode = "YH1IlYs",
			DirectionIdentifierCode2 = "F",
			LongitudeDecimalFormat = 6,
			LatitudeDecimalFormat = 4,
		};

		var actual = Map.MapObject<PPA_PropertyLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationIdentifier = "R";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		//At Least one
		subject.LongitudeCode = "oDGV8Db";
		subject.LongitudeCode = "oDGV8Db";
		subject.LatitudeCode = "YH1IlYs";
		subject.LatitudeCode = "YH1IlYs";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "oDGV8Db";
			subject.LatitudeCode = "YH1IlYs";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 6;
			subject.LatitudeDecimalFormat = 4;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "x";
			subject.LongitudeCode = "oDGV8Db";
			subject.LongitudeDecimalFormat = 6;
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "F";
			subject.LatitudeCode = "YH1IlYs";
			subject.LatitudeDecimalFormat = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "5";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//At Least one
		subject.LongitudeCode = "oDGV8Db";
		subject.LongitudeCode = "oDGV8Db";
		subject.LatitudeCode = "YH1IlYs";
		subject.LatitudeCode = "YH1IlYs";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "oDGV8Db";
			subject.LatitudeCode = "YH1IlYs";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 6;
			subject.LatitudeDecimalFormat = 4;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "x";
			subject.LongitudeCode = "oDGV8Db";
			subject.LongitudeDecimalFormat = 6;
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "F";
			subject.LatitudeCode = "YH1IlYs";
			subject.LatitudeDecimalFormat = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("oDGV8Db", "YH1IlYs", true)]
	[InlineData("oDGV8Db", "", false)]
	[InlineData("", "YH1IlYs", false)]
	public void Validation_AllAreRequiredLongitudeCode(string longitudeCode, string latitudeCode, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "5";
		subject.LocationIdentifier = "R";
		//Test Parameters
		subject.LongitudeCode = longitudeCode;
		subject.LatitudeCode = latitudeCode;
		//At Least one
		subject.DirectionIdentifierCode2 = "F";
		subject.LatitudeDecimalFormat = 4;
		//If one filled, all required
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 6;
			subject.LatitudeDecimalFormat = 4;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "x";
			subject.LongitudeDecimalFormat = 6;
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "F";
			subject.LatitudeDecimalFormat = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("oDGV8Db", 6, false)]
	[InlineData("oDGV8Db", 0, true)]
	[InlineData("", 6, true)]
	public void Validation_OnlyOneOfLongitudeCode(string longitudeCode, decimal longitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "5";
		subject.LocationIdentifier = "R";
		//Test Parameters
		subject.LongitudeCode = longitudeCode;
		if (longitudeDecimalFormat > 0) 
			subject.LongitudeDecimalFormat = longitudeDecimalFormat;
		//At Least one
		subject.LatitudeCode = "YH1IlYs";
		subject.LatitudeCode = "YH1IlYs";
		//If one filled, all required
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 6;
			subject.LatitudeDecimalFormat = 4;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode))
		{
			subject.DirectionIdentifierCode = "x";
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "F";
			subject.LatitudeCode = "YH1IlYs";
			subject.LatitudeDecimalFormat = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("x", "oDGV8Db", 6, true)]
	[InlineData("x", "", 0, false)]
	[InlineData("", "oDGV8Db", 6, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DirectionIdentifierCode(string directionIdentifierCode, string longitudeCode, decimal longitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "5";
		subject.LocationIdentifier = "R";
		//Test Parameters
		subject.DirectionIdentifierCode = directionIdentifierCode;
		subject.LongitudeCode = longitudeCode;
		if (longitudeDecimalFormat > 0) 
			subject.LongitudeDecimalFormat = longitudeDecimalFormat;
		//At Least one
		subject.LatitudeCode = "YH1IlYs";
		subject.LatitudeCode = "YH1IlYs";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "oDGV8Db";
			subject.LatitudeCode = "YH1IlYs";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 6;
			subject.LatitudeDecimalFormat = 4;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode) || subject.LatitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode2 = "F";
			subject.LatitudeCode = "YH1IlYs";
			subject.LatitudeDecimalFormat = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("YH1IlYs", 4, false)]
	[InlineData("YH1IlYs", 0, true)]
	[InlineData("", 4, true)]
	public void Validation_OnlyOneOfLatitudeCode(string latitudeCode, decimal latitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "5";
		subject.LocationIdentifier = "R";
		//Test Parameters
		subject.LatitudeCode = latitudeCode;
		if (latitudeDecimalFormat > 0) 
			subject.LatitudeDecimalFormat = latitudeDecimalFormat;
		//At Least one
		subject.LongitudeCode = "oDGV8Db";
		subject.LongitudeCode = "oDGV8Db";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "oDGV8Db";
			subject.LatitudeCode = "YH1IlYs";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 6;
			subject.LatitudeDecimalFormat = 4;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "x";
			subject.LongitudeCode = "oDGV8Db";
			subject.LongitudeDecimalFormat = 6;
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2))
		{
			subject.DirectionIdentifierCode2 = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("F", "YH1IlYs", 4, true)]
	[InlineData("F", "", 0, false)]
	[InlineData("", "YH1IlYs", 4, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DirectionIdentifierCode2(string directionIdentifierCode2, string latitudeCode, decimal latitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "5";
		subject.LocationIdentifier = "R";
		//Test Parameters
		subject.DirectionIdentifierCode2 = directionIdentifierCode2;
		subject.LatitudeCode = latitudeCode;
		if (latitudeDecimalFormat > 0) 
			subject.LatitudeDecimalFormat = latitudeDecimalFormat;
		//At Least one
		subject.LongitudeCode = "oDGV8Db";
		subject.LongitudeCode = "oDGV8Db";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "oDGV8Db";
			subject.LatitudeCode = "YH1IlYs";
		}
		if(subject.LongitudeDecimalFormat > 0 || subject.LongitudeDecimalFormat > 0 || subject.LatitudeDecimalFormat > 0)
		{
			subject.LongitudeDecimalFormat = 6;
			subject.LatitudeDecimalFormat = 4;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || subject.LongitudeDecimalFormat > 0)
		{
			subject.DirectionIdentifierCode = "x";
			subject.LongitudeCode = "oDGV8Db";
			subject.LongitudeDecimalFormat = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(6, 4, true)]
	[InlineData(6, 0, false)]
	[InlineData(0, 4, false)]
	public void Validation_AllAreRequiredLongitudeDecimalFormat(decimal longitudeDecimalFormat, decimal latitudeDecimalFormat, bool isValidExpected)
	{
		var subject = new PPA_PropertyLocation();
		//Required fields
		subject.LocationQualifier = "5";
		subject.LocationIdentifier = "R";
		//Test Parameters
		if (longitudeDecimalFormat > 0) 
			subject.LongitudeDecimalFormat = longitudeDecimalFormat;
		if (latitudeDecimalFormat > 0) 
			subject.LatitudeDecimalFormat = latitudeDecimalFormat;
		//At Least one
		subject.LongitudeCode = "oDGV8Db";
		subject.LongitudeCode = "oDGV8Db";
		subject.LatitudeCode = "YH1IlYs";
		subject.LatitudeCode = "YH1IlYs";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LongitudeCode) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.LongitudeCode = "oDGV8Db";
			subject.LatitudeCode = "YH1IlYs";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode) || !string.IsNullOrEmpty(subject.LongitudeCode))
		{
			subject.DirectionIdentifierCode = "x";
			subject.LongitudeCode = "oDGV8Db";
		}
		if(!string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.DirectionIdentifierCode2) || !string.IsNullOrEmpty(subject.LatitudeCode))
		{
			subject.DirectionIdentifierCode2 = "F";
			subject.LatitudeCode = "YH1IlYs";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
