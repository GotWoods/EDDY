using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G45Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G45*Q1nLNmrpXIso*3RgdwINcxttJ*y*w*PH*t*2*3*h3*Ja*8kEzsJA9*5*7";

		var expected = new G45_LineItemDetailPromotion()
		{
			UPCCaseCode = "Q1nLNmrpXIso",
			UPCEANConsumerPackageCode = "3RgdwINcxttJ",
			AllowanceOrChargeNumber = "y",
			ExceptionNumber = "w",
			ProductServiceIDQualifier = "PH",
			ProductServiceID = "t",
			Pack = 2,
			Size = 3,
			UnitOrBasisForMeasurementCode = "h3",
			DateQualifier = "Ja",
			Date = "8kEzsJA9",
			InnerPack = 5,
			AllowanceOrChargeRate = 7,
		};

		var actual = Map.MapObject<G45_LineItemDetailPromotion>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("PH", "t", true)]
	[InlineData("PH", "", false)]
	[InlineData("", "t", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G45_LineItemDetailPromotion();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode = "h3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Ja";
			subject.Date = "8kEzsJA9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "h3", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "h3", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G45_LineItemDetailPromotion();
		if (size > 0)
			subject.Size = size;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "PH";
			subject.ProductServiceID = "t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Ja";
			subject.Date = "8kEzsJA9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ja", "8kEzsJA9", true)]
	[InlineData("Ja", "", false)]
	[InlineData("", "8kEzsJA9", false)]
	public void Validation_AllAreRequiredDateQualifier(string dateQualifier, string date, bool isValidExpected)
	{
		var subject = new G45_LineItemDetailPromotion();
		subject.DateQualifier = dateQualifier;
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "PH";
			subject.ProductServiceID = "t";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode = "h3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
