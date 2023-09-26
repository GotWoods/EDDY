using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class PDDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PDD*v*3*3*1*k";

		var expected = new PDD_ProposalDataDetail()
		{
			AssignedIdentification = "v",
			Quantity = 3,
			MonetaryAmount = 3,
			Percent = 1,
			ProposalDataDetailIdentifierCode = "k",
		};

		var actual = Map.MapObject<PDD_ProposalDataDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new PDD_ProposalDataDetail();
		//Required fields
		//Test Parameters
		subject.AssignedIdentification = assignedIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
