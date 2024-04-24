using GradeUp.Entities;

namespace GradeUp.Repository.Implementation
{
    public class SubjectRepository : ISubjectRepository
    {
        private GradeUpContext context;

        public SubjectRepository()
        {
            context = new GradeUpContext();

        }

        public Subject getSubjectByName(string name)
        {
            return context.Subject.FirstOrDefault(s => s.name == name);
        }


        public Subject getSubjectById(long id)
        {
            return context.Subject.FirstOrDefault(s => s.id == id);
        }
        
        //de modificat 

        public List<Subject> getSubjectByYear(int year)
        {
            List<Subject> subjects = context.Subject.Where(s => s.year == year).ToList();
            return subjects;
        }

        public List<Subject> getSubjectByFaculty(string faculty)
        {
            List<Subject> subjects = context.Subject.Where(s => s.faculty == faculty).ToList();
            return subjects;

        }

    }
}
