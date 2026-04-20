public class User
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public List<Order> Orders { get; set; } = new();
}