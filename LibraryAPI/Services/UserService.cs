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
            if (createUserDto == null)
                return ResultService.Fail< CreateUserDto > ("O objeto deve ser informado");
            var result = new UserDtoValidator().Validate(createUserDto);
            if (!result.IsValid)
                return ResultService.RequestError<CreateUserDto>("Problemas da validade!: ",result);

            var user = _mapper.Map<User>(createUserDto);
            var data = await _userRepository.Add(user);
            return ResultService.Ok(_mapper.Map<CreateUserDto>(data));
        }
    }
}
