using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class CNTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CNT+";

		var expected = new CNT_ControlTotal()
		{
			Control = null,
		};

		var actual = Map.MapObject<CNT_ControlTotal>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredControl(string control, bool isValidExpected)
	{
		var subject = new CNT_ControlTotal();
		//Required fields
		//Test Parameters
		if (control != "") 
			subject.Control = new C270_Control();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
