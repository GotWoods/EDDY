using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PAITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAI*nBEA30JW*9*xM*M*c";

		var expected = new PAI_PrintAdvertisementInformation()
		{
			Date = "nBEA30JW",
			MeasurementValue = 9,
			UnitOrBasisForMeasurementCode = "xM",
			Amount = "M",
			Amount2 = "c",
		};

		var actual = Map.MapObject<PAI_PrintAdvertisementInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(9, "xM", true)]
	[InlineData(0, "xM", false)]
	[InlineData(9, "", false)]
	public void Validation_AllAreRequiredMeasurementValue(decimal measurementValue, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PAI_PrintAdvertisementInformation();
		if (measurementValue > 0)
		subject.MeasurementValue = measurementValue;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
