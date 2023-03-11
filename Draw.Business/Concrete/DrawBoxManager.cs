﻿using Draw.Business.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.Abstract.Draws;
using Draw.DataAccess.Abstract.Helpers;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.DrawManager.Concrete;
using Draw.Entities.Concrete.Draw;
using Draw.Entities.Concrete.Users;
using System.Linq.Expressions;

namespace Draw.Business.Concrete
{
    public class DrawBoxManager : IDrawBoxService
    {
        //private IDrawBoxDal _drawBoxDal;

        //public DrawBoxManager()
        //{
        //    _drawBoxDal = DataInstanceFactory.GetInstance<IDrawBoxDal>();
        //}
        //public void AddAll(User user, List<DrawBox> entities)
        //{
        //    foreach (var drawBox in entities)
        //    {
        //        _drawBoxDal.Add(drawBox);
        //    }
        //}

        //public void DeleteAll(User user, List<DrawBox> entities)
        //{
        //    foreach (var drawBox in entities)
        //    {
        //        _drawBoxDal.Delete(drawBox);
        //    }
        //}


        //public object? Get(User user, Expression<Func<DrawBox, bool>> filter)
        //{
        //    return _drawBoxDal.Get(filter);
        //}

        //public object? GetAll(User user, Expression<Func<DrawBox, bool>>? filter = null)
        //{
        //    return _drawBoxDal.GetAll(filter);
        //}

        //public object? GetLayers(User user, int drawId)
        //{
        //    return _drawBoxDal.Get(d => d.DrawBoxId == drawId)?.Layers;
        //}

        //public void UpdateAll(User user, List<DrawBox> entities)
        //{
        //    foreach (var drawBox in entities)
        //    {
        //        _drawBoxDal.Update(drawBox);
        //    }
        //}
        public Task<Response<IEnumerable<DrawBoxDTO>>> AddAllAsync(List<DrawBoxDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> DeleteAllAsync(List<int> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<DrawBoxDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<DrawBoxDTO>> GetAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<LayerDTO>>> GetLayersAsync(int drawId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> UpdateAllAsync(List<DrawBoxDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
