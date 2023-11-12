using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class PODTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "POD*woY2Vz*h9BE*O";

		var expected = new POD_ProofOfDelivery()
		{
			Date = "woY2Vz",
			Time = "h9BE",
			Name = "O",
		};

		var actual = Map.MapObject<POD_ProofOfDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("woY2Vz", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new POD_ProofOfDelivery();
		subject.Name = "O";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new POD_ProofOfDelivery();
		subject.Date = "woY2Vz";
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
