using System.ComponentModel.DataAnnotations.Schema;

namespace Migration_Tool_Performance_Manager.Models2
{
    public partial class User
    {
        [NotMapped]
        public string OldId { get; set; }
        [NotMapped]
        public string ManagerOldId { get; set; }
    }
    public partial class Scorecard
    {
        [NotMapped]
        public int OldId { get; set; }
    }
    public partial class BusinessUnit
    {
        [NotMapped]
        public int OldId { get; set; }
    }
    public partial class Department
    {
        [NotMapped]
        public int OldId { get; set; }
    }
    public partial class Goal
    {
        [NotMapped]
        public int OldId { get; set; }
    }
    public partial class Measure
    {
        [NotMapped]
        public int OldId { get; set; }
    }
    public partial class Perspective
    {
        [NotMapped]
        public int OldId { get; set; }
    }
}
