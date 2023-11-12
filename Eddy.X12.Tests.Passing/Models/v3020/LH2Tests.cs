using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class LH2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH2*w1*n*1zW2jxccDTF1hu*x54p*O5*tX*6";

		var expected = new LH2_HazardousClassificationInformation()
		{
			HazardousClassification = "w1",
			HazardousClassQualifier = "n",
			HazardousPlacardNotation = "1zW2jxccDTF1hu",
			HazardousEndorsement = "x54p",
			ReportableQuantityCode = "O5",
			UnitOfMeasurementCode = "tX",
			Temperature = 6,
		};

		var actual = Map.MapObject<LH2_HazardousClassificationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w1", true)]
	public void Validation_RequiredHazardousClassification(string hazardousClassification, bool isValidExpected)
	{
		var subject = new LH2_HazardousClassificationInformation();
		subject.HazardousClassification = hazardousClassification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || subject.Temperature > 0)
		{
			subject.UnitOfMeasurementCode = "tX";
			subject.Temperature = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("tX", 6, true)]
	[InlineData("tX", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredUnitOfMeasurementCode(string unitOfMeasurementCode, int temperature, bool isValidExpected)
	{
		var subject = new LH2_HazardousClassificationInformation();
		subject.HazardousClassification = "w1";
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		if (temperature > 0)
			subject.Temperature = temperature;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
