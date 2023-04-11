using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G45Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G45*i0WxIyfjh6nw*hlg24PJcFzb9*n*Q*wl*2*3*4*f0*3f*WLwxiN85*4*3*U4*1*cM*8";

		var expected = new G45_LineItemDetailPromotion()
		{
			UPCCaseCode = "i0WxIyfjh6nw",
			UPCEANConsumerPackageCode = "hlg24PJcFzb9",
			AllowanceOrChargeNumber = "n",
			ExceptionNumber = "Q",
			ProductServiceIDQualifier = "wl",
			ProductServiceID = "2",
			Pack = 3,
			Size = 4,
			UnitOrBasisForMeasurementCode = "f0",
			DateQualifier = "3f",
			Date = "WLwxiN85",
			InnerPack = 4,
			AllowanceOrChargeRate = 3,
			ProductServiceIDQualifier2 = "U4",
			ProductServiceID2 = "1",
			ProductServiceIDQualifier3 = "cM",
			ProductServiceID3 = "8",
		};

		var actual = Map.MapObject<G45_LineItemDetailPromotion>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("wl", "2", true)]
	[InlineData("", "2", false)]
	[InlineData("wl", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G45_LineItemDetailPromotion();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(4, "f0", true)]
	[InlineData(0, "f0", false)]
	[InlineData(4, "", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G45_LineItemDetailPromotion();
		if (size > 0)
		subject.Size = size;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("3f", "WLwxiN85", true)]
	[InlineData("", "WLwxiN85", false)]
	[InlineData("3f", "", false)]
	public void Validation_AllAreRequiredDateQualifier(string dateQualifier, string date, bool isValidExpected)
	{
		var subject = new G45_LineItemDetailPromotion();
		subject.DateQualifier = dateQualifier;
		subject.Date = date;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("U4", "1", true)]
	[InlineData("", "1", false)]
	[InlineData("U4", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G45_LineItemDetailPromotion();
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("cM", "8", true)]
	[InlineData("", "8", false)]
	[InlineData("cM", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new G45_LineItemDetailPromotion();
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
