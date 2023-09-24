using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class LH1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH1*6y*7*Vtih8m*R*M*G6*8*f*h";

		var expected = new LH1_HazardousIdentificationInformation()
		{
			UnitOfMeasurementCode = "6y",
			LadingQuantity = 7,
			UNNAIdentificationCode = "Vtih8m",
			HazardousMaterialsPage = "R",
			CommodityCode = "M",
			UnitOfMeasurementCode2 = "G6",
			LadingQuantity2 = 8,
			CompartmentIDCode = "f",
			ResidueIndicatorCode = "h",
		};

		var actual = Map.MapObject<LH1_HazardousIdentificationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6y", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new LH1_HazardousIdentificationInformation();
		subject.LadingQuantity = 7;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredLadingQuantity(int ladingQuantity, bool isValidExpected)
	{
		var subject = new LH1_HazardousIdentificationInformation();
		subject.UnitOfMeasurementCode = "6y";
		if (ladingQuantity > 0)
			subject.LadingQuantity = ladingQuantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
