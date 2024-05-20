namespace QuakeAnalitika.Model.Open;

/// <summary>
/// Data used in authentication
/// </summary>
public class CredentialsDto
{

    #region Props

    /// <summary>
    /// User's defined username
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// User's defined username
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// User's password
    /// </summary>
    public string Password { get; set; } = string.Empty;

    #endregion

    #region Actions

    /// <summary>
    /// Used in data validation
    /// </summary>
    /// <returns></returns>
    public bool HasData() => !string.IsNullOrWhiteSpace(UserName) &&
        !string.IsNullOrWhiteSpace(Password);

    #endregion

}
