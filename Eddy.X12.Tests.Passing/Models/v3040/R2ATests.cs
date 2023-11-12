using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class R2ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R2A*s*N*r*Gv*d*T*s8*l*J*xy";

		var expected = new R2A_RouteInformationWithPreference()
		{
			RoutingSequenceCode = "s",
			Preference = "N",
			TransportationMethodTypeCode = "r",
			StandardCarrierAlphaCode = "Gv",
			LocationQualifier = "d",
			LocationIdentifier = "T",
			TypeOfServiceCode = "s8",
			RouteCode = "l",
			RouteDescription = "J",
			EntityIdentifierCode = "xy",
		};

		var actual = Map.MapObject<R2A_RouteInformationWithPreference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new R2A_RouteInformationWithPreference();
		//Required fields
		subject.Preference = "N";
		//Test Parameters
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredPreference(string preference, bool isValidExpected)
	{
		var subject = new R2A_RouteInformationWithPreference();
		//Required fields
		subject.RoutingSequenceCode = "s";
		//Test Parameters
		subject.Preference = preference;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "T", true)]
	[InlineData("d", "", false)]
	[InlineData("", "T", true)]
	public void Validation_ARequiresBLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new R2A_RouteInformationWithPreference();
		//Required fields
		subject.RoutingSequenceCode = "s";
		subject.Preference = "N";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
