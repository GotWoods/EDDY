using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class VLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "VLI+++n+f+a+z++c";

		var expected = new VLI_ValueListIdentification()
		{
			ValueListIdentification = null,
			PartyIdentificationDetails = null,
			StatusDescriptionCode = "n",
			ValueListName = "f",
			ClassDesignatorCoded = "a",
			ValueListTypeCoded = "z",
			ProductCharacteristic = null,
			MaintenanceOperationCoded = "c",
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
