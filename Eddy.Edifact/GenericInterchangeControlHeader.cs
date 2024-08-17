using Eddy.Core.Validation;
using System;
using System.Text;
using Eddy.Core.Attributes;

namespace Eddy.Edifact;

public class GenericInterchangeControlHeader : EdifactSegment
{

    //TODO: generic items of all of these or a way to toggle between the 96A-99B vs the 00A-Current models
    //See the Generic Header Info.txt file for more info on the changes

    [Position(1)]
    public Eddy.Edifact.Models.D00A.Composites.S001_SyntaxIdentifier SyntaxIdentifier { get; set; }

    [Position(2)]
    public Eddy.Edifact.Models.D00A.Composites.S002_InterchangeSender InterchangeSender { get; set; }

    [Position(3)]
    public Eddy.Edifact.Models.D00A.Composites.S003_InterchangeRecipient InterchangeRecipient { get; set; }

    [Position(4)]
    public Eddy.Edifact.Models.D00A.Composites.S004_DateAndTimeOfPreparation DateAndTimeOfPreparation { get; set; }

    [Position(5)]
    public string InterchangeControlReference { get; set; }

    [Position(6)]
    public Eddy.Edifact.Models.D00A.Composites.S005_RecipientReferencePasswordDetails RecipientReferencePasswordDetails { get; set; }

    [Position(7)]
    public string ApplicationReference { get; set; }

    [Position(8)]
    public string ProcessingPriorityCode { get; set; }

    [Position(9)]
    public string AcknowledgementRequest { get; set; }

    [Position(10)]
    public string InterchangeAgreementIdentifier { get; set; }

    [Position(11)]
    public string TestIndicator { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<GenericInterchangeControlHeader>(this);
        //TODO: fix
        // validator.Required(x => x.SyntaxIdentifier);
        // validator.Required(x => x.InterchangeSender);
        // validator.Required(x => x.InterchangeRecipient);
        // validator.Required(x => x.DateAndTimeOfPreparation);
        validator.Required(x => x.InterchangeControlReference);
        validator.Length(x => x.InterchangeControlReference, 1, 14);
        validator.Length(x => x.ApplicationReference, 1, 14);
        validator.Length(x => x.ProcessingPriorityCode, 1);
        validator.Length(x => x.AcknowledgementRequest, 1);
        validator.Length(x => x.InterchangeAgreementIdentifier, 1, 35);
        validator.Length(x => x.TestIndicator, 1);
        return validator.Results;
    }
}