using Forms.Enums;

namespace Forms.Models
{
    public class UserModel: BaseModel
    {
        /// <summary>
        /// Gets or sets the FirstName.
        /// </summary>
        public string FristName { get; set; }

        /// <summary>
        /// Gets or sets the LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        public string mobileNumber { get; set; }

        public string Token { get; set; }

        public UserProfileEnum Profile { get; set; }


    }
}
