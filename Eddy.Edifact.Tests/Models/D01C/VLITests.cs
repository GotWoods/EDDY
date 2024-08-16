using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class VLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "VLI+++F+3+m+4++H";

		var expected = new VLI_ValueListIdentification()
		{
			ValueListIdentification = null,
			PartyIdentificationDetails = null,
			StatusDescriptionCode = "F",
			ValueListName = "3",
			DesignatedClassCode = "m",
			ValueListTypeCode = "4",
			CharacteristicDescription = null,
			MaintenanceOperationCode = "H",
		};

		var actual = Map.MapObject<VLI_ValueListIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredValueListIdentification(string valueListIdentification, bool isValidExpected)
	{
		var subject = new VLI_ValueListIdentification();
		//Required fields
		//Test Parameters
		if (valueListIdentification != "") 
			subject.ValueListIdentification = new C780_ValueListIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
