using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class R2ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R2A*j*R*N*Do*c*V*WM*o*B*OD";

		var expected = new R2A_RouteInformationWithPreference()
		{
			RoutingSequenceCode = "j",
			Preference = "R",
			TransportationMethodTypeCode = "N",
			StandardCarrierAlphaCode = "Do",
			LocationQualifier = "c",
			LocationIdentifier = "V",
			TypeOfServiceCode = "WM",
			RouteCode = "o",
			RouteDescription = "B",
			EntityIdentifierCode = "OD",
		};

		var actual = Map.MapObject<R2A_RouteInformationWithPreference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new R2A_RouteInformationWithPreference();
		//Required fields
		subject.Preference = "R";
		//Test Parameters
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredPreference(string preference, bool isValidExpected)
	{
		var subject = new R2A_RouteInformationWithPreference();
		//Required fields
		subject.RoutingSequenceCode = "j";
		//Test Parameters
		subject.Preference = preference;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("c", "V", true)]
	[InlineData("c", "", false)]
	[InlineData("", "V", true)]
	public void Validation_ARequiresBLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new R2A_RouteInformationWithPreference();
		//Required fields
		subject.RoutingSequenceCode = "j";
		subject.Preference = "R";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
