using lesohem_ASP_NET_MVC.DataBase;
using lesohem_ASP_NET_MVC.IService;
using System.Text;

namespace lesohem_ASP_NET_MVC.Service
{
    public class Files : IFiles
    {
        lesohemContext db;
        public Files(lesohemContext db) => this.db = db;
        public async Task<string> GetPath(IFormFile fileName)
        {
            return $"{Directory.GetCurrentDirectory()}/Files/TimeTable/{fileName.FileName}";
        }
        public void CreatePath(string path)
        {
            using(FileStream fs = new FileStream(path,FileMode.OpenOrCreate)) { }
        }
        public void FileWrite(string text, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(text);
            }
        }
        public async Task<string> FileRead(IFormFile file, string path)
        {
            string text = null!;
            using(MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                byte[] fileBytes = ms.ToArray();
                text = Encoding.Default.GetString(fileBytes);
            }
            return text;
        }
        public void SaveContent(TableContent content)
        {
            db.TableContents.Add(content);
            db.SaveChanges();
        }
        public List<TableContent> GetContent()
        {
            var content = db.TableContents.Where(u => u.TableBlockId == 1).ToList();
            return content;
        }
    }
}
