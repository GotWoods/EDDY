using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class RRETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RRE*Ms*j";

		var expected = new RRE_ContractRelatedErrorReporting()
		{
			RejectReasonCode = "Ms",
			Description = "j",
		};

		var actual = Map.MapObject<RRE_ContractRelatedErrorReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Ms", "j", true)]
	[InlineData("Ms", "", true)]
	[InlineData("", "j", true)]
	public void Validation_AtLeastOneRejectReasonCode(string rejectReasonCode, string description, bool isValidExpected)
	{
		var subject = new RRE_ContractRelatedErrorReporting();
		//Required fields
		//Test Parameters
		subject.RejectReasonCode = rejectReasonCode;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
