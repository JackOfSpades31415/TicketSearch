public class Enhancement : Ticket
{

public string software {get; set;}
public string cost {get; set;}
public string reason {get; set;}
public string estimate {get; set;}


public override string Display()
    {

      return $"{ticketID}, {summary}, {status}, {priority}, {submitter}, {assigned}, {watching}, {software}, {cost}, {reason}, {estimate}";
    }
    
}