using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;

namespace WebApi.Business.Src.Abstractions
{
    public interface IPaymentService: IBaseService<Payment, PaymentReadDto, PaymentCreateDto, PaymentUpdateDto>
    {
        
    }
}