using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class R2ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R2A*B*D*t*lX*t*d*av*2*G*0t";

		var expected = new R2A_RouteInformationWithPreference()
		{
			RoutingSequenceCode = "B",
			PreferenceCode = "D",
			TransportationMethodTypeCode = "t",
			StandardCarrierAlphaCode = "lX",
			LocationQualifier = "t",
			LocationIdentifier = "d",
			TypeOfServiceCode = "av",
			RouteCode = "2",
			RouteDescription = "G",
			EntityIdentifierCode = "0t",
		};

		var actual = Map.MapObject<R2A_RouteInformationWithPreference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new R2A_RouteInformationWithPreference();
		//Required fields
		subject.PreferenceCode = "D";
		//Test Parameters
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredPreferenceCode(string preferenceCode, bool isValidExpected)
	{
		var subject = new R2A_RouteInformationWithPreference();
		//Required fields
		subject.RoutingSequenceCode = "B";
		//Test Parameters
		subject.PreferenceCode = preferenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "d", true)]
	[InlineData("t", "", false)]
	[InlineData("", "d", true)]
	public void Validation_ARequiresBLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new R2A_RouteInformationWithPreference();
		//Required fields
		subject.RoutingSequenceCode = "B";
		subject.PreferenceCode = "D";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
