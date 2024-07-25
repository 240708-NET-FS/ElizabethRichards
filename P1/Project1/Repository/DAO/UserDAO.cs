using System.Reflection.Metadata;
using Project1.Entities;

namespace Project1.DAO;

public class UserDAO : IDAO<User>{

    private ApplicationDbContext _context;

    public UserDAO(ApplicationDbContext context){
        _context = context;
    }

    public void Create(User item){
        _context.Users.Add(item);
        _context.SaveChanges();

    }

    public void Update(User item){
        //TODO
        

    }

    public void Delete(User item){
        _context.Users.Remove(item);
        _context.SaveChanges();

    }

    public ICollection<User> GetAll(){

        List<User> users = _context.Users.ToList();
        return users;

    }

    public User GetById(int id){
        
        User user = _context.Users.FirstOrDefault(u => u.UserID == id);
        return user;   
    }


}