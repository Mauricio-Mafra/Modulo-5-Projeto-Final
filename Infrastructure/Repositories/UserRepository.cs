using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User? GetById(int id);
        User Create(User newUser);
        User Update(User updatedUser, int id);
        void Delete(int id);
    }

    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new List<User>();

        public User Create(User newUser)
        {
            newUser.Id = _users.Count + 1;

            _users.Add(newUser);

            return newUser;
        }
        public User? GetById(int id)
        {
            var user = _users.FirstOrDefault(p => p.Id == id);

            if (user is null)
            {
                throw new Exception("User not found!");
            }
            return user;
        }
        public void Delete(int id)
        {
            var User = GetById(id);

            _users.Remove(User!);
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public User Update(User updatedUser, int id)
        {
            var user = GetById(id);
            _users.Remove(user!);

            user!.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.HashedPassword = updatedUser.HashedPassword;

            _users.Add(user);
            return user;
        }
    }
}
