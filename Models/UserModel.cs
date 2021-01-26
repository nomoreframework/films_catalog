using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FilmsCatalog.Models
{
    public class UserModel : IUser<IdentityUser>
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SurName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FullName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string registrationDate => throw new NotImplementedException();

        public int UserRegisterId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public UserRegisterModel userRegister { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<FilmModel> Films { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IdentityUser IUser<IdentityUser>.userRegister { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
