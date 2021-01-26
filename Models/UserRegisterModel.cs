using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using FilmsCatalog.Interfaces.Model_Interfaces;

namespace FilmsCatalog.Models
{
    public class UserRegisterModel : IdentityUser, IUserRegister<UserModel>
    {
        public UserModel U_ser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IUserRegister<UserModel>.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
