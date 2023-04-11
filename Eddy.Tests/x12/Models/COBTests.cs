using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class COBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "COB*J*7*w*q";

		var expected = new COB_CoordinationOfBenefits()
		{
			PayerResponsibilitySequenceNumberCode = "J",
			ReferenceIdentification = "7",
			CoordinationOfBenefitsCode = "w",
			ServiceTypeCode = "q",
		};

		var actual = Map.MapObject<COB_CoordinationOfBenefits>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
