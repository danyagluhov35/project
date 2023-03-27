using lesohem_ASP_NET_MVC.DataBase;

namespace lesohem_ASP_NET_MVC.IService
{
    public interface IFiles
    {
        Task<string> GetPath(IFormFile fileName);
        void CreatePath(string path);
        void FileWrite(string text,string path);
        Task<string> FileRead(IFormFile file,string path);
        void SaveContent(TableContent content);
        List<TableContent> GetContent();
    }
}
