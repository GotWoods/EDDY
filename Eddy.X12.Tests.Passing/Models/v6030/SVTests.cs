using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class SVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV*Bj*T*M*g";

		var expected = new SV_ServiceDescription()
		{
			UnitOfTimePeriodOrIntervalCode = "Bj",
			ServiceStandard = "T",
			ServiceStandard2 = "M",
			TypeOfServiceOfferedCode = "g",
		};

		var actual = Map.MapObject<SV_ServiceDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "Bj", true)]
	[InlineData("T", "", false)]
	[InlineData("", "Bj", true)]
	public void Validation_ARequiresBServiceStandard(string serviceStandard, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new SV_ServiceDescription();
		subject.ServiceStandard = serviceStandard;
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M", "Bj", true)]
	[InlineData("M", "", false)]
	[InlineData("", "Bj", true)]
	public void Validation_ARequiresBServiceStandard2(string serviceStandard2, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new SV_ServiceDescription();
		subject.ServiceStandard2 = serviceStandard2;
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
