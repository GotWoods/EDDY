using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class COBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "COB*D*e*H*G";

		var expected = new COB_CoordinationOfBenefits()
		{
			PayerResponsibilitySequenceNumberCode = "D",
			ReferenceIdentification = "e",
			CoordinationOfBenefitsCode = "H",
			ServiceTypeCode = "G",
		};

		var actual = Map.MapObject<COB_CoordinationOfBenefits>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
