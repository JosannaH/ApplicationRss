﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    internal interface IEpisodeRepository<Episode>
    {
        void Create(Episode episode);
        List<Episode> GetAll();
    }
}
