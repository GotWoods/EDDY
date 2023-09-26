using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SV7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV7*3*O*0C";

		var expected = new SV7_DrugAdjudication()
		{
			ReferenceNumber = "3",
			ReferenceNumber2 = "O",
			PrescriptionDenialOverrideCode = "0C",
		};

		var actual = Map.MapObject<SV7_DrugAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
