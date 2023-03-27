


using lesohem_ASP_NET_MVC.DataBase;

public interface IInfoProfile
{
    string[] GetUser(int id);
    User Edit(User data, int id);
    User SaveImage(User data, int id);
    User GetImage(int id);
}