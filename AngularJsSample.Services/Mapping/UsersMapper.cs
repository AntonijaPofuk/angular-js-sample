using AutoMapper;
using AngularJsSample.Services.Messaging.Views.Users;

namespace AngularJsSample.Services.Mapping
{
    public static class UsersMapper
    {
        /// <summary>
        /// Maps Model.User.UserInfo into Messaging.Views.UserInfo
        /// </summary>
        /// <param name="model">Model.Users.UserInfo</param>
        /// <returns>Messaging.Views.Users.UserInfo</returns>
        public static UserInfo MapToView(this Model.Users.UserInfo model)
        {
            return Mapper.Map<UserInfo>(model);
        }

        /// <summary>
        /// Maps Messaging.Views.UserInfo into Model.Users.UserInfo
        /// </summary>
        /// <param name="view">Messaging.Views.UserInfo</param>
        /// <returns>Model.Users.UserInfo</returns>
        public static Model.Users.UserInfo MapToModel(this UserInfo view)
        {
            if (view == null)
                return null;
            return new Model.Users.UserInfo()
            {
                Id = view.Id,
                Email = view.Email,
                FirstName = view.FirstName,
                LastName = view.LastName
            };
        }

    }
}
