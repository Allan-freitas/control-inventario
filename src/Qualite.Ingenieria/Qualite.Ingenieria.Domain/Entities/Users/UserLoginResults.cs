namespace Qualite.Ingenieria.Domain.Entities.Users
{
    public enum UserLoginResults
    {
        /// <summary>
        /// Login successful
        /// </summary>
        Successful = 1,

        /// <summary>
        /// Customer does not exist (email or username)
        /// </summary>
        UserNotExist = 2,

        /// <summary>
        /// Wrong password
        /// </summary>
        WrongPassword = 3
    }
}
