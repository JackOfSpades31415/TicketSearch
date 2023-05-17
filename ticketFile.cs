using NLog;
public class ticketFile {

    public string filePath { get; set;}
    public List<Ticket> Tickets {get; set;}
    private static NLog.Logger logger = LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

    public ticketFile(string ticketFilePath){
        filePath = ticketFilePath;


        Tickets = new List<Ticket>();
        try{
        StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                
                string line = sr.ReadLine();
                string[] ticketInfo = line.Split(',');
                if(ticketInfo[0] == "1"){
                    BugDefect ticket = new BugDefect();
                    ticket.ticketID = UInt64.Parse(ticketInfo[1]);
                    ticket.summary = ticketInfo[2];
                    ticket.status = ticketInfo[3];
                    ticket.priority = ticketInfo[4];
                    ticket.submitter = ticketInfo[5];
                    ticket.assigned = ticketInfo[6];
                    ticket.watching = ticketInfo[7];
                    ticket.severity = ticketInfo[8];
                    Tickets.Add(ticket);
                }
                else if(ticketInfo[0] == "2"){
                    Enhancement ticket = new Enhancement();
                    ticket.ticketID = UInt64.Parse(ticketInfo[1]);
                    ticket.summary = ticketInfo[2];
                    ticket.status = ticketInfo[3];
                    ticket.priority = ticketInfo[4];
                    ticket.submitter = ticketInfo[5];
                    ticket.assigned = ticketInfo[6];
                    ticket.watching = ticketInfo[7];
                    ticket.software = ticketInfo[8];
                    ticket.cost = ticketInfo[9];
                    ticket.reason = ticketInfo[10];
                    ticket.estimate = ticketInfo[11];
                    Tickets.Add(ticket);
                }
                else if(ticketInfo[0] == "3"){
                    Task ticket = new Task();
                    ticket.ticketID = UInt64.Parse(ticketInfo[1]);
                    ticket.summary = ticketInfo[2];
                    ticket.status = ticketInfo[3];
                    ticket.priority = ticketInfo[4];
                    ticket.submitter = ticketInfo[5];
                    ticket.assigned = ticketInfo[6];
                    ticket.watching = ticketInfo[7];
                    ticket.projectName = ticketInfo[8];
                    ticket.dueDate = ticketInfo[9];
                    Tickets.Add(ticket);
                }
                else {
                    throw new InvalidDataException("Invalid Data in file.");
                }
            }
            sr.Close();

            logger.Info("Tickets in file: {Count}", Tickets.Count);
        }
        catch (Exception e){
            logger.Error(e.Message);
        }
            
    }
        public void AddBug(BugDefect bugdef){
            try{
            StreamWriter sw = new StreamWriter(filePath, true);
            bugdef.ticketID = Tickets.Max(t => t.ticketID) + 1;
            sw.WriteLine($"{bugdef.ticketID},{bugdef.summary},{bugdef.status},{bugdef.submitter},{bugdef.assigned},{bugdef.watching},{bugdef.severity}");
            sw.Close();
            Tickets.Add(bugdef);
            logger.Info("Ticket #{Id} added", bugdef.ticketID);
            }
            catch(Exception e){
                logger.Error(e.Message);
            }
            
        }
        public void AddEnhance(Enhancement enhance){
            try{
            StreamWriter sw = new StreamWriter(filePath, true);
            enhance.ticketID = Tickets.Max(t => t.ticketID) + 1;
            sw.WriteLine($"{enhance.ticketID},{enhance.summary},{enhance.status},{enhance.submitter},{enhance.assigned},{enhance.watching},{enhance.software},{enhance.cost},{enhance.reason},{enhance.estimate}");
            sw.Close();
            Tickets.Add(enhance);
            logger.Info("Ticket #{Id} added", enhance.ticketID);
            }
            catch(Exception e){
                logger.Error(e.Message);
            }
            
        }
        public void AddTask(Task task){
            try{
            StreamWriter sw = new StreamWriter(filePath, true);
            task.ticketID = Tickets.Max(t => t.ticketID) + 1;
            sw.WriteLine($"{task.ticketID},{task.summary},{task.status},{task.submitter},{task.assigned},{task.watching}");
            sw.Close();
            Tickets.Add(task);
            logger.Info("Ticket #{Id} added", task.ticketID);
            }
            catch(Exception e){
                logger.Error(e.Message);
            }
            
        }


}