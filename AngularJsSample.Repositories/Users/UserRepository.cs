using System;
using System.Collections.Generic;
using System.Linq;
using AngularJsSample.Model.Users;
using Context = AngularJsSample.Repositories.DatabaseModel;

namespace AngularJsSample.Repositories
{
    public class UserRepository : IUserRepository
    {

        /// <summary>
        /// Gets all UserInfos 
        /// </summary>
        /// <returnsList<Model.Users.UserInfo>></returns>
        public List<Model.Users.UserInfo> FindAll()
        {
            using (var context = new Context.AngularJsSampleDbEntities())
            {
                return context.UserInfoes.MapToUserInfos();
            }
        }

        /// <summary>
        /// Gets UserInfos by id
        /// </summary>
        /// <param name="key">Id</param>
        /// <returns>context.UserInfoes</returns>
        public Model.Users.UserInfo FindAll(int key)
        {
            using (var context = new Context.AngularJsSampleDbEntities())
            {
                return context.UserInfoes.FirstOrDefault(user => user.Id == key).MapToUserInfo();
            }
        }

        public int Add(UserInfo item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(UserInfo item)
        {
            throw new NotImplementedException();
        }

        public UserInfo Save(UserInfo item)
        {
            throw new NotImplementedException();
        }

        public List<UserInfo> FindAllBy(int key)
        {
            throw new NotImplementedException();
        }
    }
}
