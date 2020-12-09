using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Solution.DO.Objects.Usuarios, Models.Usuarios>().ReverseMap();
            CreateMap<Solution.DO.Objects.Roles, Models.Roles>().ReverseMap();
            CreateMap<Solution.DO.Objects.TipoPeriodo, Models.TipoPeriodo>().ReverseMap();
            CreateMap<Solution.DO.Objects.Instituciones, Models.Instituciones>().ReverseMap();
            CreateMap<Solution.DO.Objects.TipoOperaciones, Models.TipoOperaciones>().ReverseMap();
            CreateMap<Solution.DO.Objects.Materias, Models.Materias>().ReverseMap();
            CreateMap<Solution.DO.Objects.Grados, Models.Grados>().ReverseMap();
            CreateMap<Solution.DO.Objects.Grupos, Models.Grupos>().ReverseMap();
            CreateMap<Solution.DO.Objects.Calificaciones, Models.Calificaciones>().ReverseMap();
            CreateMap<Solution.DO.Objects.UsuarioXGrupo, Models.UsuarioXGrupo>().ReverseMap();
            CreateMap<Solution.DO.Objects.UsuarioXInstitucion, Models.UsuarioXInstitucion>().ReverseMap();
        }
    }
}
