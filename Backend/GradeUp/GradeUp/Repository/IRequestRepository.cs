using GradeUp.Entities;

namespace GradeUp.Repository
{
    public interface IRequestRepository
    {
        Request getRequestById(long id);
        List<Request> getRequestByIdUser1(long id_user1);
        List<Request> getRequestByIdUser2(long id_user2);
        void addRequest(Request request);
        void updateRequest(Request request);
        void deleteRequestById(long id);
        void deleteRequestByIdUser(long id_user);
    }
    
}
