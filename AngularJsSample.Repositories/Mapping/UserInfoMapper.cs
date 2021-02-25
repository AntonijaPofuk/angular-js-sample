using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsSample.Repositories
{
    public static class UserInfoMapper
    {
        /// <summary>
        /// Maps DatabaseModel into Model
        /// </summary>
        /// <param name="model">DatabaseModel.UserInfo</param>
        /// <returns>Model.Users.UserInfo</returns>
        public static Model.Users.UserInfo MapToUserInfo(this DatabaseModel.UserInfo model)
        {
            if (model == null)
                return null;
            return new Model.Users.UserInfo()
            {
                Id = model.Id,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }

        /// <summary>
        /// Maps UserInfo into List<Model.Users.UserInfo>
        /// </summary>
        /// <param name="items">IEnumerable<DatabaseModel.UserInfo></param>
        /// <returns>List<Model.Users.UserInfo></returns>
        public static List<Model.Users.UserInfo> MapToUserInfos(this IEnumerable<DatabaseModel.UserInfo> items)
        {
            var result = new List<Model.Users.UserInfo>();
            if (items == null)
                return result;
            result.AddRange(items.Select(u => u.MapToUserInfo()));
            return result;
        }


    }
}
