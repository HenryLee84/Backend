namespace Repository.DTO
{
    /// <summary>
    /// 建立使用者VM
    /// </summary>
    /// <param name="Account">帳號</param>
    /// <param name="Password">密碼</param>
    public record CreateUserViewModel(string Account, string Password);

    /// <summary>
    /// 取得使用者VM
    /// </summary>
    /// <param name="Id">Id</param>
    /// <param name="Name">名稱</param>
    /// <param name="Account">帳號</param>
    public record GetUserViewModel(int Id, string Name, string Account);

    /// <summary>
    /// 更新使用者密碼VM
    /// </summary>
    /// <param name="originalPassword">原密碼</param>
    /// <param name="newPassword">新密碼</param>
    public record UpdateUserPasswordViewModel(string originalPassword, string newPassword);
}
