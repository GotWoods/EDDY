using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A;

public class NMETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "NME+";

		var expected = new NME_Name()
		{
			NameInformation = null,
		};

		var actual = Map.MapObject<NME_Name>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredNameInformation(string nameInformation, bool isValidExpected)
	{
		var subject = new NME_Name();
		//Required fields
		//Test Parameters
		if (nameInformation != "") 
			subject.NameInformation = new E012_NameInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
