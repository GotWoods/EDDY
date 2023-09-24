using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class ID3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID3*4RBy1nYERIsY*3p*v*5*5*6*4*6*Nn*1*Q6*7*oH*2*1*7*9*Xm*n*5*42";

		var expected = new ID3_DimensionsDetail()
		{
			UPCCaseCode = "4RBy1nYERIsY",
			ProductServiceIDQualifier = "3p",
			ProductServiceID = "v",
			Pack = 5,
			InnerPack = 5,
			Height = 6,
			Width = 4,
			ItemDepth = 6,
			UnitOrBasisForMeasurementCode = "Nn",
			Weight = 1,
			UnitOrBasisForMeasurementCode2 = "Q6",
			Volume = 7,
			UnitOrBasisForMeasurementCode3 = "oH",
			TrayCount = 2,
			Height2 = 1,
			Width2 = 7,
			ItemDepth2 = 9,
			UnitOrBasisForMeasurementCode4 = "Xm",
			NestingCode = "n",
			Nesting = 5,
			UnitOrBasisForMeasurementCode5 = "42",
		};

		var actual = Map.MapObject<ID3_DimensionsDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("4RBy1nYERIsY", "3p", true)]
	[InlineData("4RBy1nYERIsY", "", true)]
	[InlineData("", "3p", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "3p";
			subject.ProductServiceID = "v";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode2 = "Q6";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 7;
			subject.UnitOrBasisForMeasurementCode3 = "oH";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Nesting = 5;
			subject.UnitOrBasisForMeasurementCode5 = "42";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3p", "v", true)]
	[InlineData("3p", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "4RBy1nYERIsY";
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode2 = "Q6";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 7;
			subject.UnitOrBasisForMeasurementCode3 = "oH";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Nesting = 5;
			subject.UnitOrBasisForMeasurementCode5 = "42";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Q6", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Q6", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.UPCCaseCode = "4RBy1nYERIsY";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "3p";
			subject.ProductServiceID = "v";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 7;
			subject.UnitOrBasisForMeasurementCode3 = "oH";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Nesting = 5;
			subject.UnitOrBasisForMeasurementCode5 = "42";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "oH", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "oH", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
			subject.UPCCaseCode = "4RBy1nYERIsY";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "3p";
			subject.ProductServiceID = "v";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode2 = "Q6";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Nesting = 5;
			subject.UnitOrBasisForMeasurementCode5 = "42";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "42", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "42", false)]
	public void Validation_AllAreRequiredNesting(decimal nesting, string unitOrBasisForMeasurementCode5, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		if (nesting > 0)
			subject.Nesting = nesting;
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
			subject.UPCCaseCode = "4RBy1nYERIsY";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "3p";
			subject.ProductServiceID = "v";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode2 = "Q6";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 7;
			subject.UnitOrBasisForMeasurementCode3 = "oH";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
