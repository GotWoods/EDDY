using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class PODTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "POD*EOXwz0*qAdS*m";

		var expected = new POD_ProofOfDelivery()
		{
			Date = "EOXwz0",
			Time = "qAdS",
			Name = "m",
		};

		var actual = Map.MapObject<POD_ProofOfDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("EOXwz0", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new POD_ProofOfDelivery();
		subject.Name = "m";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new POD_ProofOfDelivery();
		subject.Date = "EOXwz0";
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
