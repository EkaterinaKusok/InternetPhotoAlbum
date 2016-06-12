using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using ORM;

namespace DAL.Concrete
{
    public class RatingRepository : IRepository<DalRating>
    {
        private readonly DbContext context;

        public RatingRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalRating> GetAll()
        {
            var ratings = context.Set<Rating>().Select(r => r).ToList();
            return ratings.Select(r => DalMappers.ToDalRating(r));
        }

        public DalRating GetById(int key)
        {
            var ormRating = context.Set<Rating>().FirstOrDefault(r => r.RatingId == key);
            return ormRating.ToDalRating();
        }

        public DalRating GetByPredicate(Expression<Func<DalRating, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalRating e)
        {
            var rating = e.ToOrmRating();
            context.Set<Rating>().Add(rating);
        }

        public void Delete(DalRating e)
        {
            var rating = e.ToOrmRating();
            rating = context.Set<Rating>().Single(r => r.RatingId == rating.RatingId);
            context.Set<Rating>().Remove(rating);
        }

        public void Update(DalRating entity)
        {
            var rating = entity.ToOrmRating();
            Rating oldrating = context.Set<Rating>().FirstOrDefault(r => r.RatingId == rating.RatingId);
            context.Set<Rating>().AddOrUpdate(oldrating, rating);
        }
    }
}
