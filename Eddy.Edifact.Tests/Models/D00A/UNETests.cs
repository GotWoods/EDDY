using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class UNETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UNE+a+W";

		var expected = new UNE_GroupTrailer()
		{
			GroupControlCount = "a",
			GroupReferenceNumber = "W",
		};

		var actual = Map.MapObject<UNE_GroupTrailer>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredGroupControlCount(string groupControlCount, bool isValidExpected)
	{
		var subject = new UNE_GroupTrailer();
		//Required fields
		subject.GroupReferenceNumber = "W";
		//Test Parameters
		subject.GroupControlCount = groupControlCount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredGroupReferenceNumber(string groupReferenceNumber, bool isValidExpected)
	{
		var subject = new UNE_GroupTrailer();
		//Required fields
		subject.GroupControlCount = "a";
		//Test Parameters
		subject.GroupReferenceNumber = groupReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
