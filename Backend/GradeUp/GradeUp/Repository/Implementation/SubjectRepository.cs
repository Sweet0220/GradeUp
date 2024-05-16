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

        public void addSubject(Subject subject)
        {
            try
            {
                if(subject != null)
                {
                    context.Subject.Add(subject);
                    context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Invalid Subject data.");
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error while saving changes.", ex);
            }
        }

        public void updateSubject(Subject subject)
        {
            try
            {
                Subject subjectToUpdate = context.Subject.FirstOrDefault(subjectToUpdate => subjectToUpdate.id == subject.id);
                if (subjectToUpdate != null)
                {
                    /*
                        public string name { get; set; }
                        public string professor { get; set; }
                        public int year { get; set; }
                        public string faculty { get; set; }
                        public string university { get; set; }
                        public int credits { get; set; }
                    */
                    subjectToUpdate.name = subject.name;
                    subjectToUpdate.professor = subject.professor;
                    subjectToUpdate.year = subject.year;
                    subjectToUpdate.faculty = subject.faculty;
                    subjectToUpdate.university = subject.university;
                    subjectToUpdate.credits = subject.credits;
                    context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Subject data not updated.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error while saving changes in database.", ex);
            }
        }

        public void deleteSubjectById(long id)
        {
            try
            {
                Subject subjectToDelete = context.Subject.FirstOrDefault(s => s.id == id);
                if (subjectToDelete != null)
                {
                    context.Database.ExecuteSqlRaw($"DELETE FROM Teaching WHERE id_subject = {id}");
                    context.Database.ExecuteSqlRaw($"DELETE FROM Request WHERE id_subject = {id}");
                    /*List<Teaching> teachingToDelete = context.Teaching.Where(t => t.id_subject == subjectToDelete.id).ToList();
                    for(int i = 0;i < teachingToDelete.Count; i++)
                    {
                        context.Teaching.Remove(teachingToDelete.IndexOf(i));
                        context.SaveChanges();

                    }*/
                    context.Subject.Remove(subjectToDelete);
                    context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Subject not found.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error while saving changes in database.", ex);
            }
        }

    }
}
