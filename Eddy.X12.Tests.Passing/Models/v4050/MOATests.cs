using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class MOATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MOA*5*7*E*l*x*w*I*6*5";

		var expected = new MOA_MedicareOutpatientAdjudication()
		{
			PercentageAsDecimal = 5,
			MonetaryAmount = 7,
			ReferenceIdentification = "E",
			ReferenceIdentification2 = "l",
			ReferenceIdentification3 = "x",
			ReferenceIdentification4 = "w",
			ReferenceIdentification5 = "I",
			MonetaryAmount2 = 6,
			MonetaryAmount3 = 5,
		};

		var actual = Map.MapObject<MOA_MedicareOutpatientAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
