public class User
{
  public int Id { get; set; };
  public string Name { get; set; };
  public string CreatedAt { get; set; };
  public List<Order> Orders { get; set; };
}