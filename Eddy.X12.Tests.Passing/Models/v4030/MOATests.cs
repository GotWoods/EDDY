using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class MOATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MOA*6*8*c*q*x*F*1*4*6";

		var expected = new MOA_MedicareOutpatientAdjudication()
		{
			Percent = 6,
			MonetaryAmount = 8,
			ReferenceIdentification = "c",
			ReferenceIdentification2 = "q",
			ReferenceIdentification3 = "x",
			ReferenceIdentification4 = "F",
			ReferenceIdentification5 = "1",
			MonetaryAmount2 = 4,
			MonetaryAmount3 = 6,
		};

		var actual = Map.MapObject<MOA_MedicareOutpatientAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
