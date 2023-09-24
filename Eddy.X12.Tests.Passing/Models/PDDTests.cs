using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PDDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PDD*N*5*1*4*x";

		var expected = new PDD_PricingDataDetail()
		{
			AssignedIdentification = "N",
			Quantity = 5,
			MonetaryAmount = 1,
			PercentageAsDecimal = 4,
			ProposalDataDetailIdentifierCode = "x",
		};

		var actual = Map.MapObject<PDD_PricingDataDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new PDD_PricingDataDetail();
		subject.AssignedIdentification = assignedIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
