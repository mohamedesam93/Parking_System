﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Abstract
{
  public interface IUnitOfWork
    {
        ICarRepository Cars { get; }

    }
}
