using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class PAITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAI*Fziwed*6*wz*h*B";

		var expected = new PAI_PrintAdvertisementInformation()
		{
			Date = "Fziwed",
			MeasurementValue = 6,
			UnitOrBasisForMeasurementCode = "wz",
			Amount = "h",
			Amount2 = "B",
		};

		var actual = Map.MapObject<PAI_PrintAdvertisementInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "wz", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "wz", false)]
	public void Validation_AllAreRequiredMeasurementValue(decimal measurementValue, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PAI_PrintAdvertisementInformation();
		if (measurementValue > 0)
			subject.MeasurementValue = measurementValue;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
