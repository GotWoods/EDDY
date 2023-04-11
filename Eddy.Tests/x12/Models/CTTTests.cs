using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CTTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTT*3*8*1*NH*5*c3*W";

		var expected = new CTT_TransactionTotals()
		{
			NumberOfLineItems = 3,
			HashTotal = 8,
			Weight = 1,
			UnitOrBasisForMeasurementCode = "NH",
			Volume = 5,
			UnitOrBasisForMeasurementCode2 = "c3",
			Description = "W",
		};

		var actual = Map.MapObject<CTT_TransactionTotals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredNumberOfLineItems(int numberOfLineItems, bool isValidExpected)
	{
		var subject = new CTT_TransactionTotals();
		if (numberOfLineItems > 0)
		subject.NumberOfLineItems = numberOfLineItems;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(1, "NH", true)]
	[InlineData(0, "NH", false)]
	[InlineData(1, "", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new CTT_TransactionTotals();
		subject.NumberOfLineItems = 3;
		if (weight > 0)
		subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(5, "c3", true)]
	[InlineData(0, "c3", false)]
	[InlineData(5, "", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new CTT_TransactionTotals();
		subject.NumberOfLineItems = 3;
		if (volume > 0)
		subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
