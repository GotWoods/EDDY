using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G51Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G51*6*5T*1*99*D7CAYpbraRVy*bBMt5NLVMRdP*UI*2*WK";

		var expected = new G51_FreeGoods()
		{
			QuantityFree = 6,
			UnitOfMeasurementCode = "5T",
			QuantityMustPurchase = 1,
			UnitOfMeasurementCode2 = "99",
			UPCCaseCode = "D7CAYpbraRVy",
			UPCConsumerPackageCode = "bBMt5NLVMRdP",
			ProductServiceIDQualifier = "UI",
			ProductServiceID = "2",
			UnitOfMeasurementCode3 = "WK",
		};

		var actual = Map.MapObject<G51_FreeGoods>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantityFree(int quantityFree, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.UnitOfMeasurementCode = "5T";
		subject.QuantityMustPurchase = 1;
		subject.UnitOfMeasurementCode2 = "99";
		if (quantityFree > 0)
			subject.QuantityFree = quantityFree;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5T", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.QuantityFree = 6;
		subject.QuantityMustPurchase = 1;
		subject.UnitOfMeasurementCode2 = "99";
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantityMustPurchase(int quantityMustPurchase, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.QuantityFree = 6;
		subject.UnitOfMeasurementCode = "5T";
		subject.UnitOfMeasurementCode2 = "99";
		if (quantityMustPurchase > 0)
			subject.QuantityMustPurchase = quantityMustPurchase;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("99", true)]
	public void Validation_RequiredUnitOfMeasurementCode2(string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.QuantityFree = 6;
		subject.UnitOfMeasurementCode = "5T";
		subject.QuantityMustPurchase = 1;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
