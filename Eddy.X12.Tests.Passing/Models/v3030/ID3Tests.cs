using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class ID3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID3*2TQMLUwgVoog*eT*I*5*1*9*3*4*yG*5*Jh*8*QR*7*2*5*4*cS*c*1*oR";

		var expected = new ID3_DimensionsDetail()
		{
			UPCCaseCode = "2TQMLUwgVoog",
			ProductServiceIDQualifier = "eT",
			ProductServiceID = "I",
			Pack = 5,
			InnerPack = 1,
			Height = 9,
			Width = 3,
			ItemDepth = 4,
			UnitOrBasisForMeasurementCode = "yG",
			Weight = 5,
			UnitOrBasisForMeasurementCode2 = "Jh",
			Volume = 8,
			UnitOrBasisForMeasurementCode3 = "QR",
			TrayCount = 7,
			Height2 = 2,
			Width2 = 5,
			ItemDepth2 = 4,
			UnitOrBasisForMeasurementCode4 = "cS",
			NestingCode = "c",
			Nesting = 1,
			UnitOrBasisForMeasurementCode5 = "oR",
		};

		var actual = Map.MapObject<ID3_DimensionsDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("2TQMLUwgVoog", "eT", true)]
	[InlineData("2TQMLUwgVoog", "", true)]
	[InlineData("", "eT", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "eT";
			subject.ProductServiceID = "I";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 5;
			subject.UnitOrBasisForMeasurementCode2 = "Jh";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode3 = "QR";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Nesting = 1;
			subject.UnitOrBasisForMeasurementCode5 = "oR";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("eT", "I", true)]
	[InlineData("eT", "", false)]
	[InlineData("", "I", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "2TQMLUwgVoog";
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 5;
			subject.UnitOrBasisForMeasurementCode2 = "Jh";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode3 = "QR";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Nesting = 1;
			subject.UnitOrBasisForMeasurementCode5 = "oR";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "Jh", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "Jh", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.UPCCaseCode = "2TQMLUwgVoog";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "eT";
			subject.ProductServiceID = "I";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode3 = "QR";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Nesting = 1;
			subject.UnitOrBasisForMeasurementCode5 = "oR";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "QR", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "QR", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
			subject.UPCCaseCode = "2TQMLUwgVoog";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "eT";
			subject.ProductServiceID = "I";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 5;
			subject.UnitOrBasisForMeasurementCode2 = "Jh";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Nesting = 1;
			subject.UnitOrBasisForMeasurementCode5 = "oR";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "oR", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "oR", false)]
	public void Validation_AllAreRequiredNesting(decimal nesting, string unitOrBasisForMeasurementCode5, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		if (nesting > 0)
			subject.Nesting = nesting;
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
			subject.UPCCaseCode = "2TQMLUwgVoog";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "eT";
			subject.ProductServiceID = "I";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 5;
			subject.UnitOrBasisForMeasurementCode2 = "Jh";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode3 = "QR";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
