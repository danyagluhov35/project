


using lesohem_ASP_NET_MVC.DataBase;

public interface ISocMedia
{
    SocMedium Save(SocMedium socMedium);
    string[] Get(int id);
}