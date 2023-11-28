using AutoMapper;
using LibraryAPI.Data;
using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos;
using LibraryAPI.Dtos.Publishers;
using LibraryAPI.Dtos.Users;
using LibraryAPI.Dtos.Validations;
using LibraryAPI.FiltersDb;
using LibraryAPI.Models;
using LibraryAPI.Services.Interface;
using System.Reflection.Metadata.Ecma335;

namespace LibraryAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IRentalRepository _rentalRepository;

        public UserService(IUserRepository userRepository, IMapper mapper,IRentalRepository rentalRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _rentalRepository = rentalRepository;
        }
        public async Task<ResultService> CreateAsync(CreateUserDto createUserDto)
        {
            var result = new UserDtoValidator().Validate(createUserDto);
            if (!result.IsValid)
                return ResultService.BadRequest(result);

            var sameEmail = await _userRepository.GetuserByEmail(createUserDto.Email);
            if (sameEmail != null)
                return ResultService.BadRequest("Email já cadastrado.");

            var user = _mapper.Map<User>(createUserDto);
            await _userRepository.Add(user);
            return ResultService.Ok("Usuário cadastrado.");
        }

        public async Task<ResultService<ICollection<UserDto>>> GetAsync()
        {
            var user = await _userRepository.GetAllusers();
            return ResultService.Ok(_mapper.Map<ICollection<UserDto>>(user));
        }
        public async Task<ResultService<UserDto>> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetuserById(id);
            if(user == null)
            {
                return ResultService.NotFound<UserDto>("Usuário não encontrado");
            }
            return ResultService.Ok(_mapper.Map<UserDto>(user));
        }

        public async Task<ResultService> UpdateAsync(UserDto userDto)
        {
            var user = await _userRepository.GetuserById(userDto.Id);
            if (user == null)
                return ResultService.NotFound("Usuário não encontrado!");

            var validation = new UpdateUserDtoValidator().Validate(userDto);
            if (!validation.IsValid)
                return ResultService.BadRequest(validation);

            var sameEmail = await _userRepository.GetuserByEmail(userDto.Email);
            if (sameEmail != null && sameEmail.Id!= user.Id)
                return ResultService.BadRequest("Email já cadastrado.");

            user = _mapper.Map(userDto, user);
            await _userRepository.Update(user);
            return ResultService.Ok("Usuário atualizado");
        }
        public async Task<ResultService> DeleteAsync(int id)
        {
            var user = await _userRepository.GetuserById(id);
            if (user == null) 
                return ResultService.NotFound<UserDto>("Usuário não encontrado.");

            var rentalUser= await _rentalRepository.GetRentalUser(id);
            if(rentalUser != null)
                return ResultService.BadRequest("Usuário associado a aluguéis.");

            await _userRepository.Delete(user);
            return ResultService.Ok("O Usuário foi deletado.");
        }

        public async Task<ResultService<List<UserDto>>> GetPagedAsync(FilterDb request)
        {
            var userPaged = await _userRepository.GetPagedAsync(request);
            var result = new PagedBaseResponseDto<UserDto>(userPaged.TotalRegisters,userPaged.TotalPages,userPaged.Page,
                                         _mapper.Map<List<UserDto>>(userPaged.Data));
            if (result.Data.Count == 0)
                return ResultService.NotFound<List<UserDto>>("Nenhum Registro Encontrado");

            return ResultService.OkPaged(result.Data, result.TotalRegisters, result.TotalPages, result.Page);
        }

        public async Task<ResultService<List<UserDash>>> Dash()
        {
            var users = await _userRepository.GetAllusers();
            return ResultService.Ok(_mapper.Map<List<UserDash>>(users));
        }
    }
}