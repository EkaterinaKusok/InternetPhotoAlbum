using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interfacies.Entities;
using MvcPL.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcPhotoMapper
    {

        public static PhotoModel ToMvcPhoto(this PhotoEntity photoEntity)
        {
            if (photoEntity == null)
                return null;
            byte[] tempContent = null;
            if (photoEntity.Image != null)
            {
                tempContent = new byte[photoEntity.Image.Length];
                photoEntity.Image.CopyTo(tempContent, 0);
            }

            return new PhotoModel()
            {
                Id = photoEntity.Id,
                Image = tempContent,
                Name = photoEntity.Name,
                Description = photoEntity.Description,
                UserId = photoEntity.UserId,
                TotalRating = photoEntity.TotalRating,
                CreationDate = photoEntity.CreationDate
            };
        }

        public static PhotoEntity ToBllPhoto(this PhotoModel photoModel)
        {
            if (photoModel == null)
                return null;
            byte[] tempContent = null;
            if (photoModel.Image != null)
            {
                tempContent = new byte[photoModel.Image.Length];
                photoModel.Image.CopyTo(tempContent, 0);
            }

            return new PhotoEntity()
            {
                Id = photoModel.Id,
                Image = tempContent,
                Name = photoModel.Name,
                Description = photoModel.Description,
                UserId = photoModel.UserId,
                TotalRating = photoModel.TotalRating,
                CreationDate = photoModel.CreationDate
            };
        }
    }
}