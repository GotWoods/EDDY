using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6030;
using Eddy.x12.Models.v6030.Composites;

namespace Eddy.x12.Tests.Models.v6030.Composites;

public class C034Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "ODF*w2W";

		var expected = new C034_ComputationMethods()
		{
			AssuranceAlgorithmCode = "ODF",
			HashingAlgorithmCode = "w2W",
		};

		var actual = Map.MapObject<C034_ComputationMethods>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ODF", true)]
	public void Validation_RequiredAssuranceAlgorithmCode(string assuranceAlgorithmCode, bool isValidExpected)
	{
		var subject = new C034_ComputationMethods();
		//Required fields
		subject.HashingAlgorithmCode = "w2W";
		//Test Parameters
		subject.AssuranceAlgorithmCode = assuranceAlgorithmCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w2W", true)]
	public void Validation_RequiredHashingAlgorithmCode(string hashingAlgorithmCode, bool isValidExpected)
	{
		var subject = new C034_ComputationMethods();
		//Required fields
		subject.AssuranceAlgorithmCode = "ODF";
		//Test Parameters
		subject.HashingAlgorithmCode = hashingAlgorithmCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
