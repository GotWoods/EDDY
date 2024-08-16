using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class UNPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UNP+4+c";

		var expected = new UNP_ObjectTrailer()
		{
			LengthOfObjectInOctetsOfBits = "4",
			PackageReferenceNumber = "c",
		};

		var actual = Map.MapObject<UNP_ObjectTrailer>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredLengthOfObjectInOctetsOfBits(string lengthOfObjectInOctetsOfBits, bool isValidExpected)
	{
		var subject = new UNP_ObjectTrailer();
		//Required fields
		subject.PackageReferenceNumber = "c";
		//Test Parameters
		subject.LengthOfObjectInOctetsOfBits = lengthOfObjectInOctetsOfBits;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredPackageReferenceNumber(string packageReferenceNumber, bool isValidExpected)
	{
		var subject = new UNP_ObjectTrailer();
		//Required fields
		subject.LengthOfObjectInOctetsOfBits = "4";
		//Test Parameters
		subject.PackageReferenceNumber = packageReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
