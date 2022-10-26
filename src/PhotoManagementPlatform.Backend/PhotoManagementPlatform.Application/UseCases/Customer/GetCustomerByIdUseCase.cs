using MediatR;

namespace PhotoManagementPlatform.Application.UseCases.Customer
{
    public class GetCustomerByIdUseCase : IRequest<Customer>
    {
        public Guid Id { get; set; }
    }

    public class GetCustomerByIdUseCaseHandler : IRequestHandler<GetCustomerByIdUseCase, Customer>
    {

        public GetCustomerByIdUseCaseHandler()
        {
        }

        public async Task<Customer> Handle(GetCustomerByIdUseCase request, CancellationToken cancellationToken)
        {
            var customer = new Customer();
            return customer;
        }
    }

    public class Customer { }
}
