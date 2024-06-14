using System.ComponentModel.DataAnnotations;

namespace StoreProject.DB.DTO.User
{
    /// <summary>
    /// DTO для представление клиента
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// Идентификатор клиента
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Полное имя клиента
        /// </summary>
        [Required(ErrorMessage = "FullName является обязательным полем")]
        [StringLength(100, ErrorMessage = "FullName не может превышать размер 100 символов")]
        public string FullName { get; set; }
        /// <summary>
        /// Номер телефона клиента
        /// </summary>
        [Required(ErrorMessage = "NumberPhone является обязательным полем")]
        [Phone(ErrorMessage = "Ошибка формата поля NumberPhone")]
        [StringLength(15, ErrorMessage = "NumberPhone не может превышать размер 15")]
        public string NumberPhone { get; set; }
    }
}
