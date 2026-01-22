using System.ComponentModel.DataAnnotations;

namespace Polyclinic.Models
{
    /// <summary>
    /// пациент
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// id пациента
        /// </summary>
        public int Id
        {
            get; set;
        }

        /// <summary>
        /// ФИО пациента
        /// </summary>
        [Required]
        [StringLength(100)]
        public string FullName
        {
            get; set;
        } = string.Empty;

        /// <summary>
        /// дата рождения
        /// </summary>
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate
        {
            get; set;
        }

        /// <summary>
        /// телефон
        /// </summary>
        [Phone]
        public string? Phone
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