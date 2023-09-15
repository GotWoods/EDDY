using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CTTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTT*5*7*7*wR*7*3Q*E";

		var expected = new CTT_TransactionTotals()
		{
			NumberOfLineItems = 5,
			HashTotal = 7,
			Weight = 7,
			UnitOfMeasurementCode = "wR",
			Volume = 7,
			UnitOfMeasurementCode2 = "3Q",
			Description = "E",
		};

		var actual = Map.MapObject<CTT_TransactionTotals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredNumberOfLineItems(int numberOfLineItems, bool isValidExpected)
	{
		var subject = new CTT_TransactionTotals();
		if (numberOfLineItems > 0)
			subject.NumberOfLineItems = numberOfLineItems;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "wR", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "wR", true)]
	public void Validation_ARequiresBWeight(decimal weight, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new CTT_TransactionTotals();
		subject.NumberOfLineItems = 5;
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "3Q", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "3Q", true)]
	public void Validation_ARequiresBVolume(decimal volume, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new CTT_TransactionTotals();
		subject.NumberOfLineItems = 5;
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
