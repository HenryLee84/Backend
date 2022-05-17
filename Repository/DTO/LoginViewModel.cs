namespace Repository.DTO
{
    /// <summary>
    /// 登入VM
    /// </summary>
    /// <param name="Account">帳號</param>
    /// <param name="Password">密碼</param>
    public record LoginViewModel(string Account, string Password);
}
