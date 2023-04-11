using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RRETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RRE*ki*M";

		var expected = new RRE_ContractRelatedErrorReporting()
		{
			RejectReasonCode = "ki",
			Description = "M",
		};

		var actual = Map.MapObject<RRE_ContractRelatedErrorReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("ki","M", true)]
	[InlineData("", "M", true)]
	[InlineData("ki", "", true)]
	public void Validation_AtLeastOneRejectReasonCode(string rejectReasonCode, string description, bool isValidExpected)
	{
		var subject = new RRE_ContractRelatedErrorReporting();
		subject.RejectReasonCode = rejectReasonCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
