using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class IVTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IVT*tI*ul";

		var expected = new IVT_InventoryParameters()
		{
			QuantityQualifier = "tI",
			DemandEstimationTypeCode = "ul",
		};

		var actual = Map.MapObject<IVT_InventoryParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tI", true)]
	public void Validation_RequiredQuantityQualifier(string quantityQualifier, bool isValidExpected)
	{
		var subject = new IVT_InventoryParameters();
		//Required fields
		subject.DemandEstimationTypeCode = "ul";
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ul", true)]
	public void Validation_RequiredDemandEstimationTypeCode(string demandEstimationTypeCode, bool isValidExpected)
	{
		var subject = new IVT_InventoryParameters();
		//Required fields
		subject.QuantityQualifier = "tI";
		//Test Parameters
		subject.DemandEstimationTypeCode = demandEstimationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
