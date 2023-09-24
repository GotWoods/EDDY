using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class G45Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G45*i9g2Uoom8MkE*ZvtcpFIyFQJV*3*K*Oj*N*4*3*6Y*6n*NzyVOm*4*7";

		var expected = new G45_LineItemDetailPromotion()
		{
			UPCCaseCode = "i9g2Uoom8MkE",
			UPCEANConsumerPackageCode = "ZvtcpFIyFQJV",
			AllowanceOrChargeNumber = "3",
			ExceptionNumber = "K",
			ProductServiceIDQualifier = "Oj",
			ProductServiceID = "N",
			Pack = 4,
			Size = 3,
			UnitOrBasisForMeasurementCode = "6Y",
			DateQualifier = "6n",
			Date = "NzyVOm",
			InnerPack = 4,
			AllowanceOrChargeRate = 7,
		};

		var actual = Map.MapObject<G45_LineItemDetailPromotion>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Oj", "N", true)]
	[InlineData("Oj", "", false)]
	[InlineData("", "N", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G45_LineItemDetailPromotion();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode = "6Y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "6n";
			subject.Date = "NzyVOm";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "6Y", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "6Y", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G45_LineItemDetailPromotion();
		if (size > 0)
			subject.Size = size;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Oj";
			subject.ProductServiceID = "N";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "6n";
			subject.Date = "NzyVOm";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6n", "NzyVOm", true)]
	[InlineData("6n", "", false)]
	[InlineData("", "NzyVOm", false)]
	public void Validation_AllAreRequiredDateQualifier(string dateQualifier, string date, bool isValidExpected)
	{
		var subject = new G45_LineItemDetailPromotion();
		subject.DateQualifier = dateQualifier;
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Oj";
			subject.ProductServiceID = "N";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 3;
			subject.UnitOrBasisForMeasurementCode = "6Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
