using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G10*2*7*tu*1*mT";

		var expected = new G10_TotalOrderInformation()
		{
			QuantityReceived = 2,
			NumberOfUnitsShipped = 7,
			UnitOfMeasurementCode = "tu",
			LadingQuantityReceived = 1,
			UnitOfMeasurementCode2 = "mT",
		};

		var actual = Map.MapObject<G10_TotalOrderInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantityReceived(decimal quantityReceived, bool isValidExpected)
	{
		var subject = new G10_TotalOrderInformation();
		subject.UnitOfMeasurementCode = "tu";
		if (quantityReceived > 0)
			subject.QuantityReceived = quantityReceived;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tu", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G10_TotalOrderInformation();
		subject.QuantityReceived = 2;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
