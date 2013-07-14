﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab.Heroes.Core.DomainObjects
{
    public interface IHero: IObjectBase
    {
        string Name { get; set; }
        string SecretBase { get; set; }
    }
}
