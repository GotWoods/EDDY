using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PAITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAI*OVUaOn*3*9z*v*m";

		var expected = new PAI_PrintAdvertisementInformation()
		{
			Date = "OVUaOn",
			MeasurementValue = 3,
			UnitOrBasisForMeasurementCode = "9z",
			Amount = "v",
			Amount2 = "m",
		};

		var actual = Map.MapObject<PAI_PrintAdvertisementInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "9z", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "9z", false)]
	public void Validation_AllAreRequiredMeasurementValue(decimal measurementValue, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PAI_PrintAdvertisementInformation();
		if (measurementValue > 0)
			subject.MeasurementValue = measurementValue;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
