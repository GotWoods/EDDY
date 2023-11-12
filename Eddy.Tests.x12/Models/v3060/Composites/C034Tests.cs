using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060;
using Eddy.x12.Models.v3060.Composites;

namespace Eddy.x12.Tests.Models.v3060.Composites;

public class C034Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "YkF*pmU";

		var expected = new C034_ComputationMethods()
		{
			AssuranceAlgorithm = "YkF",
			HashingAlgorithm = "pmU",
		};

		var actual = Map.MapObject<C034_ComputationMethods>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YkF", true)]
	public void Validation_RequiredAssuranceAlgorithm(string assuranceAlgorithm, bool isValidExpected)
	{
		var subject = new C034_ComputationMethods();
		//Required fields
		subject.HashingAlgorithm = "pmU";
		//Test Parameters
		subject.AssuranceAlgorithm = assuranceAlgorithm;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pmU", true)]
	public void Validation_RequiredHashingAlgorithm(string hashingAlgorithm, bool isValidExpected)
	{
		var subject = new C034_ComputationMethods();
		//Required fields
		subject.AssuranceAlgorithm = "YkF";
		//Test Parameters
		subject.HashingAlgorithm = hashingAlgorithm;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
