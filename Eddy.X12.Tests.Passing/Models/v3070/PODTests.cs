using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PODTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "POD*umUVep*BCax*Y";

		var expected = new POD_ProofOfDelivery()
		{
			Date = "umUVep",
			Time = "BCax",
			Name = "Y",
		};

		var actual = Map.MapObject<POD_ProofOfDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("umUVep", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new POD_ProofOfDelivery();
		subject.Name = "Y";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new POD_ProofOfDelivery();
		subject.Date = "umUVep";
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
