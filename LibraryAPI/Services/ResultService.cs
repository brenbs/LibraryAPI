using FluentValidation.Results;
using LibraryAPI.Dtos.Validations;

namespace LibraryAPI.Services
{
    public class ResultService 
    //trata os retornos (retorna sucesso,restorna erro, e qual erro)
    {
        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public ICollection<ErrorValidation> Errors { get; set; }

        public static ResultService RequestError( ValidationResult validationResult)
        {
            return new ResultService
            {
                IsSucess = false,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }
        public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ResultService<T>
            {
                IsSucess = false,
                Message = message,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }
        public static ResultService<T> Fail<T>(string Message) => new ResultService<T> { IsSucess = false, Message = Message };
        public static ResultService Ok(string Message) => new ResultService { IsSucess = true, Message = Message };
        public static ResultService<T> Ok<T>(T Data) => new ResultService<T> { IsSucess = true, Data = Data};
    }
    public class ResultService <T> : ResultService
    {
        public T Data { get; set; }
    }
}
