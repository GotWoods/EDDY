using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV*wh*z*2*C";

		var expected = new SV_ServiceDescription()
		{
			UnitOfTimePeriodOrInterval = "wh",
			ServiceStandard = "z",
			ServiceStandard2 = "2",
			TypeOfServiceOfferedCode = "C",
		};

		var actual = Map.MapObject<SV_ServiceDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "wh", true)]
	[InlineData("z", "", false)]
	[InlineData("", "wh", true)]
	public void Validation_ARequiresBServiceStandard(string serviceStandard, string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new SV_ServiceDescription();
		subject.ServiceStandard = serviceStandard;
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2", "wh", true)]
	[InlineData("2", "", false)]
	[InlineData("", "wh", true)]
	public void Validation_ARequiresBServiceStandard2(string serviceStandard2, string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new SV_ServiceDescription();
		subject.ServiceStandard2 = serviceStandard2;
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
