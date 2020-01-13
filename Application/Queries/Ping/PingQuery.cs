using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Ping
{
    //cqrs tab tab to autogenerate this.
    public class PingQuery : IRequest<string>
    {

    }


    public class PingQueryHandler : IRequestHandler<PingQuery, string>
    {

        public PingQueryHandler()
        {

        }

        public async Task<string> Handle(PingQuery request, CancellationToken cancellationToken)
        {
            return $"Ping received {DateTime.Now}";
        }
    }


    public class PingQueryValidator : AbstractValidator<PingQuery>
    {
        public PingQueryValidator()
        {
            //RuleFor(x => x.Name).NotEmpty();
        }
    }
}
