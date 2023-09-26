using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class COBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "COB*5*C*a*s";

		var expected = new COB_CoordinationOfBenefits()
		{
			PayerResponsibilitySequenceNumberCode = "5",
			ReferenceIdentification = "C",
			CoordinationOfBenefitsCode = "a",
			ServiceTypeCode = "s",
		};

		var actual = Map.MapObject<COB_CoordinationOfBenefits>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
