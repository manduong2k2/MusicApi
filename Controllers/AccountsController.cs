using Microsoft.AspNetCore.Mvc;
using MusicApi.Data;
using MusicApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private MusicDbContext data;
        public AccountsController(MusicDbContext _data)
        {
            data = _data;
        }
        // GET: api/<AccountsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(data.Accounts.ToList());
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return BadRequest(data.Accounts.FirstOrDefault(a => a.Id == id));
        }

        // POST api/<AccountsController>
        [HttpPost("register")]
        public IActionResult Post(Account account)
        { 
            var a = new Account
            (
                account.Id,
                account.Password,
                account.TypeId
            );
            Profile p = new Profile(a.Id);
            data.Accounts.Add(a);
            createUserFolder(a.Id);
            data.SaveChanges();
            return Ok(a);
        }
        [HttpPost("login/{id}&{password}")]
        public IActionResult Login(string id,string password) 
        {
            var a = data.Accounts.FirstOrDefault(acc => acc.Id == id && acc.Password == password);
            if (a == null) return BadRequest("Incorrecr username or password !");
            else return Ok(a);
        }
        public void createUserFolder(string id)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\lib\\Res");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\lib\\Res\\" + id);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Directory.CreateDirectory(path + "\\songs");
                Directory.CreateDirectory(path + "\\images");
            }
        }
        [HttpPatch]
        public IActionResult Patch(Account account)
        {
            var a = data.Accounts.FirstOrDefault(a => a.Id == account.Id);
            if (a == null) return NotFound();
            if (account.Password != null) a.Password = account.Password;
            if (account.TypeId != null) a.TypeId = account.TypeId;
            return Ok(a);
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete]
        public IActionResult Delete(Account account)
        {
            var a = data.Accounts.FirstOrDefault(a => a.Id == account.Id);
            if (a == null) return NotFound();
            data.Accounts.Remove(a);
            deleteUserFolder(a.Id);
            data.SaveChanges();
            return Ok();
        }
        public void deleteUserFolder(string id)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\lib\\Res\\" + id);
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path + "\\songs");
                if (di.Exists)
                {
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    Directory.Delete(path + "\\songs");
                }
                di = new DirectoryInfo(path + "\\images");
                if (di.Exists)
                {
                    foreach (FileInfo file in di.GetFiles())
                        file.Delete();
                    Directory.Delete(path + "\\images");
                }
                Directory.Delete(path);
            }
        }
    }
}
