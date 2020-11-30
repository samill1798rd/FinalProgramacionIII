using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Models.ViewModel
{
    public class IglesiaViewModel
    {
        public int Id_Iglesia { get; set; }

        [Required]
        [Display(Name = "Sexo")]
        public string Sexo_DP { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos_DP { get; set; }

        [Required]
        [Display(Name = "Nombres")]
        public string Nombres_DP { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ?FechaNacimiento_DP { get; set; }

        [Required]
        [Display(Name = "Pais de Nacimiento")]
        public string PaisNacimiento_DP1 { get; set; }

        [Required]
        [Display(Name = "Ciudad de Nacimiento")]
        public string CiudadNacimiento_DP { get; set; }

        [Required]
        [Display(Name = "Pais de Residencia Actual")]
        public string PaisResidenciaActual_DP { get; set; }

        [Required]
        [Display(Name = "Ciudad de Residencia Actual")]
        public string CiudadResidneciaActual_DP { get; set; }

        [Required]
        [Display(Name = "Direccion")]
        public string Direccion_DP { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public string Telefono_DP { get; set; }

        [Required]
        [Display(Name = "Celular")]
        public string Celular_DP { get; set; }

        [Required]
        [Display(Name = "Correo")]
        [EmailAddress]
        public string Correo_DP { get; set; }

        [Required]
        [Display(Name = "Tipo de Documento de Identidad")]
        public string TipoIdentidad_DP { get; set; }

        [Required]
        [Display(Name = "Documento de Identidad")]
        public string DocumentoIdentidad_DP { get; set; }

        [Required]
        [Display(Name = "Estado Civil")]
        public string EstadoCivil_DF { get; set; }

        
        [Display(Name = "Nombre Pareja")]
        public string NombrePareja_DF { get; set; }

        [Required]
        [Display(Name = "Hijos")]
        public string Hijos_DF { get; set; }

       
        [Display(Name = "No Hijos")]
        public string NoHijos_DF { get; set; }

        [Required]
        [Display(Name = "Profesion")]
        public string Profesion_DL { get; set; }

        [Required]
        [Display(Name = "Ocupacion Actual")]
        public string OcupacionActual_DL { get; set; }

        [Required]
        [Display(Name = "Nombre de la Empresa o Negocio")]
        public string NombreEmpresa_DL { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public string EmpresaTelefono_DL { get; set; }





        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Convencion")]
        public DateTime ?FechaConvencion_DE { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Bautismo")]
        public DateTime ?FechaBautismo_DE { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de en que fue aceptado(a) formarmente como miembro en la Iglesia")]
        public DateTime ?FechaAceptado_DE { get; set; }

        [Required]
        [Display(Name = "Denominacion a la que pertenece :")]
        public string Denominacion_DE { get; set; }

        [Display(Name = "Nombre de la Iglesia a la que asiste actualmente :")]
        public string NombreIglesiaActual_DE { get; set; }

        [Display(Name = "Asiste a esta iglesia por un tiempo menor a un year :")]
        public string IglesiaMenorTiempo_DE { get; set; }

        [Display(Name = "Donde se congregaba antes :")]
        public string IglesiaAnterior_DE { get; set; }

        [Display(Name = "Nombre del pastor de su iglesia actual :")]
        public string PastorActual_DE { get; set; }

        [Display(Name = "Ha sido disciplinado alguna vez :")]
        public string SidoDisciplenado_DE { get; set; }

        [Display(Name = "Cuantas Veces:")]
        public string DisciplinaVeces_DE { get; set; }

        [Display(Name = "Causas:")]
        public string DisciplinaCausas_DE { get; set; }

        [Display(Name = "En la actualidad ocupa usted alguna de estas funciones:")]
        public string FuncionesOcupadaActural_DE { get; set; }

        [Display(Name = "Cuales son los ministerios en los que ha servido:")]
        public string MinisteriosAnteriores_DE { get; set; }

        [Display(Name = "En cual de los ministerios mencionados considera que tuvo mayo fruto:")]
        public string MinisteriosMayorFruto_DE { get; set; }

        [Display(Name = "Porque:")]
        public string MinisteriosMayorFrutoPorque_DE { get; set; }

        [Display(Name = "Considerando sus dones y talentos, aque ministerio piensa que Dios te esta llamando:")]
        public string MinisterioLlamado_DE { get; set; }

        [Display(Name = "Que metas tiene para su vida:")]
        public string MetasVida_DE { get; set; }

        [Display(Name = "Cuanto con el respaldo de sus autoridades eclesiasticas para realizar estudios:")]
        public string RespaldoIglesia_DE { get; set; }

        [Display(Name = "Nivel de Estudio:")]
        public string NivelEstudio_DA { get; set; }

        [Display(Name = "Alguna vez a sido expulsado o suspendido de alguna institucion:")]
        public string VezEspulsado_DA { get; set; }

        [Display(Name = "Porque Razon:")]
        public string VezEspulsadoPorque_DA { get; set; }
        public int ?Usuario_Id { get; set; }
        public DateTime? PaisNacimiento_DP { get; set; }

        public virtual Usuario Usuario { get; set; }

        public SelectList DdlPaises { get; set; }

        public SelectList NivelAcdemico { get; set; }

        public byte[] Imagen { get; set; }


        public string VerPaisN { get; set; }
        public string VerPaisR { get; set; }

        public string VerNivelAcademico { get; set; }


    }
}