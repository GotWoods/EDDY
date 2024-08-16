using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class DIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DII+q+X+f+l+d+A";

		var expected = new DII_DirectoryIdentification()
		{
			Version = "q",
			Release = "X",
			DirectoryStatus = "f",
			ControlAgency = "l",
			LanguageNameCode = "d",
			MaintenanceOperationCoded = "A",
		};

		var actual = Map.MapObject<DII_DirectoryIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredVersion(string version, bool isValidExpected)
	{
		var subject = new DII_DirectoryIdentification();
		//Required fields
		subject.Release = "X";
		//Test Parameters
		subject.Version = version;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredRelease(string release, bool isValidExpected)
	{
		var subject = new DII_DirectoryIdentification();
		//Required fields
		subject.Version = "q";
		//Test Parameters
		subject.Release = release;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
