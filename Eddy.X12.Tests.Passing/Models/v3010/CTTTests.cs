using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class CTTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CTT*2*2*8*bv*1*un*v";

		var expected = new CTT_TransactionTotals()
		{
			NumberOfLineItems = 2,
			HashTotal = 2,
			Weight = 8,
			UnitOfMeasurementCode = "bv",
			Volume = 1,
			UnitOfMeasurementCode2 = "un",
			Description = "v",
		};

		var actual = Map.MapObject<CTT_TransactionTotals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredNumberOfLineItems(int numberOfLineItems, bool isValidExpected)
	{
		var subject = new CTT_TransactionTotals();
		if (numberOfLineItems > 0)
			subject.NumberOfLineItems = numberOfLineItems;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
