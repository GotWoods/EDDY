using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class G3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G3*87*176*t*x*8*X";

		var expected = new G3_CompensationInformation()
		{
			CompensationPaid = 87,
			TotalCompensationAmount = 176,
			Name = "t",
			BusinessTransactionStatus = "x",
			MonetaryAmount = 8,
			CompensationQualifier = "X",
		};

		var actual = Map.MapObject<G3_CompensationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(176, true)]
	public void Validation_RequiredTotalCompensationAmount(int totalCompensationAmount, bool isValidExpected)
	{
		var subject = new G3_CompensationInformation();
		if (totalCompensationAmount > 0)
			subject.TotalCompensationAmount = totalCompensationAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
