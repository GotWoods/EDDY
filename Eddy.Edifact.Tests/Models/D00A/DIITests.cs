using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class DIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DII+N+x+U+y+j+X";

		var expected = new DII_DirectoryIdentification()
		{
			VersionIdentifier = "N",
			ReleaseIdentifier = "x",
			DirectoryStatusIdentifier = "U",
			ControllingAgencyIdentifier = "y",
			LanguageNameCode = "j",
			MaintenanceOperationCode = "X",
		};

		var actual = Map.MapObject<DII_DirectoryIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredVersionIdentifier(string versionIdentifier, bool isValidExpected)
	{
		var subject = new DII_DirectoryIdentification();
		//Required fields
		subject.ReleaseIdentifier = "x";
		//Test Parameters
		subject.VersionIdentifier = versionIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredReleaseIdentifier(string releaseIdentifier, bool isValidExpected)
	{
		var subject = new DII_DirectoryIdentification();
		//Required fields
		subject.VersionIdentifier = "N";
		//Test Parameters
		subject.ReleaseIdentifier = releaseIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
