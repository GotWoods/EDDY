using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class ASITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ASI+++Y+S";

		var expected = new ASI_ArrayStructureIdentification()
		{
			ArrayStructureIdentification = null,
			PartyIdentificationDetails = null,
			StatusDescriptionCode = "Y",
			MaintenanceOperationCoded = "S",
		};

		var actual = Map.MapObject<ASI_ArrayStructureIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredArrayStructureIdentification(string arrayStructureIdentification, bool isValidExpected)
	{
		var subject = new ASI_ArrayStructureIdentification();
		//Required fields
		//Test Parameters
		if (arrayStructureIdentification != "") 
			subject.ArrayStructureIdentification = new C779_ArrayStructureIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
