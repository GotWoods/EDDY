using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G55Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G55*jXRPYI0xJBVq*BE*l*3*gd*9*iD*9*xB*7*Mr*6*1*vQ*r*f*JM2*6*3*b*0*8*g*d*7*t*t*iy*t*M";

		var expected = new G55_ItemCharacteristicsConsumerUnit()
		{
			UPCConsumerPackageCode = "jXRPYI0xJBVq",
			ProductServiceIDQualifier = "BE",
			ProductServiceID = "l",
			Height = 3,
			UnitOfMeasurementCode = "gd",
			Width = 9,
			UnitOfMeasurementCode2 = "iD",
			Length = 9,
			UnitOfMeasurementCode3 = "xB",
			Volume = 7,
			UnitOfMeasurementCode4 = "Mr",
			Pack = 6,
			Size = 1,
			UnitOfMeasurementCode5 = "vQ",
			CashRegisterItemDescription = "r",
			CashRegisterItemDescription2 = "f",
			CouponFamilyCode = "JM2",
			DatedProductNumberOfDays = 6,
			DepositValue = 3,
			PrePriceIndicator = "b",
			Color = "0",
			UnitWeight = 8,
			WeightQualifier = "g",
			WeightUnitQualifier = "d",
			UnitWeight2 = 7,
			WeightQualifier2 = "t",
			WeightUnitQualifier2 = "t",
			ProductServiceIDQualifier2 = "iy",
			ProductServiceID2 = "t",
			FreeFormDescription = "M",
		};

		var actual = Map.MapObject<G55_ItemCharacteristicsConsumerUnit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jXRPYI0xJBVq", true)]
	public void Validation_RequiredUPCConsumerPackageCode(string uPCConsumerPackageCode, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "BE";
		subject.ProductServiceID = "l";
		subject.UPCConsumerPackageCode = uPCConsumerPackageCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BE", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.UPCConsumerPackageCode = "jXRPYI0xJBVq";
		subject.ProductServiceID = "l";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.UPCConsumerPackageCode = "jXRPYI0xJBVq";
		subject.ProductServiceIDQualifier = "BE";
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
