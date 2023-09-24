using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G3*62*369*h*R*3*x";

		var expected = new G3_CompensationInformation()
		{
			CompensationPaid = 62,
			TotalCompensationAmount = 369,
			Name = "h",
			BusinessTransactionStatus = "R",
			MonetaryAmount = 3,
			CompensationQualifier = "x",
		};

		var actual = Map.MapObject<G3_CompensationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(369, true)]
	public void Validation_RequiredTotalCompensationAmount(int totalCompensationAmount, bool isValidExpected)
	{
		var subject = new G3_CompensationInformation();
		if (totalCompensationAmount > 0)
			subject.TotalCompensationAmount = totalCompensationAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
