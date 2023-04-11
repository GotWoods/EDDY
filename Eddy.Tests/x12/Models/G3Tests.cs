using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G3*94*411*8*T*3*x";

		var expected = new G3_CompensationInformation()
		{
			CompensationPaid = 94,
			TotalCompensationAmount = 411,
			Name = "8",
			BusinessTransactionStatusCode = "T",
			MonetaryAmount = 3,
			CompensationQualifier = "x",
		};

		var actual = Map.MapObject<G3_CompensationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(411, true)]
	public void Validation_RequiredTotalCompensationAmount(int totalCompensationAmount, bool isValidExpected)
	{
		var subject = new G3_CompensationInformation();
		if (totalCompensationAmount > 0)
		subject.TotalCompensationAmount = totalCompensationAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
