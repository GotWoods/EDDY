using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PDDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PDD*k*7*5*4*z";

		var expected = new PDD_PricingDataDetail()
		{
			AssignedIdentification = "k",
			Quantity = 7,
			MonetaryAmount = 5,
			Percent = 4,
			ProposalDataDetailIdentifierCode = "z",
		};

		var actual = Map.MapObject<PDD_PricingDataDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new PDD_PricingDataDetail();
		//Required fields
		//Test Parameters
		subject.AssignedIdentification = assignedIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
