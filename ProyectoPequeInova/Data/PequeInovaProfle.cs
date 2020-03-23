using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProyectoPequeInova.Models;
using ProyectoPequeInova.Data.Entity;

namespace ProyectoPequeInova.Data
{
    public class PequeInovaProfle : Profile
    {
        public PequeInovaProfle()
        {
            this.CreateMap<AreaEntity, Area>()
                .ReverseMap();

            this.CreateMap<CursoEntity, Curso>()
                .ReverseMap();
        }
    }
}
