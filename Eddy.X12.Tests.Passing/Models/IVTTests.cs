using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IVTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IVT*lG*QI";

		var expected = new IVT_InventoryParameters()
		{
			QuantityQualifier = "lG",
			DemandEstimationTypeCode = "QI",
		};

		var actual = Map.MapObject<IVT_InventoryParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lG", true)]
	public void Validation_RequiredQuantityQualifier(string quantityQualifier, bool isValidExpected)
	{
		var subject = new IVT_InventoryParameters();
		subject.DemandEstimationTypeCode = "QI";
		subject.QuantityQualifier = quantityQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QI", true)]
	public void Validation_RequiredDemandEstimationTypeCode(string demandEstimationTypeCode, bool isValidExpected)
	{
		var subject = new IVT_InventoryParameters();
		subject.QuantityQualifier = "lG";
		subject.DemandEstimationTypeCode = demandEstimationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
