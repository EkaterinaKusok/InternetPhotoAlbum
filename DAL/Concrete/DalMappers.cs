using System.Linq;
using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Concrete
{
    public static class DalMappers
    {
        public static DalUser ToDalUser(this User user)
        {
            return new DalUser()
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
               // Roles = user.Roles.Select(ToDalRole).ToList(),
                //Photos = user.Photos.Select(ToDalPhoto).ToList()
            };
        }

        public static User ToOrmUser(this DalUser dalUser)
        {
            return new User()
            {
                Id = dalUser.Id,
                Name = dalUser.Name,
                Password = dalUser.Password,
                //Roles = dalUser.Roles.Select(ToOrmRole).ToList(),
                // Photos = dalUser.Photos.Select(current => ToOrmPhoto(current)).ToList()
                Photos = dalUser.Photos.Select(ToOrmPhoto).ToList()
            };
        }

        public static DalRole ToDalRole(this Role role)
        {
            return new DalRole()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public static Role ToOrmRole(this DalRole dalRole)
        {
            return new Role()
            {
                Id = dalRole.Id,
                Name = dalRole.Name,
                Description = dalRole.Description
            };
        }

        public static DalPhoto ToDalPhoto(this Photo photo)
        {
            byte[] tempContent = new byte[photo.Content.Length];
            photo.Content.CopyTo(tempContent,0);
            return new DalPhoto()
            {
                Id = photo.Id,
                Name = photo.Name,
                Description = photo.Description,
                Content = tempContent,
                UserId = photo.UserId
            };
        }

        public static Photo ToOrmPhoto(this DalPhoto dalPhoto)
        {
            byte[] tempContent = new byte[dalPhoto.Content.Length];
            dalPhoto.Content.CopyTo(tempContent, 0);
            return new Photo()
            {
                Id = dalPhoto.Id,
                Name = dalPhoto.Name,
                Description = dalPhoto.Description,
                Content = tempContent,
                UserId = dalPhoto.UserId
            };
        }
    }
}
