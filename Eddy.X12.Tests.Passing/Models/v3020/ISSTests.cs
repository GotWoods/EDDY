using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class ISSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISS*2*RC*5*QY*8*KS";

		var expected = new ISS_InvoiceShipmentSummary()
		{
			NumberOfUnitsShipped = 2,
			UnitOfMeasurementCode = "RC",
			Weight = 5,
			UnitOfMeasurementCode2 = "QY",
			Volume = 8,
			UnitOfMeasurementCode3 = "KS",
		};

		var actual = Map.MapObject<ISS_InvoiceShipmentSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "RC", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "RC", true)]
	public void Validation_ARequiresBNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new ISS_InvoiceShipmentSummary();
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "QY", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "QY", true)]
	public void Validation_ARequiresBWeight(decimal weight, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new ISS_InvoiceShipmentSummary();
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "KS", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "KS", true)]
	public void Validation_ARequiresBVolume(decimal volume, string unitOfMeasurementCode3, bool isValidExpected)
	{
		var subject = new ISS_InvoiceShipmentSummary();
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOfMeasurementCode3 = unitOfMeasurementCode3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
