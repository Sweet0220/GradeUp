using GradeUp.Entities;
using GradeUp.Repository;
using GradeUp.Repository.Implementation;

namespace GradeUp.Services
{
    public class TeachingService
    {
        private readonly ITeachingRepository teachingRepository;
        public TeachingService()
        {
            teachingRepository = new TeachingRepository();
        }

        public Teaching getById(long id)
        { 
            return teachingRepository.getTeachingById(id);
        }
        public List<Teaching> getByIdUser(long id_user)
        {
            return teachingRepository.getTeachingByIdUser(id_user);
        }
        public List<Teaching> getByIdSubject(long id_subject)
        {
            return teachingRepository.getTeachingByIdSubject(id_subject);
        }

        public void add_teaching(Teaching teaching) 
        { 
            teachingRepository.addTeaching(teaching);
        }

        public void update_teaching(Teaching teaching)
        {
            teachingRepository.updateTeaching(teaching);
        }

        public void deleteById(long id)
        {
            teachingRepository.deleteTeachingById(id);
        }

        public void deleteByIdUser(long id_user)
        {
            teachingRepository.deleteTeachingByIdUser(id_user);
        }

        public void deleteByIdSubject(long id_subject)
        {
            teachingRepository.deleteTeachingByIdSubject(id_subject);
        }





    }
}
