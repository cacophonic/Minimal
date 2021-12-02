using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Components.Prime.Queries
{
    internal class GetPrimeNumber : IRequest<long>
    {
        public GetPrimeNumber(int nthPrime)
        {
            NthPrime = nthPrime;
        }

        public int NthPrime { get; }

        public class Handler : IRequestHandler<GetPrimeNumber, long>
        {
            public Task<long> Handle(GetPrimeNumber request, CancellationToken cancellationToken)
            {
				return Task.FromResult(FindPrimeNumber(request.NthPrime));
            }

			private static long FindPrimeNumber(int n)
			{
				var count = 0;
				long a = 2;
				while (count < n)
				{
					long b = 2;
					var prime = false;
					while (b * b <= a)
					{
						if (a % b == 0)
						{
							prime = true;
							break;
						}
						b++;
					}
					if (!prime)
					{
						count++;
					}
					a++;
				}
				return (--a);
			}
		}

		
	}
}
