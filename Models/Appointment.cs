using System.ComponentModel.DataAnnotations;

namespace Polyclinic.Models
{
    /// <summary>
    /// appointment связывает пациента и врача
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// id приема
        /// </summary>
        public int Id
        {
            get; set;
        }

        /// <summary>
        /// дата и время приёма
        /// </summary>
        [Display(Name = "Дата и время")]
        [DataType(DataType.DateTime)]
        public DateTime DateTime
        {
            get; set;
        }

        /// <summary>
        /// id пациента
        /// </summary>
        [Required]
        public int PatientId
        {
            get; set;
        }

        /// <summary>
        /// навигационное свойство пациента
        /// </summary>
        public Patient? Patient
        {
            get; set;
        }

        /// <summary>
        /// id врача
        /// </summary>
        [Required]
        public int DoctorId
        {
            get; set;
        }

        /// <summary>
        /// навигационное свойство врачa
        /// </summary>
        public Doctor? Doctor
        {
            get; set;
        }

        /// <summary>
        /// примечание
        /// </summary>
        [StringLength(500)]
        public string? Notes
        {
            get; set;
        }
    }
}