

using lesohem_ASP_NET_MVC.DataBase;
using Newtonsoft.Json;

public class SocMedia : ISocMedia
{
    lesohemContext db;
    public SocMedia(lesohemContext db) => this.db = db;
    public SocMedium Save(SocMedium media)
    {
        db.SocMedia.Add(media);
        db.SaveChanges();
        return media;
    }
    public string[] Get(int id)
    {
        var res = db.SocMedia.Where(i => i.PersonId == id);
        string Link = "";
        foreach (var item in res)
        {
            Link += item.Link + " ";
        }
        string[] subs = Link.Split(' ').Where(x => x != "").ToArray();
        return subs;
    }
}