﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tridion.Extensions.DynamicDelivery.ContentModel
{
    public interface IRepositoryLocal
    {
        string Id { get; }
        string Title { get; }
    }
}
