using GradeUp.Entities;
using GradeUp.Repository;
using GradeUp.Repository.Implementation;

namespace GradeUp.Services
{
    public class SubjectService
    {
        private readonly ISubjectRepository subjectRepository;

        public SubjectService()
        {
            subjectRepository = new SubjectRepository();
            
        }

        public Subject getSubjectByName(string name)
        {
            return subjectRepository.getSubjectByName(name);
        }

        public Subject getSubjectById(long id)
        {
            return subjectRepository.getSubjectById(id);
        }


        public List<Subject> getSubjectByYear(int year)
        {
            return subjectRepository.getSubjectByYear(year);
        }

        public List<Subject> getSubjectByFaculty(string faculty)
        {
            return subjectRepository.getSubjectByFaculty(faculty);
        }

        /*public bool deleteSubjectById(long id)
        {
            Subject subject = subjectRepository.getSubjectById(id);

            if(subject != null) 
            {
                subjectRepository.Remove(subject);

                return true;
            }
        }
        */
    }
}
