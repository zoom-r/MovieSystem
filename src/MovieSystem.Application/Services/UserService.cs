using AutoMapper;
using MovieSystem.Application.DTOs;
using MovieSystem.Domain.Entities;
using MovieSystem.Domain.Interfaces;

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

    public async Task<UserDto?> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task AddAsync(UserDto dto)
    {
        var user = _mapper.Map<User>(dto);
        await _userRepository.AddAsync(user);
    }

    public async Task UpdateAsync(UserDto dto)
    {
        var user = _mapper.Map<User>(dto);
        await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteAsync(Guid id) =>
        await _userRepository.DeleteAsync(id);
}