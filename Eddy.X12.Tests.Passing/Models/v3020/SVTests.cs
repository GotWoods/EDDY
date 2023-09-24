using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV*Pc*N*w*8";

		var expected = new SV_ServiceDescription()
		{
			UnitOfTimePeriodCode = "Pc",
			ServiceStandard = "N",
			ServiceStandard2 = "w",
			TypeOfServiceOfferedCode = "8",
		};

		var actual = Map.MapObject<SV_ServiceDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("N", "Pc", true)]
	[InlineData("N", "", false)]
	[InlineData("", "Pc", true)]
	public void Validation_ARequiresBServiceStandard(string serviceStandard, string unitOfTimePeriodCode, bool isValidExpected)
	{
		var subject = new SV_ServiceDescription();
		subject.ServiceStandard = serviceStandard;
		subject.UnitOfTimePeriodCode = unitOfTimePeriodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w", "Pc", true)]
	[InlineData("w", "", false)]
	[InlineData("", "Pc", true)]
	public void Validation_ARequiresBServiceStandard2(string serviceStandard2, string unitOfTimePeriodCode, bool isValidExpected)
	{
		var subject = new SV_ServiceDescription();
		subject.ServiceStandard2 = serviceStandard2;
		subject.UnitOfTimePeriodCode = unitOfTimePeriodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
