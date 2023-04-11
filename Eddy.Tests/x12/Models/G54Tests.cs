using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G54Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G54*4*4U*oDWyibyw7dSD*wQ*Z*l";

		var expected = new G54_ModuleDescription()
		{
			Quantity = 4,
			UnitOrBasisForMeasurementCode = "4U",
			UPCCaseCode = "oDWyibyw7dSD",
			ProductServiceIDQualifier = "wQ",
			ProductServiceID = "Z",
			FreeFormDescription = "l",
		};

		var actual = Map.MapObject<G54_ModuleDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new G54_ModuleDescription();
		subject.UnitOrBasisForMeasurementCode = "4U";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4U", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G54_ModuleDescription();
		subject.Quantity = 4;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("oDWyibyw7dSD","wQ", true)]
	[InlineData("", "wQ", true)]
	[InlineData("oDWyibyw7dSD", "", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G54_ModuleDescription();
		subject.Quantity = 4;
		subject.UnitOrBasisForMeasurementCode = "4U";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("wQ", "Z", true)]
	[InlineData("", "Z", false)]
	[InlineData("wQ", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G54_ModuleDescription();
		subject.Quantity = 4;
		subject.UnitOrBasisForMeasurementCode = "4U";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
