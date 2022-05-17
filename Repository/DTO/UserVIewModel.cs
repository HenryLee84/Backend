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
}
