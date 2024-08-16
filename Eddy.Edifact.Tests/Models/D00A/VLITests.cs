using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class VLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "VLI+++G+Q+e+s++R";

		var expected = new VLI_ValueListIdentification()
		{
			ValueListIdentification = null,
			PartyIdentificationDetails = null,
			StatusDescriptionCode = "G",
			ValueListName = "Q",
			DesignatedClassCode = "e",
			ValueListTypeCode = "s",
			ProductCharacteristic = null,
			MaintenanceOperationCode = "R",
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
