using GradeUp.Entities;

namespace GradeUp.Repository
{
    public interface ISubjectRepository
    {
        Subject getSubjectByName(string name);
        Subject getSubjectById(long id);
        List<Subject> getSubjectByYear(int year);
        List<Subject> getSubjectByFaculty(string faculty);
    }
}
