using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class DIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DII+r+B+C+3+S+O";

		var expected = new DII_DirectoryIdentification()
		{
			Version = "r",
			Release = "B",
			DirectoryStatus = "C",
			ControlAgency = "3",
			LanguageCoded = "S",
			MaintenanceOperationCoded = "O",
		};

		var actual = Map.MapObject<DII_DirectoryIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredVersion(string version, bool isValidExpected)
	{
		var subject = new DII_DirectoryIdentification();
		//Required fields
		subject.Release = "B";
		//Test Parameters
		subject.Version = version;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredRelease(string release, bool isValidExpected)
	{
		var subject = new DII_DirectoryIdentification();
		//Required fields
		subject.Version = "r";
		//Test Parameters
		subject.Release = release;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
