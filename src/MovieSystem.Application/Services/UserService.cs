using AutoMapper;
using MovieSystem.Application.DTOs;
using MovieSystem.Domain.Interfaces;
using MovieSystem.Domain.Entities;

namespace MovieSystem.Application.Services;

public class UserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    
    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public UserDto GetById(Guid id) =>
        _mapper.Map<UserDto>(_userRepository.GetByIdAsync(id).Result);
    
    public IEnumerable<UserDto> GetAll() =>
        _mapper.Map<IEnumerable<UserDto>>(_userRepository.GetAllAsync().Result);
    
    public void Add(User user) => 
        _userRepository.AddAsync(user).Wait();
    
    public void Update(User user) => 
        _userRepository.UpdateAsync(user).Wait();
    
    public void Delete(Guid id) => 
        _userRepository.DeleteAsync(id).Wait();
}