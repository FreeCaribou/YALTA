namespace Yalta.Models.DTO
{
  public class UserSimpleDTO
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
  }

  public class UserWithoutInfoDTO
  {
    public long Id { get; set; }
    public string Name { get; set; }
  }
}