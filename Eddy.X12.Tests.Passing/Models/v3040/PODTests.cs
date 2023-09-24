using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class PODTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "POD*HeRm6v*EcrA*M";

		var expected = new POD_ProofOfDelivery()
		{
			Date = "HeRm6v",
			Time = "EcrA",
			Name = "M",
		};

		var actual = Map.MapObject<POD_ProofOfDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HeRm6v", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new POD_ProofOfDelivery();
		subject.Name = "M";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new POD_ProofOfDelivery();
		subject.Date = "HeRm6v";
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
