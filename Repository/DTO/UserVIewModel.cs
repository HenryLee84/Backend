namespace Repository.DTO
{
    /// <summary>
    /// 建立使用者VM
    /// </summary>
    /// <param name="Account">帳號</param>
    /// <param name="Password">密碼</param>
    public record CreateUserViewModel(string Account, string Password);
}
