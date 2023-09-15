using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G54Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G54*3*tW*vVSoLFmzhSF4*Ns*n*B";

		var expected = new G54_ModuleDescription()
		{
			Quantity = 3,
			UnitOfMeasurementCode = "tW",
			UPCCaseCode = "vVSoLFmzhSF4",
			ProductServiceIDQualifier = "Ns",
			ProductServiceID = "n",
			FreeFormDescription = "B",
		};

		var actual = Map.MapObject<G54_ModuleDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new G54_ModuleDescription();
		subject.UnitOfMeasurementCode = "tW";
		if (quantity > 0)
			subject.Quantity = quantity;
			subject.UPCCaseCode = "vVSoLFmzhSF4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ns";
			subject.ProductServiceID = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tW", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G54_ModuleDescription();
		subject.Quantity = 3;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
			subject.UPCCaseCode = "vVSoLFmzhSF4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ns";
			subject.ProductServiceID = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("vVSoLFmzhSF4", "Ns", true)]
	[InlineData("vVSoLFmzhSF4", "", true)]
	[InlineData("", "Ns", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G54_ModuleDescription();
		subject.Quantity = 3;
		subject.UnitOfMeasurementCode = "tW";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ns";
			subject.ProductServiceID = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ns", "n", true)]
	[InlineData("Ns", "", false)]
	[InlineData("", "n", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G54_ModuleDescription();
		subject.Quantity = 3;
		subject.UnitOfMeasurementCode = "tW";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "vVSoLFmzhSF4";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
