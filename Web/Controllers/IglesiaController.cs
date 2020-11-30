using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Models.ViewModel;
using System.IO;

namespace Web.Controllers
{

    //[Authorize]
    public class IglesiaController : Controller
    {

        public ActionResult Index()
        {
            var lista = new List<IglesiaViewModel>();

            using (var db = new IglesiaFinalEntities2())
            {
                lista = (from d in db.Iglesias.Include(x => x.Usuario)

                         select new IglesiaViewModel
                         {
                             Id_Iglesia = d.Id_Iglesia,
                             Sexo_DP = d.Sexo_DP,
                             Apellidos_DP = d.Apellidos_DP,
                             Nombres_DP = d.Nombres_DP,
                             FechaNacimiento_DP = d.FechaNacimiento_DP,
                             PaisNacimiento_DP1 = d.PaisNacimiento_DP1,
                             CiudadNacimiento_DP = d.CiudadNacimiento_DP,
                             PaisResidenciaActual_DP = d.PaisResidenciaActual_DP,
                             CiudadResidneciaActual_DP = d.CiudadResidneciaActual_DP,
                             Direccion_DP = d.Direccion_DP,
                             Telefono_DP = d.Telefono_DP,
                             Celular_DP = d.Celular_DP,
                             Correo_DP = d.Correo_DP,
                             TipoIdentidad_DP = d.TipoIdentidad_DP,
                             DocumentoIdentidad_DP = d.DocumentoIdentidad_DP,
                             EstadoCivil_DF = d.EstadoCivil_DF,
                             NombrePareja_DF = d.NombrePareja_DF,
                             Hijos_DF = d.Hijos_DF,
                             NoHijos_DF = d.NoHijos_DF,
                             Profesion_DL = d.Profesion_DL,
                             OcupacionActual_DL = d.OcupacionActual_DL,
                             NombreEmpresa_DL = d.NombreEmpresa_DL,
                             EmpresaTelefono_DL = d.EmpresaTelefono_DL,
                             FechaConvencion_DE = d.FechaConvencion_DE,
                             FechaBautismo_DE = d.FechaBautismo_DE,
                             FechaAceptado_DE = d.FechaAceptado_DE,
                             Denominacion_DE = d.Denominacion_DE,
                             NombreIglesiaActual_DE = d.NombreIglesiaActual_DE,
                             IglesiaMenorTiempo_DE = d.IglesiaMenorTiempo_DE,
                             IglesiaAnterior_DE = d.IglesiaAnterior_DE,
                             PastorActual_DE = d.PastorActual_DE,
                             SidoDisciplenado_DE = d.SidoDisciplenado_DE,
                             DisciplinaVeces_DE = d.DisciplinaVeces_DE,
                             DisciplinaCausas_DE = d.DisciplinaCausas_DE,
                             FuncionesOcupadaActural_DE = d.FuncionesOcupadaActural_DE,
                             MinisteriosAnteriores_DE = d.MinisteriosAnteriores_DE,
                             MinisteriosMayorFruto_DE = d.MinisteriosMayorFruto_DE,
                             MinisteriosMayorFrutoPorque_DE = d.MinisteriosMayorFrutoPorque_DE,
                             MinisterioLlamado_DE = d.MinisterioLlamado_DE,
                             MetasVida_DE = d.MetasVida_DE,
                             RespaldoIglesia_DE = d.RespaldoIglesia_DE,
                             NivelEstudio_DA = d.NivelEstudio_DA,
                             VezEspulsado_DA = d.VezEspulsado_DA,
                             VezEspulsadoPorque_DA = d.VezEspulsadoPorque_DA,
                             Usuario_Id = d.Usuario.Id_Usuario,
                             PaisNacimiento_DP = d.PaisNacimiento_DP,
                             Imagen = d.Foto
                         }).ToList();
            }

            return View(lista);
        }


        public ActionResult Create(int id)
        {
            if (id == 0)
            {

                var vm = new IglesiaViewModel()
                {
                    DdlPaises = GetPais(),
                    NivelAcdemico = GetNivelAcdemico()
                };

                return View(vm);
            }
            else
            {
                var model = Editar(id);
                return View(model);
            }
        }

