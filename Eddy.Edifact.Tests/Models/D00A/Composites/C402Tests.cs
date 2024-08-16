using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C402Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "u:n:c:d:I";

		var expected = new C402_PackageTypeIdentification()
		{
			DescriptionFormatCode = "u",
			TypeOfPackages = "n",
			ItemTypeIdentificationCode = "c",
			TypeOfPackages2 = "d",
			ItemTypeIdentificationCode2 = "I",
		};

		var actual = Map.MapComposite<C402_PackageTypeIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredDescriptionFormatCode(string descriptionFormatCode, bool isValidExpected)
	{
		var subject = new C402_PackageTypeIdentification();
		//Required fields
		subject.TypeOfPackages = "n";
		//Test Parameters
		subject.DescriptionFormatCode = descriptionFormatCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredTypeOfPackages(string typeOfPackages, bool isValidExpected)
	{
		var subject = new C402_PackageTypeIdentification();
		//Required fields
		subject.DescriptionFormatCode = "u";
		//Test Parameters
		subject.TypeOfPackages = typeOfPackages;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
