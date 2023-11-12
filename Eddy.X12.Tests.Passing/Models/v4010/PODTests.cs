using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PODTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "POD*fapSrAxZ*LJ5j*h";

		var expected = new POD_ProofOfDelivery()
		{
			Date = "fapSrAxZ",
			Time = "LJ5j",
			Name = "h",
		};

		var actual = Map.MapObject<POD_ProofOfDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fapSrAxZ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new POD_ProofOfDelivery();
		subject.Name = "h";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new POD_ProofOfDelivery();
		subject.Date = "fapSrAxZ";
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
