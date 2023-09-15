using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class G54Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G54*4*9Y*xw6DFyzevghr*M6*v*v";

		var expected = new G54_ModuleDescription()
		{
			Quantity = 4,
			UnitOrBasisForMeasurementCode = "9Y",
			UPCCaseCode = "xw6DFyzevghr",
			ProductServiceIDQualifier = "M6",
			ProductServiceID = "v",
			FreeFormDescription = "v",
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
		subject.UnitOrBasisForMeasurementCode = "9Y";
		if (quantity > 0)
			subject.Quantity = quantity;
			subject.UPCCaseCode = "xw6DFyzevghr";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "M6";
			subject.ProductServiceID = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9Y", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G54_ModuleDescription();
		subject.Quantity = 4;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UPCCaseCode = "xw6DFyzevghr";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "M6";
			subject.ProductServiceID = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("xw6DFyzevghr", "M6", true)]
	[InlineData("xw6DFyzevghr", "", true)]
	[InlineData("", "M6", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G54_ModuleDescription();
		subject.Quantity = 4;
		subject.UnitOrBasisForMeasurementCode = "9Y";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "M6";
			subject.ProductServiceID = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M6", "v", true)]
	[InlineData("M6", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G54_ModuleDescription();
		subject.Quantity = 4;
		subject.UnitOrBasisForMeasurementCode = "9Y";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "xw6DFyzevghr";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
