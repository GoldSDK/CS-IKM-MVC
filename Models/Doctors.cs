using System.ComponentModel.DataAnnotations;

namespace Polyclinic.Models
{
    /// <summary>
    /// врач
    /// </summary>
    public class Doctor
    {
        /// <summary>
        /// id врача
        /// </summary>
        public int Id
        {
            get; set;
        }

        /// <summary>
        /// имя врача
        /// </summary>
        [Required]
        [StringLength(100)]
        public string FullName
        {
            get; set;
        } = string.Empty;

        /// <summary>
        /// cпециальность
        /// </summary>
        [StringLength(100)]
        public string? Specialty
        {
            get; set;
        }

        /// <summary>
        /// навигационное свойство приемов
        /// </summary>
        public ICollection<Appointment> Appointments
        {
            get; set;
        } = new List<Appointment>();
    }
}