using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class VLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "VLI+++F+y+i+V++8";

		var expected = new VLI_ValueListIdentification()
		{
			ValueListIdentification = null,
			PartyIdentificationDetails = null,
			StatusCoded = "F",
			ValueListName = "y",
			ClassDesignatorCoded = "i",
			ValueListTypeCoded = "V",
			ProductCharacteristic = null,
			MaintenanceOperationCoded = "8",
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
