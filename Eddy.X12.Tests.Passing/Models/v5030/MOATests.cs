using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class MOATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MOA*4*3*9*Z*4*q*x*4*2";

		var expected = new MOA_MedicareOutpatientAdjudication()
		{
			PercentageAsDecimal = 4,
			MonetaryAmount = 3,
			ReferenceIdentification = "9",
			ReferenceIdentification2 = "Z",
			ReferenceIdentification3 = "4",
			ReferenceIdentification4 = "q",
			ReferenceIdentification5 = "x",
			MonetaryAmount2 = 4,
			MonetaryAmount3 = 2,
		};

		var actual = Map.MapObject<MOA_MedicareOutpatientAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
