public class BugDefect : Ticket
{

    public string severity {get; set;}



    public override string Display()
    {

      return $"{ticketID}, {summary}, {status}, {priority}, {submitter}, {assigned}, {watching}, {severity}";
    }
    
}

