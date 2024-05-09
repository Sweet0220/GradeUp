using GradeUp.Entities;

namespace GradeUp.Repository
{
    public interface IChatRepository
    {
        Chat getChatById(long id);
        List<Chat> getChatByUserId1(long id_user1);
        List<Chat> getChatByUserId2(long id_user2);
        
        //bool deleteSubjectById(long id);
    }
}
