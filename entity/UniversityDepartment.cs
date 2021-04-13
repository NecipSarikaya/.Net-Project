namespace entity
{
    public class UniversityDepartment
    {
        public int UniversityId { get; set; }
        public University University { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

    }
}