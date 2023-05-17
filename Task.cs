public class Task : Ticket
{

public string projectName {get; set;}
public string dueDate {get; set;}


public override string Display()
    {

      return $"{ticketID}, {summary}, {status}, {priority}, {submitter}, {assigned}, {watching}, {projectName}, {dueDate}";
    }

    
}