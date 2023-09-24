using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SN1*M*8*s5*5*5*Mn*s*00";

		var expected = new SN1_ItemDetailShipment()
		{
			AssignedIdentification = "M",
			NumberOfUnitsShipped = 8,
			UnitOfMeasurementCode = "s5",
			QuantityShippedToDate = 5,
			QuantityOrdered = 5,
			UnitOfMeasurementCode2 = "Mn",
			ReturnableContainerLoadMakeUpCode = "s",
			LineItemStatusCode = "00",
		};

		var actual = Map.MapObject<SN1_ItemDetailShipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.UnitOfMeasurementCode = "s5";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s5", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "Mn", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "Mn", true)]
	public void Validation_ARequiresBQuantityOrdered(decimal quantityOrdered, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new SN1_ItemDetailShipment();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOfMeasurementCode = "s5";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
