using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class MOATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MOA*5*7*G*N*9*2*a*6*3";

		var expected = new MOA_MedicareOutpatientAdjudication()
		{
			Percent = 5,
			MonetaryAmount = 7,
			ReferenceIdentification = "G",
			ReferenceIdentification2 = "N",
			ReferenceIdentification3 = "9",
			ReferenceIdentification4 = "2",
			ReferenceIdentification5 = "a",
			MonetaryAmount2 = 6,
			MonetaryAmount3 = 3,
		};

		var actual = Map.MapObject<MOA_MedicareOutpatientAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
