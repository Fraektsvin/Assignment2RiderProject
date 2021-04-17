using System.Text.Json;
namespace Models {
public class Adult : Person {
    public string JobTitle { get; set; }
    public bool IsCompleted { get; set; }

    public override string ToString() {
        return JsonSerializer.Serialize(this);
    }
    
    public Adult(string jobtitle, bool isCompleted, int Id)
        {
            jobtitle = JobTitle;
            isCompleted = IsCompleted;
            

        }
        
    public Adult()
        {

        }

    public void Update(Adult toUpdate) {
        JobTitle = toUpdate.JobTitle;
        base.Update(toUpdate);
    }
    
}
}