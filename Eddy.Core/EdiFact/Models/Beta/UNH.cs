namespace Eddy.Core.EdiFact.Models.Beta
{
    //UNH
    //+ME000021   //Message Reference Number
    //+IFTSTA:D:01A:UN:EAN004' //Message Type / Version # / Release Number / Controlling Agency / Association Assigned Code
    public class UNH
    {
        public string MessageReferenceNumber { get; set; }
        public string MessageType { get; set; }

        public string MessageVersion { get; set; }
        public string ReleaseNumber { get; set; }
        public string ControllingAgency { get; set; }
        public string AssociationAssignedCode { get; set; }

    }
}
