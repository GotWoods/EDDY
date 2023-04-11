using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FU4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FU4*W7*M*4*jV*6*9*e";

		var expected = new FU4_ProductPackDetail()
		{
			ProductServiceIDQualifier = "W7",
			ProductServiceID = "M",
			Pack = 4,
			UnitOrBasisForMeasurementCode = "jV",
			Size = 6,
			InnerPack = 9,
			Description = "e",
		};

		var actual = Map.MapObject<FU4_ProductPackDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("W7", "M", true)]
	[InlineData("", "M", false)]
	[InlineData("W7", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new FU4_ProductPackDetail();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("jV", 6, true)]
	[InlineData("", 6, false)]
	[InlineData("jV", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal size, bool isValidExpected)
	{
		var subject = new FU4_ProductPackDetail();
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (size > 0)
		subject.Size = size;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
