using System.Text.Json.Serialization;

public class Order
{
  public int Id { get; set; }
  public decimal Amount { get; set; } = 0;
  public int UserId { get; set; }

  [JsonIgnore]
  public User User { get; set; } = null!;

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}