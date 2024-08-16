using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C402Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "M:n:6:h:Y";

		var expected = new C402_PackageTypeIdentification()
		{
			ItemDescriptionTypeCoded = "M",
			TypeOfPackages = "n",
			ItemNumberTypeCoded = "6",
			TypeOfPackages2 = "h",
			ItemNumberTypeCoded2 = "Y",
		};

		var actual = Map.MapComposite<C402_PackageTypeIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredItemDescriptionTypeCoded(string itemDescriptionTypeCoded, bool isValidExpected)
	{
		var subject = new C402_PackageTypeIdentification();
		//Required fields
		subject.TypeOfPackages = "n";
		//Test Parameters
		subject.ItemDescriptionTypeCoded = itemDescriptionTypeCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredTypeOfPackages(string typeOfPackages, bool isValidExpected)
	{
		var subject = new C402_PackageTypeIdentification();
		//Required fields
		subject.ItemDescriptionTypeCoded = "M";
		//Test Parameters
		subject.TypeOfPackages = typeOfPackages;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
