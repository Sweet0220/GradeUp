using GradeUp.Entities;

namespace GradeUp.Repository
{
    public interface ITeachingRepository
    {
        Teaching getTeachingById(long id);
        List<Teaching> getTeachingByIdUser(long id_user);
        List<Teaching> getTeachingByIdSubject(long id_subject);
        void addTeaching(Teaching teaching);
        void updateTeaching(Teaching teaching);
        void deleteTeachingById(long id);
        void deleteTeachingByIdUser(long id_user);
        void deleteTeachingByIdSubject(long id_subject);

    }
}