        public ActionResult Eliminar(int id)
        {

            using (var db = new IglesiaFinalEntities2())
            {
                var tb = db.Iglesias.Find(id);
                db.Iglesias.Remove(tb);
                db.SaveChanges();
            }


            return RedirectToAction("Index", "Iglesia");
        }

        [HttpPost]
        public ActionResult Save(IglesiaViewModel model,HttpPostedFileBase file)
        {

            if (file != null && file.ContentLength>0)
            {
                byte[] imagenData = null;

                using (var imagen = new BinaryReader(file.InputStream))
                {
                    imagenData = imagen.ReadBytes(file.ContentLength);
                }
                model.Imagen = imagenData;
            }
            
            
            try
            {
                using (var db = new IglesiaFinalEntities2())
                {
                    var tb = new Iglesia();

                    tb.Id_Iglesia = model.Id_Iglesia;
                    tb.Sexo_DP = model.Sexo_DP;
                    tb.Apellidos_DP = model.Apellidos_DP;
                    tb.Nombres_DP = model.Nombres_DP;
                    tb.FechaNacimiento_DP = model.FechaNacimiento_DP;
                    tb.PaisNacimiento_DP1 = model.PaisNacimiento_DP1;
                    tb.CiudadNacimiento_DP = model.CiudadNacimiento_DP;
                    tb.PaisResidenciaActual_DP = model.PaisResidenciaActual_DP;
                    tb.CiudadResidneciaActual_DP = model.CiudadResidneciaActual_DP;
                    tb.Direccion_DP = model.Direccion_DP;
                    tb.Telefono_DP = model.Telefono_DP;
                    tb.Celular_DP = model.Celular_DP;
                    tb.Correo_DP = model.Correo_DP;
                    tb.TipoIdentidad_DP = model.TipoIdentidad_DP;
                    tb.DocumentoIdentidad_DP = model.DocumentoIdentidad_DP;
                    tb.EstadoCivil_DF = model.EstadoCivil_DF;
                    tb.NombrePareja_DF = model.NombrePareja_DF;
                    tb.Hijos_DF = model.Hijos_DF;
                    tb.NoHijos_DF = model.NoHijos_DF;
                    tb.Profesion_DL = model.Profesion_DL;
                    tb.OcupacionActual_DL = model.OcupacionActual_DL;
                    tb.NombreEmpresa_DL = model.NombreEmpresa_DL;
                    tb.EmpresaTelefono_DL = model.EmpresaTelefono_DL;
                    tb.FechaConvencion_DE = model.FechaConvencion_DE;
                    tb.FechaBautismo_DE = model.FechaBautismo_DE;
                    tb.FechaAceptado_DE = model.FechaAceptado_DE;
                    tb.Denominacion_DE = model.Denominacion_DE;
                    tb.NombreIglesiaActual_DE = model.NombreIglesiaActual_DE;
                    tb.IglesiaMenorTiempo_DE = model.IglesiaMenorTiempo_DE;
                    tb.IglesiaAnterior_DE = model.IglesiaAnterior_DE;
                    tb.PastorActual_DE = model.PastorActual_DE;
                    tb.SidoDisciplenado_DE = model.SidoDisciplenado_DE;
                    tb.DisciplinaVeces_DE = model.DisciplinaVeces_DE;
                    tb.DisciplinaCausas_DE = model.DisciplinaCausas_DE;
                    tb.FuncionesOcupadaActural_DE = model.FuncionesOcupadaActural_DE;
                    tb.MinisteriosAnteriores_DE = model.MinisteriosAnteriores_DE;
                    tb.MinisteriosMayorFruto_DE = model.MinisteriosMayorFruto_DE;
                    tb.MinisteriosMayorFrutoPorque_DE = model.MinisteriosMayorFrutoPorque_DE;
                    tb.MinisterioLlamado_DE = model.MinisterioLlamado_DE;
                    tb.MetasVida_DE = model.MetasVida_DE;
                    tb.RespaldoIglesia_DE = model.RespaldoIglesia_DE;
                    tb.NivelEstudio_DA = model.NivelEstudio_DA;
                    tb.VezEspulsado_DA = model.VezEspulsado_DA;
                    tb.VezEspulsadoPorque_DA = model.VezEspulsadoPorque_DA;
                    tb.PaisNacimiento_DP = model.PaisNacimiento_DP;
                    tb.Foto = model.Imagen;

                    if (model.Id_Iglesia != 0)
                    {

                        //   db.Estudiantes.Add(tb);
                        tb.Id_Iglesia = model.Id_Iglesia;
                        db.Entry(tb).State = System.Data.Entity.EntityState.Modified;

                    }
                    else
                    {
                        db.Iglesias.Add(tb);
                    }
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Iglesia");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Ver(int id)
        {
            var data = Editar(id);
            return View(data);
        }
        private SelectList GetNivelAcdemico()
        {
            var NivelAcademico = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "- Seleccione -", Value = " " },
                new SelectListItem() { Text = "Primaria ", Value = "Primaria" },
                new SelectListItem() { Text = "Secundaria ", Value = "Secundaria" },
                new SelectListItem() { Text = "Grado ", Value = "Grado" },
                new SelectListItem() { Text = "Postgrado-Maestria ", Value = "Postgrado-Maestria" },

            };
            var lista = new SelectList(NivelAcademico, "Text", "Text");
            return lista;

        }

        private SelectList GetPais()
        {

            var pais = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "- Seleccione -", Value = " " },
                new SelectListItem() { Text = "Afganistán ", Value = "Afganistán" },
                new SelectListItem() { Text = "Albania ", Value = "Albania" },
                new SelectListItem() { Text = "Alemania ", Value = "Alemania" },
                new SelectListItem() { Text = "Andorra ", Value = "Andorra" },
                new SelectListItem() { Text = "Angola ", Value = "Angola " },
                new SelectListItem() { Text = "Antigua y Barbuda", Value = "Antigua y Barbuda" },
                new SelectListItem() { Text = "Arabia Saudita", Value = "Arabia Saudita" },
                new SelectListItem() { Text = "Argelia ", Value = "Argelia" },
                new SelectListItem() { Text = "Argentina ", Value = "Argentina" },
                new SelectListItem() { Text = "Armenia ", Value = "Australia" },
                new SelectListItem() { Text = "Austria ", Value = "Austria " },
                new SelectListItem() { Text = "Azerbaiyán ", Value = "Azerbaiyán " },
                new SelectListItem() { Text = "Bahamas ", Value = "Bahamas  " },
                new SelectListItem() { Text = "Bangladés ", Value = "Bangladés  " },
                new SelectListItem() { Text = "Barbados ", Value = "Barbados  " },
                new SelectListItem() { Text = "Baréin ", Value = "Baréin  " },
                new SelectListItem() { Text = "Bélgica ", Value = "Bélgica  " },
                new SelectListItem() { Text = "Belice ", Value = "Belice  " },
                new SelectListItem() { Text = "Bolivia ", Value = "Bolivia  " },
                new SelectListItem() { Text = "Brasil ", Value = "Brasil  " },
                new SelectListItem() { Text = "Bulgaria ", Value = "Bulgaria  " },
                new SelectListItem() { Text = "Camerún ", Value = "Camerún  " },
                new SelectListItem() { Text = "Canadá ", Value = "Canadá  " },
                new SelectListItem() { Text = "Catar ", Value = "Catar  " },
                new SelectListItem() { Text = "Chile ", Value = "Chile  " },
                new SelectListItem() { Text = "China ", Value = "China  " },
                new SelectListItem() { Text = "Colombia ", Value = "Colombia  " },
                new SelectListItem() { Text = "Corea del Norte", Value = "Corea del Norte " },
                new SelectListItem() { Text = "Corea del Sur", Value = "Corea del Sur " },
                new SelectListItem() { Text = "Costa Rica", Value = "Costa Rica " },
                new SelectListItem() { Text = "Cuba ", Value = "Cuba  " },
                new SelectListItem() { Text = "Dinamarca ", Value = "Dinamarca  " },
                new SelectListItem() { Text = "Dominica ", Value = "Dominica  " },
                new SelectListItem() { Text = "Ecuador ", Value = "Ecuador  " },
                new SelectListItem() { Text = "Egipto ", Value = "Egipto  " },
                new SelectListItem() { Text = "El Salvador", Value = "El Salvador " },
                new SelectListItem() { Text = "Emiratos Árabes Unidos ", Value = "Emiratos Árabes Unidos  " },
                new SelectListItem() { Text = "España ", Value = "España  " },
                new SelectListItem() { Text = "Estados Unidos", Value = "Estados Unidos " },
                new SelectListItem() { Text = "Filipinas ", Value = "Filipinas  " },
                new SelectListItem() { Text = "Finlandia" , Value = "Finlandia  " },
                new SelectListItem() { Text = "Francia ", Value = "Francia  " },
                new SelectListItem() { Text = "Guatemala ", Value = "Guatemala  " },
                new SelectListItem() { Text = "Haití ", Value = "Haití  " },
                new SelectListItem() { Text = "Honduras ", Value = "Honduras  " },
                new SelectListItem() { Text = "India ", Value = "India  " },
                new SelectListItem() { Text = "Indonesia ", Value = "Indonesia  " },
                new SelectListItem() { Text = "Irak ", Value = "Irak  " },
                new SelectListItem() { Text = "Irán ", Value = "Irán  " },
                new SelectListItem() { Text = "Irlanda ", Value = "Irlanda  " },
                new SelectListItem() { Text = "Islandia ", Value = "Islandia  " },
                new SelectListItem() { Text = "Israel ", Value = "Israel  " },
                new SelectListItem() { Text = "Italia ", Value = "Italia  " },
                new SelectListItem() { Text = "Jamaica ", Value = "Jamaica  " },
                new SelectListItem() { Text = "Japón ", Value = "Japón  " },
                new SelectListItem() { Text = "Kenia ", Value = "Kenia  " },
                new SelectListItem() { Text = "Kuwait ", Value = "Kuwait  " },
                new SelectListItem() { Text = "Líbano ", Value = "Líbano  " },
                new SelectListItem() { Text = "Liberia ", Value = "Liberia  " },
                new SelectListItem() { Text = "Luxemburgo ", Value = "Luxemburgo  " },
                new SelectListItem() { Text = "Madagascar ", Value = "Madagascar  " },
                new SelectListItem() { Text = "Malasia ", Value = "Malasia  " },
                new SelectListItem() { Text = "México ", Value = "México  " },
                new SelectListItem() { Text = "Mongolia ", Value = "Mongolia  " },
                new SelectListItem() { Text = "Nicaragua ", Value = "Nicaragua  " },
                new SelectListItem() { Text = "Nigeria ", Value = "Nigeria  " },
                new SelectListItem() { Text = "Noruega ", Value = "Noruega  " },
                new SelectListItem() { Text = "Nueva Zelanda ", Value = "Nueva Zelanda  " },
                new SelectListItem() { Text = "Pakistán ", Value = "Pakistán  " },
                new SelectListItem() { Text = "Panamá ", Value = "Panamá  " },
                new SelectListItem() { Text = "Paraguay ", Value = "Paraguay  " },
                new SelectListItem() { Text = "Perú ", Value = "Perú  " },
                new SelectListItem() { Text = "Polonia ", Value = "Polonia  " },
                new SelectListItem() { Text = "Portugal ", Value = "Portugal  " },
                new SelectListItem() { Text = "Reino Unido", Value = "Reino Unido " },
                new SelectListItem() { Text = "República Dominicana", Value = "República Dominicana " },
                new SelectListItem() { Text = "Rumanía ", Value = "Rumanía  " },
                new SelectListItem() { Text = "Rusia ", Value = "Rusia  " },
                new SelectListItem() { Text = "Serbia ", Value = "Serbia  " },
                new SelectListItem() { Text = "Singapur ", Value = "Singapur  " },
                new SelectListItem() { Text = "Siria ", Value = "Siria  " },
                new SelectListItem() { Text = "Sudáfrica ", Value = "Sudáfrica  " },
                new SelectListItem() { Text = "Suecia ", Value = "Suecia  " },
                new SelectListItem() { Text = "Suiza ", Value = "Suiza  " },
                new SelectListItem() { Text = "Tailandia ", Value = "Tailandia  " },
                new SelectListItem() { Text = "Turquía ", Value = "Turquía  " },
                new SelectListItem() { Text = "Ucrania ", Value = "Ucrania  " },
                new SelectListItem() { Text = "Venezuela ", Value = "Venezuela  " },
                new SelectListItem() { Text = "Yemen ", Value = "Yemen  " },
                new SelectListItem() { Text = "Zambia ", Value = "Zambia  " },
                new SelectListItem() { Text = "Zimbabue ", Value = "Zimbabue  " },
            };

