using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class PDDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PDD*m*4*3*2*T";

		var expected = new PDD_PricingDataDetail()
		{
			AssignedIdentification = "m",
			Quantity = 4,
			MonetaryAmount = 3,
			PercentageAsDecimal = 2,
			ProposalDataDetailIdentifierCode = "T",
		};

		var actual = Map.MapObject<PDD_PricingDataDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new PDD_PricingDataDetail();
		//Required fields
		//Test Parameters
		subject.AssignedIdentification = assignedIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
