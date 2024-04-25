using GradeUp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        /*public bool deleteSubjectById(long id)
        {
            try
            {
                Subject subject = (Subject)context.Subject.Where(s => s.id == id);

                if (subject != null)
                {
                    context.Subject.Remove(subject);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                    //throw new ArgumentException("Subject not found!");
                    
                }

            }

            catch (DbUpdateException ex)
            {
                throw new Exception("error while saving",ex);

            }
        }*/

    }
}
