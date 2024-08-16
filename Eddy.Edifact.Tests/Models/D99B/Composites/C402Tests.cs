using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C402Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "v:5:f:K:G";

		var expected = new C402_PackageTypeIdentification()
		{
			ItemDescriptionTypeCoded = "v",
			TypeOfPackages = "5",
			ItemTypeIdentificationCode = "f",
			TypeOfPackages2 = "K",
			ItemTypeIdentificationCode2 = "G",
		};

		var actual = Map.MapComposite<C402_PackageTypeIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredItemDescriptionTypeCoded(string itemDescriptionTypeCoded, bool isValidExpected)
	{
		var subject = new C402_PackageTypeIdentification();
		//Required fields
		subject.TypeOfPackages = "5";
		//Test Parameters
		subject.ItemDescriptionTypeCoded = itemDescriptionTypeCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredTypeOfPackages(string typeOfPackages, bool isValidExpected)
	{
		var subject = new C402_PackageTypeIdentification();
		//Required fields
		subject.ItemDescriptionTypeCoded = "v";
		//Test Parameters
		subject.TypeOfPackages = typeOfPackages;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
