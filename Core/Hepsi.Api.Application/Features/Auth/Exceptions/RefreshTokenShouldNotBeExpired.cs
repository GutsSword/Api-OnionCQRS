using Hepsi.Api.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsi.Api.Application.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpired : BaseException
    {
        public RefreshTokenShouldNotBeExpired() : base("Oturum Süresi Doldu. Lütfen Tekrar Giriş Yapın.")
        {         
        }
    }
}
