using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G45Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G45*80aZPP4stbFL*jxzMMj6bn4NW*H*r*NF*E*5*3*K6*2u*oE6jM6*6*8";

		var expected = new G45_LineItemDetailPromotion()
		{
			UPCCaseCode = "80aZPP4stbFL",
			UPCEANConsumerPackageCode = "jxzMMj6bn4NW",
			AllowanceOrChargeNumber = "H",
			ExceptionNumber = "r",
			ProductServiceIDQualifier = "NF",
			ProductServiceID = "E",
			Pack = 5,
			Size = 3,
			UnitOrBasisForMeasurementCode = "K6",
			DateQualifier = "2u",
			Date = "oE6jM6",
			InnerPack = 6,
			AllowanceOrChargeRate = 8,
		};

		var actual = Map.MapObject<G45_LineItemDetailPromotion>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("NF", "E", true)]
	[InlineData("NF", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G45_LineItemDetailPromotion();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode = "K6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "2u";
			subject.Date = "oE6jM6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "K6", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "K6", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G45_LineItemDetailPromotion();
		if (size > 0)
			subject.Size = size;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "NF";
			subject.ProductServiceID = "E";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "2u";
			subject.Date = "oE6jM6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2u", "oE6jM6", true)]
	[InlineData("2u", "", false)]
	[InlineData("", "oE6jM6", false)]
	public void Validation_AllAreRequiredDateQualifier(string dateQualifier, string date, bool isValidExpected)
	{
		var subject = new G45_LineItemDetailPromotion();
		subject.DateQualifier = dateQualifier;
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "NF";
			subject.ProductServiceID = "E";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode = "K6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
