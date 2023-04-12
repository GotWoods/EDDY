using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV*H5*o*c*N";

		var expected = new SV_ServiceDescription()
		{
			UnitOfTimePeriodOrIntervalCode = "H5",
			ServiceStandard = "o",
			ServiceStandard2 = "c",
			TypeOfServiceOfferedCode = "N",
		};

		var actual = Map.MapObject<SV_ServiceDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "H5", true)]
	[InlineData("o", "", false)]
	public void Validation_ARequiresBServiceStandard(string serviceStandard, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new SV_ServiceDescription();
		subject.ServiceStandard = serviceStandard;
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "H5", true)]
	[InlineData("c", "", false)]
	public void Validation_ARequiresBServiceStandard2(string serviceStandard2, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new SV_ServiceDescription();
		subject.ServiceStandard2 = serviceStandard2;
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
