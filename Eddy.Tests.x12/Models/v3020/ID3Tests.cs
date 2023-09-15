using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class ID3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID3*qdyI1cRE8fcw*sr*U*9*3*2*8*8*A5*6*Ew*1*PJ*8*2*4*4*pg*G*1*LN";

		var expected = new ID3_DimensionsDetail()
		{
			UPCCaseCode = "qdyI1cRE8fcw",
			ProductServiceIDQualifier = "sr",
			ProductServiceID = "U",
			Pack = 9,
			InnerPack = 3,
			Height = 2,
			Width = 8,
			ItemDepth = 8,
			UnitOfMeasurementCode = "A5",
			Weight = 6,
			UnitOfMeasurementCode2 = "Ew",
			Volume = 1,
			UnitOfMeasurementCode3 = "PJ",
			TrayCount = 8,
			Height2 = 2,
			Width2 = 4,
			ItemDepth2 = 4,
			UnitOfMeasurementCode4 = "pg",
			NestingCode = "G",
			Nesting = 1,
			UnitOfMeasurementCode5 = "LN",
		};

		var actual = Map.MapObject<ID3_DimensionsDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("qdyI1cRE8fcw", "sr", true)]
	[InlineData("qdyI1cRE8fcw", "", true)]
	[InlineData("", "sr", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "sr";
			subject.ProductServiceID = "U";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Weight = 6;
			subject.UnitOfMeasurementCode2 = "Ew";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Volume = 1;
			subject.UnitOfMeasurementCode3 = "PJ";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Nesting = 1;
			subject.UnitOfMeasurementCode5 = "LN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sr", "U", true)]
	[InlineData("sr", "", false)]
	[InlineData("", "U", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "qdyI1cRE8fcw";
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Weight = 6;
			subject.UnitOfMeasurementCode2 = "Ew";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Volume = 1;
			subject.UnitOfMeasurementCode3 = "PJ";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Nesting = 1;
			subject.UnitOfMeasurementCode5 = "LN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "Ew", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "Ew", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
			subject.UPCCaseCode = "qdyI1cRE8fcw";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "sr";
			subject.ProductServiceID = "U";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Volume = 1;
			subject.UnitOfMeasurementCode3 = "PJ";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Nesting = 1;
			subject.UnitOfMeasurementCode5 = "LN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "PJ", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "PJ", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOfMeasurementCode3, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOfMeasurementCode3 = unitOfMeasurementCode3;
			subject.UPCCaseCode = "qdyI1cRE8fcw";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "sr";
			subject.ProductServiceID = "U";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Weight = 6;
			subject.UnitOfMeasurementCode2 = "Ew";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Nesting = 1;
			subject.UnitOfMeasurementCode5 = "LN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "LN", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "LN", false)]
	public void Validation_AllAreRequiredNesting(decimal nesting, string unitOfMeasurementCode5, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		if (nesting > 0)
			subject.Nesting = nesting;
		subject.UnitOfMeasurementCode5 = unitOfMeasurementCode5;
			subject.UPCCaseCode = "qdyI1cRE8fcw";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "sr";
			subject.ProductServiceID = "U";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Weight = 6;
			subject.UnitOfMeasurementCode2 = "Ew";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Volume = 1;
			subject.UnitOfMeasurementCode3 = "PJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
