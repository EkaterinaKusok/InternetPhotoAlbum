using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class RatingService : IRatingService
    {
        private readonly IUnitOfWork uow;
        private readonly IRatingRepository ratingRepository;

        public RatingService(IUnitOfWork uow, IRatingRepository repository)
        {
            this.uow = uow;
            this.ratingRepository = repository;
        }

        public RatingEntity GetRatingEntityById(int id)
        {
            return ratingRepository.GetById(id)?.ToBllRating();
        }

        public RatingEntity GetUserRatingOfPhoto(int userId, int photoId)
        {
            return ratingRepository.GetUserRatingOfPhoto(userId, photoId)?.ToBllRating();
        }

        public IEnumerable<RatingEntity> GetAllRatingEntities()
        {
            return ratingRepository.GetAll().Select(r => r.ToBllRating());
        }

        public IEnumerable<RatingEntity> GetPhotoRatings(int photoId)
        {
            return ratingRepository.GetPhotoRatings(photoId).Select(rating => rating.ToBllRating());
        }

        public void CreateRating(RatingEntity rating)
        {
            ratingRepository.Create(rating.ToDalRating());
            uow.Commit();
        }

        public void DeleteRating(RatingEntity rating)
        {
            ratingRepository.Delete(rating.ToDalRating());
            uow.Commit();
        }

        public void UpdateRating(RatingEntity rating)
        {
            ratingRepository.Update(rating.ToDalRating());
            uow.Commit();
        }

        public int CountTotalRating(int photoId)
        {
            return ratingRepository.CountTotalRating(photoId);
        }
    }
}
