using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using DAL.Mappers;
using ORM;

namespace DAL.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly DbContext context;

        public RatingRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalRating> GetAll()
        {
            return context.Set<Rating>().Select(r=>r).ToList().Select(r => r.ToDalRating());
        }

        public DalRating GetById(int key)
        {
            return context.Set<Rating>().FirstOrDefault(r => r.RatingId == key)?.ToDalRating();
        }

        public DalRating GetByPredicate(Expression<Func<DalRating, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalRating dalRating)
        {
            context.Set<Rating>().Add(dalRating.ToOrmRating());
        }

        public void Delete(DalRating dalRating)
        {
            Rating rating = context.Set<Rating>().FirstOrDefault(r => r.RatingId == dalRating.Id);
            if (rating!=null)
                context.Set<Rating>().Remove(rating);
        }

        public void Update(DalRating dalRating)
        {
            Rating oldRating = context.Set<Rating>().FirstOrDefault(r => r.RatingId == dalRating.Id);
            if (oldRating != null)
            {
                oldRating.UserRating = dalRating.UserRating;
                oldRating.UserProfileId = dalRating.FromUserId;
                oldRating.PhotoId = dalRating.PhotoId;
            }
            else
                context.Set<Rating>().Add(dalRating.ToOrmRating());
        }

        public IEnumerable<DalRating> GetPhotoRatings(int photoId)
        {
            return context.Set<Photo>().FirstOrDefault(photo => photo.Id == photoId)?.Ratings.Select(rating => rating.ToDalRating()).ToList();
        }

        public int CountTotalRating(int photoId)
        {
            var photoRatings = GetPhotoRatings(photoId);
            int ratingSum = 0;
            foreach (var rating in photoRatings)
            {
                ratingSum += rating.UserRating;
            }
            return ratingSum;
        }

        public DalRating GetUserRatingOfPhoto(int userId, int photoId)
        {
            return context.Set<Rating>().FirstOrDefault(r => r.UserProfileId == userId && r.PhotoId == photoId)?.ToDalRating();
        }
    }
}
