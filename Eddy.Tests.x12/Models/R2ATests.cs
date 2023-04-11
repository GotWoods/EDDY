using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class R2ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R2A*D*W*a*vJ*P*i*SV*R*J*i4";

		var expected = new R2A_RouteInformationWithPreference()
		{
			RoutingSequenceCode = "D",
			PreferenceCode = "W",
			TransportationMethodTypeCode = "a",
			StandardCarrierAlphaCode = "vJ",
			LocationQualifier = "P",
			LocationIdentifier = "i",
			TypeOfServiceCode = "SV",
			RouteCode = "R",
			RouteDescription = "J",
			EntityIdentifierCode = "i4",
		};

		var actual = Map.MapObject<R2A_RouteInformationWithPreference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new R2A_RouteInformationWithPreference();
		subject.PreferenceCode = "W";
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredPreferenceCode(string preferenceCode, bool isValidExpected)
	{
		var subject = new R2A_RouteInformationWithPreference();
		subject.RoutingSequenceCode = "D";
		subject.PreferenceCode = preferenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "i", true)]
	[InlineData("P", "", false)]
	public void Validation_ARequiresBLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new R2A_RouteInformationWithPreference();
		subject.RoutingSequenceCode = "D";
		subject.PreferenceCode = "W";
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
