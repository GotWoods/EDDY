using Eddy.Core.Attributes;
using Eddy.Edifact.Models.Elements;

namespace Eddy.Edifact.Models.Beta;


[Segment("UNB")]
public class UNB_InterchangeHeader
{
    [Position(1)]
    public S001_SyntaxIdentifier SyntaxIdentifier { get; set; } = new();

    [Position(2)]
    public S002_InterchangeSender Sender { get; set; } = new();

    [Position(3)]
    public S003_InterchangeRecipient Recipient { get; set; } = new();

    [Position(4)]
    public S004_Date Date { get; set; } = new();

    [Position(5)]
    public string InterchangeControlReference { get; set; }
    public void Parse(string line)
    {
        var parts = line.Split('+');

        //prim parts can be parsed as normal
        //complex types can be performed by a sub-parser that uses the ":" splitter

        //var syntaxComponent = parts[1].Split(':');

        // SyntaxIdentifier = syntaxComponent[0];
        // SyntaxVersionNumber = syntaxComponent[1];
        //
        // var senderComponent = parts[2].Split(':');
        // this.Sender = senderComponent[0];
        //
        // var recipientComponent = parts[3].Split(':');
        // this.Recipient = recipientComponent[0];
        //
        // var dateTimeComponent = parts[4].Split(':');
        // this.Date = dateTimeComponent[0];
        // this.Time = dateTimeComponent[1];

        var controlReference = parts[5].Split(':');
        ControlReferenceNumber = controlReference[0];
    }

    public string ControlReferenceNumber { get; set; }








}