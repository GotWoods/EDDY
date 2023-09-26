using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class COBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "COB*S*i*a";

		var expected = new COB_CoordinationOfBenefits()
		{
			PayerResponsibilitySequenceNumberCode = "S",
			ReferenceIdentification = "i",
			CoordinationOfBenefitsCode = "a",
		};

		var actual = Map.MapObject<COB_CoordinationOfBenefits>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
