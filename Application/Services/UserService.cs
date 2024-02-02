using Domain.Entities;
using Infrastructure.Repositories;

namespace Application.Services
{
    public interface IUserService
    {
        List<User> List();
        User? GetById(int id);
        User Create(User user);
        User Update(User user, int id);
        void Delete(int id);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Create(User user)
        {
            return _userRepository.Create(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public User? GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public List<User> List()
        {
            var users = _userRepository.GetAll();
            return users;
        }

        public User Update(User user, int id)
        {
            return _userRepository.Update(user, id);
        }
    }
}
