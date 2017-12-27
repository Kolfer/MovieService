using MoviesDomain.Concrety;
using AuthecantionWithCookie.Abstract;
using System.Data.Entity;
using System.Linq;
using System;
using MoviesDomain.Entities.AuthEntities;


namespace MovieService.Models
{
    public class MovieRepositoryAuth : MovieRepository, IAuthecantionRepository
    {
        public IUser Login(string LoginOrEmail, string password)
        {

                if (LoginOrEmail.Contains('@'))
                {
                    return context.Users.FirstOrDefault((u) => u.Email == LoginOrEmail
                                        && u.UserPassword == password);
                }
                else
                {
                    return context.Users.FirstOrDefault((u) => u.Name == LoginOrEmail
                                       && u.UserPassword == password);
                }
        }

        //----------------------------------------------------------------//

        public IUser getUserFromEmail( string email)
        {
            return context.Users.FirstOrDefault((u) => u.Email == email);
        }

        //----------------------------------------------------------------//

        public void RegisterUser(IUser user, string role)
        {
            if(user != null)
            {
                Users u = user as Users;
                if(u != null)
                {
                    Roles _role = findItem<Roles>(role);
                    _role.Users.Add(u);
                    u.Roles.Add(_role);
                    context.Users.Add(u);
                    context.SaveChanges();
                }
            }
        }

        //----------------------------------------------------------------//

        public void addRole(string Role)
        {
            if( context.Roles.FirstOrNull( (r) => r.Name == Role) == null)
            {
                context.Roles.Add(new Roles()
                {
                    Id = context.Roles.Count(),
                    Name = Role
                });
                context.SaveChanges();
            }
        }

        //----------------------------------------------------------------//

    }
}