using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class PDHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PDH*1V**cCzI**i**Cc*M*";

		var expected = new PDH_PharmaceuticalDrugInformation()
		{
			RouteOfAdministrationForPharmaceuticalDrugs = "1V",
			CompositeIngredientInformation = null,
			DosageFormForPharmaceuticalDrugs = "cCzI",
			CompositeIngredientInformation2 = null,
			BiomedicalHazard = "i",
			CompositeIngredientInformation3 = null,
			TradeItemDrugBrandingType = "Cc",
			ShapeCode = "M",
			CompositeIngredientInformation4 = null,
		};

		var actual = Map.MapObject<PDH_PharmaceuticalDrugInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1V", "A", false)]
	[InlineData("1V", "", true)]
	[InlineData("", "A", true)]
	public void Validation_OnlyOneOfRouteOfAdministrationForPharmaceuticalDrugs(string routeOfAdministrationForPharmaceuticalDrugs, string compositeIngredientInformation, bool isValidExpected)
	{
		var subject = new PDH_PharmaceuticalDrugInformation();
		//Required fields
		//Test Parameters
		subject.RouteOfAdministrationForPharmaceuticalDrugs = routeOfAdministrationForPharmaceuticalDrugs;
		if (compositeIngredientInformation != "") 
			subject.CompositeIngredientInformation = new C068_CompositeIngredientInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("cCzI", "A", false)]
	[InlineData("cCzI", "", true)]
	[InlineData("", "A", true)]
	public void Validation_OnlyOneOfDosageFormForPharmaceuticalDrugs(string dosageFormForPharmaceuticalDrugs, string compositeIngredientInformation2, bool isValidExpected)
	{
		var subject = new PDH_PharmaceuticalDrugInformation();
		//Required fields
		//Test Parameters
		subject.DosageFormForPharmaceuticalDrugs = dosageFormForPharmaceuticalDrugs;
		if (compositeIngredientInformation2 != "") 
			subject.CompositeIngredientInformation2 = new C068_CompositeIngredientInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "A", false)]
	[InlineData("i", "", true)]
	[InlineData("", "A", true)]
	public void Validation_OnlyOneOfBiomedicalHazard(string biomedicalHazard, string compositeIngredientInformation3, bool isValidExpected)
	{
		var subject = new PDH_PharmaceuticalDrugInformation();
		//Required fields
		//Test Parameters
		subject.BiomedicalHazard = biomedicalHazard;
		if (compositeIngredientInformation3 != "") 
			subject.CompositeIngredientInformation3 = new C068_CompositeIngredientInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M", "A", false)]
	[InlineData("M", "", true)]
	[InlineData("", "A", true)]
	public void Validation_OnlyOneOfShapeCode(string shapeCode, string compositeIngredientInformation4, bool isValidExpected)
	{
		var subject = new PDH_PharmaceuticalDrugInformation();
		//Required fields
		//Test Parameters
		subject.ShapeCode = shapeCode;
		if (compositeIngredientInformation4 != "") 
			subject.CompositeIngredientInformation4 = new C068_CompositeIngredientInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
