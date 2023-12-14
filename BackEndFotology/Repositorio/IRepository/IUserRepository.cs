using BackEndFotology.Models;
using BackEndFotology.Models.DTOs;

namespace BackEndFotology.Repositorio.IRepository
{
    public interface IUserRepository
    {
        Task<ICollection<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetByIdAsync(string id);
        bool IsUnique(string userName);
        Task<UserLoginResponseDTO> LoginAsync(UserLoginDTO userLoginDTO);
        Task<UserDTO> RegisterAsync(UserRegisterDTO userRegisterDTO);

    }
}