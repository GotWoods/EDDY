using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class MOATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MOA*5*5*J*0*z*D*K*6*4";

		var expected = new MOA_MedicareOutpatientAdjudication()
		{
			Percent = 5,
			MonetaryAmount = 5,
			ReferenceNumber = "J",
			ReferenceNumber2 = "0",
			ReferenceNumber3 = "z",
			ReferenceNumber4 = "D",
			ReferenceNumber5 = "K",
			MonetaryAmount2 = 6,
			MonetaryAmount3 = 4,
		};

		var actual = Map.MapObject<MOA_MedicareOutpatientAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
