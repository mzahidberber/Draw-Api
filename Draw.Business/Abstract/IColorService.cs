﻿using Draw.Business.Abstract.BaseSevice;
using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;

namespace Draw.Business.Abstract
{
    public interface IColorService:IHelperService<User,Color>
    {   
    }
}