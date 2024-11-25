using System;

namespace DevConnector.Models
{
    /// <summary>
    /// Represents the response returned after a successful authentication request.
    /// </summary>
    public class AuthResponse
    {
        /// <summary>
        /// Gets or sets the JWT token generated upon successful authentication.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the username of the authenticated user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the email of the authenticated user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the role of the authenticated user (e.g., Admin, User).
        /// </summary>
        public string Role { get; set; }
    }
}
