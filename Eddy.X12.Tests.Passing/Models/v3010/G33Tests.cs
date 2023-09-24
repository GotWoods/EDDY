using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G33Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G33*S";

		var expected = new G33_TotalDollarsSummary()
		{
			TotalInvoiceAmount = "S",
		};

		var actual = Map.MapObject<G33_TotalDollarsSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredTotalInvoiceAmount(string totalInvoiceAmount, bool isValidExpected)
	{
		var subject = new G33_TotalDollarsSummary();
		subject.TotalInvoiceAmount = totalInvoiceAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
