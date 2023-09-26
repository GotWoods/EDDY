using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class COBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "COB*Q*w*n";

		var expected = new COB_CoordinationOfBenefits()
		{
			PayerResponsibilitySequenceNumberCode = "Q",
			ReferenceNumber = "w",
			CoordinationOfBenefitsCode = "n",
		};

		var actual = Map.MapObject<COB_CoordinationOfBenefits>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
