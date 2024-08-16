using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class TPLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TPL+";

		var expected = new TPL_TransportPlacement()
		{
			TransportIdentification = null,
		};

		var actual = Map.MapObject<TPL_TransportPlacement>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredTransportIdentification(string transportIdentification, bool isValidExpected)
	{
		var subject = new TPL_TransportPlacement();
		//Required fields
		//Test Parameters
		if (transportIdentification != "") 
			subject.TransportIdentification = new C222_TransportIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
