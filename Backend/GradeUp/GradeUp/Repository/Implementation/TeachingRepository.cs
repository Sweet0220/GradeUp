using GradeUp.Entities;
using Microsoft.EntityFrameworkCore;

namespace GradeUp.Repository.Implementation
{
    public class TeachingRepository : ITeachingRepository
    {
        private GradeUpContext _context;
        public TeachingRepository()
        {
            _context = new GradeUpContext();
        }

        public Teaching getTeachingById(long id)
        {
            return _context.Teaching.FirstOrDefault(t => t.id == id);
        }

        public List<Teaching> getTeachingByIdUser(long id_user)
        {
            return _context.Teaching.Where(t => t.id_user == id_user).ToList<Teaching>();
        }

        public List<Teaching> getTeachingByIdSubject(long id_subject)
        {
            return _context.Teaching.Where(t => t.id_subject == id_subject).ToList<Teaching>();
        }

        public void addTeaching(Teaching teaching)
        {
            try
            {
                if (teaching != null)
                {
                    _context.Teaching.Add(teaching);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Invalid teaching informations.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the entity changes.", ex);
            }
        }
   

        public void updateTeaching(Teaching teaching)
        {
            try
            {
                Teaching teachingToUpdate = _context.Teaching.FirstOrDefault(teachingToUpdate => teachingToUpdate.id == teaching.id);
                if (teachingToUpdate != null)
                {
                    //_context.Teaching.Update(teachingToUpdate);
                    teachingToUpdate.id_user = teaching.id_user;
                    teachingToUpdate.id_subject = teaching.id_subject;
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Teaching information was not updated.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while saving changes in database.", ex);
            }
        }
        public void deleteTeachingById(long id)
        {
            try
            {
                Teaching teachingToDelete = _context.Teaching.FirstOrDefault(t => t.id == id);
                if (teachingToDelete != null)
                {
                    _context.Teaching.Remove(teachingToDelete);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Teaching not found.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while saving changes in database.", ex);            
            }
        }

        public void deleteTeachingByIdUser(long id_user)
        {
            try
            {
                List<Teaching> teachingToDelete = _context.Teaching.Where(t => t.id_user == id_user).ToList<Teaching>();
                if (teachingToDelete != null)
                {
                    _context.Teaching.RemoveRange(teachingToDelete);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Teaching not found.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while saving changes in database.", ex);
            }
        }

        public void deleteTeachingByIdSubject(long id_subject)
        {
            try
            {
                List<Teaching> teachingToDelete = _context.Teaching.Where(t => t.id_subject == id_subject).ToList<Teaching>();
                if (teachingToDelete != null)
                {
                    _context.Teaching.RemoveRange(teachingToDelete);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Teaching not found.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while saving changes in database.", ex);
            }
        }




    }
    
}