            var lista = new SelectList(pais, "Text", "Text");
            return lista;
        }

        public object Editar(int Id)
        {
            var model = new IglesiaViewModel()
            {
                DdlPaises = GetPais(),
                NivelAcdemico = GetNivelAcdemico()
            }; 

            using (var db = new IglesiaFinalEntities2())
            {
                var tb = db.Iglesias.Find(Id);

                model.Id_Iglesia = tb.Id_Iglesia;
                model.Sexo_DP = tb.Sexo_DP;
                model.Apellidos_DP = tb.Apellidos_DP;
                model.Nombres_DP = tb.Nombres_DP;
                model.FechaNacimiento_DP = tb.FechaNacimiento_DP;
                //model.PaisNacimiento_DP1 = tb.PaisNacimiento_DP1;
                model.CiudadNacimiento_DP = tb.CiudadNacimiento_DP;
                //model.PaisResidenciaActual_DP = tb.PaisResidenciaActual_DP;
                model.CiudadResidneciaActual_DP = tb.CiudadResidneciaActual_DP;
                model.Direccion_DP = tb.Direccion_DP;
                model.Telefono_DP = tb.Telefono_DP;
                model.Celular_DP = tb.Celular_DP;
                model.Correo_DP = tb.Correo_DP;
                model.TipoIdentidad_DP = tb.TipoIdentidad_DP;
                model.DocumentoIdentidad_DP = tb.DocumentoIdentidad_DP;
                model.EstadoCivil_DF = tb.EstadoCivil_DF;
                model.NombrePareja_DF = tb.NombrePareja_DF;
                model.Hijos_DF = tb.Hijos_DF;
                model.NoHijos_DF = tb.NoHijos_DF;
                model.Profesion_DL = tb.Profesion_DL;
                model.OcupacionActual_DL = tb.OcupacionActual_DL;
                model.NombreEmpresa_DL = tb.NombreEmpresa_DL;
                model.EmpresaTelefono_DL = tb.EmpresaTelefono_DL;
                model.FechaConvencion_DE = tb.FechaConvencion_DE;
                model.FechaBautismo_DE = tb.FechaBautismo_DE;
                model.FechaAceptado_DE = tb.FechaAceptado_DE;
                model.Denominacion_DE = tb.Denominacion_DE;
                model.NombreIglesiaActual_DE = tb.NombreIglesiaActual_DE;
                model.IglesiaMenorTiempo_DE = tb.IglesiaMenorTiempo_DE;
                model.IglesiaAnterior_DE = tb.IglesiaAnterior_DE;
                model.PastorActual_DE = tb.PastorActual_DE;
                model.SidoDisciplenado_DE = tb.SidoDisciplenado_DE;
                model.DisciplinaVeces_DE = tb.DisciplinaVeces_DE;
                model.DisciplinaCausas_DE = tb.DisciplinaCausas_DE;
                model.FuncionesOcupadaActural_DE = tb.FuncionesOcupadaActural_DE;
                model.MinisteriosAnteriores_DE = tb.MinisteriosAnteriores_DE;
                model.MinisteriosMayorFruto_DE = tb.MinisteriosMayorFruto_DE;
                model.MinisteriosMayorFrutoPorque_DE = tb.MinisteriosMayorFrutoPorque_DE;
                model.MinisterioLlamado_DE = tb.MinisterioLlamado_DE;
                model.MetasVida_DE = tb.MetasVida_DE;
                model.RespaldoIglesia_DE = tb.RespaldoIglesia_DE;
                //model.NivelEstudio_DA = tb.NivelEstudio_DA;
                model.VezEspulsado_DA = tb.VezEspulsado_DA;
                model.VezEspulsadoPorque_DA = tb.VezEspulsadoPorque_DA;
                model.PaisNacimiento_DP = tb.PaisNacimiento_DP;
                model.VerNivelAcademico = tb.NivelEstudio_DA;
                model.VerPaisN = tb.PaisNacimiento_DP1;
                model.VerPaisR = tb.PaisResidenciaActual_DP;
            }
            return model;
        }

        public object ConvertImagen(int id)
        {
            using (var db = new IglesiaFinalEntities2())
            {
                var imagen = (from d in db.Iglesias
                              where d.Id_Iglesia == id
                              select d.Foto).FirstOrDefault();

                return File(imagen, "~/App_Data/Imagen/jpg");

            }


        }
    }
}