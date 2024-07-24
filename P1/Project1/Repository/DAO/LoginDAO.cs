using Project1.Entities;

using Microsoft.EntityFrameworkCore;


namespace Project1.DAO;


public class LoginDAO : IDAO<Login>{
    private ApplicationDbContext _context;


    public LoginDAO(ApplicationDbContext context){
        _context = context;
    }

    public void Create(Login item){
        _context.Logins.Add(item);
        _context.SaveChanges();
    }

    public void Delete(Login item){
        _context.Logins.Remove(item);
        _context.SaveChanges();

    }

    public ICollection<Login> GetAll(){
        List<Login> logins = _context.Logins.Include(l => l.User)
                                            .ToList();
        return logins;

    }

    public Login GetById(int Id){
        Login login = _context.Logins
                            .Include(l => l.User)
                            .FirstOrDefault(l => l.LoginID == Id);

        return login;
    }

    public void Update(Login newItem){

    }

    public Login GetLoginByUAndP(string u, string p){
        Login login = _context.Logins
                                .Include(l => l.User)
                                .FirstOrDefault(l => l.Username == u && l.Password == p);

        return login;    
    }

}