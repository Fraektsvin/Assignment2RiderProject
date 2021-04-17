using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Models {
public class Adult : Person {
    [Required, MaxLength(128)]
    [JsonPropertyName("title")]
    public string JobTitle { get; set; }
    
    [JsonPropertyName("completed")]
    public bool IsCompleted { get; set; }

    public override string ToString() {
        return JsonSerializer.Serialize(this);
    }
    
    public void Update(Adult toUpdate) {
        JobTitle = toUpdate.JobTitle;
        base.Update(toUpdate);
    }

        public Adult(string jobtitle, bool isCompleted, int Id)
        {
            jobtitle = JobTitle;
            isCompleted = IsCompleted;


        }
    }
}