using AutoMapper;
using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos.Users;
using LibraryAPI.Dtos.Validations;
using LibraryAPI.Models;
using LibraryAPI.Services.Interface;
using System.Reflection.Metadata.Ecma335;

namespace LibraryAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<ResultService> CreateAsync(CreateUserDto createUserDto)
        {
            var result = new UserDtoValidator().Validate(createUserDto);
            if (!result.IsValid)
                return ResultService.RequestError<CreateUserDto>("Problemas da validade!: ",result);

            var sameEmail = await _userRepository.GetuserByEmail(createUserDto.Email);
            if (sameEmail != null)
                return ResultService.Fail<CreateUserDto>("Email já cadastrado.");

            var user = _mapper.Map<User>(createUserDto);
            await _userRepository.Add(user);
            return ResultService.Ok("Usuário cadastrado.");
        }

        public async Task<ResultService<ICollection<UserDto>>> GetAsync()
        {
            var user = await _userRepository.GetAllusers();
            return ResultService.Ok<ICollection<UserDto>>(_mapper.Map<ICollection<UserDto>>(user));
        }
        public async Task<ResultService<UserDto>> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetuserById(id);
            if(user == null)
            {
                return ResultService.Fail<UserDto>("Usuário não encontrado");
            }
            return ResultService.Ok(_mapper.Map<UserDto>(user));
        }

        public async Task<ResultService> UpdateAsync(UserDto userDto)
        {
            if (userDto == null)
                return ResultService.Fail<UserDto>("Usuário não encontrado.");

            var user = await _userRepository.GetuserById(userDto.Id);
            if (user == null)
                return ResultService.Fail<UserDto>("Usuário não encontrado!");

            var validation = new UpdateUserDtoValidator().Validate(userDto);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas com a validação dos campos", validation);

            user = _mapper.Map<UserDto,User>(userDto, user);
            await _userRepository.Update(user);
            return ResultService.Ok("Usuário atualizado");
        }
        public async Task<ResultService> DeleteAsync(int id)
        {
            var user = await _userRepository.GetuserById(id);
            if (user == null) 
                return ResultService.Fail<UserDto>("Usuário não encontrado.");

            await _userRepository.Delete(user);
            return ResultService.Ok("O Usuário foi deletado.");
        }
    }
}