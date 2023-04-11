using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MOATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MOA*8*6*T*1*C*B*r*4*9";

		var expected = new MOA_OutpatientAdjudication()
		{
			PercentageAsDecimal = 8,
			MonetaryAmount = 6,
			ReferenceIdentification = "T",
			ReferenceIdentification2 = "1",
			ReferenceIdentification3 = "C",
			ReferenceIdentification4 = "B",
			ReferenceIdentification5 = "r",
			MonetaryAmount2 = 4,
			MonetaryAmount3 = 9,
		};

		var actual = Map.MapObject<MOA_OutpatientAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
