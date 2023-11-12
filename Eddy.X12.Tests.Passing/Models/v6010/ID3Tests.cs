using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class ID3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID3*09Z670fx3QUI*db*V*9*5*5*9*4*8e*9*Us*2*VP*4*8*5*9*kG*c*4*tI";

		var expected = new ID3_DimensionsDetail()
		{
			UPCCaseCode = "09Z670fx3QUI",
			ProductServiceIDQualifier = "db",
			ProductServiceID = "V",
			Pack = 9,
			InnerPack = 5,
			Height = 5,
			Width = 9,
			ItemDepth = 4,
			UnitOrBasisForMeasurementCode = "8e",
			Weight = 9,
			UnitOrBasisForMeasurementCode2 = "Us",
			Volume = 2,
			UnitOrBasisForMeasurementCode3 = "VP",
			TrayCount = 4,
			Height2 = 8,
			Width2 = 5,
			ItemDepth2 = 9,
			UnitOrBasisForMeasurementCode4 = "kG",
			NestingCode = "c",
			Nesting = 4,
			UnitOrBasisForMeasurementCode5 = "tI",
		};

		var actual = Map.MapObject<ID3_DimensionsDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("09Z670fx3QUI", "db", true)]
	[InlineData("09Z670fx3QUI", "", true)]
	[InlineData("", "db", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "db";
			subject.ProductServiceID = "V";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 9;
			subject.UnitOrBasisForMeasurementCode2 = "Us";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 2;
			subject.UnitOrBasisForMeasurementCode3 = "VP";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Nesting = 4;
			subject.UnitOrBasisForMeasurementCode5 = "tI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("db", "V", true)]
	[InlineData("db", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "09Z670fx3QUI";
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 9;
			subject.UnitOrBasisForMeasurementCode2 = "Us";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 2;
			subject.UnitOrBasisForMeasurementCode3 = "VP";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Nesting = 4;
			subject.UnitOrBasisForMeasurementCode5 = "tI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "Us", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "Us", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.UPCCaseCode = "09Z670fx3QUI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "db";
			subject.ProductServiceID = "V";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 2;
			subject.UnitOrBasisForMeasurementCode3 = "VP";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Nesting = 4;
			subject.UnitOrBasisForMeasurementCode5 = "tI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "VP", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "VP", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
			subject.UPCCaseCode = "09Z670fx3QUI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "db";
			subject.ProductServiceID = "V";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 9;
			subject.UnitOrBasisForMeasurementCode2 = "Us";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Nesting = 4;
			subject.UnitOrBasisForMeasurementCode5 = "tI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "tI", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "tI", false)]
	public void Validation_AllAreRequiredNesting(decimal nesting, string unitOrBasisForMeasurementCode5, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		if (nesting > 0)
			subject.Nesting = nesting;
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
			subject.UPCCaseCode = "09Z670fx3QUI";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "db";
			subject.ProductServiceID = "V";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 9;
			subject.UnitOrBasisForMeasurementCode2 = "Us";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 2;
			subject.UnitOrBasisForMeasurementCode3 = "VP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
