namespace WeddingPlanner.Models;

public class AllParticipationView
{
    public List<Wedding> AllWeddings {get;set;} = new();
    public Participation Participate {get;set;} = new Participation();

}