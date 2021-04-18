using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Models {
public class Adult : Person {
    /*[Required, MaxLength(128)]
    [JsonPropertyName("JobTitle")]
    public string JobTitle { get; set; }
    
    [JsonPropertyName("IsCompleted")]
    public bool IsCompleted { get; set; }
    */
    public override string ToString() {
        return JsonSerializer.Serialize(this);
    }
    
    public void Update(Adult toUpdate) {
        JobTitle = toUpdate.JobTitle;
        IsCompleted = toUpdate.IsCompleted;
        base.Update(toUpdate);
    }

        public Adult()
        {
            


        }
    }
}