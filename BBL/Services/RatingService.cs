using System.Collections.Generic;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class RatingService : IRatingService
    {
        private readonly IUnitOfWork uow;
        private readonly IRepository<DalRating> ratingRepository;

        public RatingService(IUnitOfWork uow, IRepository<DalRating> repository)
        {
            this.uow = uow;
            this.ratingRepository = repository;
        }

        public RatingEntity GetRatingEntityById(int id)
        {
            return ratingRepository.GetById(id).ToBllRating();
        }

        public IEnumerable<RatingEntity> GetAllRatingEntities()
        {
            return ratingRepository.GetAll().Select(r => r.ToBllRating());
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
    }
}
