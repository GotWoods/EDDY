using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CTTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTT*6*1*2*LP*8*xE*L";

		var expected = new CTT_TransactionTotals()
		{
			NumberOfLineItems = 6,
			HashTotal = 1,
			Weight = 2,
			UnitOrBasisForMeasurementCode = "LP",
			Volume = 8,
			UnitOrBasisForMeasurementCode2 = "xE",
			Description = "L",
		};

		var actual = Map.MapObject<CTT_TransactionTotals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredNumberOfLineItems(int numberOfLineItems, bool isValidExpected)
	{
		var subject = new CTT_TransactionTotals();
		if (numberOfLineItems > 0)
			subject.NumberOfLineItems = numberOfLineItems;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "LP", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "LP", true)]
	public void Validation_ARequiresBWeight(decimal weight, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new CTT_TransactionTotals();
		subject.NumberOfLineItems = 6;
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "xE", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "xE", true)]
	public void Validation_ARequiresBVolume(decimal volume, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new CTT_TransactionTotals();
		subject.NumberOfLineItems = 6;
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
