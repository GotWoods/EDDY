using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class ID3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID3*Op5mVvVqIgTz*Xc*T*8*7*4*7*4*wR*5*X8*8*4f*3*9*1*2*0o*F*9*r9";

		var expected = new ID3_DimensionsDetail()
		{
			UPCCaseCode = "Op5mVvVqIgTz",
			ProductServiceIDQualifier = "Xc",
			ProductServiceID = "T",
			Pack = 8,
			InnerPack = 7,
			Height = 4,
			Width = 7,
			ItemDepth = 4,
			UnitOrBasisForMeasurementCode = "wR",
			Weight = 5,
			UnitOrBasisForMeasurementCode2 = "X8",
			Volume = 8,
			UnitOrBasisForMeasurementCode3 = "4f",
			TrayCount = 3,
			Height2 = 9,
			Width2 = 1,
			ItemDepth2 = 2,
			UnitOrBasisForMeasurementCode4 = "0o",
			NestingCode = "F",
			Nesting = 9,
			UnitOrBasisForMeasurementCode5 = "r9",
		};

		var actual = Map.MapObject<ID3_DimensionsDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Op5mVvVqIgTz", "Xc", true)]
	[InlineData("Op5mVvVqIgTz", "", true)]
	[InlineData("", "Xc", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Xc";
			subject.ProductServiceID = "T";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 5;
			subject.UnitOrBasisForMeasurementCode2 = "X8";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode3 = "4f";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Nesting = 9;
			subject.UnitOrBasisForMeasurementCode5 = "r9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Xc", "T", true)]
	[InlineData("Xc", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "Op5mVvVqIgTz";
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 5;
			subject.UnitOrBasisForMeasurementCode2 = "X8";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode3 = "4f";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Nesting = 9;
			subject.UnitOrBasisForMeasurementCode5 = "r9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "X8", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "X8", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.UPCCaseCode = "Op5mVvVqIgTz";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Xc";
			subject.ProductServiceID = "T";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode3 = "4f";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Nesting = 9;
			subject.UnitOrBasisForMeasurementCode5 = "r9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "4f", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "4f", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
			subject.UPCCaseCode = "Op5mVvVqIgTz";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Xc";
			subject.ProductServiceID = "T";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 5;
			subject.UnitOrBasisForMeasurementCode2 = "X8";
		}
		//If one is filled, all are required
		if(subject.Nesting > 0 || subject.Nesting > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.Nesting = 9;
			subject.UnitOrBasisForMeasurementCode5 = "r9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "r9", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "r9", false)]
	public void Validation_AllAreRequiredNesting(decimal nesting, string unitOrBasisForMeasurementCode5, bool isValidExpected)
	{
		var subject = new ID3_DimensionsDetail();
		if (nesting > 0)
			subject.Nesting = nesting;
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
			subject.UPCCaseCode = "Op5mVvVqIgTz";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Xc";
			subject.ProductServiceID = "T";
		}
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 5;
			subject.UnitOrBasisForMeasurementCode2 = "X8";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 8;
			subject.UnitOrBasisForMeasurementCode3 = "4f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
