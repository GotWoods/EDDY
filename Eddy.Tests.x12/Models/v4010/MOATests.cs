using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class MOATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MOA*1*6*8*J*w*O*f*9*2";

		var expected = new MOA_MedicareOutpatientAdjudication()
		{
			Percent = 1,
			MonetaryAmount = 6,
			ReferenceIdentification = "8",
			ReferenceIdentification2 = "J",
			ReferenceIdentification3 = "w",
			ReferenceIdentification4 = "O",
			ReferenceIdentification5 = "f",
			MonetaryAmount2 = 9,
			MonetaryAmount3 = 2,
		};

		var actual = Map.MapObject<MOA_MedicareOutpatientAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
