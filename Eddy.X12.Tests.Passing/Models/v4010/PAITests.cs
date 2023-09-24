using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PAITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAI*Ip4f6BPb*8*8s*o*F";

		var expected = new PAI_PrintAdvertisementInformation()
		{
			Date = "Ip4f6BPb",
			MeasurementValue = 8,
			UnitOrBasisForMeasurementCode = "8s",
			Amount = "o",
			Amount2 = "F",
		};

		var actual = Map.MapObject<PAI_PrintAdvertisementInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "8s", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "8s", false)]
	public void Validation_AllAreRequiredMeasurementValue(decimal measurementValue, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PAI_PrintAdvertisementInformation();
		if (measurementValue > 0)
			subject.MeasurementValue = measurementValue;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
