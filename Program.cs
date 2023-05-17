
using NLog;

string path = Directory.GetCurrentDirectory() + "\\nlog.config";

var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();

string ticketFilePath = Directory.GetCurrentDirectory() + "\\Ticket.csv";
string prompt = "";
logger.Info("Program on");
ticketFile ticketFile = new ticketFile(ticketFilePath);
do{
Console.WriteLine("[1] Display ticket list and information");
Console.WriteLine("[2] Create new ticket.");
Console.WriteLine("[3] Search for tickets.");
Console.WriteLine("Enter other keys to exit.");

prompt = Console.ReadLine();

if (prompt == "1"){

     foreach(Ticket t in ticketFile.Tickets)
    {
      Console.WriteLine(t.Display());
    }
  }


else if (prompt == "2"){
  
    StreamWriter sw = new StreamWriter("Ticket.csv", true);
    string type = "";
    Console.WriteLine("What type of ticket will this be?");
    Console.WriteLine("[1] for Bugs or Defects.");
    Console.WriteLine("[2] for Enhancements");
    Console.WriteLine("[3] for Tasks");
    type = Console.ReadLine();

    if(type == "1"){
    BugDefect bugdef = new BugDefect();
    bugdef.type = 1;
    bugdef.ticketID = ticketFile.Tickets.Max(t => t.ticketID) + 1;
    Console.WriteLine("Summary?");
    bugdef.summary = Console.ReadLine();
    Console.WriteLine("Current Status?");
    bugdef.status = Console.ReadLine();
    Console.WriteLine("What's the Priority?");
    bugdef.priority = Console.ReadLine();
    Console.WriteLine("Who is the Submitter?");
    bugdef.submitter = Console.ReadLine();
    Console.WriteLine("Who is Assigned?");
    bugdef.assigned = Console.ReadLine();
    Console.WriteLine("Who is Watching?");
    bugdef.watching = Console.ReadLine();
    Console.WriteLine("What is the severity?");
    bugdef.severity = Console.ReadLine();
    sw.WriteLine($"{bugdef.type},{bugdef.ticketID},{bugdef.summary},{bugdef.status},{bugdef.submitter},{bugdef.assigned},{bugdef.watching},{bugdef.severity}");
    sw.Close();
    logger.Info("Ticket #{Id} added", bugdef.ticketID);
    }
    else if(type == "2"){
      Enhancement enhance = new Enhancement();
      enhance.type = 2;
      enhance.ticketID = ticketFile.Tickets.Max(t => t.ticketID) + 1;
    Console.WriteLine("Summary?");
    enhance.summary = Console.ReadLine();
    Console.WriteLine("Current Status?");
    enhance.status = Console.ReadLine();
    Console.WriteLine("What is the Priority?");
    enhance.priority = Console.ReadLine();
    Console.WriteLine("Who is the Submitter?");
    enhance.submitter = Console.ReadLine();
    Console.WriteLine("Who is Assigned?");
    enhance.assigned = Console.ReadLine();
    Console.WriteLine("Who is Watching?");
    enhance.watching = Console.ReadLine();
    Console.WriteLine("For what software?");
    enhance.software = Console.ReadLine();
    Console.WriteLine("How much would it cost?");
    enhance.cost = Console.ReadLine();
    Console.WriteLine("What is the reason for this?");
    enhance.reason = Console.ReadLine();
    Console.WriteLine("What is the estimate?");
    enhance.estimate = Console.ReadLine();
    sw.WriteLine($"{enhance.type},{enhance.ticketID},{enhance.summary},{enhance.status},{enhance.submitter},{enhance.assigned},{enhance.watching},{enhance.software},{enhance.cost},{enhance.reason},{enhance.estimate}");
            sw.Close();
            logger.Info("Ticket #{Id} added", enhance.ticketID);
    }
    else if(type == "3"){
      Task task = new Task();
      task.type = 3;
      task.ticketID = ticketFile.Tickets.Max(t => t.ticketID) + 1;
    Console.WriteLine("Summary?");
    task.summary = Console.ReadLine();
    Console.WriteLine("Current Status?");
    task.status = Console.ReadLine();
    Console.WriteLine("What is the Priority?");
    task.priority = Console.ReadLine();
    Console.WriteLine("Who is the Submitter?");
    task.submitter = Console.ReadLine();
    Console.WriteLine("Who is Assigned?");
    task.assigned = Console.ReadLine();
    Console.WriteLine("Who is Watching?");
    task.watching = Console.ReadLine();
    Console.WriteLine("What is the name of the project?");
    task.projectName = Console.ReadLine();
    Console.WriteLine("When must it be completed by?");
    task.dueDate = Console.ReadLine();
    sw.WriteLine($"{task.type},{task.ticketID},{task.summary},{task.status},{task.submitter},{task.assigned},{task.watching}");
            sw.Close();
            logger.Info("Ticket #{Id} added", task.ticketID);
    }
    else{
      Console.WriteLine("That is not a valid response.");
    }
}
 else if(prompt == "3"){
    string searchType = "";
      
      Console.WriteLine("What are we searching by?");
      Console.WriteLine("[1] for status");
      Console.WriteLine("[2] for priority");
      Console.WriteLine("[3] for submitted");
      searchType = Console.ReadLine();
  
   
    if(searchType == "1" || searchType == "2" || searchType == "3"){
      Console.WriteLine("Input keywords you'd like to search by:");
      String searchInput = Console.ReadLine();
        if(searchType == "1"){
          var Tickets = ticketFile.Tickets.Where(t => t.status.Contains(searchInput));
          int num = ticketFile.Tickets.Where(t => t.status.Contains(searchInput)).Count();
          Console.WriteLine($"There are {Tickets.Count()} tickets that fit that search query.");
          foreach(Ticket t in Tickets){
            Console.WriteLine($"  {t.ticketID}  {t.summary}");
            }
    
      }
      else if(searchType == "2"){
          var Tickets = ticketFile.Tickets.Where(t => t.priority.Contains(searchInput));
          int num = ticketFile.Tickets.Where(t => t.priority.Contains(searchInput)).Count();
          Console.WriteLine($"There are {Tickets.Count()} tickets that fit that search query.");
          foreach(Ticket t in Tickets){
            Console.WriteLine($"  {t.ticketID}  {t.summary}");
            }
      }
      else if(searchType == "3"){
          var Tickets = ticketFile.Tickets.Where(t => t.submitter.Contains(searchInput));
          int num = ticketFile.Tickets.Where(t => t.submitter.Contains(searchInput)).Count();
          Console.WriteLine($"There are {Tickets.Count()} tickets that fit that search query.");
          foreach(Ticket t in Tickets){
            Console.WriteLine($"  {t.ticketID}  {t.summary}");
            }
      }
      
    }
    else{
      Console.WriteLine("That is not a valid response.");
    }


 }


      

}while(prompt == "1" || prompt == "2" || prompt == "3");
 logger.Info("Program over.");
 

    


